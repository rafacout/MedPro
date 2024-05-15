using MedPro.Domain.Entities.Base;
using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Person : BaseEntity
{
    public Person()
    {
    }
    
    public Person(Guid userId)
    {
        UserId = userId;
    }
    
    public Person(Guid userId, string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string documentNumber, BloodTypeEnum bloodTypeEnum, string address)
    {
        UserId = userId;
        FirstFirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        Email = email;
        DocumentNumber = documentNumber;
        BloodTypeEnum = bloodTypeEnum;
        Address = address;
    }

    public Guid UserId { get; private set; }
    public string FirstFirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string DocumentNumber { get; private set; }
    public BloodTypeEnum BloodTypeEnum { get; private set; }
    public string Address { get; private set; }
}