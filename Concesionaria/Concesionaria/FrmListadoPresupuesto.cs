using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;
using System.Data.SqlClient;
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
            InicializarFechas();
            Buscar();
        }

        private void InicializarFechas()
        {
            DateTime Fecha = DateTime.Now;
            int dia = Fecha.Day;
            int Mes = Fecha.Month;
            Fecha = Fecha.AddDays(-dia);
            Fecha = Fecha.AddDays(1);
            dpFechaDesde.Value = Fecha;
            Fecha = Fecha.AddMonths(1);
            Fecha = Fecha.AddDays(-1);
            dpFechaHasta.Value = Fecha;
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar ()
        {
            string Nombre = "";
            string Apellido = "";
            if (txtNombre.Text != "")
                Nombre = txtNombre.Text;
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;

            cFunciones fun = new cFunciones();
            cPresupuesto prep = new Clases.cPresupuesto();
            DataTable trdo = prep.GetPresupuestos(dpFechaDesde.Value, dpFechaHasta.Value, Nombre, Apellido);
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
            Principal.CodPresupuesto = null;
        }

        private void btnAbrirCompra_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Sistema");
                return;
            }
            Int32? CodPresupuesto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodPresupuesto = CodPresupuesto;
            FrmVenta frm = new FrmVenta();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }

            string msj = "Confirma Borrar el presupuesto ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            Int32 CodPresupuesto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cPresupuesto pre = new cPresupuesto();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();

            pre.Borrar(CodPresupuesto);
            Buscar();
        }
    }
}
