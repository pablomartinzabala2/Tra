using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public  class cReporteBoleto
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion, int CodVenta,
            string Importe)
        {
            string sql = "insert into ReporteBoleto(";
            sql = sql + "CodVenta,Importe";
            sql = sql + ")";
            sql = sql + " Values(";
            sql = sql + CodVenta.ToString();
            sql = sql + "," + "'" + Importe + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
