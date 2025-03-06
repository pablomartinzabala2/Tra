using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cMensajeCliente
    {
        public void InsertarMensaje(string Mensaje, DateTime Fecha, Int32 CodCliente)
        {
            string sql = "Insert into MensajeCliente ";
            sql = sql + "(Mensaje,Fecha,CodCliente)";
            sql = sql + "values(" + "'" + Mensaje + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + CodCliente.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMensajesxCodCliente(Int32 CodCliente)
        {
            string sql = "select CodMensaje,Fecha,Mensaje from MensajeCliente ";
            sql = sql + " where CodCliente =" + CodCliente.ToString();
            sql = sql + " order by CodMensaje Desc";
            return cDb.ExecuteDataTable(sql);
        }

        public void borrar(Int32 CodMensaje)
        {
            string sql = "delete from MensajeCliente ";
            sql = sql + " where CodMensaje=" + CodMensaje.ToString();
            cDb.ExecutarNonQuery(sql);
        }

       

        public DataTable GetMensajesxCodMensaje(Int32 CodMensaje)
        {
            string sql = "select CodMensaje,Fecha,Mensaje from MensajeCliente ";
            sql = sql + " where CodMensaje =" + CodMensaje.ToString();
            sql = sql + " order by CodMensaje Desc";
            return cDb.ExecuteDataTable(sql);
        }

        public string GetUltimaFecha(Int32 CodCliente)
        {
            string Fecha = "";
            string sql = "select * from MensajeCliente ";
            sql = sql + " where CodCliente =" + CodCliente.ToString();
            sql = sql + " order by CodMensaje desc";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodMensaje"].ToString() != "")
                    Fecha = trdo.Rows[0]["Fecha"].ToString();
            }
            return Fecha;
        }
    }
}
