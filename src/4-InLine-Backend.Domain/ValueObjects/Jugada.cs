namespace InLineBackend.Domain.ValueObjects
{
    public class Jugada
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdJuego { get; set; }
        public int Jugador { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
        public bool Marcada { get; set; } = false;

    }
}
