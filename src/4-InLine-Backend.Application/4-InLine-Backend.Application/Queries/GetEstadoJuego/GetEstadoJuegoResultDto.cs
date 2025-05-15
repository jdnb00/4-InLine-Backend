using _4_InLine_Backend.Application.Dto;

namespace _4_InLine_Backend.Application.Queries.GetEstadoJuego
{
    public class GetEstadoJuegoResultDto
    {
        public JuegoDto Juego { get; set; }
        public List<JugadaDto> Matriz { get; set; }
    }
}
