using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Concesionaria.Clases
{
    public class cTransferencia
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,Int32? CodVenta,
            Int32? CodBanco,string Numero, Double Importe,DateTime Fecha, Int32? CodRecibo)
        {
            string sql = "insert into transferencia(";
            sql = sql + "CodVenta,CodBanco,Numero,Importe,Fecha,CodRecibo)";
            sql = sql + " values(";
            if (CodVenta != null)
                sql = sql + CodVenta.ToString();
            else
                sql = sql + "null";
             
            if (CodBanco != null)
                sql = sql + "," + CodBanco.ToString();
            else
                sql = sql + ",null";

            sql = sql + "," + "'" + Numero + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            if (CodRecibo != null)
                sql = sql + "," + CodRecibo.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetTransferenciaxCodVenta(Int32 CodVenta)
        {
            string sql = " select t.CodBanco,b.Nombre,t.Numero,t.Importe";
            sql = sql + " from transferencia t, Banco b ";
            sql = sql + " where t.CodBanco = b.CodBanco ";
            sql = sql + " and t.CodVenta=" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
