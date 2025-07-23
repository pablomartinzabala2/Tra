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
           // fun.LlenarComboDatatable(cmbTipo, tr, "Nombre", "Codigo");
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
            int Vencida = 0;
            if (chkVencidas.Checked == true)
                Vencida = 1;
            Clases.cEfectivoaPagar obj = new Clases.cEfectivoaPagar();
            DataTable trdo = obj.GetEfectivosaPagarxFecha(FechaDesde, FechaHasta, txtPatente.Text.Trim(), Impagos, Nombre, Descripcion, Vencida);
            CalcularTotalFactrado(trdo);
            trdo = fun.TablaaMiles(trdo, "SaldoEfectivo");
            trdo = fun.TablaaMiles(trdo, "Efectivo");
            trdo = fun.TablaaMiles(trdo, "Facturado");
            trdo = fun.TablaaMiles(trdo, "SaldoFacturado");
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            string Col = "0;10;20;10;10;10;10;10;10;10";
            fun.AnchoColumnas(Grilla, Col);
            Grilla.Columns[2].HeaderText = "Proveedor";
            Grilla.Columns[1].HeaderText = "Venc.";
            //  Grilla.Columns[9].HeaderText = "Saldo Fac";


        }

        private void CalcularTotalFactrado(DataTable trdo)
        {
            cFunciones fun = new cFunciones();
            Double Efectivo = 0;
            Double Facturado = 0;
            Double TotalSaldo = 0;
            Double Total = 0;
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                if (trdo.Rows[i]["Efectivo"].ToString() != "")
                {
                    Total = Total + Convert.ToDouble(trdo.Rows[i]["Efectivo"]);
                }
                if (trdo.Rows[i]["SaldoEfectivo"].ToString ()!="0")
                {
                    Efectivo = Efectivo + Convert.ToDouble(trdo.Rows[i]["SaldoEfectivo"]);
                }

                if (trdo.Rows[i]["SaldoFacturado"].ToString().Trim () != "")
                {
                    Facturado = Facturado + Convert.ToDouble(trdo.Rows[i]["SaldoFacturado"]);
                }
            }

            TotalSaldo = Efectivo + Facturado;
            txtTotal.Text = fun.FormatoEnteroMiles(TotalSaldo.ToString());
            txtTotalFacturado.Text = fun.FormatoEnteroMiles(Facturado.ToString());
            txtEfectivo.Text = fun.FormatoEnteroMiles(Efectivo.ToString());
            Double TotalGeneral = fun.TotalizarColumna(trdo, "Total");
            txtTotalGeneral.Text = fun.FormatoEnteroMiles(TotalGeneral.ToString());

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.Rows.Count <1)
            {
                MessageBox.Show("La grilla no tiene elementos para imprimir");
                return;
            }

            cReporte reporte = new cReporte();
            reporte.Borrar();
            int Orden = 1;
            string Vencimiento = "", Apellido = "", Modelo = "";
            string Total = "", Efectivo = "", SaldoEfectivo = "";
            string Fecturado = "", SaldoFacturado = "";
            string ResumenTotal = "";
            ResumenTotal = "Total " + txtTotalGeneral.Text;
            ResumenTotal = ResumenTotal + " Saldo Efectivo "+ txtEfectivo.Text;
            ResumenTotal = ResumenTotal + " Facturado " + txtTotalFacturado.Text;
            ResumenTotal = ResumenTotal + " Saldo " + txtTotal.Text; 

            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Vencimiento = Grilla.Rows[i].Cells[1].Value.ToString();
                if (Vencimiento.Length >10)
                {
                    Vencimiento = Vencimiento.Substring(0, 10);
                }
                Apellido = Grilla.Rows[i].Cells[2].Value.ToString();
                Modelo = Grilla.Rows[i].Cells[4].Value.ToString();
                Total = Grilla.Rows[i].Cells[5].Value.ToString();
                Efectivo = Grilla.Rows[i].Cells[6].Value.ToString();
                SaldoEfectivo =  Grilla.Rows[i].Cells[7].Value.ToString();
                Fecturado = Grilla.Rows[i].Cells[8].Value.ToString();
                SaldoFacturado = Grilla.Rows[i].Cells[9].Value.ToString();
                reporte.Insertar(Orden, Vencimiento, Apellido, Modelo, Total,
                    Efectivo, SaldoEfectivo, Fecturado, SaldoFacturado, ResumenTotal, "", "", "", "", "");
                Orden++; 
            }
            FrmReporteEfectivoPagar frm = new FrmReporteEfectivoPagar();
            frm.Show();
        }
    }
}
