using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCPFPagamentoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPFPagador",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPFPagador",
                table: "Pacientes");
        }
    }
}
