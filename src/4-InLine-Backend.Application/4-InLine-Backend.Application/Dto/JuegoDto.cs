
namespace _4_InLine_Backend.Application.Dto
{
    public class JuegoDto
    {
        public string Id { get; set; }
        public int ColumnaMax { get; set; }
        public int FilaMax { get; set; }
        public bool Finalizado { get; set; }
        public JugadorDto? Ganador { get; set; }

    }
}
