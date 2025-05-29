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
            Buscar();
        }

        private void Buscar ()
        {
            cDistancia dis = new Clases.cDistancia();
            DataTable trdo = dis.GetDistancias();
            Grilla.DataSource = trdo;
            cFunciones fun = new cFunciones();
            fun.AnchoColumnas(Grilla, "0;0;40;0;40;20");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar ");
                return;
            }

            if (txtKm.Text =="")
            {
                MessageBox.Show("Debe ingresar un kilometros para continuar ");
                return;
            }

            int CodDistancia = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            int Km = Convert.ToInt32(txtKm.Text);
            cDistancia Dis = new cDistancia();
            Dis.Modificar(CodDistancia, Km);
            MessageBox.Show("Datos actualizados correctamente ");
            Buscar();
        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            
            string msj = "Confirma eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar ");
                return;
            }



            cDistancia Dis = new cDistancia();
            int CodDistancia = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
           
            try
            {
                Dis.Eliminar(CodDistancia);
                MessageBox.Show("Datos borrados correctamente ");
                Buscar();
            }
            catch (Exception)
            {
                MessageBox.Show("El reigstro no se puede borrar, asegure que no tiene viajes asociados ");
            }
        }
    }
}
