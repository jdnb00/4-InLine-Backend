using MediatR;

namespace _4_InLine_Backend.Application.Queries.GetEstadoJuego
{
    public record GetEstadoJuegoQuery(string IdJuego) : IRequest<GetEstadoJuegoResultDto>
    {
    }
}
