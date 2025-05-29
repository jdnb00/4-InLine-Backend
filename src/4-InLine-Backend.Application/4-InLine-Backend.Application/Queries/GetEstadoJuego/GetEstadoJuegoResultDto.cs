using InLineBackend.Application.Dto;

namespace InLineBackend.Application.Queries.GetEstadoJuego
{
    public class GetEstadoJuegoResultDto
    {
        public JuegoDto Juego { get; set; }
        public List<JugadaDto> Matriz { get; set; }
    }
}
