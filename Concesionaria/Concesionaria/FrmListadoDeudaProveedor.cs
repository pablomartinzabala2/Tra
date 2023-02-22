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
    public partial class FrmListadoDeudaProveedor : FormularioBase
    {
        public FrmListadoDeudaProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearDeudaProveedor fr = new FrmCrearDeudaProveedor();
            fr.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            Buscar(FechaDesde, FechaHasta);
        }

        private void Buscar(DateTime FechaDesde,DateTime FechaHasta)
        {
            cFunciones fun = new cFunciones();
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            DataTable trdo = Deuda.GetDeuda(FechaDesde, FechaHasta);
            trdo = fun.TablaaFechas(trdo, "Importe");
            trdo = fun.TablaaFechas(trdo, "Saldo");
            Grilla.DataSource = trdo;
            
            fun.AnchoColumnas(Grilla, "0;40;30;20;20");
        }

        private void FrmListadoDeudaProveedor_Load(object sender, EventArgs e)
        {
            InicializarFechas();
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            Buscar(FechaDesde, FechaHasta);
        }

        private void InicializarFechas()
        {
            DateTime Fecha = DateTime.Now;
            int dia = Fecha.Day;
            int Mes = Fecha.Month;
            Fecha = Fecha.AddDays(-dia);
            Fecha = Fecha.AddDays(1);
            dpFechaDesde.Value = Fecha;
            Fecha = Fecha.AddMonths(1);
            Fecha = Fecha.AddDays(-1);
            dpFechaHasta.Value = Fecha;
        }

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {

        }
    }
}
