using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPaciente10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prontuario",
                table: "Pacientes",
                type: "varchar(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prontuario",
                table: "Pacientes");
        }
    }
}
