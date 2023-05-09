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
    public partial class FrmResumenCuentaProveedor : FormularioBase
    {
        public FrmResumenCuentaProveedor()
        {
            InitializeComponent();
            InicializarFechas();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            if (Principal.CodigoPrincipalAbm != null)
            {
                Int32 CodCuenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                txtCodCuenta.Text = CodCuenta.ToString();
                cCuentaProveedor Cuenta = new Clases.cCuentaProveedor();
                DataTable trdo = Cuenta.GetDetalleCuentas(CodCuenta);
                if (trdo.Rows.Count > 0)
                {
                    txtProveedor.Text = trdo.Rows[0]["Proveedor"].ToString();
                    txtCuentaProveedor.Text = trdo.Rows[0]["Nombre"].ToString();
                    Cargar(CodCuenta);
                }
               
            }
        }

        private void InicializarFechas()
        {  
            DateTime Fecha = DateTime.Now;
            dpFechaHasta.Value = Fecha;
            Fecha = Fecha.AddYears(-1);
            dpFechaDesde.Value = Fecha;
            /*
            int dia = Fecha.Day;
            int Mes = Fecha.Month;
            Fecha = Fecha.AddDays(-dia);
            Fecha = Fecha.AddDays(1);
            dpFechaDesde.Value = Fecha;
            Fecha = Fecha.AddMonths(1);
            Fecha = Fecha.AddDays(-1);
            dpFechaHasta.Value = Fecha;
            */
        }

        private void FrmResumenCuentaProveedor_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Cargar(Int32 CodCuentaProveedor)
        {
            cFunciones fun = new Clases.cFunciones();
            cMovimientoProveedor mov = new Clases.cMovimientoProveedor();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            DataTable trdo = mov.GetResumen(CodCuentaProveedor, FechaDesde, FechaHasta);
                
            Double Debe = 0;
            Double Haber = 0;
            Debe = fun.TotalizarColumna(trdo, "Debe");
            Haber = fun.TotalizarColumna(trdo, "Haber");
            Double Saldo = Haber - Debe;
            txtSaldo.Text = Saldo.ToString();
            txtSaldo.Text = fun.FormatoEnteroMiles(txtSaldo.Text);
            trdo = fun.TablaaMiles(trdo, "Debe");
            trdo = fun.TablaaMiles(trdo, "Haber");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;15;45;20;20;0;0;0");
            Grilla.Columns[2].HeaderText = "Concepto";
            Grilla.Columns[3].HeaderText = "Debe";
            Grilla.Columns[4].HeaderText = "Haber";
        }

        private void btnAbrirDeuda_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Msj("Debe seleccionar un elemento ");
                return;
            }
            string CodDeuda = Grilla.CurrentRow.Cells[6].Value.ToString();
            string CodPago = Grilla.CurrentRow.Cells[7].Value.ToString();

            if (CodDeuda !="")
            {
                Principal.Codigo = Convert.ToInt32(CodDeuda);
                FrmCrearDeudaProveedor frm = new FrmCrearDeudaProveedor();
                frm.ShowDialog();
                Principal.Codigo = null;
            }

            if (CodPago !="")
            {
                Principal.Codigo = Convert.ToInt32(CodPago);
                FrmPagoCuentaProveedor frm = new FrmPagoCuentaProveedor();
                frm.ShowDialog();
                Principal.Codigo = null;

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            cReporte Reporte = new cReporte();
            Reporte.Borrar();
            int Orden = 1;
            string Proveedor = txtProveedor.Text;
            string Cuenta = txtCuentaProveedor.Text;
            string FechaDesde = dpFechaDesde.Value.ToShortDateString();
            string FechaHasta = dpFechaHasta.Value.ToShortDateString();
            string Fecha = "";
            string Concepto = "";
            string Debe = "";
            string Haber = "";
            for (int i =0;i < Grilla.Rows.Count -1;i++)
            {
                Fecha = Grilla.Rows[i].Cells[1].Value.ToString();
                Fecha = Fecha.Substring(0, 10);
                Concepto = Grilla.Rows[i].Cells[2].Value.ToString();
                Debe = Grilla.Rows[i].Cells[3].Value.ToString();
                Haber = Grilla.Rows[i].Cells[4].Value.ToString();
                Reporte.Insertar(Orden, Proveedor, Cuenta, FechaDesde, FechaHasta,
                    Fecha, Concepto, Debe, Haber);
                Orden = Orden + 1;
            }
            string Saldo = txtSaldo.Text;
            Orden++;
            Reporte.Insertar(Orden, "", "", "", "", "", "", "", "");
            Orden++;
            Reporte.Insertar(Orden, "", "", "", "", "", "Saldo", Saldo, "");
            FrmReporteResumenProveedor frm = new FrmReporteResumenProveedor();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
