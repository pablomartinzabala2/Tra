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
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();
        }

        private void FormularioBase_Load(object sender, EventArgs e)
        {

        }

        public void Msj(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema");
        }
    }
}
