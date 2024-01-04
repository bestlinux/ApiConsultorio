using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AlteraPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nascimento",
                table: "Pacientes",
                newName: "DataNascimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Pacientes",
                newName: "Nascimento");
        }
    }
}
