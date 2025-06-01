using System.Collections.Generic;
using Application.Dto;
using Application.Interface;

namespace Application.Services
{
 public class AmbulanceService : IAmbulanceService
{
    private readonly IAmbulanceRequestRepository _ambulanceRequestRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public AmbulanceService(
        IAmbulanceRequestRepository ambulanceRequestRepository,
        IPatientRepository patientRepository,
        INotificationService notificationService,
        IMapper mapper)
    {
        _ambulanceRequestRepository = ambulanceRequestRepository;
        _patientRepository = patientRepository;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<AmbulanceRequest> RequestAmbulanceAsync(AmbulanceRequestDto requestDto)
    {
        var patient = await _patientRepository.GetByIdAsync(requestDto.PatientId);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        var request = _mapper.Map<AmbulanceRequest>(requestDto);
        request = await _ambulanceRequestRepository.AddAsync(request);

        // Send emergency notification
        await _notificationService.SendNotificationAsync(
            requestDto.PatientId,
            "Ambulance Requested",
            $"Ambulance has been requested from {requestDto.PickupLocation} to {requestDto.Destination}",
            NotificationType.Emergency);

        return request;
    }

    public async Task UpdateAmbulanceStatusAsync(Guid requestId, AmbulanceStatus status)
    {
        var request = await _ambulanceRequestRepository.GetByIdAsync(requestId);
        request.Status = status;
        await _ambulanceRequestRepository.UpdateAsync(request);

        // Send notification
        var statusMessage = status switch
        {
            AmbulanceStatus.Dispatched => "Ambulance has been dispatched to your location",
            AmbulanceStatus.Completed => "Ambulance service completed",
            AmbulanceStatus.Cancelled => "Ambulance request has been cancelled",
            _ => $"Ambulance request status updated to {status}"
        };

        await _notificationService.SendNotificationAsync(
            request.PatientId,
            "Ambulance Status Update",
            statusMessage,
            NotificationType.Emergency);
    }

    public async Task<IEnumerable<AmbulanceRequest>> GetPatientAmbulanceRequestsAsync(Guid patientId)
    {
        return await _ambulanceRequestRepository.GetByPatientIdAsync(patientId);
    }
}
}
