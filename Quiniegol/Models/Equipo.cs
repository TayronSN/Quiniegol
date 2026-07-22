using System;

namespace Quiniegol.Models
{
    internal class Equipo
    {
        public int IdEquipo { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Grupo { get; set; } = string.Empty;

        public string Bandera { get; set; } = string.Empty;
    }
}