using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class CompanySystemContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CompanySystemDB;User=SA;Password=NadaSQL100;TrustServerCertificate=True");
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WebSection> WebSections { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<UserDetail>(ud => ud.UserDetails)
                .WithOne(u => u.Users)
                .HasForeignKey<User>(u => u.UserId);
                

        }
    }
}

