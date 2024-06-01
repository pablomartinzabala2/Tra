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
            dpFecha.Value = DateTime.Now;
            lblVencidas.BackColor = Color.LightGreen;
            Buscar();
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
            Clases.cFunciones fun = new Clases.cFunciones();
           //   DataTable tResul = fun.CrearTabla("Codigo;Tipo;Cuota;Patente;Descripcion;Apellido;Telefono;Celular;Importe;Saldo;Vencimiento");
          //  DataTable tResul = fun.CrearTabla("Codigo;Tipo;Cuota;Patente;Descripcion;Apellido;Telefono;Celular;Importe;Saldo");

            string Descripcion = "";
            if (txtDescripcion.Text != "")
                Descripcion = txtDescripcion.Text;

            DateTime Fecha = dpFecha.Value;
            string Valor = "";
          
            //de aca en adelante agregar el apellido y nombre concatenado..
            cCobranzaGeneral cobGen = new cCobranzaGeneral();
            //GetDedudaCobranzaGeneralDetallada
          //  DataTable tResul = cobGen.GetDedudaCobranzaGeneral(txtApellido.Text, txtPatente.Text, Fecha, Descripcion);
            DataTable tResul = cobGen.GetDedudaCobranzaGeneralDetallada(txtApellido.Text, txtPatente.Text, Fecha, Descripcion);
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

            Valor = "1;" + "Total";
            Valor = Valor + ";;;;";
            Valor = Valor + ";" + TotalImporte.ToString();
            Valor = Valor + ";" + TotalSaldo.ToString();
            Valor = Valor + ";01/01/1900";
            tResul = fun.AgregarFilas(tResul, Valor);
            tResul = fun.TablaaMiles(tResul, "Importe");
            tResul = fun.TablaaMiles(tResul, "Saldo");

            Grilla.DataSource = tResul;
            //Grilla.DataSource = dv;
            fun.AnchoColumnas(Grilla, "0;0;0;30;30;10;10;10;10");
          
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
    }
}
