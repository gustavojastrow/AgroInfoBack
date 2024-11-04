using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroInfoBack.Migrations
{
    /// <inheritdoc />
    public partial class testeteste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "Plantacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeObtida",
                table: "Plantacoes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "QuantidadeObtida",
                table: "Plantacoes");
        }
    }
}
