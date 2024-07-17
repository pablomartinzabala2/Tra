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
    public partial class FrmListadoDeudaCoibranzaxCliente : Form
    {
        public FrmListadoDeudaCoibranzaxCliente()
        {
            InitializeComponent();
        }

        private void FrmListadoDeudaCoibranzaxCliente_Load(object sender, EventArgs e)
        {
           if (Principal.CodCliente !=null)
            {
                Int32 CodCliente = Convert.ToInt32(Principal.CodCliente);
                BuscarDeuda(CodCliente);
            }
        }

        private void BuscarDeuda(Int32 CodCliente)
        {
            cFunciones fun = new cFunciones();
            cCobranzaGeneral cob = new cCobranzaGeneral();
            DataTable trdo = cob.GetDedudaCobranzaGeneralxCodCliente(CodCliente);
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            GrillaDeuda.DataSource = trdo;
            GrillaDeuda.Columns[1].Visible = false;
            GrillaDeuda.Columns[2].Visible = false;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (CalcularTotalSeleccionado() == false )
            {
                return;
            }
            string Codigo = "";
            foreach (DataGridViewRow r in GrillaDeuda.Rows)
            {
                if (Convert.ToBoolean (r.Cells["Cobrar"].Value)==true)
                {
                    Codigo = r.Cells[1].Value.ToString(); 
                }
            }
        }

        private void GrillaDeuda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // CalcularTotalSeleccionado();
        }

        private Boolean CalcularTotalSeleccionado()
        {
            cFunciones fun = new cFunciones();
            Double Pesos = 0;
            Double Dolares = 0;
            Double Saldo = 0;
            string Moneda = "";
            int b = 0;
            int Filas = GrillaDeuda.Rows.Count;
            int i = 1;
            foreach (DataGridViewRow r in GrillaDeuda.Rows)
            {
                if (i<Filas)
                {
                    Moneda = r.Cells["Moneda"].Value.ToString();
                    if (Convert.ToBoolean(r.Cells["Cobrar"].Value) == true)
                    {
                        b = 1;
                        Saldo = Convert.ToDouble(fun.FormatoEnteroMiles(r.Cells["Saldo"].Value.ToString()));
                        if (Moneda == "Pesos")
                            Pesos = Pesos + Saldo;

                        if (Moneda == "Dolares")
                            Dolares = Dolares + Saldo;
                    }      
                }
               
                i++;
            }

            if (b==0)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar ");
                return false;
            }

            if (Pesos >0 && Dolares >0)
            {
                MessageBox.Show("Debe seleccionar un solo tipo de moneda para continuarr ");
                return false;
            }

            if (Pesos >0)
            {
                lblMoneda.Text = "Pesos";
                txtSaldo.Text = fun.FormatoEnteroMiles(Pesos.ToString());
            }

            if (Dolares  > 0)
            {
                lblMoneda.Text = "Dolares";
                txtSaldo.Text = fun.FormatoEnteroMiles(Dolares.ToString());
            }

            return true;
        }

        private void btnCalcularSaldo_Click(object sender, EventArgs e)
        {
            if (CalcularTotalSeleccionado() == false)
            {
                txtSaldo.Text = "";
                lblMoneda.Text = "";
                return;
            }
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (txtImporte.Text !="")
            {
                txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
            }
        }
    }
}
