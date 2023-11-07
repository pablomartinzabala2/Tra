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
    public partial class FrmAperturaCaja : FormularioBase
    {
        public FrmAperturaCaja()
        {
            InitializeComponent();
        }

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            VerificarApertura();
            CargarUsuarios();
            CargarCaja(dpFecha.Value);
        }

        private void CargarUsuarios()
        {
            cUsuario user = new cUsuario();
            DataTable trdo = user.GetAllUsuarios();
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(CmbUsuario, trdo, "Nombre", "CodUsuario");
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (txtImporte.Text =="")
            {
                MessageBox.Show("Debe ingresar un importe ");
                return;
            }
            if (CmbUsuario.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar un usuario ");
                return;
            }

            cMovimientoCaja mov = new cMovimientoCaja();
            Int32 CodApertura = 0;
            Int32 CodUsuario = Convert.ToInt32(CmbUsuario.SelectedValue);
            cFunciones fun = new cFunciones();
            DateTime Fecha = dpFecha.Value;
            Double Importe = fun.ToDouble(txtImporte.Text);
            cAperturaCaja aper = new cAperturaCaja();
            CodApertura = aper.AbrirCaja(Fecha, Importe,CodUsuario);
            mov.Insertar("Apertura Caja", dpFecha.Value, 1, Importe, 0, null, null, CodApertura);
            MessageBox.Show("Datos grabados correctamente", "Sistema");
            VerificarApertura();
            txtCodApertura.Text = CodApertura.ToString();
            CargarCaja(dpFecha.Value);
        }

        public void VerificarApertura()
        {
            int b = 0;
            Boolean op = false;
            cAperturaCaja aper = new cAperturaCaja();
            DateTime Fecha = dpFecha.Value;
            op  = aper.VerificarApertura(Fecha);
            if (op==true)
            {
                b = 1;
            }

            if (b ==1)
            {
                btnAbrirCaja.Enabled = false;
                btnCerrar.Enabled = true;
            }
            else
            {
                btnAbrirCaja.Enabled = true ;
                btnCerrar.Enabled = false;
            }
        }

        public void CargarCaja(DateTime Fecha)
        {
            cFunciones fun = new cFunciones();
            cAperturaCaja aper = new cAperturaCaja();
            DataTable trdo = aper.GetApertura(Fecha);
            Grilla.DataSource = trdo;
            txtCodApertura.Text = aper.GetMaxCodApertura().ToString();
            fun.AnchoColumnas(Grilla, "0;25;25;25;25");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Int32 CodApertura = Convert.ToInt32(txtCodApertura.Text);
            cAperturaCaja aper = new cAperturaCaja();
            aper.CerrarCaja(CodApertura, dpFecha.Value);
            CargarCaja(dpFecha.Value);
            MessageBox.Show("Datos grabados correctamente", "Sistema");
        }
    }
}
