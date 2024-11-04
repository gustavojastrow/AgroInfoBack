using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroInfoBack.Migrations
{
    /// <inheritdoc />
    public partial class numero2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemFim",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "ImagemInicio",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "ImagemMeio",
                table: "Plantacoes");

            migrationBuilder.AddColumn<string>(
                name: "ImagemFimUrl",
                table: "Plantacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemInicioUrl",
                table: "Plantacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemMeioUrl",
                table: "Plantacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemFimUrl",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "ImagemInicioUrl",
                table: "Plantacoes");

            migrationBuilder.DropColumn(
                name: "ImagemMeioUrl",
                table: "Plantacoes");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagemFim",
                table: "Plantacoes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagemInicio",
                table: "Plantacoes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagemMeio",
                table: "Plantacoes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
