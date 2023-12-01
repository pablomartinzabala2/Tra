using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Concesionaria.Clases
{
    public  class cMensajeVenta
    {
        public void Insertar(string Mensaje, Int32 CodVenta)
        {
            string sql = "Insert into MensajeVenta(";
            sql = sql + "Mensaje,CodVenta)";
            sql = sql + " values (" + "'" + Mensaje + "'";
            sql = sql + "," + CodVenta.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void InsertarTran (SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta, string Mensaje)
        {
            string sql = "Insert into MensajeVenta(";
            sql = sql + "Mensaje,CodVenta)";
            sql = sql + " values (" + "'" + Mensaje + "'";
            sql = sql + "," + CodVenta.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetMensajexCodVenta(Int32 CodVenta)
        {
            string sql = "select CodMensaje, CodVenta, Mensaje ";
            sql = sql + " from MensajeVenta ";
            sql = sql + " where CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);

        }

        public void Borrar(Int32 CodMensaje)
        {
            string sql = "delete from MensajeVenta ";
            sql = sql + " where CodMensaje=" + CodMensaje.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
