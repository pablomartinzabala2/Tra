using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cVentaxCliente
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta, Int32 CodCliente)
        {
            string sql = "insert into VentaxCliente (CodVenta, CodCliente)";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
