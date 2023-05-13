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
    public partial class FrmBoletoTraut : Form
    {
        public FrmBoletoTraut()
        {
            InitializeComponent();
        }

        private void FrmBoletoTraut_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsReportes.Cliente' table. You can move, or remove it, as needed.
            Int32 CodVenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            this.ClienteTableAdapter.Fill(this.DsReportes.Cliente,CodVenta);
           
            this.reportViewer1.RefreshReport();
        }
    }
}
