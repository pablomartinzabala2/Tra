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
            cVencimiento venc = new cVencimiento();
            DataTable trdo = venc.GetVencimiento();
            Grilla.DataSource = trdo;
        }
    }
}
