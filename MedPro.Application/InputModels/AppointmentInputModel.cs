using MedPro.Domain.Enums;

namespace MedPro.Application.InputModels;

public class AppointmentInputModel
{
    public DateTime BookDateTime { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public Guid ServiceId { get; set; }
    public string Description { get; set; }
    public Guid InsuranceId { get; set; }
    public AppointmentTypeEnum AppointmentTypeEnum { get; set; }
}