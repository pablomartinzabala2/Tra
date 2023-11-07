using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Concesionaria.Clases
{
    public class cAperturaCaja
    {
        public Int32  AbrirCaja (DateTime Fecha, Double Importe, Int32 CodUsuario, Int32 CodCuentaProveedor)
        {
            string sql = "insert into AperturaCaja(";
            sql = sql + "FechaApertura,Importe,CodUsuario,CodCuentaProveedor";
            sql = sql + ")";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + CodUsuario.ToString();
            sql = sql + "," + CodCuentaProveedor.ToString();
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);
           // cDb.ExecutarNonQuery(sql);
        }

        public void CerrarCaja(Int32 CodApertura, DateTime Fecha)
        {
            string sql = "update AperturaCaja ";
            sql = sql + " set FechaCierre = " + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " where CodApertura =" + CodApertura.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public Boolean VerificarApertura(DateTime Fecha)
        {
            Boolean op = false;
            string sql = "select a.* ";
            sql = sql + " from AperturaCaja a ";
            sql = sql + " where FechaCierre is null ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["FechaApertura"].ToString ()!="")
                {
                    op = true;
                }
            }
            return op;
        }

        public DataTable GetApertura(DateTime Fecha)
        {
            string sql = "select a.CodApertura , ";
            sql = sql + " (select u.Nombre from Usuario u where u.CodUsuario = a.CodUsuario ) as Nombre ";
            sql = sql + " ,a.FechaApertura,a.FechaCierre,a.Importe";
            sql = sql + " from AperturaCaja a ";
            sql = sql + " where FechaApertura >=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " and FechaApertura <=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " order by CodApertura desc";
            //  sql = sql + " and FechaCierre is null ";
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 GetMaxCodApertura()
        {
            Int32 CodApertura = 0;
            string sql = " select max(CodApertura) as CodApertura ";
            sql = sql + " from AperturaCaja ";
            sql = sql + " where FechaCierre is  null ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodApertura"].ToString ()!="")
                {
                    CodApertura = Convert.ToInt32(trdo.Rows[0]["CodApertura"]);
                }
            }
            return CodApertura;
        }
    }
}
