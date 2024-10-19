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
    public partial class FrmPersonal : FormularioBase 
    {
        public FrmPersonal()
        {
            InitializeComponent();
        }

        private void FrmPersonal_Load(object sender, EventArgs e)
        {
            Int32 CodCliente = Convert.ToInt32(Principal.CodCliente);
            CargarCombo();
            CargarGrilla(CodCliente);
        }

        private void CargarCombo()
        {
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(cmbCargo, "Cargo", "Nombre", "CodCargo");
        }

        private void btnAgregarResponsable_Click(object sender, EventArgs e)
        {
            Int32 CodCliente = Convert.ToInt32(Principal.CodCliente);
            string Nombre = "";
            string Telefono = "";
            Int32? CodCargo = null;
            if (txtNombre.Text =="")
            {
                MessageBox.Show("Debe ingresar un elemento ");
                return;
            }

            if (txtTelefono.Text  == "")
            {
                MessageBox.Show("Debe ingresar un Telefono ");
                return;
            }

            if (cmbCargo.SelectedIndex >0)
            {
                CodCargo = Convert.ToInt32(cmbCargo.SelectedValue);
            }

            Nombre = txtNombre.Text;
            Telefono = txtTelefono.Text;

            cPersonal personal = new cPersonal();
            personal.Insertar(Nombre, CodCargo, CodCliente, Telefono);
            MessageBox.Show("Datos grabados correctramente");
            txtNombre.Text = "";
            txtTelefono.Text = "";
            CargarGrilla(CodCliente);
        }

        private void CargarGrilla(Int32 CodCliente)
        {
            cFunciones fun = new Clases.cFunciones();
            cPersonal Personal = new cPersonal();
            DataTable trdo = Personal.GetPersonalxCodCliente(CodCliente);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;30;30;40");
        }

        private void btnQuitarResponsable_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elelemtno ");
                return;
            }

            Int32 CodPersonal = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cPersonal personal = new Clases.cPersonal();
            personal.Borrar(CodPersonal);
            MessageBox.Show("Datos borrados correctamnete ");
            Int32 CodCliente = Convert.ToInt32(Principal.CodCliente);
            CargarGrilla(CodCliente);
        }

        private void btnNuevoCargo_Click(object sender, EventArgs e)
        {

            // Principal.CodigoPrincipalAbm = null;
            // Principal.CampoIdSecundario = "CodBarrio";
            //  Principal.CampoNombreSecundario = "Nombre";
            //  Principal.NombreTablaSecundario = "Barrio";
            FrmAbmRubro form = new FrmAbmRubro();
            form.FormClosing += new FormClosingEventHandler(ContinuarCargo);
            form.ShowDialog();
        }

        private void ContinuarCargo(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != null)
            {  
                cFunciones fun = new cFunciones();
                fun.LlenarCombo(cmbCargo, "Cargo", "Nombre", "CodCargo");
                cmbCargo.SelectedValue = Principal.CampoIdSecundarioGenerado;
            }

        }
    }
}
