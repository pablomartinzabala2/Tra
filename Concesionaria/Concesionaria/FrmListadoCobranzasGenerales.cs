using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Concesionaria.Clases;
using System.Windows.Forms;

namespace Concesionaria
{
    public partial class FrmListadoCobranzasGenerales : Form
    {
        public FrmListadoCobranzasGenerales()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar ()
        {
            Clases.cFunciones fun = new Clases.cFunciones();
          

            if (dpFechaHasta.Value >  dpFechaHasta.Value)
            {
                MessageBox.Show("La fecha desde debe sedr inferior a la fecha hasta", Clases.cMensaje.Mensaje());
                return;
            }

            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            int SoloImpago = 0;
            if (chkSoloImpagos.Checked)
                SoloImpago = 1;
            cCobranzaGeneral cob = new cCobranzaGeneral();
            DataTable trdo = cob.GetCobranzasGeneralesxFecha(FechaDesde, FechaHasta, SoloImpago, txtConcepto.Text, txtCliente.Text);
            txtTotal.Text = fun.TotalizarColumna(trdo, "Saldo").ToString();
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "ImportePagado");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            Grilla.Columns[4].HeaderText = "Importe Pagado";
            Grilla.Columns[5].HeaderText = "Fecha Pago";
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Width = 240;
            Grilla.Columns[4].Width = 140;
            Grilla.Columns[5].Width = 120;
            Grilla.Columns[7].Width = 120;
            if (txtTotal.Text != "" && txtTotal.Text != "0")
            {
                txtTotal.Text = fun.SepararDecimales(txtTotal.Text);
                txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            }
        }

        private void FrmListadoCobranzasGenerales_Load(object sender, EventArgs e)
        {
            DateTime fechahoy = DateTime.Now;
            int Anio = fechahoy.Year;
            string FechaDesde = "01/01/" + Anio.ToString();
            string FechaHasta = "31/12/" + Anio.ToString();
            dpFechaDesde.Value = Convert.ToDateTime(FechaDesde);
            dpFechaHasta.Value = Convert.ToDateTime(FechaHasta);
            Buscar();
        }

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString();
            FrmRegistrarCobroCobranzasGenerales form = new FrmRegistrarCobroCobranzasGenerales();
            form.ShowDialog();
        }

        private void txtFechaHasta_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnBorarCobranza_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow==null)
            {
                MessageBox.Show("Debe seleccioanr un registro para continuar");
                return;
            }
            string msj = "Confirma borrar la cobranza ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            string FechaPago = Grilla.CurrentRow.Cells[4].Value.ToString();
            if (FechaPago!="")
            {
                MessageBox.Show("Debe anular la cobranza para poder borrarla");
                return;
            }

            Int32 CodCobranza = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            cCobranzaGeneral cob = new cCobranzaGeneral();
            cob.BorrarCobranza(CodCobranza);
            Buscar();
        }
    }
}
