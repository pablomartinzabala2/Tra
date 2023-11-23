using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Concesionaria.Clases
{
    public class cResponsable
    {
        public void Insertar (SqlConnection con, SqlTransaction Transaccion,string Nombre,string Apellido,
            string Concepto, string Telefono, Int32 CodCliente)
        {
            string sql = "insert into Responsable (Nombre,Apellido,Concepto,telefono,CodCliente)";
            sql = sql + " values (";
            sql = sql + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Concepto  + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + ","  + "'" + CodCliente.ToString () + "'";
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetResponsable(Int32 CodCliente)
        {
            string sql = " select * ";
            sql = sql + " from Responsable ";
            sql = sql + " where CodCliente =" + CodCliente.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void Borrar (Int32 CodResponsable)
        {
            string sql = "delete from Responsable ";
            sql = sql + " where CodResponsable =" + CodResponsable.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
