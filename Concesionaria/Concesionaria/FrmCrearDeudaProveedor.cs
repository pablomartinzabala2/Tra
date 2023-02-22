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
            cDeudaProveedor Deuda = new cDeudaProveedor();
            Int32 CodCuentaProveedor= Convert.ToInt32 (txtCodCuenta.Text);
            string COncepto = txtConcepto.Text;
            DateTime Fecha = Convert.ToDateTime(dpFecha.Value);
            DateTime FechaVto = Convert.ToDateTime(dpFechaVencimiento.Value);
            Double Importe = 0;
            string Observacion = txtDescripcion.Text;
            cFunciones fun = new cFunciones();
            Importe = fun.ToDouble(txtImporte.Text);
            Deuda.Insertar(CodCuentaProveedor,COncepto,
             Fecha,  FechaVto,  Importe,  Observacion);
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

        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
        }
    }

}
