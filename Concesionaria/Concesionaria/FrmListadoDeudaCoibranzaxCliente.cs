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
            cFunciones fun = new cFunciones();
            cCobranzaGeneral Cobranza = new cCobranzaGeneral();
            Double SaldoGeneral = 0;
            Double Importe = 0;
            Double Saldo = 0;
            if (CalcularTotalSeleccionado() == false )
            {
                return;
            }
            Importe = Convert.ToDouble(fun.FormatoEnteroMiles(txtImporte.Text));
            SaldoGeneral = Convert.ToDouble(fun.FormatoEnteroMiles(txtSaldo.Text));
            if (Importe >SaldoGeneral)
            {
                MessageBox.Show("El importe a pagar supera el saldo");
                return;
            }
            DateTime Fecha = DateTime.Now;
            int Filas = GrillaDeuda.Rows.Count;
            int i = 1;
            int b = 0;
            Int32 CodCobranza = 0;
            string Cliente = "";
            string Descripción = "";
            Clases.cMovimiento mov = new Clases.cMovimiento();

            foreach (DataGridViewRow r in GrillaDeuda.Rows)
            {
                if (i<Filas)
                {
                    if (Convert.ToBoolean(r.Cells["Cobrar"].Value) == true)
                    {
                        CodCobranza = Convert.ToInt32 (r.Cells[1].Value.ToString());
                        Saldo = Convert.ToDouble(fun.FormatoEnteroMiles(r.Cells[7].Value.ToString()));
                        Cliente = r.Cells[4].Value.ToString();
                        Descripción = "Pago de deuda " + Cliente;
                        if (Importe >=Saldo && Importe >0)
                        {
                            Cobranza.RegistrarCobro(CodCobranza, Fecha, Saldo);
                            Importe = Importe - Saldo;
                            b = 1;
                            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado, Saldo, 0, 0, 0, 0, Fecha, Descripción);
                        }
                        else
                        {
                            Cobranza.RegistrarCobro(CodCobranza, Fecha, Importe);
                            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado, Importe, 0, 0, 0, 0, Fecha, Descripción);
                            Importe = 0;
                            b = 1;
                        }
                       
                        
                    }
                }
                i++;
               
            }
            if (b==1)
            {
                MessageBox.Show("Datos grabados correctamente ");
                if (Principal.CodCliente != null)
                {
                    Int32 CodCliente = Convert.ToInt32(Principal.CodCliente);
                    BuscarDeuda(CodCliente);
                    if (CodCliente > 0)
                    {
                        Double? ImportePagado = fun.ToDouble(txtImporte.Text);
                        Principal.CodCliente = CodCliente;
                        Principal.Importe = ImportePagado;
                        FrmRecibo rec = new FrmRecibo();
                        rec.ShowDialog();
                        Principal.CodCliente = null;

                    }
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
