// See https://aka.ms/new-console-template for more information

using MedPro.Domain.Entities;
using MedPro.Domain.Enums;

Console.WriteLine("Hello, MedPro!");

// create a new instance of the Doctor with all the properties using the constructor
var doctor = new Doctor(Guid.NewGuid(), "John", "Doe", new DateTime(1983, 7, 24), "995656565", "email@gmail.com",
    "document", BloodTypeEnum.BPositive,
    "Address", new Speciality("Nutricionist", "Description of speciality"), "CRM");    
    

