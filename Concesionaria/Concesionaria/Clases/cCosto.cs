﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace Concesionaria.Clases
{
    public class cCosto
    {
        public void InsertarCosto(Int32 CodAuto,string Patente,Double? Importe,string Fecha,string Descripcion, Int32? CodStock, Int32? CodDeuda , Int32? CodMovimientoCaja, int? Inflacion)
        {
            string sql = "";
            sql = "Insert into Costo(CodAuto,Patente,";
            sql = sql + "Importe,Fecha,Descripcion,CodStock,CodDeuda,CodMovimientoCaja,Inflacion ";
            sql = sql + ")";
            sql = sql + "values(" + CodAuto.ToString ();
            sql = sql + "," + "'" + Patente  +"'";
            if (Importe ==null)
                sql = sql + ",null";
            else
                sql = sql + "," + Importe.ToString ();
            sql = sql + "," + "'" + Fecha  + "'";
            sql = sql + "," + "'" + Descripcion  + "'";
            if (CodStock == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodStock.ToString();

            if (CodDeuda == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodDeuda.ToString();
            if (CodMovimientoCaja != null)
                sql = sql + "," + CodMovimientoCaja.ToString();
            else
                sql = sql + ",null";
            if (Inflacion !=null)
            {
                sql = sql + "," + Inflacion.ToString();
            }
            else
            {
                sql = sql + ",null";
            }
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetCostoxPatente(string Patente)
        {
            string sql = "select CodCosto,Patente,Descripcion,Fecha,Importe from Costo";
            sql = sql + " where FechaBaja is null ";
            sql = sql + " and Patente =" + "'" + Patente + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarCosto(Int32 CodCosto)
        {
            string sql = "";
            sql = "delete from costo where CodCosto =" + CodCosto.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetCostoxCodigoStock(Int32 CodStock)
        {
            string sql = "select CodCosto,Patente,Descripcion,Fecha,Importe from Costo";
          //  sql = sql + " where FechaBaja is null ";
            sql = sql + " where CodStock =" + CodStock.ToString() ;
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarCostoxCodDeuda(Int32 CodDeuda)
        {
            string sql = "delete from Costo ";
            sql = sql + " where CodDeuda=" + CodDeuda.ToString();
            cDb.ExecutarNonQuery(sql);
              
        }

        public void BorrarCostoxCodMovimientoCaja(Int32 CodMovimientoCaja)
        {
            string sql = "delete from Costo ";
            sql = sql + " where CodMovimientoCaja =" + CodMovimientoCaja.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public Double GetTotalInflacion(Int32 CodStock)
        {
            Double Importe = 0;
            string sql = "select  isnull(sum(c.Importe),0) as Importe ";
            sql = sql + " from Costo c ";
            sql = sql + " where c.CodStock =" + CodStock.ToString();
            sql = sql + " and Inflacion=1";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                Importe = Convert.ToDouble(trdo.Rows[0]["Importe"]);
            }
            return Importe;
        }
    }
}
