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
    public partial class FrmAbmEntidad : FormularioBase
    {
        cFunciones fun;
        public FrmAbmEntidad()
        {
            fun = new Clases.cFunciones();
            InitializeComponent();
        }

        private void FrmAbmEntidad_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
        }

        private void Botonera(int Jugada)
        {
            switch (Jugada)
            {
                //estado inicial
                case 1:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;

                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;

                    break;
                case 3:
                    //viene del buscador
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;


                    break;
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
           
            fun.LimpiarGenerico(this);
           
            Grupo.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.Text =="")
            {
                MessageBox.Show("Debe ingresar una entidad");
                return;
            }  
            if (txtCoodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Entidad");
            else
                fun.ModificarGenerico(this, "Entidad", "CodEntidad", txtCoodigo.Text);
            MessageBox.Show("Datos grabados Correctamente", Clases.cMensaje.Mensaje());
            Botonera(1);
            fun.LimpiarGenerico(this);
            txtCoodigo.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Nombre";
            Principal.TablaPrincipal = "Entidad";
            Principal.OpcionesColumnasGrilla = "CodEntidad;Nombre";
            Principal.ColumnasVisibles = "0;1";
            Principal.ColumnasAncho = "0;580";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            //CargarJugador(Convert.ToInt32(PRINCIPAL.CDOGIO_JUGADOR));
            if (Principal.CodigoPrincipalAbm != null)
            {
                if (Principal.CodigoPrincipalAbm != "")
                { 
                    Botonera(3);
                    txtCoodigo.Text = Principal.CodigoPrincipalAbm.ToString();

                    if (Principal.CodigoPrincipalAbm != "")
                        fun.CargarControles(this, "Entidad", "CodEntidad", txtCoodigo.Text);
                    Grupo.Enabled = false;
                    return;
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Botonera(1); 
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LimpiarGenerico(this);
            txtCoodigo.Text = "";
            Grupo.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "Confirma eliminar la entidad ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            
            try
            { 
                fun.EliminarGenerico("Entidad", "CodEntidad", txtCoodigo.Text); 
                MessageBox.Show("La entidad se ha eliminado de la base", Clases.cMensaje.Mensaje());
                fun.LimpiarGenerico(this);
                txtCoodigo.Text = "";
                Botonera(1);
            }
            catch (Exception)
            {
                MessageBox.Show("El registro no se puede eliminar, esta asociado a otras entidades", Clases.cMensaje.Mensaje());
            }
        }
    }
}
