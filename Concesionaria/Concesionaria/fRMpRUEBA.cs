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
    public partial class fRMpRUEBA : Form
    {
        public fRMpRUEBA()
        {
            InitializeComponent();
        }

        private void fRMpRUEBA_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            // cCiudad city = new Clases.cCiudad();
            // city.Insertar(Nombre);

            cBarrio  bar = new cBarrio();
          int id =bar.Insertar(Nombre, 1);
        }
    }
}
