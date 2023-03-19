using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Suplidor_SuplidorId",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_SuplidorId",
                table: "Articulo");

            migrationBuilder.AddColumn<int>(
                name: "PagoId",
                table: "Articulo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagoId",
                table: "Articulo");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_SuplidorId",
                table: "Articulo",
                column: "SuplidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Suplidor_SuplidorId",
                table: "Articulo",
                column: "SuplidorId",
                principalTable: "Suplidor",
                principalColumn: "SuplidorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
