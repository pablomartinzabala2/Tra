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
    public partial class FrmConsultaMovimientoCaja : Form
    {
        cFunciones fun;
        public FrmConsultaMovimientoCaja()
        {
            InitializeComponent();
        }

        private void FrmConsultaMovimientoCaja_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            InicializarFecha();
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            CargarGrilla(FechaDesde, FechaHasta);

        }

        private void InicializarFecha()
        {
            DateTime Hoy = DateTime.Now;
            dpFechaHasta.Value = Hoy;
            int Mes = Hoy.Month;
            int anio = Hoy.Year;
            DateTime FechaInicio = Convert.ToDateTime(("01/" + Mes.ToString() + "/" + anio.ToString()));
            dpFechaDesde.Value = FechaInicio;

        }

        private void CargarGrilla(DateTime FechaDesde,DateTime FechaHasta)
        {
            Double Ingreso = 0, Egreso = 0, Saldo = 0;
            cMovimientoCaja mov = new cMovimientoCaja();
            DataTable trdo = mov.GetMovimientoxFecha(FechaDesde, FechaHasta);
            Ingreso = fun.TotalizarColumna(trdo, "ImporteIngreso");
            Egreso = fun.TotalizarColumna(trdo, "ImporteEgreso");
            Saldo = Ingreso - Egreso;
            trdo = fun.TablaaMiles(trdo, "ImporteIngreso");
            trdo = fun.TablaaMiles(trdo, "ImporteEgreso");
            Grilla.DataSource = trdo;
            Grilla.Columns[6].HeaderText = "Ingreso";
            Grilla.Columns[7].HeaderText = "Egreso";
            fun.AnchoColumnas(Grilla, "0;15;20;15;15;15;10;10");
            txtIngresos.Text = fun.FormatoEnteroMiles(Ingreso.ToString());
            txtEgresos.Text = fun.FormatoEnteroMiles(Egreso.ToString());
            txtSaldo.Text = fun.FormatoEnteroMiles(Saldo.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            CargarGrilla(FechaDesde, FechaHasta);
        }
    }
}
