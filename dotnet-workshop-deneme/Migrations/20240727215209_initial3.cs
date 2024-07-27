using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_workshop_deneme.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Musteriler_MusteriId",
                table: "Kitaplar");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Kitaplar",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Musteriler_MusteriId",
                table: "Kitaplar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Musteriler_MusteriId",
                table: "Kitaplar");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Kitaplar",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Musteriler_MusteriId",
                table: "Kitaplar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
