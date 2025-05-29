using MediatR;

namespace _4_InLine_Backend.Application.Commnads.PostNuevaJugada
{
    public record PostNuevaJugadaCommand(string IdJuego, int Jugador, int Columna) : IRequest<PostNuevaJugadaResultDto>;
}
