﻿using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Employees.Core.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Employee>().HasData(
                new List<Employee>()
                {
                    new Employee()
                    {
                        Id = Guid.Parse("0059e695-f8fd-442f-ac01-850f898057ff"),
                        Name = "Vadym",
                        LastName = "Bei",
                        Age = 22,
                        Email = "bey1705@gmail.com",
                        Phone = "380971234567"
                    }
                });

            base.OnModelCreating(builder);
        }
    }
}