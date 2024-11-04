using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroInfoBack.Migrations
{
    /// <inheritdoc />
    public partial class removetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Irrigacoes");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Plantacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAplicacao",
                table: "Fertilizantes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NotaResultado",
                table: "Fertilizantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Objetivo",
                table: "Fertilizantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Quantidade",
                table: "Fertilizantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Fertilizantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAplicacao",
                table: "Agrotoxicos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Dosagem",
                table: "Agrotoxicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NotaResultado",
                table: "Agrotoxicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Objetivo",
                table: "Agrotoxicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Agrotoxicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "DataAplicacao",
                table: "Fertilizantes");

            migrationBuilder.DropColumn(
                name: "NotaResultado",
                table: "Fertilizantes");

            migrationBuilder.DropColumn(
                name: "Objetivo",
                table: "Fertilizantes");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Fertilizantes");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Fertilizantes");

            migrationBuilder.DropColumn(
                name: "DataAplicacao",
                table: "Agrotoxicos");

            migrationBuilder.DropColumn(
                name: "Dosagem",
                table: "Agrotoxicos");

            migrationBuilder.DropColumn(
                name: "NotaResultado",
                table: "Agrotoxicos");

            migrationBuilder.DropColumn(
                name: "Objetivo",
                table: "Agrotoxicos");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Agrotoxicos");

            migrationBuilder.CreateTable(
                name: "Irrigacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAgendada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Irrigacoes_Plantacoes_PlantacaoId",
                        column: x => x.PlantacaoId,
                        principalTable: "Plantacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Irrigacoes_PlantacaoId",
                table: "Irrigacoes",
                column: "PlantacaoId");
        }
    }
}
