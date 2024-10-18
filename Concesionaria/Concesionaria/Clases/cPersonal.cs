using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cPersonal
    {
        public void Insertar (string Nombre, Int32? CodCargo ,
            Int32 CodCliente, string Telefono)
        {
            string sql = "Insert into Personal (";
            sql = sql + " Nombre,CodCargo,Telefono,CodCliente ";
            sql = sql + ") Values (";
            sql = sql + "'" + Nombre + "'";
            if (CodCargo != null)
                sql = sql + "," + CodCargo.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + ","+  "'" + CodCliente.ToString () + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }


        public DataTable GetPersonalxCodCliente(Int32 CodCliente)
        {
            string sql = "";
            sql = "select p.CodPersonal , p.Nombre ,p.Telefono ";
            sql = sql + ", (select c.Nombre from Cargo c where c.CodCargo = p.CodCargo) as Cargo ";
            sql = sql + " from Personal p ";
            sql = sql + " where p.CodCliente =" + CodCliente.ToString();
            sql = sql + " order by Nombre ";
            return cDb.ExecuteDataTable(sql);
        }


        public void Borrar(Int32 CodPersonal)
        {
            string sql = "delete from Personal ";
            sql = sql + " where CodPersonal =" + CodPersonal.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
