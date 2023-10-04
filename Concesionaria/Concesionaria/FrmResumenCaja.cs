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
    public partial class FrmResumenCaja : Form
    {
        public FrmResumenCaja()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime Desde = dpFechaDesde.Value;
            DateTime Hasta = dpFechaHasta.Value;
            cMovimientoCaja mov = new Clases.cMovimientoCaja();
            DataTable trdo = mov.GetResumenDiario(Desde, Hasta);
            trdo = fun.TablaaMiles(trdo, "Ingreso");
            trdo = fun.TablaaMiles(trdo, "Egreso");
          //  trdo = fun.TablaaFechas(trdo, "Fecha");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "30;35;35");
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

        private void FrmResumenCaja_Load(object sender, EventArgs e)
        {
            InicializarFecha();
            Buscar();
        }
    }
}
