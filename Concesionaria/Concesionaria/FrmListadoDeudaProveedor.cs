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
    public partial class FrmListadoDeudaProveedor : FormularioBase
    {
        public FrmListadoDeudaProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearDeudaProveedor fr = new FrmCrearDeudaProveedor();
            fr.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Proveedor = "";
            if (txtProveedor.Text != "")
                Proveedor = txtProveedor.Text;

            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            Buscar(FechaDesde, FechaHasta, Proveedor);
        }

        private void Buscar(DateTime FechaDesde,DateTime FechaHasta, string Proveedor)
        {
            cFunciones fun = new cFunciones();
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            Double Total = 0, Saldo = 0;
            DataTable trdo = Deuda.GetDeuda(FechaDesde, FechaHasta, Proveedor);
            Total = fun.TotalizarColumna(trdo, "Importe");
            Saldo = fun.TotalizarColumna(trdo, "Saldo");
            txtTotalDeuda.Text = fun.FormatoEnteroMiles(Total.ToString());
            txtTotalSaldo.Text = fun.FormatoEnteroMiles(Saldo.ToString());
            trdo = fun.TablaaFechas(trdo, "Importe");
            trdo = fun.TablaaFechas(trdo, "Saldo");
            Grilla.DataSource = trdo;
            //select d.CodDeuda,p.Nombre as Proveedor,c.Nombre as Cuenta,d.Concepto,d.Importe,d.Saldo,d.CodPago,d.CodDeudaProveedor
            fun.AnchoColumnas(Grilla, "0;20;20;30;15;15;0;0");
        }

        private void FrmListadoDeudaProveedor_Load(object sender, EventArgs e)
        {
            InicializarFechas();
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            Buscar(FechaDesde, FechaHasta,"");
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

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarDeuda_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow==null)
            {
                Msj("Debe seleccionar un registro");
                return;
            }

            string msj = "Confirma Eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            string sCodPago = Grilla.CurrentRow.Cells[6].Value.ToString().Trim();
            if (sCodPago !="")
            {
                Msj("Debe anular el pago para poder borrarlo ");
                return;
            }
            else
            {  
                cMovimientoProveedor mov = new cMovimientoProveedor();
                Int32 CodDeuda = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
                Int32 CodCuentaProveedor = Convert.ToInt32(Grilla.CurrentRow.Cells[7].Value.ToString());
                cDeudaProveedor Deuda = new cDeudaProveedor();
                Deuda.Borrrar(CodDeuda);
                cCosto Costo = new cCosto();
                Costo.BorrarCostoxCodDeuda(CodDeuda);
                cCuentaProveedor Cuenta = new cCuentaProveedor();
                Double Saldo = Cuenta.GetSaldo(CodCuentaProveedor);
                //Actualizo el saldo de la cuenta
                Cuenta.ActuaizarSaldo(CodCuentaProveedor, Saldo);
                //Actualizo el saldo del proveedor
                
                //EN PROVEEDOR Y CUENTA PROVEEDOR
                mov.BorrarMovimientoxCodDeuda(CodDeuda);
                DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
                DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
                string Proveedor = "";
                if (txtProveedor.Text != "")
                    Proveedor = txtProveedor.Text;
                Buscar(FechaDesde, FechaHasta, Proveedor);
                Msj("Datos grabados correctamente ");
            }
            
        }

        private void btnAbrirDeuda_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Msj("Debe seleccionar un registro");
                return;
            }
            Int32 CodDeuda = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Principal.Codigo = CodDeuda;
            FrmCrearDeudaProveedor frm = new FrmCrearDeudaProveedor();
            frm.ShowDialog();
            Principal.Codigo = null;

        }
    }
}
