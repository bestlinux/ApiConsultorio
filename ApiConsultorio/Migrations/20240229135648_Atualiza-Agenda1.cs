using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaAgenda1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PacienteNome",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PacienteNome",
                table: "Agendas");
        }
    }
}
