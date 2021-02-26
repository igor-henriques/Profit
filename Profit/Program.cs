using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsAdministrator)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\fix.exe"))
                    File.Delete(Directory.GetCurrentDirectory() + @"\fix.exe");

                Application.Run(new AuthenticationForm());
            }
            else
            {                                                                
                MessageBox.Show("Por favor, inicie o programa novamente em Modo Administrador.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static bool IsAdministrator => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}
