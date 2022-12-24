using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    class cReportePresupuesto
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,Int32 CodPresupuesto,string Campo1,
            string Campo2, string Campo3, string Campo4, int Orden )
        {
            string sql = "insert into ReportePresupuesto(";
            sql = sql + "CodPresupuesto,Campo1,Campo2,Campo3,Campo4,Orden)";
            sql = sql + " Values (" + CodPresupuesto.ToString();
            sql = sql + "," + "'" + Campo1 + "'";
            sql = sql + "," + "'" + Campo2 + "'";
            sql = sql + "," + "'" + Campo3 + "'";
            sql = sql + "," + "'" + Campo4 + "'";
            sql = sql + "," + Orden.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
