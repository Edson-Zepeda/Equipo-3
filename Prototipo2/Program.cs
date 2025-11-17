using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Prototipo2.Logging;

namespace Prototipo2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Init simple logging
            try
            {
                if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
                SimpleLogger.Info("Aplicación iniciando");
            }
            catch
            {
                // No detener si logging falla
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            VentanaInicio loginForm = new VentanaInicio();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                bool esAdmin = loginForm.EsAdmin;
                int usuarioID = loginForm.UsuarioID;

                Application.Run(new VentanaMenu(esAdmin, usuarioID));
            }
            else
            {

                Application.Exit();
            }
        }
    }
}
