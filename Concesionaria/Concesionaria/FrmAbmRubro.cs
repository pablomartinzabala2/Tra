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
    public partial class FrmAbmRubro : FormularioBase
    {
        public FrmAbmRubro()
        {
            InitializeComponent();
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
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
            Grupo.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtCodigo.Text == "")
            {
                fun.GuardarNuevoGenerico(this, "Cargo");
                string sql = "select max(CodCargo) AS CodCargo from Cargo  ";
                DataTable trdo = cDb.ExecuteDataTable(sql);
                if (trdo.Rows.Count > 0)
                {
                    txtCodigo.Text = trdo.Rows[0]["CodCargo"].ToString();
                }
            }

            else
                fun.ModificarGenerico(this, "Cargo", "CodCargo", txtCodigo.Text);
            MessageBox.Show("Datos grabados Correctamente", Clases.cMensaje.Mensaje());
            Principal.CampoIdSecundarioGenerado = txtCodigo.Text;
            Botonera(1);
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Nombre";
            //nombre de la tabla, 
            Principal.TablaPrincipal = "Cargo";
            Principal.OpcionesColumnasGrilla = "CodCargo; Nombre";
            Principal.ColumnasVisibles = "0;1";
            Principal.ColumnasAncho = "100;580";
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
                    txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();

                    if (Principal.CodigoPrincipalAbm != "")
                        fun.CargarControles(this, "Cargo", "CodCargo", txtCodigo.Text);
                    Grupo.Enabled = false;
                    return;
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Botonera(1);
            Grupo.Enabled = false;
            fun.LimpiarGenerico(this);
            txtCodigo.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "Confirma Eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                cFunciones fun = new cFunciones();
                try
                {
                    fun.EliminarGenerico("Cargo", "CodCargo", txtCodigo.Text);
                    MessageBox.Show("Datos borrados correctamente ");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede eliminar el registro, tiene cuentas asociadas ");

                }
                Botonera(1);
                Grupo.Enabled = false;
                txt_Nombre.Text = "";
            }
        }

        private void FrmAbmRubro_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
