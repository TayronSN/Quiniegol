namespace Quiniegol.Core.Models
{
    public class Partido
    {
        // Identificador único del partido
        public int IdPartido { get; set; }

        // Identificador del equipo que juega como local
        public int IdEquipoLocal { get; set; }

        // Identificador del equipo que juega como visitante
        public int IdEquipoVisitante { get; set; }

        // Fase del torneo a la que pertenece el partido
        public string Fase { get; set; }

        // Estado actual del partido: abierto o cerrado
        public string Estado { get; set; }

        // Resultado final del partido: local, empate o visitante
        public string Resultado { get; set; }
    }
}