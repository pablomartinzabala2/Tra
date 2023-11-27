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
    public partial class FrmCambioClave : FormularioBase
    {
        public FrmCambioClave()
        {
            InitializeComponent();
        }

        private void FrmCambioClave_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
            txtReingresarClave.PasswordChar = '*';
            Int32 CodUsuario = Principal.CodUsuarioLogueado;
            cUsuario usuario = new cUsuario();
            DataTable trdo = usuario.GetUsuarioxCodigo(CodUsuario);
            if (trdo.Rows.Count >0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString(); 
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text =="")
            {
                MessageBox.Show("Debe ingresar una contraseña");
                return;
            }
            
            if (txtReingresarClave.Text == "")
            {
                MessageBox.Show("Debe re ingresar una contraseña");
                return;
            }

            if (txtClave.Text != txtReingresarClave.Text )
            {
                MessageBox.Show("Ambas contraseñas deben ser iguales");
                return;
            }
            Int32 CodUsuario = Principal.CodUsuarioLogueado;
            string Clave = txtClave.Text;
            cUsuario user = new cUsuario();
            user.ActualizarClave(CodUsuario, Clave);
            MessageBox.Show("Datos actualizados correctamente");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtReingresarClave.Text = "";
        }

        private void chkContraseña_Click(object sender, EventArgs e)
        {
            if (chkContraseña.Checked)
            {
                txtClave.PasswordChar = '\0';
                txtReingresarClave.PasswordChar = '\0';
               
            }
            else
            {
                txtClave.PasswordChar = '*';
                txtReingresarClave.PasswordChar = '*';
            }
        }
    }
}
