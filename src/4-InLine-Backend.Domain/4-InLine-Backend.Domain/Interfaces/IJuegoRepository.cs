using _4_InLine_Backend.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_InLine_Backend.Domain.Interfaces
{
    public interface IJuegoRepository
    {
        Task SaveAsync();
        Task<Juego?> GetEstadoJuego(string id);
    }
}
