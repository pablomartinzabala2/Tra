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
            fun.LlenarCombo(CmbTipoDoc, "tipodocumento", "Nombre", "CodTipoDoc");
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
                Int32? CodCliente = null;
                if (txtCodCliente.Text != "")
                    CodCliente = Convert.ToInt32(txtCodCliente.Text);
                else
                {
                    CodCliente = GrabarCliente();
                    txtCodCliente.Text = CodCliente.ToString();
                }

                if (cmbBanco.SelectedIndex > 0)
                    CodBanco = Convert.ToInt32(cmbBanco.SelectedValue);
                cChequesaPagar cheque = new cChequesaPagar();
                cheque.InsertarCheque(NumeroCheque, Importe, CodBanco, Fecha, FechaVencimiento, CodCliente);
                MessageBox.Show("Datos grabados correctamente", "Sistema");
            }
        }

        private Boolean Validar()
        {
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

            if (txtCodCliente.Text=="")
            {
                if (txtNombre.Text =="")
                {
                    MessageBox.Show("Debe ingresar un Nombre ");
                    return false;
                }
                
                if (txtApellido.Text == "")
                {
                    MessageBox.Show("Debe ingresar un Apellido ");
                    return false;
                }
                 
                if (txtNroDocumento.Text == "")
                {
                    MessageBox.Show("Debe ingresar un Número de documento ");
                    return false;
                }

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
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                if (trdo.Rows[0]["CodTipoDoc"].ToString ()!="")
                {
                    CmbTipoDoc.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
                }
            }
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            if (txtNroDocumento.Text.Length>3)
            {  
                string  NroDoc = txtNroDocumento.Text;
                cCliente cliente = new cCliente();
                DataTable trdo = cliente.GetClientesxNroDocSolo(NroDoc);
                if (trdo.Rows.Count > 0)
                {
                    b = 1;
                    txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
                    txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                    txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txtNroDocumento.Text = trdo.Rows[0]["NroDocumento"].ToString();
                    txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                    if (trdo.Rows[0]["CodTipoDoc"].ToString() != "")
                    {
                        CmbTipoDoc.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
                    }
                }
                if (b==0)
                {
                    txtCodCliente.Text = "";
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                   // txtNroDocumento.Text = "";
                    txtTelefono.Text = "";
                    if (CmbTipoDoc.SelectedIndex>0)
                    {
                        CmbTipoDoc.SelectedIndex = -1;
                    }
                }
            }
        }

        public Int32 GrabarCliente()
        {
            Int32 CodCliente = 0;
            cCliente cli = new cCliente();
            string Apellido = txtApellido.Text;
            string Nombre = txtNombre.Text;
            string NroDoc = txtNroDocumento.Text;
            string Telefono = txtTelefono.Text;
            Int32? CodTipoDoc = null;
            if (CmbTipoDoc.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(CmbTipoDoc.SelectedValue);


            CodCliente = cli.InserterClienteId2(CodTipoDoc, NroDoc, Nombre, Apellido, Telefono);
            return CodCliente;
            }
    }
}
