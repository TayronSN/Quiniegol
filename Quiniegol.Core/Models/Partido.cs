namespace Quiniegol.Core.Models
{
    // Representa un partido del torneo.
    public class Partido
    {
        public int IdPartido { get; set; }

        public int IdEquipoLocal { get; set; }

        public int IdEquipoVisitante { get; set; }

        public string Fase { get; set; } = string.Empty;

        // "Abierto" mientras acepta pronósticos, "Cerrado" cuando ya tiene resultado.
        public string Estado { get; set; } = string.Empty;

        // Local, Empate o Visitante. Null mientras el partido no haya terminado.
        public string? Resultado { get; set; }
    }
}
