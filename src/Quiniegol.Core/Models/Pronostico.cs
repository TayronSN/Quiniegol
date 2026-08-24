namespace Quiniegol.Core.Models
{
    public class Pronostico
    {
        // Identificador único del pronóstico
        public int IdPronostico { get; set; }

        // ID del empleado que realizó el pronóstico
        public string IdEmpleado { get; set; }

        // ID del partido sobre el cual se realiza el pronóstico
        public int IdPartido { get; set; }

        // Resultado que el empleado considera que ocurrirá en el partido
        public string ResultadoPronosticado { get; set; }
    }
}