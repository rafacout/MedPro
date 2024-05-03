namespace MedPro.Application.InputModels;

public class AppointmentViewModel
{
    public Guid Id { get; set; }
    public DateTime BookDateTime { get; set; }
    public Guid DoctorId { get; set; }
    public string DoctorName { get; set; }
    public Guid PatientId { get; set; }
    public string PatientName { get; set; }
    public Guid ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public Guid InsuranceId { get; set; }
    public string InsuranceName { get; set; }
    public string AppointmentType { get; set; }
}