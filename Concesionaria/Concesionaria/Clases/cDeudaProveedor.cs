using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cDeudaProveedor
    {
        public void Insertar (Int32 CodCuentaProveedor, string COncepto,
            DateTime Fecha, DateTime FechaVto, Double Importe, string Observacion)
        {
            string sql = "Insert into DeudaProveedor(";
            sql = sql + "CodCuentaProveedor,COncepto,Fecha,FechaVto,Importe,Observacion,Saldo)";
            sql = sql + " values(" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + COncepto + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + FechaVto.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetDeuda(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select d.CodDeuda,p.Nombre as Proveedor,c.Nombre as Cuenta,d.Importe,d.Saldo,d.CodPago";
            sql = sql + " from CuentaProveedor c,Proveedor p,DeudaProveedor d";
            sql = sql + " where c.CodProveedor=p.CodProveedor";
            sql = sql + " and d.CodCuentaProveedor=c.CodCuenta "; 
            sql = sql + " and d.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and d.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by CodDeuda Desc ";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarSaldo(SqlConnection con, SqlTransaction Transaccion,Int32 CodDeuda,Double Importe,Int32 CodPago)
        {
            string sql = "update DeudaProveedor ";
            sql = sql + " set Saldo = Saldo -" + Importe.ToString().Replace(",", ".");
            sql = sql + ", CodPago =" + CodPago.ToString();
            sql = sql + " where CodDeuda =" + CodDeuda.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);

        }

        public void Anular(SqlConnection con, SqlTransaction Transaccion,Int32 CodPago)
        {
            string sql = " update DeudaProveedor ";
            sql = sql + " set Saldo = Importe ";
            sql = sql + " , CodPago = null ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void Borrrar(Int32 CodDeuda)
        {
            string sql = "delete from DeudaProveedor ";
            sql = sql + " where CodDeuda=" + CodDeuda.ToString();
            cDb.ExecutarNonQuery(sql);

        }
    }
}
