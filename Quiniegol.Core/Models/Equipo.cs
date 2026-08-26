namespace Quiniegol.Core.Models
{
    // Representa un equipo participante del torneo.
    public class Equipo
    {
        public int IdEquipo { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Grupo { get; set; } = string.Empty;

        // Ruta relativa de la imagen de la bandera del equipo.
        public string Bandera { get; set; } = string.Empty;
    }
}
