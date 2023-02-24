using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Concesionaria.Clases
{
    public class cMovimientoProveedor
    {
        public void InsertarTran(SqlConnection con, SqlTransaction Transaccion,
            Int32 CodCuentaProveedor, DateTime Fecha, string Concepto,Double Debe, Double Haber,Double Saldo)
        {
            string sql = "insert into MovimientoProveedor(CodCuentaProveedor,Fecha,Concepto,";
            sql = sql + "Debe,Haber,Saldo)";
            sql = sql + " values (" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + "," + Saldo.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void Insertar(
           Int32 CodCuentaProveedor, DateTime Fecha, string Concepto, Double Debe, Double Haber,Double Saldo )
        {

            string sql = "insert into MovimientoProveedor(CodCuentaProveedor,Fecha,Concepto,";
            sql = sql + "Debe,Haber,Saldo)";
            sql = sql + " values (" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + "," + Saldo.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

       public DataTable GetResumen(Int32 CodCuentaProveedor)
        {
            Double Saldo = 0;
            Saldo = GetSaldo(CodCuentaProveedor);
            string sql = " select 0,'' as Fecha,'',0,0"; 
            sql = sql + "," + Saldo.ToString().Replace(",", ".") + " as Saldo ";
            sql = sql + " union ";
            sql = sql + "select CodCuentaProveedor,Fecha,Concepto,Debe,Haber, Saldo";
            sql = sql + " from MovimientoProveedor ";
            sql = sql + " where CodCuentaProveedor=" + CodCuentaProveedor.ToString();
            sql = sql + " order by Fecha asc ";
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetSaldo(Int32 CodCuenta)
        {
            Double Saldo = 0;
            string sql = "select isnull(Saldo,0) as Saldo from CuentaProveedor ";
            sql = sql + " where CodCuenta=" + CodCuenta.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Saldo"].ToString ()!="")
                {
                    Saldo = Convert.ToDouble(trdo.Rows[0]["Saldo"].ToString());
                }
            }
            return Saldo;
        }
    }
}
