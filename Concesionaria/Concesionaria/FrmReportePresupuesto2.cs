using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concesionaria
{
    public partial class FrmReportePresupuesto2 : Form
    {
        public FrmReportePresupuesto2()
        {
            InitializeComponent();
        }

        private void FrmReportePresupuesto2_Load(object sender, EventArgs e)
        {
             Int32 CodPresupuesto = Convert.ToInt32(Principal.CodPresupuesto);
           // Int32 CodPresupuesto = 9;
            // TODO: This line of code loads data into the 'DsReportes.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DsReportes.DataTable1, CodPresupuesto);

            this.reportViewer1.RefreshReport();
        }
    }
}
