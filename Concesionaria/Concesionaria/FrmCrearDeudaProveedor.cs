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
    public partial class FrmCrearDeudaProveedor : FormularioBase
    {
        public FrmCrearDeudaProveedor()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscadorCuentaProveedor frm = new FrmBuscadorCuentaProveedor();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodigoPrincipalAbm!=null)
            {
                Int32 CodCuenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                txtCodCuenta.Text = CodCuenta.ToString();
                cCuentaProveedor Cuenta = new Clases.cCuentaProveedor();
                DataTable trdo = Cuenta.GetDetalleCuentas(CodCuenta);
                if (trdo.Rows.Count >0)
                {
                    txtProveedor.Text = trdo.Rows[0]["Proveedor"].ToString();
                    txtCuentaProveedor.Text = trdo.Rows[0]["Nombre"].ToString();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {  
           if (txtCodCuenta.Text =="")
           {
                MessageBox.Show("Debe ingresar un proveedor ");
                return;
           }
           
           if (txtImporte.Text =="")
           {
                MessageBox.Show("Debe ingresar un importe ");
                return;
           } 

           if (txtConcepto.Text =="")
            {
                MessageBox.Show("Debe ingresar un concepto ");
                return;
            }
            Int32 CodDeuda = 0;
            cCuentaProveedor cuentaProv = new cCuentaProveedor();
            Double Saldo = 0;
            cMovimientoProveedor mov = new cMovimientoProveedor();
            cDeudaProveedor Deuda = new cDeudaProveedor();
            Int32 CodCuentaProveedor= Convert.ToInt32 (txtCodCuenta.Text);
            Saldo = mov.GetSaldo(CodCuentaProveedor);
            string COncepto = txtConcepto.Text;
            DateTime Fecha = Convert.ToDateTime(dpFecha.Value);
            DateTime FechaVto = Convert.ToDateTime(dpFechaVencimiento.Value);
            Double Importe = 0;
            string Observacion = txtDescripcion.Text;
            cFunciones fun = new cFunciones();
            Importe = fun.ToDouble(txtImporte.Text);
            CodDeuda = Deuda.Insertar(CodCuentaProveedor,COncepto,
             Fecha,  FechaVto,  Importe,  Observacion);
            Saldo = Saldo - Importe;
            mov.Insertar(CodCuentaProveedor, Fecha, COncepto, Importe, 0, Saldo, CodDeuda, 0);

           
            cuentaProv.ActuaizarSaldo(CodCuentaProveedor, Saldo);
            MessageBox.Show("Datos Grabados Correctamente");
            Limpiar();
        }

        private void Limpiar()
        {
            txtConcepto.Text = "";
            txtImporte.Text = "";
            txtDescripcion.Text = "";

        }



        private void FrmCrearDeudaProveedor_Load(object sender, EventArgs e)
        {
            if (Principal.Codigo!=null)
            {
                Int32 CodDeuda = Convert.ToInt32(Principal.Codigo);
                BuscarDeuda(CodDeuda);
            }
        }

        private void BuscarDeuda(Int32 CodDeuda)
        {
            cFunciones fun = new cFunciones();
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            DataTable trdo = Deuda.GetDeudaxCodigo(CodDeuda);
            txtConcepto.Text = trdo.Rows[0]["Concepto"].ToString();
            txtDescripcion.Text = trdo.Rows[0]["Observacion"].ToString();
            Double Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            txtImporte.Text = Importe.ToString();
            txtImporte.Text = fun.FormatoEnteroMiles(Importe.ToString());
            DateTime Fecha = Convert.ToDateTime(trdo.Rows[0]["Fecha"]);
            dpFecha.Value = Fecha;
            if (trdo.Rows[0]["FechaVto"].ToString ()!="")
            {
                DateTime FechaVto = Convert.ToDateTime(trdo.Rows[0]["FechaVto"].ToString());
                dpFechaVencimiento.Value = FechaVto;
            }
            txtCuentaProveedor.Text = trdo.Rows[0]["Cuenta"].ToString();
            txtProveedor.Text = trdo.Rows[0]["Proveedor"].ToString();
            btnGuardar.Visible = false;
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
        }
   
    }

}
