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
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            GrillaDeuda.DataSource = trdo;
            GrillaDeuda.Columns[1].Visible = false;
            GrillaDeuda.Columns[2].Visible = false;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            string Codigo = "";
            foreach (DataGridViewRow r in GrillaDeuda.Rows)
            {
                if (Convert.ToBoolean (r.Cells["Cobrar"].Value)==true)
                {
                    Codigo = r.Cells[1].Value.ToString(); 
                }
            }
        }
    }
}
