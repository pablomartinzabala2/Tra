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
    public partial class FrmRegistrarChequePagar : Form
    {
        cFunciones fun;
        public FrmRegistrarChequePagar()
        {
            InitializeComponent();
        }

        private void FrmRegistrarChequePagar_Load(object sender, EventArgs e)
        {   
            fun = new cFunciones();
            fun.LlenarCombo(cmbBanco, "Banco", "Nombre", "CodBanco");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar()==true)
            {
                string NumeroCheque = txtNumeroCheque.Text;
                Double Importe = fun.ToDouble(txtImporte.Text);
                DateTime Fecha = dpFecha.Value;
                DateTime FechaVencimiento = dpFechaVencimiento.Value;
                Int32? CodBanco = null;
                if (cmbBanco.SelectedIndex > 0)
                    CodBanco = Convert.ToInt32(cmbBanco.SelectedValue);
                cChequesaPagar cheque = new cChequesaPagar();
                cheque.InsertarCheque(NumeroCheque, Importe, CodBanco, Fecha, FechaVencimiento);
                MessageBox.Show("Datos grabados correctamente", "Sistema");
            }
        }

        private Boolean Validar()
        {
            Boolean op = true;
            if (txtNumeroCheque.Text =="")
            {
                MessageBox.Show("Debe ingresar un cheque", "Sistema");
                return false;
            }
            if (txtImporte.Text =="")
            {
                MessageBox.Show("Debe ingresar un cheque", "Sistema");
                return false;
            }
            return true;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscadorCliente frm = new FrmBuscadorCliente();
            frm.FormClosing += new FormClosingEventHandler(FrmBuscarCliente);
            frm.Show();
        }

        private void FrmBuscarCliente(object sender, FormClosingEventArgs e)
        {
            Int32 CodCliente = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            BuscarClientexCodigo(CodCliente);
        }

        private void BuscarClientexCodigo(Int32 CodCliente)
        {
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientesxCodigo(CodCliente);
            if (trdo.Rows.Count >0)
            {
                txtCodCliente.Text = CodCliente.ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtNroDocumento.Text = trdo.Rows[0]["NroDocumento"].ToString();
            }
        }
    }
}
