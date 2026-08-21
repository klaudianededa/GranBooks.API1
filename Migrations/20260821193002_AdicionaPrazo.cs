using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GranBooks.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaPrazo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevisaoDevolucao",
                table: "Emprestimos",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPrevisaoDevolucao",
                table: "Emprestimos");
        }
    }
}
