using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiVentasV1.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "TEXT", nullable: true),
                    Identificacion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Fecha = table.Column<string>(type: "TEXT", nullable: true),
                    Monto = table.Column<string>(type: "TEXT", nullable: true),
                    PersonaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Facturas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "PersonaId", "ApellidoMaterno", "ApellidoPaterno", "Identificacion", "Nombre" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Martínez", "Cortes", "123456789", "Isaac" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "PersonaId", "ApellidoMaterno", "ApellidoPaterno", "Identificacion", "Nombre" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Cortes", "Martinez", "987654321", "Angel" });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "FacturaId", "Fecha", "Monto", "PersonaId" },
                values: new object[] { new Guid("119672b6-0119-44f2-8ae7-8e2c0d7b6212"), "01012023", "4000", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "FacturaId", "Fecha", "Monto", "PersonaId" },
                values: new object[] { new Guid("52a64329-202e-4091-aff0-80230f189cd1"), "01052023", "3000", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "FacturaId", "Fecha", "Monto", "PersonaId" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "01052024", "2000", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "FacturaId", "Fecha", "Monto", "PersonaId" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "01012024", "1000", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_PersonaId",
                table: "Facturas",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
