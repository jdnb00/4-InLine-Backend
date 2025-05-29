using InLineBackend.Domain.ValueObjects;

namespace InLineBackend.Domain.Aggregate
{
    public class Juego
    {
        public string IdJuego { get; set; } = Guid.NewGuid().ToString();
        public int ColumnasMax { get; set; }
        public int FilasMax { get; set; }
        public bool Finalizado => ExisteGanador() != null;
        public int? Ganador => ExisteGanador();
        private int? ExisteGanador()
        {
            // Aquí va la lógica para determinar si hay un ganador
            return Jugadas.FirstOrDefault(x => x.Marcada)?.Jugador;
        }
        public List<Jugada> Jugadas { get; set; }

        private Juego(int col, int fil)
        {
            ColumnasMax = col;
            FilasMax = fil;
            Jugadas = new List<Jugada>();
        }
        public static Juego Crear(int col, int fil)
        {
            return new Juego(col, fil);
        }

        public Juego AddJugada(Jugada njugada)
        {
            Jugadas.Add(njugada);
            DefinirJugadas(njugada);
            return this;
        }
        public void DefinirJugadas(Jugada njugada)
        {
            var h = CheckHorizontal(njugada.Fila, njugada.Columna, njugada.Jugador);
            if (h.Count >= 4) { MarcarGanadoras(h); return; }

            var v = CheckVertical(njugada.Fila, njugada.Columna, njugada.Jugador);
            if (v.Count >= 4) { MarcarGanadoras(v); return; }

            var dd = CheckDiaDerecha(njugada.Fila, njugada.Columna, njugada.Jugador);
            if (dd.Count >= 4) { MarcarGanadoras(dd); return; }

            var di = CheckDiaIzquierda(njugada.Fila, njugada.Columna, njugada.Jugador);
            if (di.Count >= 4) { MarcarGanadoras(di); return; }

        }

        private List<(int,int)> CheckHorizontal(int fil, int col, int jugador) 
        {
            var resultado = new List<(int, int)>();

            // Buscar la jugada base
            var jugadaBase = Jugadas.FirstOrDefault(j => j.Fila == fil && j.Columna == col);
            if (jugadaBase == null) return resultado;

            // Buscar hacia la derecha
            int c = col + 1;
            while (Jugadas.Any(j => j.Fila == fil && j.Columna == c && j.Jugador == jugador))
            {
                resultado.Add((fil, c));
                c++;
            }

            // Buscar hacia la izquierda
            c = col - 1;
            while (Jugadas.Any(j => j.Fila == fil && j.Columna == c && j.Jugador == jugador))
            {
                resultado.Insert(0, (fil, c)); // Insertar al principio para mantener orden izquierda → derecha
                c--;
            }

            return resultado;
        }
        private List<(int, int)> CheckVertical(int fil, int col, int jugador) 
        {
            var resultado = new List<(int, int)>();

            // Buscar hacia abajo (filas mayores)
            int f = fil + 1;
            while (Jugadas.Any(j => j.Fila == f && j.Columna == col && j.Jugador == jugador))
            {
                resultado.Add((f, col));
                f++;
            }

            // Buscar hacia arriba (filas menores)
            f = fil - 1;
            while (Jugadas.Any(j => j.Fila == f && j.Columna == col && j.Jugador == jugador))
            {
                resultado.Insert(0, (f, col)); // Insertar al principio para mantener orden ascendente
                f--;
            }

            return resultado;
        }
        private List<(int, int)> CheckDiaDerecha(int fil, int col, int jugador) 
        {
            var resultado = new List<(int, int)>();

            // ↘️ Diagonal inferior derecha
            int f = fil + 1;
            int c = col + 1;
            while (Jugadas.Any(j => j.Fila == f && j.Columna == c && j.Jugador == jugador))
            {
                resultado.Add((f, c));
                f++;
                c++;
            }

            // ↖️ Diagonal superior izquierda
            f = fil - 1;
            c = col - 1;
            while (Jugadas.Any(j => j.Fila == f && j.Columna == c && j.Jugador == jugador))
            {
                resultado.Insert(0, (f, c));
                f--;
                c--;
            }

            return resultado;
        }
        private List<(int, int)> CheckDiaIzquierda(int fil, int col, int jugador) 
        {
            var resultado = new List<(int, int)>();

            // ↙️ Diagonal inferior izquierda
            int f = fil + 1;
            int c = col - 1;
            while (Jugadas.Any(j => j.Fila == f && j.Columna == c && j.Jugador == jugador))
            {
                resultado.Add((f, c));
                f++;
                c--;
            }

            // ↗️ Diagonal superior derecha
            f = fil - 1;
            c = col + 1;
            while (Jugadas.Any(j => j.Fila == f && j.Columna == c && j.Jugador == jugador))
            {
                resultado.Insert(0, (f, c));
                f--;
                c++;
            }

            return resultado;
        }

        private void MarcarGanadoras(List<(int, int)> ganadoras)
        {
            //a Cada jugada marcar Ganadora
            foreach (var g in ganadoras)
            {
                Jugadas.Find(x => x.Fila == g.Item1 && x.Columna == g.Item2).Marcada = true;
            }
        }
    }
}
