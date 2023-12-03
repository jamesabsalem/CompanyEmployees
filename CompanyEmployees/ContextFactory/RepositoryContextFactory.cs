using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace CompanyEmployees.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            // Log or debug to check the configuration values
            var connectionString = configuration.GetConnectionString("sqlConnection");

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(connectionString, b => b.MigrationsAssembly("CompanyEmployees"));

            return new RepositoryContext(builder.Options);

        }
    }
}
