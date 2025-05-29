using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4_InLine_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    IdJuego = table.Column<string>(type: "TEXT", nullable: false),
                    ColumnasMax = table.Column<int>(type: "INTEGER", nullable: false),
                    FilasMax = table.Column<int>(type: "INTEGER", nullable: false),
                    Finalizado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ganador_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Ganador_Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.IdJuego);
                });

            migrationBuilder.CreateTable(
                name: "Jugada",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    IdJuego = table.Column<string>(type: "TEXT", nullable: false),
                    Jugador_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Jugador_Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Columna = table.Column<int>(type: "INTEGER", nullable: false),
                    Fila = table.Column<int>(type: "INTEGER", nullable: false),
                    Marcada = table.Column<bool>(type: "INTEGER", nullable: false),
                    JuegoIdJuego = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugada_Juegos_JuegoIdJuego",
                        column: x => x.JuegoIdJuego,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugada_JuegoIdJuego",
                table: "Jugada",
                column: "JuegoIdJuego");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugada");

            migrationBuilder.DropTable(
                name: "Juegos");
        }
    }
}
