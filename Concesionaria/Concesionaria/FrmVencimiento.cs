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
    public partial class FrmVencimiento : Form
    {
        public FrmVencimiento()
        {
            InitializeComponent();
        }

        private void FrmVencimiento_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            cVencimiento venc = new cVencimiento();
            DataTable trdo = venc.GetVencimiento();
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;15;15;15;15;15;25");
        }
    }
}
