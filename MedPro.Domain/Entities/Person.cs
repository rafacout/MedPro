using MedPro.Domain.Entities.Base;
using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Person : BaseEntity
{
    public Person()
    {
    }
    
    public Person(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string documentNumber, BloodTypeEnum bloodTypeEnum, string address)
    {
        FirstFirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        Email = email;
        DocumentNumber = documentNumber;
        BloodTypeEnum = bloodTypeEnum;
        Address = address;
    }
    public string FirstFirstName { get; private set; }
    
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string DocumentNumber { get; private set; }
    public BloodTypeEnum BloodTypeEnum { get; private set; }
    public string Address { get; private set; }
}