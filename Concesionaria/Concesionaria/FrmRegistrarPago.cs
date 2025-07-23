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
    public partial class FrmRegistrarPago : FrmBase
    {
        public FrmRegistrarPago()
        {
            InitializeComponent();
        }

        private void FrmRegistrarPago_Load(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbTipoPago, "TipoPago","Nombre", "CodTipoPago");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTipoPago frm = new Concesionaria.FrmTipoPago();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbTipoPago, "TipoPago", "Nombre", "CodTipoPago");
            if (Principal.CodigoPrincipalAbm != "")
            {
              //  int Codigo = Convert.ToInt32(Principal.CodigoPrincipalAbm);
              //  cmbTipoPago.SelectedValue = Codigo;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtImporte.Text =="")
            {
                MessageBox.Show("Debe ingresar un importe para continuar ");
                return; 
            }
            if (cmbTipoPago.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar un tipo de pago ");
                return;
            }

            int CodTipoPago = 0;
            int CodObligatorio = 0;
            string Obligatorio = "No Obligatorio";
            cPago pago = new cPago();
            DateTime Fecha = dpFecha.Value;
            DateTime FechaVencimiento = dpVencimiento.Value;
            Double Importe = 0;
            Importe = Convert.ToDouble(txtImporte.Text);
            if (chkPbligatorio.Checked ==true)
            {
                CodObligatorio = 1;
                Obligatorio = "Obligatorio";
            }
            CodTipoPago = Convert.ToInt32(cmbTipoPago.SelectedValue);
            pago.Insertar(Fecha, FechaVencimiento, Importe, CodObligatorio, Obligatorio, CodTipoPago);
            MessageBox.Show("Datos grabados correctamente ");
            txtImporte.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtImporte.Text = "";
        }
    }
}
