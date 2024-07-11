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
    public partial class FrmListadoChequesaPagar : Form
    {
        public FrmListadoChequesaPagar()
        {
            InitializeComponent();
        }

        private void FrmListadoChequesaPagar_Load(object sender, EventArgs e)
        {
            DateTime fechahoy = DateTime.Now;
            dpFechaHasta.Value = fechahoy;
            string PrimerDia = "01-01-" + DateTime.Now.Year;
            DateTime FechaCorta = Convert.ToDateTime(PrimerDia);
            dpFechaDesde.Value = Convert.ToDateTime (FechaCorta.ToShortDateString());
            Buscar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            Clases.cFunciones fun = new Clases.cFunciones();

            if (dpFechaDesde.Value > dpFechaHasta.Value)
            {
                MessageBox.Show("La fecha desde debe ser inferior a la fecha hasta", Clases.cMensaje.Mensaje());
                return;
            }

            int Impago = 0;
            if (chkImpagos.Checked == true)
                Impago = 1;

            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string NroCheque = "";
            string Nombre = "";
            int Impagos = 0;
            int Vencidas = 0;
            if (chkImpagos.Checked == true)
                Impagos = 1;
            if (chkVencidas.Checked == true)
                Vencidas = 1;
            if (txtNumero.Text != "")
                NroCheque = txtNumero.Text;
            if (txtNombre.Text != "")
                Nombre = txtNombre.Text;
            Clases.cChequesaPagar cheque = new Clases.cChequesaPagar();
            DataTable trdo = cheque.GetChequesPagar(FechaDesde, FechaHasta, Impago, "", NroCheque, Nombre, Vencidas);
            txtTotal.Text = fun.TotalizarColumna(trdo, "Importe").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            Grilla.DataSource = trdo;
            string Col = "0;10;30;0;10;10;10;10;10;0;0;10";
            fun.AnchoColumnas(Grilla, Col);
            Grilla.Columns[8].HeaderText = "Fecha Pago";
            Grilla.Columns[11].HeaderText = "Fecha Vto";
        }

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje());
                return;
            }
            Int32 CodCheque = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodigoPrincipalAbm = CodCheque.ToString();
            FrmRegistrarPagoCheque frm = new FrmRegistrarPagoCheque();
            frm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistrarChequePagar frm = new FrmRegistrarChequePagar();
            frm.Show();
        }

        private void btnBorrarCheque_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            Int32 CodCheque = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);    
            string FechaPago = Grilla.CurrentRow.Cells[8].Value.ToString(); 
            if (FechaPago =="")
            {
                var result = MessageBox.Show("Confirma eliminar el cheque", "Información",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.No)
                {
                    return;
                }

                cChequesaPagar cheque = new cChequesaPagar();
                cheque.BorrarCheque(CodCheque);
                Buscar();
                MessageBox.Show("Datos Borrados Correctamente ");

            }
            else
            {
                MessageBox.Show("El cheque se debe anular para poder borrarlo ");
            }
        }
    }
}
