using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroInfoBack.Migrations
{
    /// <inheritdoc />
    public partial class testeteste3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resultado",
                table: "Fertilizantes",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "Resultado",
                table: "Agrotoxicos",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Fertilizantes",
                newName: "Resultado");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Agrotoxicos",
                newName: "Resultado");
        }
    }
}
