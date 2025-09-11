using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCPFAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Agendas");
        }
    }
}
