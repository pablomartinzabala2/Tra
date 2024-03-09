using Concesionaria.Clases;
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
    public partial class FrmListadoGastos : Form
    {
        public FrmListadoGastos()
        {
            InitializeComponent();
        }

        private void FrmListadoGastos_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            DateTime fechahoy = DateTime.Now;
           // txtFechaHasta.Text = fechahoy.ToShortDateString();
            dpFechaHasta.Value = fechahoy;
            fechahoy = fechahoy.AddMonths(-1);
            dpFechaDesde.Value = fechahoy;  
            //txtFechaDesde.Text = fechahoy.ToShortDateString(); 
            fun.LlenarCombo(cmbCategoria, "CategoriaGastoTransferencia", "Descripcion", "Codigo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            int Impagos = 0;
            if (chkImpagos.Checked == true)
                Impagos = 1;

            string Categoria = "";
            if (cmbCategoria.SelectedIndex > 0)
                Categoria = cmbCategoria.Text;
            //Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            DataTable trdo = gasto.GetGastosPagarxFecha(FechaDesde, FechaHasta, txtPatente.Text, Impagos, Nombre, Apellido, Categoria);
            Double TotalTransferencia = fun.TotalizarColumna(trdo, "Importe");
            Double TotalCosto = fun.TotalizarColumna(trdo, "importepagado");
            Double TotalGanancia = fun.TotalizarColumna(trdo, "Ganancia");
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "importepagado");
            trdo = fun.TablaaMiles(trdo, "Ganancia");
            txtTotal.Text = fun.FormatoEnteroMiles(TotalTransferencia.ToString());
            txtTotalCosto.Text = fun.FormatoEnteroMiles(TotalCosto.ToString());
            txtTotalGanancia.Text = fun.FormatoEnteroMiles(TotalGanancia.ToString());
            Grilla.DataSource = trdo;
            string  Col = "0;10;10;10;10;10;10;10;10;10;0;10";
            fun.AnchoColumnas(Grilla, Col);
            txtCantidad.Text = trdo.Rows.Count.ToString();
           
        }

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje()); 
                return;
            }

            Int32 CodGasto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString ());
            Principal.CodigoPrincipalAbm = CodGasto.ToString();
            FrmRegistrarPagoGastos frm = new FrmRegistrarPagoGastos();
            frm.ShowDialog();
        }
    }
}
