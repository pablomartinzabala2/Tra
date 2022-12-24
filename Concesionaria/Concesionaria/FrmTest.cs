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
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = dateTimePicker1.Value;
            textBox1.Text = Fecha.ToShortDateString();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            DateTime Fecha = dateTimePicker1.Value;
            Fecha = Fecha.AddMonths(1);
            dateTimePicker1.Value = Fecha;

        }
    }
}
