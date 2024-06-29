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
            string Apellido = "";
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;
            DataTable trdo = cob.GetDeudaCliente(Apellido);
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
           
            string Col = "CodCliente;Cliente;Apellido;Telefono;Pesos;Dolares";
            DataTable tbDeudores = fun.CrearTabla(Col);
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                CodCliente = Convert.ToInt32(trdo.Rows[i]["CodCliente"]);
                SaldoPesos = GetSaldo(CodCliente, "Pesos", trdo);
                SaldoDolares = GetSaldo(CodCliente, "Dolares", trdo);
                if (Buscar (tbDeudores ,CodCliente)==0)
                {
                    Val = CodCliente.ToString();
                    Val = Val + ";" + trdo.Rows[i]["Cliente"].ToString();
                    Val = Val + ";" + trdo.Rows[i]["Apellido"].ToString();
                    Val = Val + ";" + trdo.Rows[i]["Telefono"].ToString();
                    Val = Val + ";" + SaldoPesos.ToString();
                    Val = Val + ";" + SaldoDolares.ToString();
                    tbDeudores = fun.AgregarFilas(tbDeudores, Val);
                }
                        
            }
            Pesos = fun.TotalizarColumna(tbDeudores, "Pesos");
            Dolares = fun.TotalizarColumna(tbDeudores, "Dolares");
            txtTotalPesos.Text = fun.FormatoEnteroMiles(Pesos.ToString());
            txtTotalDolares.Text = fun.FormatoEnteroMiles(Dolares.ToString());
            tbDeudores = fun.TablaaMiles(tbDeudores, "Pesos");
            tbDeudores = fun.TablaaMiles(tbDeudores, "Dolares");
            string AnchoCol = "0;45;0;15;20;20";
            Grilla.DataSource = tbDeudores;
            fun.AnchoColumnas(Grilla, AnchoCol);
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
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Cliente = Grilla.Rows[i].Cells[1].Value.ToString();
                Telefono = Grilla.Rows[i].Cells[3].Value.ToString();
                Pesos = Grilla.Rows[i].Cells[4].Value.ToString();
                Dolares = Grilla.Rows[i].Cells[5].Value.ToString();
                reporte.Insertar(Orden, Cliente, Telefono,
                    Pesos, Dolares, txtTotalPesos.Text, txtTotalDolares.Text, "",
                    "", "", "");
            }
        }
    }
}
