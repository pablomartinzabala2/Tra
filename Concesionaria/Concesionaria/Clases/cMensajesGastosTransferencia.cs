using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Concesionaria.Clases
{
    public class cMensajesGastosTransferencia
    {
        public void Insertar (string Mensaje, DateTime Fecha ,Int32 CodGasto)
        {
            string sql = "insert into MensajesGastosTransferencia(";
            sql = sql + "Mensaje,Fecha,CodGasto)";
            sql = sql + " values(" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() +"'";
            sql = sql + "," + CodGasto.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensajexCodGasto(Int32 CodGasto)
        {
            string sql = "select CodMensaje,Mensaje,Fecha from MensajesGastosTransferencia";
            sql = sql + " where CodGasto=" + CodGasto.ToString();
            sql = sql + " order by CodMensaje Desc ";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetMensajexCodMensaje(Int32 CodMensaje)
        {
            string sql = "select * from MensajesGastosTransferencia";
            sql = sql + " where CodMensaje=" + CodMensaje.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void Eliminar(Int32 CodMensaje)
        {
            string sql = "delete from MensajesGastosTransferencia ";
            sql = sql + " where CodMensaje=" + CodMensaje.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
