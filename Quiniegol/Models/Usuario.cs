using Quiniegol.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Quiniegol.Models
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