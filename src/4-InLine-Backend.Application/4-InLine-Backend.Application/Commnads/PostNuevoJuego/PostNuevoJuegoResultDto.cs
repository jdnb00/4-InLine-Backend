using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_InLine_Backend.Application.Commnads.PostNuevoJuego
{
    public class PostNuevoJuegoResultDto
    {
        public string IdJuego { get; set; } 
        public int ColumnasMax { get; set; }
        public int FilasMax { get; set; }
        public bool Finalizado { get; set; }

    }
}
