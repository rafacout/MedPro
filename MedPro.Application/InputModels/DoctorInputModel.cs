using MedPro.Domain.Enums;

namespace MedPro.Application.InputModels;

public class DoctorInputModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public BloodTypeEnum BloodTypeEnum { get; set; }
    public string Address { get; set; }
    public Guid SpecialityId { get; set; }
    public string CRM { get; set; }
}