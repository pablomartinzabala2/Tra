﻿using System;
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
    public partial class FrmControlGeneralOperaciones : Form
    {
        public FrmControlGeneralOperaciones()
        {
            InitializeComponent();
        }

        private void FrmControlGeneralOperaciones_Load(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArmarDataTableDeudores();
        }

        private void ArmarDataTableDeudores()
        {
            string Apellido = null;
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;
            Clases.cVenta objVenta = new Clases.cVenta();
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            Int32 CodVenta = 0;
            Double Cobranza = 0;
            Clases.cFunciones fun = new Clases.cFunciones();
            cCobranza objCobranza = new cCobranza();
            string Col = "CodVenta;Patente;Descripcion;Apellido;ImporteVenta;Cuotas;Cheque;Cobranza;Prenda;Telefono;Tipo";
            //Tipo se usa para saber a donde tiene que abrir
            Clases.cCuota cuota = new Clases.cCuota();
            Clases.cCheque objCheque = new Clases.cCheque();
            cPrenda objPrenda = new cPrenda();
            string telefono = "";
            int TieneDeuda = 0;
            Double Cuotas = 0;
            Double Prenda = 0;
            Double Cheque = 0;
            string val = "";
            int TipoPantalla = 1;
            DataTable tb = new DataTable();
            tb = fun.CrearTabla(Col);
            DataTable trdo = objVenta.GetVentasxFecha(FechaDesde, FechaHasta, txtPatente.Text.Trim(), Apellido);
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                CodVenta = Convert.ToInt32(trdo.Rows[i]["CodVenta"].ToString());
                TieneDeuda = objVenta.TieneDeuda(CodVenta);
                if (TieneDeuda == 1)
                {
                    Cuotas = cuota.GetSaldoDeudaCuotas(CodVenta);
                    Cheque = objCheque.GetSaldoCheque(CodVenta);
                    Cobranza = objCobranza.GetSaldoCobranza(CodVenta);
                    Prenda = objPrenda.ImporteAdeudado(CodVenta);
                    telefono = BuscarTelefonoCliente(CodVenta);
                    val = CodVenta.ToString();
                    val = val + ";" + trdo.Rows[i]["Patente"].ToString();
                    val = val + ";" + trdo.Rows[i]["Descripcion"].ToString();
                    val = val + ";" + trdo.Rows[i]["Apellido"].ToString();
                    val = val + ";" + trdo.Rows[i]["ImporteVenta"].ToString();
                    val = val + ";" + Cuotas.ToString();
                    val = val + ";" + Cheque.ToString();
                    val = val + ";" + Cobranza.ToString();
                    val = val + ";" + Prenda.ToString();
                    val = val + ";" + telefono.ToString();
                    val = val + ";" + TipoPantalla.ToString();
                    tb = fun.AgregarFilas(tb, val);
                }
            }
            TipoPantalla = 2;
            //agrego las cuotas anteriores
            cCuotasAnteriores cuotasAnt = new cCuotasAnteriores();
            DataTable tcuotasAnt = cuotasAnt.GetCuotasAnterioresAdeudadesxFecha(txtPatente.Text, txtApellido.Text, FechaDesde, FechaHasta);
            for (int i = 0; i < tcuotasAnt.Rows.Count; i++)
            {
                val = tcuotasAnt.Rows[i]["CodGrupo"].ToString();
                val = val + ";" + tcuotasAnt.Rows[i]["Patente"].ToString();
                val = val + ";" + tcuotasAnt.Rows[i]["Descripcion"].ToString();
                val = val + ";" + tcuotasAnt.Rows[i]["Apellido"].ToString();
                val = val + ";" + tcuotasAnt.Rows[i]["Importe"].ToString();
                val = val + ";";
                val = val + ";";
                val = val + ";";
                val = val + ";";
                val = val + ";" + tcuotasAnt.Rows[i]["Telefono"].ToString();
                val = val + ";" + TipoPantalla.ToString();
                tb = fun.AgregarFilas(tb, val);

            }
            TipoPantalla = 3;
            //Cobranza general 
            cCobranzaGeneral cobGen = new cCobranzaGeneral();
            DataTable tbCobGen = cobGen.GetDedudaCobranzaGeneralxFecha(Apellido, txtPatente.Text, FechaDesde, FechaHasta);
            for (int i = 0; i < tbCobGen.Rows.Count; i++)
            {
                val = tbCobGen.Rows[i]["CodCobranza"].ToString();
                val = val + ";" + tbCobGen.Rows[i]["Patente"].ToString();
                val = val + ";" + tbCobGen.Rows[i]["Descripcion"].ToString();
                val = val + ";" + tbCobGen.Rows[i]["Cliente"].ToString();
                val = val + ";" + tbCobGen.Rows[i]["Importe"].ToString();
                val = val + ";" + tbCobGen.Rows[i]["Importe"].ToString();
                val = val + ";";
                val = val + ";" + tbCobGen.Rows[i]["Importe"].ToString();
                val = val + ";";
                val = val + ";" + tbCobGen.Rows[i]["Telefono"].ToString();
                val = val + ";" + TipoPantalla.ToString();
                tb = fun.AgregarFilas(tb, val);

            }
            // 

            Double TotalVenta = fun.TotalizarColumna(tb, "ImporteVenta");
            Double TotalCuotas = fun.TotalizarColumna(tb, "Cuotas");
            Double TotalPrenda = fun.TotalizarColumna(tb, "Prenda");
            Double TotalCobranza = fun.TotalizarColumna(tb, "Cobranza");
            Double TotalCheque = fun.TotalizarColumna(tb, "Cheque");
            val = "";
            val = val + ";";
            val = val + ";";
            val = val + ";";
            val = val + ";" + TotalVenta.ToString();
            val = val + ";" + TotalCuotas.ToString();
            val = val + ";" + TotalCheque.ToString();
            val = val + ";" + TotalCobranza.ToString();
            val = val + ";" + TotalPrenda.ToString();
            val = val + ";" + telefono.ToString();
            tb = fun.AgregarFilas(tb, val);

            tb = fun.TablaaMiles(tb, "ImporteVenta");
            tb = fun.TablaaMiles(tb, "Cuotas");
            tb = fun.TablaaMiles(tb, "Cheque");
            tb = fun.TablaaMiles(tb, "Cobranza");
            tb = fun.TablaaMiles(tb, "Prenda");
            Grilla.DataSource = tb;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[10].Visible = false;
            Grilla.Columns[4].HeaderText = "Total";
            Grilla.Columns[5].HeaderText = "Documentos";
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                if (i == (Grilla.Rows.Count - 2))
                    Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        //Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
        private string BuscarTelefonoCliente(Int32 CodVenta)
        {
            string telefono = "";
            cVenta venta = new cVenta();
            DataTable tbventa = venta.GetVentaxCodigo(CodVenta);
            if (tbventa.Rows.Count > 0)
            {
                if (tbventa.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCli = Convert.ToInt32(tbventa.Rows[0]["CodCliente"].ToString());
                    cCliente cli = new cCliente();
                    DataTable tcli = cli.GetClientesxCodigo(CodCli);
                    if (tcli.Rows.Count > 0)
                    {
                        telefono = tcli.Rows[0]["Telefono"].ToString();
                    }
                }
            }
            return telefono;
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una fila", "Sistema");
                return;
            }

            if (Grilla.CurrentRow.Cells[0].Value.ToString() == "")
            {
                return;
            }
            string Tipo = Grilla.CurrentRow.Cells[10].Value.ToString();
            if (Tipo == "1")
            {
                string CodVenta = Grilla.CurrentRow.Cells[0].Value.ToString();
                Principal.CodigoPrincipalAbm = CodVenta;
                Principal.CodigoSenia = null;
                FrmVenta form = new FrmVenta();
                form.ShowDialog();
            }
            if (Tipo == "2")
            {
                string CodGrupo = Grilla.CurrentRow.Cells[0].Value.ToString();
                Principal.CodigoPrincipalAbm = CodGrupo;
                Principal.CodigoSenia = null;
                FrmDocumentosAnteriores form = new FrmDocumentosAnteriores();
                form.ShowDialog();
            }


        }
    }
}
