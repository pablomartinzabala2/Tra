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
            Double Gastos ,String Descripcion, int KmIda, int KmVuelta, int CodChofer )
        {
            string sql = "";
            sql = "insert into Viaje(CodDistancia,Fecha,Adelanto,Gastos,Descripcion,KmIda,KmVuelta,CodChofer)";
            sql = sql + " values (" + CodDistancia.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Adelanto.ToString().Replace(",", ".");
            sql = sql + "," + Gastos.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + "," + KmIda.ToString();
            sql = sql + "," + KmVuelta.ToString();
            sql = sql + "," + CodChofer.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetViajes(DateTime Desde, DateTime Hasta, Int32? CodChofer )
        {
            string sql = "";
            sql = "select v.CodViaje,v.Fecha, ";
            sql = sql + " (select (Nombre + ' ' + Apellido) from Chofer where CodChofer = v.CodChofer ) as Chofer ,";
            sql = sql + " (select nombre from ciudad where codciudad =d.CodOrigen ) as origen ,";
            sql = sql + "(select nombre from ciudad where codciudad =d.CodDestino  ) as Destino ";
            sql = sql + " ,v.Gastos ,v.Adelanto ,v.KmIda , v.KmVuelta ";
            sql = sql + ",( isnull(v.KmVuelta,0) - isnull(v.KmIda,0)) as Km ";
            sql = sql + ", v.Descripcion ";
            sql = sql + " from viaje v, Distancia d ";
            sql = sql + " where v.CodDistancia = d.CodDistancia  ";
            sql = sql + " and v.Fecha >=" + "'" + Desde + "'";
            sql = sql + " and v.Fecha <=" + "'" + Hasta  + "'";
            if (CodChofer !=null)
            {
                sql = sql + " and v.CodChofer=" + CodChofer.ToString();
            }
            sql = sql + " order by v.CodViaje  desc  ";
            return cDb.ExecuteDataTable(sql);
        }

        public void Eliminar(Int32 CodViaje)
        {
            string sql = " delete from Viaje ";
            sql = sql + " where CodViaje = " + CodViaje.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
