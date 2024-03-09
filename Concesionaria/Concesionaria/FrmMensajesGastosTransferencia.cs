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
    public partial class FrmMensajesGastosTransferencia : Form
    {
        public FrmMensajesGastosTransferencia()
        {
            InitializeComponent();
        }

        private void FrmMensajesGastosTransferencia_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text =="")
            {
                MessageBox.Show("Debe ingresar un mensaje");
                return;
            }

            string Mensaje = txtMensaje.Text;
            DateTime Fecha = dpFecha.Value;
            Int32 CodGasto = Convert.ToInt32(Principal.CodigoPrincipalAbm);

            cMensajesGastosTransferencia msj = new cMensajesGastosTransferencia();
            msj.Insertar(Mensaje, Fecha, CodGasto);
            MessageBox.Show("Datos grabados correctamente", "Sistema");
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));

        }

        private void CargarMensajes(Int32 CodGasto)
        {
            cMensajesGastosTransferencia msj = new cMensajesGastosTransferencia();
            DataTable trdo = msj.GetMensajexCodGasto(CodGasto);
            cFunciones fun = new cFunciones();
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;75;25");
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            string msj = "Confirma Eliminar el mensaje";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            Int32 CodMensaje = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cMensajesGastosTransferencia objMsj = new cMensajesGastosTransferencia();
            objMsj.Eliminar (CodMensaje);
            MessageBox.Show("Datos borrados correctamente", "Sistema");
            CargarMensajes(Convert.ToInt32(txtCodigo.Text));

        }

        private void btnVerMensaje_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            string Mensaje = Grilla.CurrentRow.Cells[1].Value.ToString();
            txtMensaje.Text = Mensaje;
        }
    }
}
