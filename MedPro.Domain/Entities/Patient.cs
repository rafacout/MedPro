using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Patient : Person
{
    public Patient(string name, string lastName, DateTime birthDate, string phoneNumber, string email,
        string documentNumber, BloodTypeEnum bloodTypeEnum, string address, decimal heigth, decimal weigth) : base(
        name, lastName, birthDate, phoneNumber, email, documentNumber, bloodTypeEnum, address)
    {
        Heigth = heigth;
        Weigth = weigth;
    }
    
    public decimal Heigth { get; private set; }
    public decimal Weigth { get; private set; }
    
    public List<Appointment> Appointments { get; set; }
}