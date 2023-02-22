using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    public class cMensajeCobranza
    {
        public void InsertarMensaje(string Mensaje, DateTime Fecha, Int32 CodVenta)
        {
            string sql = "Insert into MensajesCobranza";
            sql = sql + "(Mensaje,Fecha,CodCobranza)";
            sql = sql + "values(" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodVenta.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensajesxCodCobranza(Int32 CodCobranza)
        {
            string sql = "select CodMensaje,Fecha,Mensaje from MensajesCobranza";
            sql = sql + " where CodCobranza =" + CodCobranza.ToString();
            sql = sql + " order by Fecha Desc";
            return cDb.ExecuteDataTable(sql);
        }

        public void borrar(Int32 CodMensaje)
        {
            string sql = "delete from MensajesCobranza ";
            sql = sql + " where CodMensaje=" + CodMensaje.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
