namespace MedPro.Domain.Entity;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime BookDateTime { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public Service Service { get; set; }
    public string Description { get; set; }
    public Insurance Insurance { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public AppointmentTypeEnum AppointmentTypeEnum { get; set; }
}