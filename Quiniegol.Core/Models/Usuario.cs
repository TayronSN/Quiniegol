namespace Quiniegol.Core.Models
{
    public class Usuario
    {
        public string IdEmpleado { get; set; }
        public string Departamento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}