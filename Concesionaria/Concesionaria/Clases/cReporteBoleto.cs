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
            string Importe, string Gasto , string TotalVenta,  string Saldo, string Patentamiento)
        {
            string sql = "insert into ReporteBoleto(";
            sql = sql + "CodVenta,Importe,Gasto,TotalVenta, Saldo,Patentamiento";
            sql = sql + ")";
            sql = sql + " Values(";
            sql = sql + CodVenta.ToString();
            sql = sql + "," + "'" + Importe + "'";
            sql = sql + "," + "'" + Gasto + "'";
            sql = sql + "," + "'" + TotalVenta + "'";
            sql = sql + "," + "'" + Saldo + "'";
            sql = sql + "," + "'" + Patentamiento + "'";
            sql = sql + ")"; 
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
