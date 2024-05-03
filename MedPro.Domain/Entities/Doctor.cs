using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Doctor : Person
{
    public Doctor() : base()
    {
    }
    
    public Doctor(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email,
        string documentNumber, BloodTypeEnum bloodTypeEnum, string address, Speciality speciality, string crm) : base(
        firstName, lastName, birthDate, phoneNumber, email, documentNumber, bloodTypeEnum, address)
    {
        Speciality = speciality;
        CRM = crm;
    }

    public Guid SpecialityId { get; set; }
    public string CRM { get; private set; }
    
    public Speciality Speciality { get; private set; }

    public List<Appointment> Appointments { get; set; }
}