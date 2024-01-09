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
        public void Insertar(Int32 CodVenta,string Campo1, string Campo2,string  Campo3, 
            string Campo4, string Campo5, string Campo6, string Campo7, string  Campo8)
        {
            //Campo1 domicilio , campo2 nombre aderente
            //Campo3 aderente , campo4 telefono adherente
            //Campo5 código de venta , Campo6 Titular
            //Campo7 titulo listado auto parte pago
            //Campo 8 el nombre de los autos en parte de pago
            string sql = "Insert into BoletoTraut (";
            sql = sql + "CodVenta,Campo1, Campo2, Campo3 , Campo4 ,Campo5,Campo6";
            sql = sql + ",Campo7,Campo8";
            sql = sql + ")";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + "'" + Campo1 + "'";
            sql = sql + "," + "'" + Campo2 + "'";
            sql = sql + "," + "'" + Campo3 + "'";
            sql = sql + "," + "'" + Campo4 + "'";
            sql = sql + "," + "'" + Campo5 + "'";
            sql = sql + "," + "'" + Campo6 + "'";
            sql = sql + "," + "'" + Campo7 + "'";
            sql = sql + "," + "'" + Campo8 + "'";

            sql = sql + ")";   
            cDb.ExecutarNonQuery(sql);
        }
    }
}
