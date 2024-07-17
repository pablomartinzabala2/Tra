using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;
namespace Concesionaria
{
    public partial class FrmListadoDeudaCoibranzaxCliente : Form
    {
        public FrmListadoDeudaCoibranzaxCliente()
        {
            InitializeComponent();
        }

        private void FrmListadoDeudaCoibranzaxCliente_Load(object sender, EventArgs e)
        {
           if (Principal.CodCliente !=null)
            {
                Int32 CodCliente = Convert.ToInt32(Principal.CodCliente);
                BuscarDeuda(CodCliente);
            }
        }

        private void BuscarDeuda(Int32 CodCliente)
        {
            cFunciones fun = new cFunciones();
            cCobranzaGeneral cob = new cCobranzaGeneral();
            DataTable trdo = cob.GetDedudaCobranzaGeneralxCodCliente(CodCliente);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;0;10;22;23;10;10;10;10;5");
        }
    }
}
