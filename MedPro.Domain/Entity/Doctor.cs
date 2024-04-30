namespace MedPro.Domain.Entity;

public class Doctor : Person
{
    public Speciality Speciality { get; set; }
    public string CRM { get; set; }
}