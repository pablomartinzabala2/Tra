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
    public partial class FrmConsultaDistancia : FrmBase
    {
        public FrmConsultaDistancia()
        {
            InitializeComponent();
        }

        private void FrmConsultaDistancia_Load(object sender, EventArgs e)
        {
            cDistancia dis = new Clases.cDistancia();
            DataTable trdo = dis.GetDistancias();
            Grilla.DataSource = trdo;
            cFunciones fun = new cFunciones();
            fun.AnchoColumnas(Grilla, "0;40;0;40;20");
        }
    }
}
