namespace _4_InLine_Backend.Application.Commnads.PostNuevaJugada
{
    public class PostNuevaJugadaResultDto
    {
        public List<(int, int, bool, int)> MatrizJugadas { get; set; }
        public bool Finalizado { get; set; }
    }
}
