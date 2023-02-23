using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cMovimientoProveedor
    {
        public void InsertarTran(SqlConnection con, SqlTransaction Transaccion,
            Int32 CodCuentaProveedor, DateTime Fecha, string Concepto,Double Debe, Double Haber)
        {
            string sql = "insert into MovimientoProveedor(CodCuentaProveedor,Fecha,Concepto,";
            sql = sql + "Debe,Haber)";
            sql = sql + " values (" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void Insertar(
           Int32 CodCuentaProveedor, DateTime Fecha, string Concepto, Double Debe, Double Haber)
        {
            string sql = "insert into MovimientoProveedor(CodCuentaProveedor,Fecha,Concepto,";
            sql = sql + "Debe,Haber)";
            sql = sql + " values (" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }
    }
}
