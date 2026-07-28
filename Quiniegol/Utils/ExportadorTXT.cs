using System;
using System.Collections.Generic;
using System.Text;

namespace Quiniegol.Utils
{
    internal class ExportadorTXT
    {

        public static void Exportar(string ruta, List<string> lineas)
        {
            File.WriteAllLines(ruta, lineas);
        }

    }
}
