using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InLineBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CambioJugadorAGanadorInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jugador_Id",
                table: "Jugada");

            migrationBuilder.DropColumn(
                name: "Jugador_Nombre",
                table: "Jugada");

            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "Ganador_Id",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "Ganador_Nombre",
                table: "Juegos");

            migrationBuilder.AddColumn<int>(
                name: "Jugador",
                table: "Jugada",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jugador",
                table: "Jugada");

            migrationBuilder.AddColumn<string>(
                name: "Jugador_Id",
                table: "Jugada",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Jugador_Nombre",
                table: "Jugada",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Juegos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Ganador_Id",
                table: "Juegos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ganador_Nombre",
                table: "Juegos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
