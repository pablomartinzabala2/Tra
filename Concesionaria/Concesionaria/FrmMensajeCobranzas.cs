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
    public partial class FrmMensajeCobranzas : FormularioBase
    {
        public FrmMensajeCobranzas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();

            if (txtMensaje.Text == "")
            {
                MessageBox.Show("Debe ingresar un mensaje para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            cMensajeCobranza msj = new cMensajeCobranza();
            string Mensaje = txtMensaje.Text;
            Int32 CodCobranza = Convert.ToInt32(txtCodigo.Text);
            DateTime Fecha = dpFecha.Value;
            msj.InsertarMensaje(Mensaje, Fecha, CodCobranza);

            MessageBox.Show("Datos Grabados Correctamente", Clases.cMensaje.Mensaje());
            DataTable trdo = msj.GetMensajesxCodCobranza(CodCobranza);
            Grilla.DataSource = trdo;
            txtMensaje.Text = "";
            fun.AnchoColumnas(Grilla, "0;20;80");

        }

        private void FrmMensajeCobranzas_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
            Int32 CodCobranza = Convert.ToInt32(txtCodigo.Text);
            Buscar(CodCobranza);  
        }

        private void Buscar(Int32 CodCobranza)
        {
            cFunciones fun = new Clases.cFunciones();
            cMensajeCobranza msj = new cMensajeCobranza();
            DataTable trdo = msj.GetMensajesxCodCobranza(CodCobranza);
            Grilla.DataSource = trdo;
            txtMensaje.Text = "";
            fun.AnchoColumnas(Grilla, "0;20;80");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 CodCobranza = Convert.ToInt32(txtCodigo.Text);
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }
            Int32 CodMensaje = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            cMensajeCobranza msj = new cMensajeCobranza();
            msj.borrar(CodMensaje);
            Buscar(CodCobranza);
        }

        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Grilla.CurrentRow !=null)
            {
                String Mensaje = Grilla.CurrentRow.Cells[2].Value.ToString();
                txtMensaje.Text = Mensaje; 
            }
        }
    }
}
