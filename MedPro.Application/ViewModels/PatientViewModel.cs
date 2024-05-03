namespace MedPro.Application.Services.Interfaces;

public class PatientViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public string BloodType { get; set; }
    public string Address { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}