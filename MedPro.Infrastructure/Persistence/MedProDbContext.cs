using MedPro.Domain.Entities;

namespace MedPro.Infrastructure.Persistence;

public class MedProDbContext
{
    public MedProDbContext()
    {
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
        Specialities = new List<Speciality>();
    }
    
    public List<Doctor> Doctors { get; set; }
    public List<Patient> Patients { get; set; }
    public List<Speciality> Specialities { get; set; }
    
    public void SaveChanges()
    {
        // Save changes to the database
    }
}