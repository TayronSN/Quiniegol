namespace Quiniegol.Core.Models
{
    // Representa una insignia que un usuario puede obtener por sus logros.
    public class Insignia
    {
        public string Nombre { get; set; } = string.Empty;

        // Condición que debe cumplirse para obtener esta insignia.
        public string Descripcion { get; set; } = string.Empty;
    }
}
