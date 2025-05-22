using _4_InLine_Backend.Domain.ValueObjects;

namespace _4_InLine_Backend.Domain.Aggregate
{
    public class Juego
    {
        public string IdJuego { get; set; } = Guid.NewGuid().ToString();
        public int ColumnasMax { get; set; }
        public int FilasMax { get; set; }
        public bool Finalizado => ExisteGanador() != null;
        public Jugador? Ganador => ExisteGanador();
        public List<Jugada> Jugadas { get; set; }

        private Juego(int col, int fil)
        {
            ColumnasMax = col;
            FilasMax = fil;
            Jugadas = new List<Jugada>();
        }

        public static Juego Crear(int col, int fil)
        {
            return new Juego(col, fil);
        }

        private Jugador? ExisteGanador()
        {
            // Aquí va la lógica para determinar si hay un ganador
            return Jugadas.FirstOrDefault(x => x.Marcada)?.Jugador;
        }
    }
}
