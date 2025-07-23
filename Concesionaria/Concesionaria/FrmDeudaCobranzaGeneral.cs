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
    public partial class FrmDeudaCobranzaGeneral : Form
    {
        public FrmDeudaCobranzaGeneral()
        {
            InitializeComponent();
        }

        private void FrmDeudaCobranzaGeneral_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            dpFecha.Value = DateTime.Now;
            lblVencidas.BackColor = Color.LightGreen;
            CargarComboSaldo();
            fun.LlenarCombo(CmbMoneda, "Moneda", "Nombre", "CodMoneda");
            Buscar();
        }

        private void CargarComboSaldo()
        {
            cFunciones fun = new cFunciones();
            DataTable tb = fun.CrearTabla("Codigo;Nombre");
            tb = fun.AgregarFilas(tb, "1;Saldo Asc");
            tb = fun.AgregarFilas(tb, "2;Saldo Desc");
            fun.LlenarComboDatatable(cmbOrdenSaldo, tb, "Nombre", "Codigo");
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            int ConDeuda = 0;
            if (ChkVencida.Checked == true)
                ConDeuda = 1;

            Int32? CodMoneda = null;
            Clases.cFunciones fun = new Clases.cFunciones();
            //   DataTable tResul = fun.CrearTabla("Codigo;Tipo;Cuota;Patente;Descripcion;Apellido;Telefono;Celular;Importe;Saldo;Vencimiento");
            //  DataTable tResul = fun.CrearTabla("Codigo;Tipo;Cuota;Patente;Descripcion;Apellido;Telefono;Celular;Importe;Saldo");

            if (CmbMoneda.SelectedIndex > 0)
                CodMoneda = Convert.ToInt32(CmbMoneda.SelectedValue);

            string Descripcion = "";
            if (txtDescripcion.Text != "")
                Descripcion = txtDescripcion.Text;

            DateTime Fecha = dpFecha.Value;

            Int32? OrdenSaldo = null;
            if (cmbOrdenSaldo.SelectedIndex > 0)
                OrdenSaldo = Convert.ToInt32(cmbOrdenSaldo.SelectedValue);

            string Valor = "";
          
            //de aca en adelante agregar el apellido y nombre concatenado..
            cCobranzaGeneral cobGen = new cCobranzaGeneral();
            //GetDedudaCobranzaGeneralDetallada
          //  DataTable tResul = cobGen.GetDedudaCobranzaGeneral(txtApellido.Text, txtPatente.Text, Fecha, Descripcion);
            DataTable tResul = cobGen.GetDedudaCobranzaGeneralDetallada(txtApellido.Text, txtPatente.Text, Fecha, Descripcion, CodMoneda, OrdenSaldo);
            /*
            for (int i = 0; i < tCobGen.Rows.Count; i++)
            {
                Valor = tCobGen.Rows[i]["CodCobranza"].ToString();
                Valor = Valor + ";" + "Cobranza General";
                Valor = Valor + ";1";
                Valor = Valor + ";" + tCobGen.Rows[i]["Patente"].ToString();
                Valor = Valor + ";" + tCobGen.Rows[i]["Descripcion"].ToString();
                Valor = Valor + ";" + tCobGen.Rows[i]["Cliente"].ToString();
                Valor = Valor + ";" + tCobGen.Rows[i]["Telefono"].ToString();
                Valor = Valor + ";";
                Valor = Valor + ";" + tCobGen.Rows[i]["Importe"].ToString();
                Valor = Valor + ";" + tCobGen.Rows[i]["Saldo"].ToString();
                Valor = Valor + ";" + tCobGen.Rows[i]["FechaCompromiso"].ToString();
                tResul = fun.AgregarFilas(tResul, Valor);
            }
           */

            Double TotalImporte = 0;
            Double TotalSaldo = 0;
            TotalImporte = fun.TotalizarColumna(tResul, "Importe");
            TotalSaldo = fun.TotalizarColumna(tResul, "Saldo");

            Valor = "1;" + "Total;01/01/1900;";
            Valor = Valor + ";";
            Valor = Valor + ";" + TotalImporte.ToString();
            Valor = Valor + ";" + TotalSaldo.ToString();
            Valor = Valor + ";;";
            tResul = fun.AgregarFilas(tResul, Valor);
            tResul = fun.TablaaMiles(tResul, "Importe");
            tResul = fun.TablaaMiles(tResul, "Saldo");

            Grilla.DataSource = tResul;
            //Grilla.DataSource = dv;
            fun.AnchoColumnas(Grilla, "0;0;10;22;23;10;10;10;10;5");
            Pintar();
            /*
            Grilla.Columns["Apellido"].DisplayIndex = 1;
            Grilla.Columns["Telefono"].DisplayIndex = 2;
            //Pintar();
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                if (i == (Grilla.Rows.Count - 2))
                    Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            Grilla.Columns[5].HeaderText = "Cliente";
            */
        }

        private void Pintar()
        {
            cFunciones fun = new cFunciones();
            Double Saldo = 0;
            DateTime Fecha = DateTime.Now;
            DateTime FechaCompromiso = DateTime.Now;
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                if (Grilla.Rows[i].Cells[2].Value.ToString ()!="")
                {
                    FechaCompromiso = Convert.ToDateTime(Grilla.Rows[i].Cells[2].Value.ToString());
                }

                if (Grilla.Rows[i].Cells[6].Value.ToString() != "")
                { 
                    Saldo =fun.ToDouble(Grilla.Rows[i].Cells[6].Value.ToString());
                }

                if (FechaCompromiso < Fecha && Saldo >0)
                {
                    Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }

              //  if (i == (Grilla.Rows.Count - 2))
              //      Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void btnCobroPrenda_Click(object sender, EventArgs e)
        {    
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro para continuar");
                return;
            }
            
            string CodidoCobranza = Grilla.CurrentRow.Cells[0].Value.ToString();
            Principal.CodigoPrincipalAbm = CodidoCobranza.ToString();
            FrmRegistrarCobroCobranzasGenerales FrmCob = new FrmRegistrarCobroCobranzasGenerales();
            FrmCob.ShowDialog();
          
        }

        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            cReporte Reporte = new Clases.cReporte();
            Reporte.Borrar();
            string Cliente = "";
            string Descripcion = "";
            string Patente = "";
            string Importe = "";
            string Saldo = "";
            string Vencimiento = "";
            int Orden = 1;
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Cliente = Grilla.Rows[i].Cells[3].Value.ToString();
                Descripcion = Grilla.Rows[i].Cells[4].Value.ToString();
                Patente = Grilla.Rows[i].Cells[2].Value.ToString();
                Importe = Grilla.Rows[i].Cells[5].Value.ToString();
                Saldo = Grilla.Rows[i].Cells[6].Value.ToString();
                Vencimiento = Grilla.Rows[i].Cells[2].Value.ToString();
                if (Vencimiento.Length > 10)
                    Vencimiento = Vencimiento.Substring(0, 10);
                Reporte.Insertar(Orden, Vencimiento, Cliente, Descripcion, Patente, Importe, Saldo,  "",
                    "", "", "","", "", "", "");
            }

            FrmReporteControlOperaciones frm = new FrmReporteControlOperaciones();
            frm.Show();
        }
    }
}
