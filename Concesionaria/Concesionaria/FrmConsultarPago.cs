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
    public partial class FrmConsultarPago : FrmBase
    {
        public FrmConsultarPago()
        {
            InitializeComponent();
        }

        private void FrmConsultarPago_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            dpFechaDesde.Value = Fecha;
            dpFechaHasta.Value = Fecha.AddDays(3);
            Consultar();
        }

        private void Consultar()
        {
            cFunciones fun = new cFunciones();
            cPago Pago = new Clases.cPago();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            DataTable trdo = Pago.Consultar(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaFechas(trdo, "Fecha");
            trdo = fun.TablaaFechas(trdo, "FechaVencimiento");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;25;15;15;15;15;15");
            ConsultarTotalVencimientoDiario();
            Grilla.Columns[3].HeaderText = "Vencimiento";
            Grilla.Columns[6].HeaderText = "Condición";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void ConsultarTotalVencimientoDiario()
        {
            DateTime Fecha = dpFechaDesde.Value;
            cPago pago = new Clases.cPago();
            Double Total = pago.GetTotalPagosDiario(Fecha);
            cFunciones fun = new cFunciones();
            txtTotal.Text = fun.FormatoEnteroMiles(Total.ToString());
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string msj = "Confirma eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            Int32 CodPago = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cPago pago = new cPago();
            pago.Eliminar(CodPago);
            Consultar();
            
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            string msj = "Confirma  registrar el pago";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            cPago pago = new Clases.cPago();
            DateTime fecha = DateTime.Now;
            Int32 CodPago = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            pago.ActualizarPago(CodPago, fecha);
            MessageBox.Show("Datos actualizados correctamente ");
            Consultar();
        }
    }
}
