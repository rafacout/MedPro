using MedPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPro.Infrastructure.Persistence.Configurations;

public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Speciality)
            .WithMany(p => p.Doctors);
    }
}