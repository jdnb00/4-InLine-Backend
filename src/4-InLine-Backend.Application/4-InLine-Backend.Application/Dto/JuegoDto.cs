
namespace InLineBackend.Application.Dto
{
    public class JuegoDto
    {
        public string Id { get; set; }
        public int ColumnaMax { get; set; }
        public int FilaMax { get; set; }
        public bool Finalizado { get; set; }
        public int? Ganador { get; set; }

    }
}
