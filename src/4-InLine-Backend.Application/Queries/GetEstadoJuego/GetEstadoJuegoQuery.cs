using MediatR;

namespace InLineBackend.Application.Queries.GetEstadoJuego
{
    public record GetEstadoJuegoQuery(string IdJuego) : IRequest<GetEstadoJuegoResultDto>
    {
    }
}
