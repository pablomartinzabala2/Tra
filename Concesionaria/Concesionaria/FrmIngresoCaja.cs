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
    public partial class FrmIngresoCaja : Form
    {
        cFunciones fun;
        public FrmIngresoCaja()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar ()==false)
            {
                return;
            }
            cMovimientoCaja mov = new cMovimientoCaja();
            string Concepto = txtConcepto.Text;
            DateTime Fecha = Convert.ToDateTime(dpFechaHasta.Value);
            Int32? CodTipo = null;
            Double Importe = 0;
            Int32 CodCuenta = 0;
            if (txtImporte.Text != "")
                Importe = fun.ToDouble(txtImporte.Text);
            if (CmbTipoMov.SelectedIndex > 0)
                CodTipo = Convert.ToInt32(CmbTipoMov.SelectedValue);
            if (txtCodCuenta.Text != "")
                CodCuenta = Convert.ToInt32(txtCodCuenta.Text);
            mov.Insertar(Concepto, Fecha,CodTipo,Importe,CodCuenta);
            MessageBox.Show("Datos grabados correctamente ");
            CargarGrilla(Fecha);
        }

        public Boolean Validar()
        {   
            if (txtConcepto.Text =="")
            {
                MessageBox.Show("Debe ingresar un concepto");
                return false;
            }
              
            if (txtImporte.Text == "")
            {
                MessageBox.Show("Debe ingresar un Importe");
                return false;
            }
             
            if (txtCodCuenta.Text == "")
            {
                MessageBox.Show("Debe ingresar una cuenta");
                return false;
            }

            return true;
        }

        private void FrmIngresoCaja_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            fun.LlenarCombo(CmbTipoMov, "TipoMovimiento", "Nombre", "CodTipo");
            DateTime Fecha = dpFechaHasta.Value;
            CargarGrilla(Fecha);
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            if (txtImporte.Text != "")
                txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
        }

        private void CargarGrilla(DateTime Fecha)
        {
            cMovimientoCaja mov = new cMovimientoCaja();
            DataTable trdo = mov.GetMovimientoxFecha(Fecha);
            trdo = fun.TablaaMiles(trdo, "ImporteIngreso");
            Grilla.DataSource = trdo;
            Grilla.Columns[4].HeaderText = "Importe";
            fun.AnchoColumnas(Grilla, "0;15;25;15;15;15;15");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime Fecha = dpFechaHasta.Value;
            CargarGrilla(Fecha);
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            FrmBuscadorCuentaProveedor frm = new FrmBuscadorCuentaProveedor();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
