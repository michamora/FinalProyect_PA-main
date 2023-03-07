using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Inventario_InventarioId",
                table: "Articulo");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_InventarioId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Articulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Articulo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadRegistrada = table.Column<double>(type: "REAL", nullable: false),
                    DescripcionArticulo = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    NuevaCantidad = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.InventarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_InventarioId",
                table: "Articulo",
                column: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Inventario_InventarioId",
                table: "Articulo",
                column: "InventarioId",
                principalTable: "Inventario",
                principalColumn: "InventarioId");
        }
    }
}
