namespace Quiniegol.Core.Models
{
    // Agrupa las estadísticas de un usuario para mostrar en reportes y rankings.
    public class UsuarioEstadistica
    {
        public string IdEmpleado { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public int Pronosticos { get; set; }

        public int Aciertos { get; set; }
    }
}
