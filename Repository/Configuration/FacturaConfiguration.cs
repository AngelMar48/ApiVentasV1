using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
	public void Configure(EntityTypeBuilder<Factura> builder)
	{
		builder.HasData
		(
			new Factura
			{
				Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
				Fecha = "01052024",
				Monto = "2000",
				PersonaId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Factura
            {
                Id = new Guid("52a64329-202e-4091-aff0-80230f189cd1"),
                Fecha = "01052023",
                Monto = "3000",
                PersonaId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Factura
			{
				Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Fecha = "01012024",
                Monto = "1000",
                PersonaId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            },

            new Factura
            {
                Id = new Guid("119672b6-0119-44f2-8ae7-8e2c0d7b6212"),
                Fecha = "01012023",
                Monto = "4000",
                PersonaId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            }
        );
	}
}
