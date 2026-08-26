namespace Quiniegol.Models
{
    // Representa un empleado registrado en el sistema.
    internal class Usuario
    {
        public string IdEmpleado { get; set; } = string.Empty;

        public string Departamento { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        // 1 = Administrador, 2 = Usuario normal.
        public int IdRol { get; set; }
    }
}
