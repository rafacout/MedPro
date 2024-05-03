﻿using MedPro.Domain.Enums;

namespace MedPro.Domain.Entities;

public class Doctor : Person
{
    public Doctor(string name, string lastName, DateTime birthDate, string phoneNumber, string email,
        string documentNumber, BloodTypeEnum bloodTypeEnum, string address, Speciality speciality, string crm) : base(
        name, lastName, birthDate, phoneNumber, email, documentNumber, bloodTypeEnum, address)
    {
        Speciality = speciality;
        CRM = crm;
    }

    public Guid SpecialityId { get; set; }
    public Speciality Speciality { get; private set; }
    public string CRM { get; private set; }

    public List<Appointment> Appointments { get; set; }
}