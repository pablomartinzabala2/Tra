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
    public partial class FrmListadoPresupuesto : FormularioBase 
    {
        public FrmListadoPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmListadoPresupuesto_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
            Buscar();
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar ()
        {
            cFunciones fun = new cFunciones();
            cPresupuesto prep = new Clases.cPresupuesto();
            DataTable trdo = prep.GetPresupuestos();
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;15;15;15;15;15;15;10");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }
            Principal.CodPresupuesto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            FrmReportePresupuesto frm = new FrmReportePresupuesto();
            frm.Show();
        }
    }
}
