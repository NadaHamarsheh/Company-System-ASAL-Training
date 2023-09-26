using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class CompanySystemContext : DbContext
	{
        public CompanySystemContext(DbContextOptions<CompanySystemContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>()
                .HasOne(a => a.Users)
                .WithOne(b => b.UserDetails)
                .HasForeignKey<User>(b => b.UserDetailId);

            modelBuilder.Entity<EmployeeDetail>()
                .HasOne(a => a.User)
                .WithOne(b => b.EmployeeDetail)
                .HasForeignKey<User>(b => b.EmployeeDetailId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Employees)
                .WithOne(u => u.Leader)
                .HasForeignKey(u => u.LeaderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}