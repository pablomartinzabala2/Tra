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
    public partial class FrmReporteResponsabilidadCivil : Form
    {
        public FrmReporteResponsabilidadCivil()
        {
            InitializeComponent();
        }

        private void FrmReporteResponsabilidadCivil_Load(object sender, EventArgs e)
        {
            Int32 CodStock = 373;
            this.AutoTableAdapter.Fill(this.DsReportes.Auto, CodStock);

            this.reportViewer1.RefreshReport();
        }
    }
}
