using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    public  class cPagoProveedor
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,Double Efectivo, string Concepto)
        {
            string sql = "insert into PagoProveedor(";
            sql = sql + "Fecha,Efectivo,Concepto)";
            sql = sql + " values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion (con, Transaccion, sql);
        }
    }
}
