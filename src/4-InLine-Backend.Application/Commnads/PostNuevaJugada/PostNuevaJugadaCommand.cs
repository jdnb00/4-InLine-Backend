using MediatR;

namespace InLineBackend.Application.Commnads.PostNuevaJugada
{
    public record PostNuevaJugadaCommand(string IdJuego, int Jugador, int Columna) : IRequest<PostNuevaJugadaResultDto>;
}
