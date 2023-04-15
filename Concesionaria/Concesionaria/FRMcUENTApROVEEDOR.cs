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
    public partial class FRMcUENTApROVEEDOR : FormularioBase
    {
        public FRMcUENTApROVEEDOR()
        {
            InitializeComponent();
        }

        private void FRMcUENTApROVEEDOR_Load(object sender, EventArgs e)
        {
            if (Principal.CodProveedor !=null)
            {
                txtCodProveedor.Text = Principal.CodProveedor.ToString();
            }
            if (txtCodProveedor.Text !="")
            {
                Int32 CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
                Buscar(CodProveedor);
                BuscarCuentas(CodProveedor);
            }
        }

        private void Buscar (Int32 CodProveedor)
        {
            cProveedor pro = new cProveedor();
            DataTable trdo = pro.GetProveedor(CodProveedor);
            if (trdo.Rows.Count>0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString(); 
            }
        }

        private void BuscarCuentas(Int32 CodProveedor)
        {
            cFunciones fun = new cFunciones();
            cCuentaProveedor cuenta = new cCuentaProveedor();
            DataTable trdo = cuenta.GetCuentas(CodProveedor);
            Grilla.DataSource = trdo;


            fun.AnchoColumnas(Grilla, "0;100;0");
        }

        private void btnAgregarFinanciacion_Click(object sender, EventArgs e)
        {
            if (txtCuenta.Text =="")
            {
                MessageBox.Show("Debe ingresar un nombre de cuenta");
                return;
            }

            string Nombre = txtCuenta.Text;
            Int32 CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
            Double Saldo = 0;
            if (txtSaldo.Text != "")
                Saldo = Convert.ToInt32(txtSaldo.Text);
            cCuentaProveedor cuenta = new cCuentaProveedor();
            cuenta.Insertar(Nombre, CodProveedor, Saldo);
            BuscarCuentas(CodProveedor);
            MessageBox.Show("Datos Grabados Correctamente ");
            BuscarCuentas(CodProveedor);
            txtCuenta.Text = "";
        }

        private void btnQuitarFinanciacion_Click(object sender, EventArgs e)
        {   
            if (Grilla.CurrentRow ==null)
            {
                Msj("Debe seleccionar una cuenta ");
                return;
            }
            Int32 CodCuenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cCuentaProveedor cuenta = new cCuentaProveedor();
            try
            {
                cuenta.BorrrarCuenta(CodCuenta);
                Msj("Cuenta borrada correctamente ");
            }
            catch (Exception)
            {
                Msj("No se puede eliminar la cuenta, tiene deudas o pagos asociados");
                
            }

            Int32 CodProveedor = Convert.ToInt32(txtCodProveedor.Text);
            BuscarCuentas(CodProveedor);
        }
    }
}
