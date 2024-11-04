using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroInfoBack.Migrations
{
    /// <inheritdoc />
    public partial class numeros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemMeioUrl",
                table: "Plantacoes",
                newName: "ImagemMeio");

            migrationBuilder.RenameColumn(
                name: "ImagemInicioUrl",
                table: "Plantacoes",
                newName: "ImagemInicio");

            migrationBuilder.RenameColumn(
                name: "ImagemFimUrl",
                table: "Plantacoes",
                newName: "ImagemFim");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemMeio",
                table: "Plantacoes",
                newName: "ImagemMeioUrl");

            migrationBuilder.RenameColumn(
                name: "ImagemInicio",
                table: "Plantacoes",
                newName: "ImagemInicioUrl");

            migrationBuilder.RenameColumn(
                name: "ImagemFim",
                table: "Plantacoes",
                newName: "ImagemFimUrl");
        }
    }
}
