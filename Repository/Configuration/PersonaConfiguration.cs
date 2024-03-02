using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
	public void Configure(EntityTypeBuilder<Persona> builder)
	{
		builder.HasData
		(
			new Persona
            {
				Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
				Nombre = "Angel",
				ApellidoPaterno = "Martinez",
				ApellidoMaterno = "Cortes",
                Identificacion = "987654321",
            },
			new Persona
            {
				Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Nombre = "Isaac",
                ApellidoPaterno = "Cortes",
                ApellidoMaterno = "Martínez",
                Identificacion = "123456789",
            }
		);
	}
}
