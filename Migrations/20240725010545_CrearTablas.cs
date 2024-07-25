using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalPOO2.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jefes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreJefe = table.Column<string>(type: "text", nullable: true),
                    Departamento = table.Column<string>(type: "text", nullable: true),
                    Sueldo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jefes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginEncargados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CorreoEnc = table.Column<string>(type: "text", nullable: false),
                    ContraseñaEnc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginEncargados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegEmpleados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreCompleto = table.Column<string>(type: "text", nullable: true),
                    FechaEntrada = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Nacionalidad = table.Column<string>(type: "text", nullable: true),
                    EstadoCivil = table.Column<string>(type: "text", nullable: true),
                    Curp = table.Column<string>(type: "text", nullable: true),
                    Rfc = table.Column<string>(type: "text", nullable: true),
                    Domicilio = table.Column<string>(type: "text", nullable: true),
                    Turno = table.Column<string>(type: "text", nullable: true),
                    Jefe = table.Column<string>(type: "text", nullable: true),
                    Departamento = table.Column<string>(type: "text", nullable: true),
                    JefeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegEmpleados_Jefes_JefeId",
                        column: x => x.JefeId,
                        principalTable: "Jefes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegEmpleados_JefeId",
                table: "RegEmpleados",
                column: "JefeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginEncargados");

            migrationBuilder.DropTable(
                name: "RegEmpleados");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Jefes");
        }
    }
}
