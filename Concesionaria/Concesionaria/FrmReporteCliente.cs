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
    public partial class FrmReporteCliente : Form
    {
        public FrmReporteCliente()
        {
            InitializeComponent();
        }

        private void FrmReporteCliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsReportes.Reporte' table. You can move, or remove it, as needed.
            this.ReporteTableAdapter.Fill(this.DsReportes.Reporte);

            this.reportViewer1.RefreshReport();
        }
    }
}
