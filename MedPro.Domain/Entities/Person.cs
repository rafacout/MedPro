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
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        Email = email;
        DocumentNumber = documentNumber;
        BloodTypeEnum = bloodTypeEnum;
        Address = address;
    }

    public Guid UserId { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public DateTime BirthDate { get; protected set; }
    public string PhoneNumber { get; protected set; }
    public string Email { get; protected set; }
    public string DocumentNumber { get; protected set; }
    public BloodTypeEnum BloodTypeEnum { get; protected set; }
    public string Address { get; protected set; }
}