﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConsultorio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AgendaSessaoRecorrente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExisteSessaoRecorrente",
                table: "Agendas",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExisteSessaoRecorrente",
                table: "Agendas");
        }
    }
}
