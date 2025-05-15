using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_InLine_Backend.Application.Commnads.PostNuevoJuego
{
    public record PostNuevoJuegoCommand(int Columna, int Fila) : IRequest<PostNuevoJuegoResultDto>
    {

    }
}
