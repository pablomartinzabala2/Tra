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
    public partial class FrmResumenDeuda : Form
    {
        public FrmResumenDeuda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            cCobranzaGeneral cob = new Clases.cCobranzaGeneral();
            int? CodMoneda = null;
            if (cmbMoneda.SelectedIndex > 0)
                CodMoneda = Convert.ToInt32(cmbMoneda.SelectedValue);
            string Apellido = "";
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;
            Int32? CodVendedor = null;
            DateTime FechaHoy = DateTime.Now;
            if (CmbVendedor.SelectedIndex > 0)
                CodVendedor = Convert.ToInt32(CmbVendedor.SelectedValue);
            DataTable trdo = cob.GetDeudaCliente(Apellido, CodMoneda , CodVendedor,FechaHoy);
            ArmarTabla(trdo);
        }

        private void ArmarTabla(DataTable trdo)
        {
            cFunciones fun = new cFunciones();
            Int32 CodCliente = 0;
            Double SaldoPesos = 0;
            Double SaldoDolares = 0;
            Double Pesos = 0;
            Double Dolares = 0;
            string Val = "";
            cCliente cli = new cCliente();
            string Responsable = "";
            string FechaVto = "";
            string UltimaFecha = "";
            string Tipo = "";
            cCobranzaGeneral cob = new cCobranzaGeneral();
            //ultima fecha es para sacar la ulitam fecha del contacto
            string Col = "CodCliente;Cliente;Apellido;Telefono;Pesos;Dolares;Responsable;FechaVto;UltimaFecha;Tipo";
            DataTable tbDeudores = fun.CrearTabla(Col);
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                CodCliente = Convert.ToInt32(trdo.Rows[i]["CodCliente"]);
                Tipo = cob.GetTipo(CodCliente);
                FechaVto = GetFechaCompromiso(CodCliente);
                Responsable = cli.GetVendedorxCodCliente(CodCliente);
                SaldoPesos = GetSaldo(CodCliente, "Pesos", trdo);
                SaldoDolares = GetSaldo(CodCliente, "Dolares", trdo);
                UltimaFecha = GetUltimaFecha(CodCliente);
                if (Buscar (tbDeudores ,CodCliente)==0)
                {
                    Val = CodCliente.ToString();
                    Val = Val + ";" + trdo.Rows[i]["Cliente"].ToString();
                    Val = Val + ";" + trdo.Rows[i]["Apellido"].ToString();
                    Val = Val + ";" + trdo.Rows[i]["Telefono"].ToString();
                    Val = Val + ";" + SaldoPesos.ToString();
                    Val = Val + ";" + SaldoDolares.ToString();
                    Val = Val + ";" + Responsable.ToString();
                    Val = Val + ";" + FechaVto;
                    Val = Val + ";" + UltimaFecha;
                    Val = Val + ";" + Tipo;
                    tbDeudores = fun.AgregarFilas(tbDeudores, Val);
                }
                        
            }
            Pesos = fun.TotalizarColumna(tbDeudores, "Pesos");
            Dolares = fun.TotalizarColumna(tbDeudores, "Dolares");
            txtTotalPesos.Text = fun.FormatoEnteroMiles(Pesos.ToString());
            txtTotalDolares.Text = fun.FormatoEnteroMiles(Dolares.ToString());
            tbDeudores = fun.TablaaMiles(tbDeudores, "Pesos");
            tbDeudores = fun.TablaaMiles(tbDeudores, "Dolares");
            string AnchoCol = "0;15;0;15;10;15;15;10;10;10";
            Grilla.DataSource = tbDeudores;
            fun.AnchoColumnas(Grilla, AnchoCol);
            Grilla.Columns[8].HeaderText = "Contacto ";
            PintarGrilla();
        }

        private string GetUltimaFecha(Int32 CodCliente)
        {
            string Fecha = "";
            cMensajeCliente msj = new cMensajeCliente();
            Fecha = msj.GetUltimaFecha(CodCliente);
            return Fecha;
        }

        private void PintarGrilla()
        {
            DateTime FechaHOy = DateTime.Now;
            DateTime Fecha = DateTime.Now;
            int b = 0;
            for (int i = 0; i < Grilla.Rows.Count -1 ; i++)
            {
                Fecha = Convert.ToDateTime(Grilla.Rows[i].Cells[7].Value.ToString());
                if (Fecha < FechaHOy)
                {
                    // Grilla.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    b = 1;
                }

                if (b ==0)
                {
                    if (Fecha.Month ==FechaHOy.Month)
                    {
                        if (Fecha.Year ==FechaHOy.Year)
                        {
                            Grilla.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }


                b = 0;
            }
        }

        private string GetFechaCompromiso(Int32 CodCliente)
        {
            cCobranzaGeneral cob = new cCobranzaGeneral();
            string Fecha = cob.GetMenorFechaVencimiento(CodCliente);
            return Fecha;
        }

        private Double GetSaldo (Int32 CodCliente, string Moneda , DataTable trdo)
        {
            Int32 CodCli = 0;
            Double Saldo = 0;
            string Money = "";
      
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                if(trdo.Rows[i]["CodCliente"].ToString()!="")
                    CodCli = Convert.ToInt32(trdo.Rows[i]["CodCliente"].ToString());
                Money = trdo.Rows[i]["Moneda"].ToString();
                if (CodCli == CodCliente && Money ==Moneda)
                {
                    if (trdo.Rows[i]["Saldo"].ToString ()!="")
                    {
                        Saldo = Convert.ToDouble(trdo.Rows[i]["Saldo"].ToString());
                    }
                }
            }
            return Saldo;
        }

        public int Buscar(DataTable trdo ,Int32 CodCliente)
        {
            int b = 0;
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                if (trdo.Rows[i]["CodCliente"].ToString ()==CodCliente.ToString ())
                {
                    b = 1;
                }
            }

            return b;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.Rows.Count.ToString()=="0")
            {
                MessageBox.Show("Debe seleccionar un registro para continuar");
                return;
            }
            int Orden = 1;
            string Cliente = "";
            string Telefono = "";
            string Pesos = "";
            string Dolares = "";
            cReporte reporte = new cReporte();
            reporte.Borrar();
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Cliente = Grilla.Rows[i].Cells[1].Value.ToString();
                Telefono = Grilla.Rows[i].Cells[3].Value.ToString();
                Pesos = Grilla.Rows[i].Cells[4].Value.ToString();
                Dolares = Grilla.Rows[i].Cells[5].Value.ToString();
                reporte.Insertar(Orden, Cliente, Telefono,
                    Pesos, Dolares, txtTotalPesos.Text, txtTotalDolares.Text, "",
                    "", "", "", "", "", "", "");
            }

            FrmReporteDeudaCliente frm = new FrmReporteDeudaCliente();
            frm.Show();

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Sistema");
                return;
            }

            cFunciones fun = new cFunciones();
            Double SaldoPesos = 0;
            Double SaldoDolares = 0;
            string TextoSaldos = "";
            Int32 CodCliente = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            DateTime FechaHoy = DateTime.Now;
            cCobranzaGeneral cob = new cCobranzaGeneral();
            DataTable trdo = cob.GetDedudaCobranzaGeneralDetalladaxCodCliente("", "",FechaHoy  ,"", null, null, CodCliente);
            SaldoPesos = GetTotalxMoneda(trdo, "Pesos");
            SaldoDolares = GetTotalxMoneda(trdo, "Dolares");
            cReporte reporte = new cReporte();
            //obtiene la leyenda de cuanto debe
            TextoSaldos = LeyendaSaldo(SaldoPesos, SaldoDolares);
            reporte.Borrar();
            int orden = 1;
            string Vencimiento = "";
            string Descripcion = "";
            string Cliente = "";
            string Saldo = "";
            string Moneda = "";
            string Importe = "";
            string Cuota = "";
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                Cliente = trdo.Rows[i]["Cliente"].ToString();
                Cuota = trdo.Rows[i]["Cuota"].ToString();
                Descripcion = trdo.Rows[i]["Descripcion"].ToString();
                if (Cuota !="")
                {
                    Descripcion = Descripcion + " Cuota " + Cuota; 
                }
                Vencimiento = trdo.Rows[i]["FechaCompromiso"].ToString();
                if (Vencimiento.Length > 8)
                    Vencimiento = Vencimiento.Substring(0, 10);
                Importe = trdo.Rows[i]["Importe"].ToString();
                Saldo = trdo.Rows[i]["Saldo"].ToString();
                //parte 8 tiene la leyenda de los saldos
                Moneda = trdo.Rows[i]["Moneda"].ToString();
                reporte.Insertar(orden, Cliente, Vencimiento, Descripcion, Importe, Saldo, Moneda, TextoSaldos, "", "", "", "", "", "", "");
                orden++;
            }
            FrmDetalleDeudaxCliente frm = new FrmDetalleDeudaxCliente();
            frm.Show();
        }

        public Double GetTotalxMoneda(DataTable trdo , string Moneda)
        {
            Double Saldo = 0;
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                if (trdo.Rows[i]["Moneda"].ToString ()== Moneda)
                {
                    Saldo = Saldo + Convert.ToDouble(trdo.Rows[i]["Saldo"]);
                }
            }
            return Saldo;
        }

        public string LeyendaSaldo(Double Pesos, Double Dolares)
        {
            cFunciones fun = new Clases.cFunciones();
            string Texto = "Saldo Total ";
            string sPesos = "";
            string sDolares = "";
            if (Pesos >0)
            {
                sPesos = fun.FormatoEnteroMiles(Pesos.ToString());
                Texto = Texto + " Pesos: " + sPesos;
            }

            if (Dolares > 0)
            {
                sDolares = fun.FormatoEnteroMiles(Dolares.ToString());
                Texto = Texto + " Dolares: " + sDolares;
            }

            return Texto;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            Int32 CodCliente = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodCliente = CodCliente;
            FrmListadoDeudaCoibranzaxCliente form = new FrmListadoDeudaCoibranzaxCliente();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmResumenDeuda_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(cmbMoneda, "Moneda", "Nombre", "CodMoneda");
            CargarVendedor();
        }

        private void CargarVendedor()
        {
            cVendedor Vendedor = new cVendedor();
            DataTable trdo = Vendedor.GetVendedores();
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable (CmbVendedor, trdo, "Apellido", "CodVendedor");

        }

        private void btnMensaje_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            Int32 CodCliente = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodCliente = CodCliente;
            FrmMensajeCliente frm = new FrmMensajeCliente();
            frm.Show();
        }
    }
}
