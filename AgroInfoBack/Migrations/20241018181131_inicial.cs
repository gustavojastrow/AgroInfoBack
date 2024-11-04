using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroInfoBack.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plantacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemInicio = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagemMeio = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagemFim = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agrotoxicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agrotoxicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agrotoxicos_Plantacoes_PlantacaoId",
                        column: x => x.PlantacaoId,
                        principalTable: "Plantacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fertilizantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fertilizantes_Plantacoes_PlantacaoId",
                        column: x => x.PlantacaoId,
                        principalTable: "Plantacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Irrigacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAgendada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    PlantacaoId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Agrotoxicos_PlantacaoId",
                table: "Agrotoxicos",
                column: "PlantacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizantes_PlantacaoId",
                table: "Fertilizantes",
                column: "PlantacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Irrigacoes_PlantacaoId",
                table: "Irrigacoes",
                column: "PlantacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agrotoxicos");

            migrationBuilder.DropTable(
                name: "Fertilizantes");

            migrationBuilder.DropTable(
                name: "Irrigacoes");

            migrationBuilder.DropTable(
                name: "Plantacoes");
        }
    }
}
