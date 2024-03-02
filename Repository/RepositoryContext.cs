using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
	public RepositoryContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfiguration(new PersonaConfiguration());
        modelBuilder.ApplyConfiguration(new FacturaConfiguration());
    }

    public DbSet<Persona>? Personas { get; set; }
    public DbSet<Factura>? Facturas { get; set; }
}
