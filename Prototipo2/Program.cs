using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo2
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
