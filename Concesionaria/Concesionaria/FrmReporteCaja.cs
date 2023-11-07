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
    public partial class FrmReporteCaja : Form
    {
        public FrmReporteCaja()
        {
            InitializeComponent();
        }

        private void FrmReporteCaja_Load(object sender, EventArgs e)
        {
            
            string Fecha = Principal.Fecha.ToShortDateString();
            // TODO: This line of code loads data into the 'DsReportes.DtMovimientoCaja' table. You can move, or remove it, as needed.
            this.DtMovimientoCajaTableAdapter.Fill(this.DsReportes.DtMovimientoCaja, Fecha);

            this.reportViewer1.RefreshReport();
        }
    }
}
