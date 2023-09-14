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
    public partial class FrmListadoEfectivosaPagar : Form
    {
        public FrmListadoEfectivosaPagar()
        {
            InitializeComponent();
        }

        private void FrmListadoEfectivosaPagar_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            DateTime fecha = DateTime.Now;
            DateTime fecha1 = fecha.AddMonths(-1);
            dpFechaDesde.Value = fecha1;
            dpFechaHasta.Value = fecha;
            DataTable tr = fun.CrearTabla("Codigo;Nombre");
            tr = fun.AgregarFilas(tr, "1;Efectivo");
            tr = fun.AgregarFilas(tr, "2;Facturado");
            fun.LlenarComboDatatable(cmbTipo, tr, "Nombre", "Codigo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
           
            if (dpFechaDesde.Value > dpFechaHasta.Value)
            {
                MessageBox.Show("La fecha desde debe ser inferior a la fecha hasta", Clases.cMensaje.Mensaje());
                return;
            }

            int Impagos = 0;
            if (chkImpagos.Checked == true)
                Impagos = 1;

            Int32? CodTipo = null;
            if (cmbTipo.SelectedIndex > 0)
                CodTipo = Convert.ToInt32(cmbTipo.SelectedValue);

            Clases.cPrenda prenda = new Clases.cPrenda();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string Descripcion = "";
            string Nombre = "";
            if (txtProveedor.Text != "")
                Nombre = txtProveedor.Text;

            if (txtDescripcion.Text !="")
            {
                Descripcion = txtDescripcion.Text;
            }

            Clases.cEfectivoaPagar obj = new Clases.cEfectivoaPagar();
            DataTable trdo = obj.GetEfectivosaPagarxFecha(FechaDesde, FechaHasta, txtPatente.Text.Trim(), Impagos, Nombre, CodTipo, Descripcion);
            CalcularTotalFactrado(trdo);
            trdo = fun.TablaaMiles(trdo, "Saldo");
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Facturado");
            Grilla.DataSource = trdo;
            string Col = "0;10;10;10;10;10;20;20;10;0";
           // fun.AnchoColumnas(Grilla, Col);
           
            txtTotal.Text = fun.TotalizarColumna(trdo, "Saldo").ToString();
            if (txtTotal.Text != "")
                txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);

        }

        private void CalcularTotalFactrado(DataTable trdo)
        {
            cFunciones fun = new cFunciones();
            Double Efectivo = 0;
            Double Facturado = 0;
            Double Total = 0;
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                if (trdo.Rows[i]["Importe"].ToString ()!="0")
                {
                    Efectivo = Efectivo + Convert.ToDouble(trdo.Rows[i]["Importe"]);
                }

                if (trdo.Rows[i]["Facturado"].ToString().Trim () != "")
                {
                    Facturado = Facturado + Convert.ToDouble(trdo.Rows[i]["Facturado"]);
                }
            }

            Total = Efectivo + Facturado;
            txtTotalFacturado.Text = fun.FormatoEnteroMiles(Facturado.ToString());
            txtEfectivo.Text = fun.FormatoEnteroMiles(Efectivo.ToString());
          //  Double TotalGeneral = fun.TotalizarColumna(trdo, "Total");
         //   txtTotalGeneral.Text = fun.FormatoEnteroMiles(TotalGeneral.ToString());

        }

        private void btnCobroPrenda_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje());
                return;
            }
            string CodRegistro = Grilla.CurrentRow.Cells[0].Value.ToString();
            Principal.CodigoPrincipalAbm = CodRegistro;
            FrmRegistarEfectivosaPagar form = new FrmRegistarEfectivosaPagar();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
