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
    public partial class FrmRegistrarCobranzaGeneral : Form
    {
        public FrmRegistrarCobranzaGeneral()
        {
            InitializeComponent();
        }

        private void FrmRegistrarCobranzaGeneral_Load(object sender, EventArgs e)
        {
           
            
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (txtEfectivo.Text == "")
            {
                Mensaje("Debe ingresar un monto");
                return;
            }

            if (txtDescripcion.Text == "")
            {
                Mensaje("Debe ingresar una Descripción");
                return;
            }

            Int32 CodCLi = 0;
            cCliente cli = new cCliente();
            DateTime Fecha = dpFecha.Value;
            DateTime FechaVencimiento = dpFechaVencimiento.Value;
            string Descripcion = txtDescripcion.Text ;
            double Importe = fun.ToDouble(txtEfectivo.Text);;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string NroDoc = txtNroDoc.Text;
            string Telefono = txtTelefono.Text;
            string Patente = txtPatente.Text;
            string Direccion = txtDireccion.Text;
            string Nombrecliente = txtNombre + " " + txtApellido.Text;
            cCobranzaGeneral cob = new cCobranzaGeneral();
            if (txtCodCLiente.Text =="")
            {
                CodCLi =  cli.InserterClienteId2(null, NroDoc, Nombre, Apellido, Telefono);
            }
            else
            {
                txtCodCLiente.Text = "";
            }

            cob.InsertarCobranza(Fecha, Descripcion, Importe, Nombrecliente, Telefono, Direccion, Patente, FechaVencimiento);
            Mensaje("Datos grabados correctamente");
            txtDescripcion.Text = "";
            txtEfectivo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (txtEfectivo.Text != "")
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
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
            if (trdo.Rows.Count > 0)
            {
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                txtCodCLiente.Text = trdo.Rows[0]["CodCliente"].ToString();
            }
            else
            {
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtCodCLiente.Text = "";
            }
                
        }
    }
}
