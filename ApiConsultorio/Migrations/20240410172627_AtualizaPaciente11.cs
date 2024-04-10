using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPaciente11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prontuario",
                table: "Pacientes",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prontuario",
                table: "Pacientes",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }
    }
}
