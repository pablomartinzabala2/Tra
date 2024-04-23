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
    public partial class FrmReporteEfectivoPagar : Form
    {
        public FrmReporteEfectivoPagar()
        {
            InitializeComponent();
        }

        private void FrmReporteEfectivoPagar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsReportes.Reporte1' table. You can move, or remove it, as needed.
            this.reporte1TableAdapter.Fill(this.dsReportes.Reporte1);

            this.reportViewer1.RefreshReport();
        }
    }
}
