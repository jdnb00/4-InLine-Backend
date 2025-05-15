using MediatR;

namespace _4_InLine_Backend.Application.Commnads.PostNuevoJuego
{
    public record PostNuevoJuegoCommand(int Columna, int Fila) : IRequest<PostNuevoJuegoResultDto>
    {

    }
}
