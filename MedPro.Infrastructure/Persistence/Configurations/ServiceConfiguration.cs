using MedPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPro.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Appointments)
            .WithOne(p => p.Service)
            .HasForeignKey(p => p.ServiceId);
    }
}