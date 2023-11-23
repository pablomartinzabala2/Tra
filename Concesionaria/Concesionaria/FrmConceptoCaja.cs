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
    public partial class FrmConceptoCaja : FormularioBase
    {
        public FrmConceptoCaja()
        {
            InitializeComponent();
        }

        private void FrmConceptoCaja_Load(object sender, EventArgs e)
        {
            txtConcepto.Text = Principal.ConceptoCaja;
        }
    }
}
