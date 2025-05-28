using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cDistancia
    {
        public void Insertar(int CodOrigen, int CodDestino, int km)
        {
            string sql = "insert into Distancia(";
            sql = sql + " CodOrigen,CodDestino,km)";
            sql = sql + " values (" + CodOrigen.ToString();
            sql = sql + "," + CodDestino.ToString();
            sql = sql + "," + km.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void Modificar(int CodDistancia, int Km)
        {
            string sql = "update Distancia ";
            sql = sql + " set Km=" + Km.ToString();
            sql = sql + " where CodDistancia=" + CodDistancia.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetDistancias()
        {
            string sql = "";
            sql = "select D.CodDistancia, D.CodOrigen ,";
            sql = sql + "(select c.Nombre From Ciudad c where c.CodCiudad = D.CodOrigen) as Origen ";
            sql = sql + " ,D.CodDestino ";
            sql = sql + " ,(select c.Nombre From Ciudad c where c.CodCiudad = D.CodDestino) as Destino ";
            sql = sql + ",km ";
            sql = sql + " from Distancia d ";
            sql = sql + " order by Origen,Destino ";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDistanciasxId(Int32 CodDistancia)
        {
            string sql = "";
            sql = "select D.CodDistancia, D.CodOrigen ,";
            sql = sql + "(select c.Nombre From Ciudad c where c.CodCiudad = D.CodOrigen) as Origen ";
            sql = sql + " ,D.CodDestino ";
            sql = sql + " ,(select c.Nombre From Ciudad c where c.CodCiudad = D.CodDestino) as Destino ";
            sql = sql + ",km ";
            sql = sql + " from Distancia d ";
            sql = sql + " where CodDistancia=" + CodDistancia.ToString();
            sql = sql + " order by Origen,Destino ";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDistanciasDetallada()
        {
            string sql = "";
            sql = "select  D.CodOrigen ,";
            sql = sql + "(select c.Nombre From Ciudad c where c.CodCiudad = D.CodOrigen) as Origen ";
            sql = sql + " ,D.CodDestino ";
            sql = sql + " ,(select c.Nombre From Ciudad c where c.CodCiudad = D.CodDestino) as Destino ";
            sql = sql + ",km ";
            sql = sql + ",Completo ";
            sql = sql + ",Media ";
            sql = sql + ",Cuarto ";
            sql = sql + " from Distancia d ";
            sql = sql + " order by Origen,Destino ";
            return cDb.ExecuteDataTable(sql);
        }

        public void Eliminar(int CodDistancia)
        {
            string sql = " delete from Distancia ";
            sql = sql + " where CodDistancia =" + CodDistancia.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void ActualizarPrecio (double Precio)
        {
            string sql = "update Distancia ";
            sql = sql + " set Completo = km *" + Precio.ToString();
            sql = sql + " , Media = (km *" + Precio.ToString() + ")/2";
            sql = sql + " , Cuarto = (km *" + Precio.ToString() + ")/4";
            sql = sql + ", Precio =" + Precio.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public double GetPrecio ()
        {
            Double Precio = 0;
            string sql = "select distinct(isnull(Precio,0)) as Precio ";
            sql = sql + " from Distancia ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Precio"].ToString ()!="")
                {
                    Precio = Convert.ToDouble(trdo.Rows[0]["Precio"].ToString());
                }
            }
            return Precio;
        }
    }
}
