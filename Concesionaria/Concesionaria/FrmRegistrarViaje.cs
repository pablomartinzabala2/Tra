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
    public partial class FrmRegistrarViaje : FrmBase
    {  /// <summary>
    ///  2 8 de
    /// </summary>
        public FrmRegistrarViaje()
        {
            InitializeComponent();
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            FrmBuscarDistancias frm = new FrmBuscarDistancias();
            frm.FormClosing += new FormClosingEventHandler(Continuar);
            frm.ShowDialog();
        }

        private void Continuar(object sender, FormClosingEventArgs e)
        {
            if (Principal.Codigo !=null)
            {
                Int32 CodDistancia = Convert.ToInt32(Principal.Codigo);
                cDistancia dis = new Clases.cDistancia();
                DataTable trdo = dis.GetDistanciasxId(CodDistancia);
                if (trdo.Rows.Count >0)
                {
                    txtOrigen.Text = trdo.Rows[0]["Origen"].ToString();
                    txtDestino.Text = trdo.Rows[0]["Destino"].ToString();
                    txtCodDistancia.Text = CodDistancia.ToString();
                }


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodDistancia.Text =="")
            {
                MessageBox.Show("Debe seleccionar un recorrido ");
                return;
            }
            Int32 CodDistancia = Convert.ToInt32 (txtCodDistancia.Text);
            Double Adelanto = 0;
            Double Gastos = 0;
            if (txtAdelanto.Text =="")
            {
                Adelanto = Convert.ToDouble(txtAdelanto.Text);
            }
             
            if (txtGastos.Text == "")
            {  
                Gastos = Convert.ToDouble(txtGastos.Text);
            }
            DateTime Fecha = dpFecha.Value;
            string Descripcion = txtDescripcion.Text;
            cViaje viaje = new Clases.cViaje();
            viaje.Insertar(CodDistancia, Fecha, Adelanto, Gastos, Descripcion);
            MessageBox.Show("Datos grabados correctamente ");

        }
    }
}
