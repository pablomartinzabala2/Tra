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
    public partial class FrmMensajeCliente : FrmBase
    {
        public FrmMensajeCliente()
        {
            InitializeComponent();
        }

        private void FrmMensajeCliente_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = Principal.CodCliente.ToString();
            CargarEmpleado();
            BuscarVendedorxCliente(Convert.ToInt32 (txtCodigo.Text));
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));
            string Nombre = Principal.NombreUsuarioLogueado.ToUpper();
            ValidarUsuario();
        }

        private void BuscarVendedorxCliente(Int32 CodCliente)
        {
            cCliente cli = new Clases.cCliente();
            Int32 CodVendedor = cli.GetCodVendedorxCodCliente(CodCliente);
            if (CodVendedor >0)
            {
                cmbEmpleado.SelectedValue = CodVendedor.ToString();
            }
        }

        private void CargarEmpleado()
        {
            Clases.cVendedor ven = new Clases.cVendedor();
            DataTable tvend = ven.GetVendedores();
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(cmbEmpleado, tvend, "Apellido", "CodVendedor");
        }

        private void BtnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex<1)
            {
                MessageBox.Show("Debe seleccionar un elemento para continaur ");
                return;
            }

            Int32 CodCliente = Convert.ToInt32(txtCodigo.Text);
            Int32 CodVendedor = Convert.ToInt32(cmbEmpleado.SelectedValue);

            cCliente cli = new cCliente();
            cli.ActualizarVendedor(CodCliente, CodVendedor);
            MessageBox.Show("Datos actualizados correctamente");
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text == "")
            {
                MessageBox.Show("Debe ingresar un mensaje para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            cMensajeCliente msj = new cMensajeCliente();
            string Mensaje = txtMensaje.Text;
            Int32 CodCliente = Convert.ToInt32(txtCodigo.Text);
            DateTime Fecha = dpFechaDesde.Value;
            msj.InsertarMensaje(Mensaje, Fecha, CodCliente);
            MessageBox.Show("Datos Grabados Correctamente", Clases.cMensaje.Mensaje());
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));
        }

        private void CargarMensajes(Int32 CodCliente)
        {
            cMensajeCliente msj = new cMensajeCliente();
            cFunciones fun = new cFunciones();
            DataTable trdo = msj.GetMensajesxCodCliente(CodCliente);
            Grilla.DataSource = trdo;
            txtMensaje.Text = "";
            fun.AnchoColumnas(Grilla, "0;20;80");
        }

        private void btnVerMensaje_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            Int32 CodMensaje = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            cMensajeCliente msj = new cMensajeCliente();
            DataTable trdo = msj.GetMensajesxCodMensaje(CodMensaje);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodMensaje"].ToString ()!="")
                {
                    string Mensaje = trdo.Rows[0]["Mensaje"].ToString();
                    txtMensaje.Text = Mensaje; 
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            Int32 CodMensaje = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cMensajeCliente msj = new cMensajeCliente();
            msj.borrar(CodMensaje);
            MessageBox.Show(" Se ha borrado el mensaje correctamente ");
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));
        }

        private void ValidarUsuario()
        {
            int b = 0;
            string Usuario = Principal.NombreUsuarioLogueado;
            if (Usuario.ToUpper()=="ADMIN" || Usuario.ToUpper() == "VENTAS")
            {
                b = 1;
            }

            if (b==0)
            {
                btnEliminar.Enabled = false;
              //  btnAgregar.Enabled = false;
                btnGuardarVendedor.Enabled = false;
            }
        }
    }
                
}
