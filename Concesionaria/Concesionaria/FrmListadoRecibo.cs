using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;
using System.Data.SqlClient;
namespace Concesionaria
{
    public partial class FrmListadoRecibo : FormularioBase
    {
        public FrmListadoRecibo()
        {
            InitializeComponent();
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

        private void FrmListadoRecibo_Load(object sender, EventArgs e)
        {
            InicializarFechas();
            Buscar();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar ()
        {
            DateTime FechaDesde = Convert.ToDateTime(dpFechaDesde.Value);
            DateTime FechaHasta = Convert.ToDateTime(dpFechaHasta.Value);
            string Nombre = "";
            if (txtNombre.Text != "")
                Nombre = txtNombre.Text;

            cFunciones fun = new cFunciones();
            cRecibo rec = new Clases.cRecibo();
            DataTable trdo = rec.GetRecibos(FechaDesde, FechaHasta, Nombre);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            string Val = "0;20;20;10;20;10;10;10";
            fun.AnchoColumnas(Grilla, Val);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRecibo frm = new Concesionaria.FrmRecibo();
            frm.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }

            Int32 CodRecibo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodRecibo = CodRecibo;
            FrmReporteRecibo frm = new FrmReporteRecibo();
            frm.Show();
            Principal.CodRecibo = null; 
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }

            string msj = "Confirma Borrar el recibo ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            cRecibo recibo = new Clases.cRecibo();
            Int32 COdRecibo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            Double Efectivo = 0;
            try
            {
                Efectivo = recibo.GetImporteRecibo(COdRecibo);
                if (Efectivo >0)
                {
                    cMovimiento mov = new cMovimiento();
                    mov.RegistrarMovimientoDescripcionTransaccion(con, Transaccion,
                        Principal.CodUsuarioLogueado, 0,-1* Efectivo, 0, 0, 0, 0, DateTime.Now, "Anulación de Recibo", 0);
                }
                recibo.Borrrar(con, Transaccion, COdRecibo);
                Transaccion.Commit();
                con.Close();
                Buscar();
            }
            catch (Exception)
            {
                Transaccion.Rollback();
                con.Close();
            }
           

        }
    }
}
