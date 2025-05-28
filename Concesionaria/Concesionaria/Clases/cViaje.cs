using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cViaje
    {
        public void Insertar (Int32 CodDistancia, DateTime Fecha ,Double Adelanto, 
            Double Gastos ,String Descripcion)
        {
            string sql = "";
            sql = "insert into Viaje(CodDistancia,Fecha,Adelanto,Gastos,Descripcion)";
            sql = sql + " values (" + CodDistancia.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Adelanto.ToString().Replace(",", ".");
            sql = sql + "," + Gastos.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }
    }
}
