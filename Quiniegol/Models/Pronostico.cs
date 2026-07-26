using System;
using System.Collections.Generic;
using System.Text;

namespace Quiniegol.Models
{
    internal class Pronostico
    {
        public int IdPronostico { get; set; }

        public string IdEmpleado { get; set; }

        public int IdPartido { get; set; }

        public string ResultadoPronosticado { get; set; }
    }
}
