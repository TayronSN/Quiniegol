namespace Quiniegol.Core.Models
{
    // Representa el pronóstico que un empleado hace sobre el resultado de un partido.
    public class Pronostico
    {
        public int IdPronostico { get; set; }

        public string IdEmpleado { get; set; } = string.Empty;

        public int IdPartido { get; set; }

        // Local, Empate o Visitante.
        public string ResultadoPronosticado { get; set; } = string.Empty;
    }
}
