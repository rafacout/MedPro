using MedPro.Domain.Entities.Base;
using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Appointment : BaseEntity
{
    public Appointment(DateTime bookDateTime, Doctor doctor, Patient patient, Service service, string description,
        Insurance insurance, DateTime startDateTime, DateTime endDateTime, AppointmentTypeEnum appointmentTypeEnum)
    {
        BookDateTime = bookDateTime;
        Doctor = doctor;
        Patient = patient;
        Service = service;
        Description = description;
        Insurance = insurance;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        AppointmentTypeEnum = appointmentTypeEnum;
    }
    
    public DateTime BookDateTime { get; private set; }
    public string Description { get; private set; }
    public Guid DoctorId { get; set; }
    
    public Guid PatientId { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public Guid InsuranceId { get; set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public AppointmentTypeEnum AppointmentTypeEnum { get; private set; }

    
    public Doctor Doctor { get; private set; }
    public Patient Patient { get; private set; }
    public Service Service { get; private set; }
    public Insurance Insurance { get; private set; }
    
}