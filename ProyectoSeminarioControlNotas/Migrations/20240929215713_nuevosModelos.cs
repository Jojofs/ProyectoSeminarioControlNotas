using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSeminarioControlNotas.Migrations
{
    /// <inheritdoc />
    public partial class nuevosModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "carrera",
                table: "alumnos",
                type: "int",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarreraidCarrera",
                table: "alumnos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estadoCarrera = table.Column<bool>(type: "bit", nullable: false),
                    codigoCarrera = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    numeroCiclo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    idCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ciclo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.idCurso);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alumnos_CarreraidCarrera",
                table: "alumnos",
                column: "CarreraidCarrera");

            migrationBuilder.AddForeignKey(
                name: "FK_alumnos_Carrera_CarreraidCarrera",
                table: "alumnos",
                column: "CarreraidCarrera",
                principalTable: "Carrera",
                principalColumn: "idCarrera");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumnos_Carrera_CarreraidCarrera",
                table: "alumnos");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropIndex(
                name: "IX_alumnos_CarreraidCarrera",
                table: "alumnos");

            migrationBuilder.DropColumn(
                name: "CarreraidCarrera",
                table: "alumnos");

            migrationBuilder.AlterColumn<string>(
                name: "carrera",
                table: "alumnos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
