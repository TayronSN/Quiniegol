namespace Quiniegol.Core.Models
{
    public class Usuario
    {
        // Identificador del empleado dentro del sistema
        public string IdEmpleado { get; set; }

        // Departamento al que pertenece el empleado
        public string Departamento { get; set; }

        // Nombre del empleado
        public string Nombre { get; set; }

        // Apellido del empleado
        public string Apellido { get; set; }

        // Correo electrónico utilizado por el empleado
        public string Correo { get; set; }

        // Contraseña utilizada para iniciar sesión
        public string Password { get; set; }

        // Identificador del rol del usuario
        // 1 = Administrador, 2 = Usuario
        public int IdRol { get; set; }
    }
}