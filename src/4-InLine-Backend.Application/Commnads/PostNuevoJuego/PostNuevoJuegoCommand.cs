using MediatR;

namespace InLineBackend.Application.Commnads.PostNuevoJuego
{
    public record PostNuevoJuegoCommand : IRequest<PostNuevoJuegoResultDto>
    {
        public int Columna { get; }
        public int Fila { get; }

        public PostNuevoJuegoCommand(int columna, int fila)
        {
            if (columna <= 0) throw new ArgumentException("Columna inválida");
            if (fila <= 0) throw new ArgumentException("Fila inválida");

            Columna = columna;
            Fila = fila;
        }
    }
}
