using Application.Dto;
namespace Application.Mapping{
    public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<AppointmentRequestDto, Appointment>();
        CreateMap<MedicineOrderDto, MedicineOrder>();
        CreateMap<InquiryDto, Inquiry>();
        CreateMap<DiagnosticBookingDto, DiagnosticBooking>();
        CreateMap<AmbulanceRequestDto, AmbulanceRequest>();
    }
}
}