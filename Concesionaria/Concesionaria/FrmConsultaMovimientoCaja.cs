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
    public partial class FrmConsultaMovimientoCaja : Form
    {
        cFunciones fun;
        public FrmConsultaMovimientoCaja()
        {
            InitializeComponent();
        }

        private void FrmConsultaMovimientoCaja_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            InicializarFecha();
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            CargarGrilla(FechaDesde, FechaHasta);

        }

        private void InicializarFecha()
        {
            DateTime Hoy = DateTime.Now;
            dpFechaHasta.Value = Hoy;
            dpFechaDesde.Value = Hoy;

        }

        private void CargarGrilla(DateTime FechaDesde,DateTime FechaHasta)
        {
            Double Ingreso = 0, Egreso = 0, Saldo = 0;
            cMovimientoCaja mov = new cMovimientoCaja();
            string Proveedor = "";
            if (txtProveedor.Text != "")
                Proveedor = txtProveedor.Text;
            string Cuenta = "";
            if (txtCuenta.Text != "")
                Cuenta = txtCuenta.Text;
            string Concepto = "";
            if (txtConcepto.Text != "")
                Concepto = txtConcepto.Text;

            DataTable trdo = mov.GetMovimientoxFecha(FechaDesde, FechaHasta,Proveedor,Cuenta,Concepto);
            Ingreso = fun.TotalizarColumna(trdo, "ImporteIngreso");
            Egreso = fun.TotalizarColumna(trdo, "ImporteEgreso");
            Saldo = Ingreso - Egreso;
            trdo = fun.TablaaMiles(trdo, "ImporteIngreso");
            trdo = fun.TablaaMiles(trdo, "ImporteEgreso");
            Grilla.DataSource = trdo;
            Grilla.Columns[6].HeaderText = "Ingreso";
            Grilla.Columns[7].HeaderText = "Egreso";
            fun.AnchoColumnas(Grilla, "0;15;20;15;15;15;10;10");
            txtIngresos.Text = fun.FormatoEnteroMiles(Ingreso.ToString());
            txtEgresos.Text = fun.FormatoEnteroMiles(Egreso.ToString());
            txtSaldo.Text = fun.FormatoEnteroMiles(Saldo.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            CargarGrilla(FechaDesde, FechaHasta);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtIngresos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEgresos_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {   
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }

            string msj = "Confirma eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            cCosto costo = new cCosto();
            cMovimientoCaja mov = new cMovimientoCaja();
            Int32 CodMovimiento = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            mov.Borrar(CodMovimiento);
            costo.BorrarCostoxCodMovimientoCaja(CodMovimiento);
            MessageBox.Show("Datos actualizados correctamente");
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            CargarGrilla(FechaDesde, FechaHasta);

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elelemtno ");
                return;
            }
            Principal.ConceptoCaja = Grilla.CurrentRow.Cells[2].Value.ToString();
            FrmConceptoCaja frm = new FrmConceptoCaja();
            frm.ShowDialog(); 
        }
    }
}
