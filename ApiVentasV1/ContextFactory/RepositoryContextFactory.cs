using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace ApiVentasV1.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
	public RepositoryContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<RepositoryContext>()
			.UseSqlite(configuration.GetConnectionString("sqlConnection"),
			b => b.MigrationsAssembly("ApiVentasV1"));

		return new RepositoryContext(builder.Options);
	}
}
