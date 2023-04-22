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
    public partial class FrmListadoChequeCobrar : Form
    {
        public FrmListadoChequeCobrar()
        {
            InitializeComponent();
        }

        private void FrmListadoChequeCobrar_Load(object sender, EventArgs e)
        {   
            DateTime Fecha = DateTime.Now;
            daFechaCobro.Value = Fecha;
            dpFechaHasta.Value = Fecha;
            Fecha = Fecha.AddMonths(-1);
            dpFechaDesde.Value = Fecha;
            Buscar();
        }

        private void Buscar()
        {
            DateTime Desde = dpFechaDesde.Value;
            DateTime Hasta = dpFechaHasta.Value;
            string Apellido = "";
            string NumeroCheque = "";
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;
            if (txtNumeroCheque.Text != "")
                NumeroCheque = txtNumeroCheque.Text;

            int SoloImpago = 0;
            if (chkSoloImpago.Checked == true)
                SoloImpago = 1;
            cChequeCobrar cheque = new cChequeCobrar();
            DataTable trdo = cheque.GetChequesxFecha(Desde, Hasta, SoloImpago, Apellido, NumeroCheque);
            Clases.cFunciones fun = new Clases.cFunciones();
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].HeaderText = "Nro Cheque";
            Grilla.Columns[5].HeaderText = "Fecha Cobro";
            Grilla.Columns[2].Width = 120;
            Grilla.Columns[3].Width = 200;
            Grilla.Columns[5].Width = 120;
            Grilla.Columns[9].Width = 160;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro para continuar ");
                return;
            }

            
            
            if (Grilla.CurrentRow.Cells[5].Value.ToString() != "")
            {
                MessageBox.Show("Ya se ha cobrado el cheque ");
                return;
            }

            //Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(daFechaCobro.Value.ToShortDateString ()) == false)
            {
                MessageBox.Show("La fecha cobro es incorrecta ", "Sistema");
                return;
            }
            string Entregado = Grilla.CurrentRow.Cells[9].Value.ToString();
            DateTime FechaCobro = daFechaCobro.Value;
            Int32 CodCheque = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Double Importe = fun.ToDouble(Grilla.CurrentRow.Cells[4].Value.ToString());
            string NumeroCheque = Grilla.CurrentRow.Cells[2].Value.ToString();
            string Descripcion = "COBRO DE CHEQUE " + NumeroCheque.ToString();
            if (Entregado != "")
                Descripcion = Descripcion + ", " + Entregado;
            cChequeCobrar cheque = new cChequeCobrar();
            cMovimiento mov = new cMovimiento();
            cheque.CobroCheque(FechaCobro, CodCheque);
            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado, Importe,
                0, 0, 0, 0, FechaCobro, Descripcion);
            Buscar();
            MessageBox.Show("Datos grabados correctamente ");
             
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro para continuar ");
                return;
            }

            if (fun.ValidarFecha(daFechaCobro.Value.ToShortDateString ()) == false)
            {
                MessageBox.Show("La fecha de cobro es incorrecta");
                return;
            }

            if (Grilla.CurrentRow.Cells[5].Value.ToString() == "")
            {
                MessageBox.Show("Ya se ha anulado el cheque ");
                return;
            }
            DateTime FechaCobro = daFechaCobro.Value;

            Int32 CodCheque = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Double Importe = fun.ToDouble(Grilla.CurrentRow.Cells[4].Value.ToString());
            string NumeroCheque = Grilla.CurrentRow.Cells[2].Value.ToString();
            string Descripcion = "ANULACION COBRO DE CHEQUE " + NumeroCheque.ToString();
            cChequeCobrar cheque = new cChequeCobrar();
            cMovimiento mov = new cMovimiento();
            cheque.AnularCheque(CodCheque);
            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado,-1* Importe,
                0, 0, 0, 0, FechaCobro, Descripcion);
            Buscar();
            MessageBox.Show("Datos grabados correctamente ");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro para continuar ");
                return;
            }

            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString();
            FrmCobroCheque2 frm = new FrmCobroCheque2();
            frm.Show();
        }
    }
}
