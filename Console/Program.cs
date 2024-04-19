// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, MedPro!");

// create a new instance of the Doctor with all the properties
var doctor = new Doctor
{
    Id = Guid.NewGuid(),
    Name = "Dr. John Doe",
    Email = "drjohn@gmail.com",
    PhoneNumber = "123456789",
    DocumentNumber = "123456789",
    BirthDate = new DateTime(1980, 1, 1),
    Address = new Address
    {
        Street = "123 Main St",
        City = "Miami",
        State = "FL",
        ZipCode = "33101"
    },
    Speciality = new Speciality
    {
        Id = Guid.NewGuid(),
        Name = "Cardiologist",
        Description = "Heart Specialist"
    },
    BloodType = BloodType.ABPositive,
};
