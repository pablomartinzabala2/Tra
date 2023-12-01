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

        public DataTable GetClientexCodVenta(Int32 CodVenta)
        {
            string sql = "select c.CodCliente, c.NroDocumento,";
            sql = sql + "  (select t.Nombre from TipoDocumento t where t.CodTipoDoc=c.CodTipoDoc) as TipoDoc ";
            sql = sql + "  ,c.Nombre , c.Apellido ";
            sql = sql + " from VentaxCliente v , cliente c ";
            sql = sql + " where v.CodCliente = c.CodCliente ";
            sql = sql + " and v.CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
