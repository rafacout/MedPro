using MedPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Infrastructure.Persistence.Context;

public class MedProDbContext : DbContext
{
    public MedProDbContext(DbContextOptions<MedProDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedProDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public MedProDbContext()
    {
    }
    
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Speciality> Specialities { get; set; }
}