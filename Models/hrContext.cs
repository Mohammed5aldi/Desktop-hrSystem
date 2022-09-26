using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HrSystem.Models
{
    public partial class hrContext : DbContext
    {
        public hrContext()
        {
        }

        public hrContext(DbContextOptions<hrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Dependent> Dependents { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\ssQss\\OneDrive\\Desktop\\hr.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .HasColumnType("text")
                    .HasColumnName("department_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.ToTable("dependents");

                entity.Property(e => e.DependentId).HasColumnName("dependent_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FirstName)
                    .HasColumnType("text")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("text")
                    .HasColumnName("last_name");

                entity.Property(e => e.Relationship)
                    .HasColumnType("text")
                    .HasColumnName("relationship");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Dependents)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasColumnType("text")
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("text")
                    .HasColumnName("hire_date");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LastName)
                    .HasColumnType("text")
                    .HasColumnName("last_name");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("text")
                    .HasColumnName("phone_number");

                entity.Property(e => e.Salary)
                    .HasColumnType("double")
                    .HasColumnName("salary");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobTitle)
                    .HasColumnType("text")
                    .HasColumnName("job_title");

                entity.Property(e => e.MaxSalary)
                    .HasColumnType("double")
                    .HasColumnName("max_salary");

                entity.Property(e => e.MinSalary)
                    .HasColumnType("double")
                    .HasColumnName("min_salary");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.City)
                    .HasColumnType("text")
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("text")
                    .HasColumnName("postal_code");

                entity.Property(e => e.StateProvince)
                    .HasColumnType("text")
                    .HasColumnName("state_province");

                entity.Property(e => e.StreetAddress)
                    .HasColumnType("text")
                    .HasColumnName("street_address");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("regions");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.RegionName)
                    .HasColumnType("text")
                    .HasColumnName("region_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
