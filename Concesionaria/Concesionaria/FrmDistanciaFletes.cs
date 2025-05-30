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
    public partial class FrmDistanciaFletes : FrmBase
    {
        public FrmDistanciaFletes()
        {
            InitializeComponent();
        }

        private void FrmDistanciaFletes_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {   
            cFunciones fun = new Clases.cFunciones();  
            fun.LlenarCombo(cmbProvinciaOrigen, "Provincia", "Nombre", "CodProvincia");
            fun.LlenarCombo(cmbProvinciaDestino, "Provincia", "Nombre", "CodProvincia");
        }

        private void cmbProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cmbProvinciaOrigen.SelectedIndex < 1)
            {
                return;
            }
            Int32 CodProvincia = Convert.ToInt32(cmbProvinciaOrigen.SelectedValue);
            cCiudad ciudad = new Clases.cCiudad();
            DataTable trdo = ciudad.GetCiudadxCodProvincia(CodProvincia);
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(cmbCiudadOrigen, trdo, "Nombre", "CodCiudad");
        }

        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cmbProvinciaDestino.SelectedIndex < 1)
            {
                return;
            }
            Int32 CodProvincia = Convert.ToInt32(cmbProvinciaDestino.SelectedValue);
            cCiudad ciudad = new Clases.cCiudad();
            DataTable trdo = ciudad.GetCiudadxCodProvincia(CodProvincia);
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(cmbCiudadDestino, trdo, "Nombre", "CodCiudad");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar ()==false)
            {
                return;
            }

            int CodCiudadOirigan = Convert.ToInt32(cmbCiudadOrigen.SelectedValue);
            int CodCiudadDestino = Convert.ToInt32(cmbCiudadDestino.SelectedValue);
            int Km = Convert.ToInt32(txtKm.Text);
            cDistancia dis = new Clases.cDistancia();
            dis.Insertar(CodCiudadOirigan, CodCiudadDestino, Km);
            MessageBox.Show("Datos grabados correctamente");
            txtKm.Text = "";
            cmbCiudadOrigen.SelectedIndex = -1;
            cmbCiudadDestino.SelectedIndex = -1;
        }

        private Boolean Validar()
        {
            Boolean op = true;
            if (cmbCiudadOrigen.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar una ciudad de origen");
                return false;
            }
             
            if (cmbCiudadDestino.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una ciudad de destino");
                return false;
            }

            if (txtKm.Text =="")
            {
                MessageBox.Show("Debe ingresar la cantidad de kilómetros ");
                return false;
            }

            return op;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            FrmConsultaDistancia frm = new FrmConsultaDistancia();
            frm.Show();
        }

        private void btnCCancelar_Click(object sender, EventArgs e)
        {
            txtKm.Text = "";
            cmbCiudadOrigen.SelectedIndex = -1;
            cmbCiudadDestino.SelectedIndex = -1; 
        }
    }
}
