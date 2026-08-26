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
