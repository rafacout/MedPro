using MedPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPro.Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.Doctor)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.DoctorId);

        builder
            .HasOne(p => p.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.PatientId);
        
        builder
            .HasOne(p => p.Service)
            .WithMany(p => p.Appointments)
            .HasForeignKey(p => p.ServiceId);

        builder
            .HasOne(p => p.Insurance);
    }
}