namespace InLineBackend.Application.Dto
{
    public class JugadaDto
    {
        public string Id { get; set; }
        public string IdJuego { get; set; }
        public int? Jugador { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
        public bool Marcada { get; set; }
    }
}
