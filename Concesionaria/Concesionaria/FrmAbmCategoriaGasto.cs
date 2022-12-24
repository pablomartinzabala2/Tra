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
    public partial class FrmAbmCategoriaGasto : FormularioBase
    {
        cFunciones fun;
        public FrmAbmCategoriaGasto()
        {
            InitializeComponent();
            fun = new Clases.cFunciones();
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

        private void FrmAbmCategoriaGasto_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
            Grupo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "CategoriaGastoTransferencia");
            else
                fun.ModificarGenerico(this, "CategoriaGastoTransferencia", "Codigo", txtCodigo.Text);
            MessageBox.Show("Datos grabados Correctamente", Clases.cMensaje.Mensaje());
            Botonera(1);
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Nombre";
            //nombre de la tabla, 
            Principal.TablaPrincipal = "CategoriaGastoTransferencia";
            Principal.OpcionesColumnasGrilla = "Codigo; Descripcion";
            Principal.ColumnasVisibles = "0;1";
            Principal.ColumnasAncho = "100;580";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //CargarJugador(Convert.ToInt32(PRINCIPAL.CDOGIO_JUGADOR));
            if (Principal.CodigoPrincipalAbm != null)
            {
                if (Principal.CodigoPrincipalAbm != "")
                {
                    Botonera(3);
                    txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();

                    if (Principal.CodigoPrincipalAbm != "")
                        fun.CargarControles(this, "CategoriaGastoTransferencia", "Codigo", txtCodigo.Text);
                    Grupo.Enabled = false;
                    return;
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "Confirma eliminar la categoria de gasto ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            Clases.cAuto cauto = new Clases.cAuto();
            try
            {   
                fun.EliminarGenerico("CategoriaGastoTransferencia", "Codigo", txtCodigo.Text);
                MessageBox.Show("La categoria de gasto se ha eliminado de la base", Clases.cMensaje.Mensaje());
                fun.LimpiarGenerico(this);
                txtCodigo.Text = "";
                Botonera(1);
            }
            catch (Exception)
            {
                MessageBox.Show("El registro no se puede eliminar, esta asociado a otras entidades", Clases.cMensaje.Mensaje());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
