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
    public partial class FrmReporteResumenProveedor : Form
    {
        public FrmReporteResumenProveedor()
        {
            InitializeComponent();
        }

        private void FrmReporteResumenProveedor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsReportes.ReporteResumenCuenta' table. You can move, or remove it, as needed.
            this.ReporteResumenCuentaTableAdapter.Fill(this.DsReportes.ReporteResumenCuenta);

            this.reportViewer1.RefreshReport();
        }
    }
}
