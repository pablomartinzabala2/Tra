using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Concesionaria.Clases
{
    public class cBoletoTraut
    {
        public void Borrar()
        {
            string sql = "delete from BoletoTraut ";
            cDb.ExecutarNonQuery(sql);
        }
        public void Insertar(Int32 CodVenta,string Campo1)
        {
            //Campo1 domicilio 
            string sql = "Insert into BoletoTraut (";
            sql = sql + "CodVenta,Campo1";
            sql = sql + ")";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + "'" + Campo1 + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }
    }
}
