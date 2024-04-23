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
    public partial class FrmReportedeEfectivoaPagar : Form
    {
        public FrmReportedeEfectivoaPagar()
        {
            InitializeComponent();
        }

        private void FrmReportedeEfectivoaPagar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsReportes.Reporte1' table. You can move, or remove it, as needed.
            this.Reporte1TableAdapter.Fill(this.DsReportes.Reporte1);

            this.reportViewer1.RefreshReport();
        }
    }
}
