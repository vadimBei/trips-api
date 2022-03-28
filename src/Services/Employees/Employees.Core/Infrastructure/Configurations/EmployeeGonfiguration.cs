using Employees.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Core.Infrastructure.Configurations
{
    public class EmployeeGonfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Verifications");

            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();
        }
    }
}
