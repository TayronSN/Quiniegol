using Quiniegol.Core.Models;

namespace Quiniegol.Core.Utils
{
    // Servicio de sesión con ciclo de vida Scoped.
    // En Blazor Server cada conexión de usuario recibe su propia instancia,
    // por lo que dos usuarios conectados al mismo tiempo no comparten la sesión.
    public class SesionService
    {
        // Guarda el usuario que actualmente tiene la sesión iniciada
        public Usuario? UsuarioActual { get; private set; }

        // Indica si existe un usuario con una sesión iniciada
        public bool InicioSesion => UsuarioActual != null;

        // Indica si el usuario actual tiene el rol de administrador
        public bool EsAdmin => UsuarioActual != null && UsuarioActual.IdRol == 1;

        // Indica si el usuario actual tiene el rol de usuario normal
        public bool EsUser => UsuarioActual != null && UsuarioActual.IdRol == 2;

        // Evento que se acciona cuando cambia el estado de la sesión.
        // NavMenu se suscribe a este evento para actualizarse automáticamente.
        public event Action? OnCambio;

        // Guarda el usuario recibido como el usuario de la sesión actual
        public void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
            NotificarCambio();
        }

        // Elimina el usuario actual y cierra la sesión
        public void Cerrar()
        {
            UsuarioActual = null;
            NotificarCambio();
        }

        // Notifica a todos los componentes suscritos que la sesión cambió
        public void NotificarCambio() => OnCambio?.Invoke();
    }
}
