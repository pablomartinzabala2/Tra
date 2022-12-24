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
    public partial class FrmListadoCompra : Form
    {
        public FrmListadoCompra()
        {
            InitializeComponent();
        }

        private void FrmListadoCompra_Load(object sender, EventArgs e)
        {
            InicializarFechas();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Patente = txtPatente.Text.Trim();
            cCompra compra = new cCompra();
            DataTable trdo = compra.getComprasxFecha(FechaDesde, FechaHasta, Patente);
            Grilla.DataSource = trdo;
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Patente = txtPatente.Text.Trim();
            cCompra compra = new cCompra();
            DataTable trdo = compra.getComprasxFecha(FechaDesde, FechaHasta, Patente);
            trdo = fun.TablaaMiles(trdo, "ImporteCompra");
            trdo = fun.TablaaMiles(trdo, "ImporteEfectivo");
            Grilla.DataSource = trdo;
            string Col = "0;20;20;20;20;20";
            fun.AnchoColumnas(Grilla, Col);
            /*
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].Width = 150;
            Grilla.Columns[3].Width = 150;
            Grilla.Columns[5].Width = 250;
            */
            Grilla.Columns[5].HeaderText = "Importe Compra";
        }



        private void btnAbrirCompra_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodCompra = Grilla.CurrentRow.Cells[0].Value.ToString();
            Principal.CodCompra = CodCompra;
            FrmAutos frm = new Concesionaria.FrmAutos();
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar ");
                return;
            }
            string msj = "Confirma eliminar la compra ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            cFunciones fun = new cFunciones();
            cCompra compra = new cCompra();
            Int32 CodCompra = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Double Efectivo = fun.ToDouble(Grilla.CurrentRow.Cells[6].Value.ToString ());
            Int32 CodStock = Convert.ToInt32(Grilla.CurrentRow.Cells[7].Value.ToString());
            compra.BorrarCompra(CodCompra, Efectivo, CodStock);
            MessageBox.Show("Datos grabados correctamente ");
            Buscar();
        }
    }
}
