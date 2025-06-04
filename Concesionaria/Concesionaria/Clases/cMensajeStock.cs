using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cMensajeStock
    {
        public void Insertar (string Mensaje, DateTime Fecha, int CodStock)
        {
            string sql = "insert into MensajeStock ";
            sql = sql + " (Mensaje,Fecha,CodStock) ";
            sql = sql + " values (" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodStock.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql); 
        }

        public void Eliminar(int CodMensaje)
        {
            string sql = " delete from MensajeStock ";
            sql = sql + " where CodMensaje =" + CodMensaje.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensaje(int CodStock)
        {
            string sql = "select CodMensaje,Fecha, Mensaje ";
            sql = sql + " from MensajeStock ";
            sql = sql + " where CodStock =" + CodStock.ToString();
            sql = sql + " order by CodMensaje desc ";
            return cDb.ExecuteDataTable(sql);
        }

        
    }
}
