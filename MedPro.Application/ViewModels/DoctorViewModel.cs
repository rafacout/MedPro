namespace MedPro.Application.ViewModels;

public class DoctorViewModel
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
    public string Speciality { get; set; }
    public decimal CRM { get; set; }
}