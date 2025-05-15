namespace _4_InLine_Backend.Domain.ValueObjects
{
    public class Jugada
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdJuego { get; set; }
        public Jugador Jugador { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
        public bool Marcada { get; set; }

    }
}
