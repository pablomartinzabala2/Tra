﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concesionaria
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnBuscarApe_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                MessageBox.Show ("Ingresar Nombre de Usuario");
                return;
            }
            
            if (txtContraseña.Text=="")
            {
                MessageBox.Show ("Ingresar una Contraseña");
                return;
            }
           
            Clases.cUsuario USUARIO = new Clases.cUsuario();
            DataTable trdo = USUARIO.GetUsuario(txtUsuario.Text, txtContraseña.Text);
            if (trdo.Rows.Count > 0)
            {
                Principal.CodUsuarioLogueado =Convert.ToInt32 (trdo.Rows[0]["CodUsuario"].ToString());
                Principal.NombreUsuarioLogueado = txtUsuario.Text;
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                Principal  p = new Principal();
                p.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario incorrecto", "Información");
                return;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {  /*
            DateTime Vto = Convert.ToDateTime("01/12/2022");
            DateTime Fecha = DateTime.Now;
            if (Fecha > Vto)
            {
                btnBuscarApe.Enabled = false;
            }
            */
            
        }
    }
}
