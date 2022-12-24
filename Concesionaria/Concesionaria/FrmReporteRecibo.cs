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
    public partial class FrmReporteRecibo : FormularioBase
    {
        public FrmReporteRecibo()
        {
            InitializeComponent();
        }

        private void FrmReporteRecibo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsReportes.DataTable2' table. You can move, or remove it, as needed.
           
            Int32 CodRecibo = Convert.ToInt32(Principal.CodRecibo);
            this.DataTable2TableAdapter.Fill(this.DsReportes.DataTable2, CodRecibo);

            this.reportViewer1.RefreshReport();
        }
    }
}
