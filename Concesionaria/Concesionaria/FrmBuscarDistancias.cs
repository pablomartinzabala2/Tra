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
    public partial class FrmBuscarDistancias : FrmBase
    {
        public FrmBuscarDistancias()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            cDistancia dis = new Clases.cDistancia();
            DataTable trdo = dis.GetDistancias();
            Grilla.DataSource = trdo;
            cFunciones fun = new cFunciones();
            fun.AnchoColumnas(Grilla, "0;0;40;0;40;20");
        }

        private void FrmBuscarDistancias_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro para contiinuar ");
                return;
            }

            Int32 CodDistancia = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.Codigo = CodDistancia;
            this.Close();
        }
    }
}
