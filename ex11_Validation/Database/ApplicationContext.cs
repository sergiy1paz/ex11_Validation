using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ex11_Validation.Models;

namespace ex11_Validation.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Director> Directors { get; set; }

        public ApplicationContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(PersonConfigure);
            modelBuilder.Entity<Manager>(ManagerConfigure);
            modelBuilder.Entity<Employee>(EmployeeConfigure);
            modelBuilder.Entity<Director>(DirectorConfigure);
        }

        private void PersonConfigure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(person => person.Name).IsRequired();
            builder.Property(person => person.Age).IsRequired();
        }

        private void ManagerConfigure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Managers");
            builder.Property(manager => manager.Language).IsRequired();

            // add more configuration
        }

        private void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder
                .HasOne(employee => employee.Manager)
                .WithMany(manager => manager.Employees)
                .HasForeignKey(employee => employee.ManagerId);

            // add more configuration
        }

        private void DirectorConfigure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");
            builder.Property(director => director.Experience).IsRequired();
            builder.Property(director => director.CompanyName).IsRequired();

            // add more configuration
        }
    }
}
