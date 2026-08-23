namespace Quiniegol.Core.Models
{
    public class Partido
    {
        public int IdPartido { get; set; }

        public int IdEquipoLocal { get; set; }

        public int IdEquipoVisitante { get; set; }

        public string Fase { get; set; }

        public string Estado { get; set; }

        public string Resultado { get; set; }
    }
}