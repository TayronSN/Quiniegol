namespace Quiniegol.Core.Models
{
    public class Equipo
    {
        // Identificador único del equipo
        public int IdEquipo { get; set; }

        // Nombre del equipo
        public string Nombre { get; set; } = string.Empty;

        // Grupo al que pertenece el equipo
        public string Grupo { get; set; } = string.Empty;

        // Ruta de la imagen de la bandera del equipo
        public string Bandera { get; set; } = string.Empty;
    }
}