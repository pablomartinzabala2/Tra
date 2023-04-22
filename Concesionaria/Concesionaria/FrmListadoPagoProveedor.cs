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
    public partial class FrmListadoPagoProveedor : FormularioBase
    {
        public FrmListadoPagoProveedor()
        {
            InitializeComponent();
        }

        private void FrmListadoPagoProveedor_Load(object sender, EventArgs e)
        {
            InicializarFechas();
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

        private void Buscar ()
        {
            cFunciones fun = new cFunciones();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            cPagoProveedor pago = new Clases.cPagoProveedor();
            DataTable trdo = pago.Buscar(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Efectivo");
            trdo = fun.TablaaMiles(trdo, "ImportaCheque");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;10;20;20;30;10;0;10");
            Grilla.Columns[7].HeaderText = "Cheque ";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow==null)
            {
                Msj("Debe seleccionar un elemento ");
                return;
            }

            string msj = "Confirma anular el pago ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            Int32 CodPago = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cPagoProveedor pago = new cPagoProveedor();
            DataTable trdo = pago.GetPagoxCodigo(CodPago);
            Double Efectivo = 0;
            if (trdo.Rows.Count >0)
            {
                Efectivo = Convert.ToDouble(trdo.Rows[0]["Efectivo"].ToString());
            }
           
            cDeudaProveedor deuda = new cDeudaProveedor();
            cDeudaProveedor Deuda = new Clases.cDeudaProveedor();
            cMovimiento mov = new cMovimiento();
            cMovimientoProveedor movProv = new cMovimientoProveedor();
            movProv.BorrarMovimientoxCodPago(CodPago);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();

            try
            {
                pago.Borrar(con, Transaccion, CodPago);
                deuda.Anular(con, Transaccion, CodPago);
                if (Efectivo >0)
                {
                    mov.RegistrarMovimientoDescripcionTransaccion(con, Transaccion, 0, Principal.CodUsuarioLogueado, Efectivo, 0, 0, 0, 0, DateTime.Now, "Pago Anulado", 0);
                    
                }
                Transaccion.Commit();
                con.Close();
                Buscar();
                Msj("Datos procesados correctamente ");
               
            }
            catch (Exception Ex)
            {
                string Mensaje = Ex.Message.ToString();
                Transaccion.Rollback();
                con.Close();
            }
        }

        
    }
}
