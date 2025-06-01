using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface
{
    public interface IAmbulanceService
{
    Task<AmbulanceRequest> RequestAmbulanceAsync(AmbulanceRequestDto requestDto);
    Task UpdateAmbulanceStatusAsync(Guid requestId, AmbulanceStatus status);
    Task<IEnumerable<AmbulanceRequest>> GetPatientAmbulanceRequestsAsync(Guid patientId);
}
}
