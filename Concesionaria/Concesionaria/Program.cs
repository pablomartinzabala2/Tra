using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Concesionaria
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
             Application.Run(new FrmLogin());
            //     Principal.CodigoPrincipalAbm = "432";
            //     Application.Run(new FrmBoletoTraut());

            //   Application.Run(new FrmReporteControlOperaciones  ());
            //   Application.Run(new FrmListadoCliente());
        }
    }
}
