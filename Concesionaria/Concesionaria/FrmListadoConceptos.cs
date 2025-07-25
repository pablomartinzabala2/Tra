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
    public partial class FrmListadoConceptos : FrmBase
    {
        public FrmListadoConceptos()
        {
            InitializeComponent();
        }

        private void FrmListadoConceptos_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            cFunciones fun = new cFunciones();
            string col = "CodConcepto;Nombre;Fecha;FechaVencimiento;Importe;Condicion;CostoFijo;Tipo";
            DataTable Tabla = fun.CrearTabla(col);
            cPago pago = new Clases.cPago();
            cConcepto concepto = new Clases.cConcepto();
            int CodConcepto = 0;
            string Nombre = "";
            string Condicion = "";
            string CostoFijo = "";
            string Val = "";
            DataTable trdo = concepto.GetConceptos();
            string Fecha = "";
            string FechaVencimiento = "";
            string Importe = "";
            string sImporte = "";
            string Tipo = "";
             
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                if (trdo.Rows[i]["CodConcepto"].ToString ()!="")
                {
                    CodConcepto = Convert.ToInt32(trdo.Rows[i]["CodConcepto"].ToString());
                    Nombre = trdo.Rows[i]["Nombre"].ToString();
                    DataTable tpago = pago.GetPagoxCodConcepto(CodConcepto);
                    if (tpago.Rows.Count >0)
                    {
                        Fecha = tpago.Rows[0]["Fecha"].ToString();
                        FechaVencimiento = tpago.Rows[0]["FechaVencimiento"].ToString();
                        sImporte = tpago.Rows[0]["Importe"].ToString();
                        string[] Vec = sImporte.Split(','); 
                        Importe = fun.FormatoEnteroMiles(Vec[0]);
                        Condicion = tpago.Rows[0]["Obligatorio"].ToString();
                        CostoFijo = tpago.Rows[0]["Costo"].ToString();
                        Tipo = tpago.Rows[0]["Nombre"].ToString();
                    }
                    else
                    {
                        Fecha = "";
                        FechaVencimiento = "";
                        Importe = "";
                        Condicion = "";
                        CostoFijo = "";
                        Tipo = "";
                    }
                    Val = CodConcepto.ToString() + ";" + Nombre;
                    Val = Val + ";" + Fecha + ";" + FechaVencimiento + ";" + Importe.ToString();
                    Val = Val + ";" + Condicion + ";" + CostoFijo + ";" + Tipo;
                    Tabla = fun.AgregarFilas(Tabla, Val);
                   // Tabla = fun.TablaaMiles(Tabla, "Importe");
                    Grilla.DataSource = Tabla;
                }
            }
            
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }

            int CodConcepto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Principal.Codigo = CodConcepto;
            FrmRegistrarPago frm = new FrmRegistrarPago();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();

        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Consultar();
        }


        private DataTable GetPagoxConcepto(int CodConcepto)
        {
            cPago pago = new Clases.cPago();
            DataTable tr = pago.GetPagoxCodConcepto(CodConcepto);
            return tr;
        }
    }
}
