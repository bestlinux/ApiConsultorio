using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCPFPagadorAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPFPagador",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPFPagador",
                table: "Agendas");
        }
    }
}
