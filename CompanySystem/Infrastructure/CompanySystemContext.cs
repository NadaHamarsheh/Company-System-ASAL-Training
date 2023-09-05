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
    }
}

