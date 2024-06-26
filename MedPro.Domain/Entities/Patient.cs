﻿using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Patient : Person
{
    public Patient()
    {
    }
    
    public Patient(Guid userId, string firstName, string lastName, DateTime birthDate, string phoneNumber, string email,
        string documentNumber, BloodTypeEnum bloodTypeEnum, string address, decimal heigth, decimal weigth) : base(
        userId, firstName, lastName, birthDate, phoneNumber, email, documentNumber, bloodTypeEnum, address)
    {
        Heigth = heigth;
        Weigth = weigth;
    }
    
    public decimal Heigth { get; private set; }
    public decimal Weigth { get; private set; }
    
    public List<Appointment> Appointments { get; set; }

    public void Update(Guid userId, string firstName, string lastName, DateTime birthDate, string phoneNumber, string email,
        string documentNumber, BloodTypeEnum bloodTypeEnum, string address, decimal heigth, decimal weigth)
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
        Heigth = heigth;
        Weigth = weigth;
    }
}