﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPagamento2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoPagamento",
                table: "Pagamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoPagamento",
                table: "Pagamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
