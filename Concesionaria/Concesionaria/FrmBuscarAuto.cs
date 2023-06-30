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
    public partial class FrmBuscarAuto : Form
    {
        cFunciones fun;
        public FrmBuscarAuto()
        {
            InitializeComponent();
        }

        private void FrmBuscarAuto_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
            Buscar();
        }
        private void Buscar()
        {
            string Patente = "";
            Int32? CodMarca = null;
            string Descripcion = "";
            if (cmbMarca.SelectedIndex > 0)
            {
                CodMarca = Convert.ToInt32(cmbMarca.SelectedValue);
            }

            if (txtPatente.Text !="")
            {
                Patente = txtPatente.Text; 
            }

            if (txtDescripcion.Text !="")
            {
                Descripcion = txtDescripcion.Text;
            }

            DataTable trdo;
            cAuto auto = new cAuto();
            cStockAuto stock = new cStockAuto();
            if (chkStock.Checked == true)
                trdo = stock.GetStockResumidoVigente(Patente, CodMarca, Descripcion);
            else
                trdo = auto.GetAutoResumido(Patente, CodMarca, Descripcion);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;20;40;20;10;10");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un regisstro", "Sistema");
                return;
            }
            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString();
            Principal.CodStock = Convert.ToInt32(Grilla.CurrentRow.Cells[5].Value.ToString());
            this.Close();
        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }
    }
}
