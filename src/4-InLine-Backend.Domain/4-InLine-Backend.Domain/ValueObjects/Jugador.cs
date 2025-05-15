using Microsoft.EntityFrameworkCore;

namespace _4_InLine_Backend.Domain.ValueObjects
{
    [Owned]
    public class Jugador
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

    }
}
