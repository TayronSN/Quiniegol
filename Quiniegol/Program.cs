using Quiniegol.Data;
using Quiniegol.Forms;

namespace Quiniegol
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            EquiposData.InicializarEquipos();
            Application.Run(new FrmLogin());
        }
    }
}
