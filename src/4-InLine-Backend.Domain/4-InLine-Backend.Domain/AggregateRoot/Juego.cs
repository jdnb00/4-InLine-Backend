using _4_InLine_Backend.Domain.ValueObjects;

namespace _4_InLine_Backend.Domain.Aggregate
{
    public class Juego 
    {
        public string IdJuego { get; set; } = Guid.NewGuid().ToString();
        public int ColumnasMax { get; set; }
        public int FilasMax { get; set; }
        public bool Finalizado { get; set; }
        public Jugador Ganador { get; set; }
        public List<Jugada> Jugadas { get; set; }

    }
}
