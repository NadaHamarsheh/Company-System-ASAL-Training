using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class DesignTimeCompanySystemContextFactory : IDesignTimeDbContextFactory<CompanySystemContext>
    {
        public CompanySystemContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<CompanySystemContext>();

            var connectionString = "Server=localhost;Database=CompanySystemDB;" +
                "User=SA;Password=NadaSQL100;TrustServerCertificate=True;MultipleActiveResultSets=True";

            dbContextBuilder.UseSqlServer(connectionString);
            return new CompanySystemContext(dbContextBuilder.Options);
        }
    }
}