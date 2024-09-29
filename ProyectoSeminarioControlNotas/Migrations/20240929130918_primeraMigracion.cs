using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeminarioControlNotas.Migrations
{
    /// <inheritdoc />
    public partial class primeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alumnos",
                columns: table => new
                {
                    idAlumno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estadoAlumno = table.Column<bool>(type: "bit", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    carrera = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    numeroTelefono = table.Column<int>(type: "int", nullable: true),
                    fechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos", x => x.idAlumno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alumnos");
        }
    }
}
