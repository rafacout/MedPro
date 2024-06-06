using MedPro.Domain.Enums;

namespace MedPro.Application.Services.Interfaces;

public class PatientInputModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Email { get; set; }
    public string? DocumentNumber { get; set; }
    public BloodTypeEnum BloodTypeEnum { get; set; }
    public string? Address { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}