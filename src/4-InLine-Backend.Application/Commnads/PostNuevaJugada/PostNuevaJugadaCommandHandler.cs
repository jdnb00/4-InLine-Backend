using InLineBackend.Domain.Aggregate;
using InLineBackend.Domain.Interfaces;
using InLineBackend.Domain.ValueObjects;
using MediatR;

namespace InLineBackend.Application.Commnads.PostNuevaJugada
{
    public class PostNuevaJugadaCommandHandler(IJuegoService juegoService) : IRequestHandler<PostNuevaJugadaCommand, PostNuevaJugadaResultDto>
    {
        private readonly IJuegoService _juegoService = juegoService;

        public async Task<PostNuevaJugadaResultDto> Handle(PostNuevaJugadaCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // comprobar juego  existe
                Juego? juego = await _juegoService.GetEstadoJuego(command.IdJuego) ??
                    throw new ArgumentException("Juego no Existe...");
                // definir fila de esta juagada
                int nFila = juego.Jugadas.Where(x => x.Columna == command.Columna)
                            .Select(x => x.Fila).DefaultIfEmpty(-1).Max() + 1;

                //validaciones columnas contra command.columna y nueva fila
                if (command.Columna > juego.ColumnasMax || command.Columna < 0) { throw new ArgumentException("Numero d Columna incorrecta"); }
                //validaciones columnas contra command.columna y nueva fila
                if (nFila > juego.FilasMax || nFila < 0) { return MapResult(juego); }
                //Validar jugada Repetida

                if (juego.Finalizado) { return MapResult(juego); }

                //crear nueva jugada
                Jugada nJugada = new Jugada()
                {
                    IdJuego = command.IdJuego,
                    Jugador = command.Jugador,
                    Columna = command.Columna,
                    Fila = nFila,
                };
                juego.AddJugada(nJugada);

                // Guardar Contexto
                await _juegoService.SaveContext();

                return MapResult(juego);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error en Nuevo" + ex.ToString());
            }
        }

        private PostNuevaJugadaResultDto MapResult(Juego juego)
        {
            var matrizJugadas = juego.Jugadas
                .Select(j => (
                    j.Fila,
                    j.Columna,
                    j.Marcada,
                    j.Jugador
                ))
                .ToList();

            return new PostNuevaJugadaResultDto
            {
                MatrizJugadas = matrizJugadas,
                Finalizado = juego.Finalizado
            };
        }
    }
}
