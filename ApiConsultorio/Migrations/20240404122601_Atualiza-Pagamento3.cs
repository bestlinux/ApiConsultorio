using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPagamento3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoPagamento",
                table: "Pagamentos",
                newName: "StatusPagamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusPagamento",
                table: "Pagamentos",
                newName: "TipoPagamento");
        }
    }
}
