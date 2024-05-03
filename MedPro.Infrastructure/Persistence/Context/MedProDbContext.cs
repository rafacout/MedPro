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
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Appointment>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Appointment>()
            .HasOne(p => p.Doctor)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.DoctorId);

        modelBuilder.Entity<Appointment>()
            .HasOne(p => p.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.PatientId);
        
        modelBuilder.Entity<Appointment>()
            .HasOne(p => p.Service)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.ServiceId);

        modelBuilder.Entity<Appointment>()
            .HasOne(p => p.Insurance);
        
        
        modelBuilder.Entity<Doctor>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Doctor>()
            .HasOne(p => p.Speciality)
            .WithMany(p => p.Doctors);

        modelBuilder.Entity<Patient>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Patient>()
            .HasOne(p => p.Address);
        
        modelBuilder.Entity<Insurance>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Service>()
            .HasKey(p => p.Id);
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