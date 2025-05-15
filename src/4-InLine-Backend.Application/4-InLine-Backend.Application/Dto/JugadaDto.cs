using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_InLine_Backend.Application.Dto
{
    public class JugadaDto
    {
        public string Id { get; set; }
        public string IdJuego { get; set; }
        public JugadorDto Jugador { get; set; }
        public int Columna { get; set; }
        public int Fila { get; set; }
        public bool Marcada { get; set; }
    }
}
