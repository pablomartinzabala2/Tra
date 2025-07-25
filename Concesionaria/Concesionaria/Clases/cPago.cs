using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cPago
    {
        public void Insertar(DateTime Fecha , DateTime FechaVencimiento, Double Importe, int CodObligatorio
            , string Obligatorio, int CodTipoPago, int CodConcepto, int CodCosto, string Costo)
        {
            string sql = "";
            sql = "insert into Pago(";
            sql = sql + "Fecha,FechaVencimiento,Importe,CodObligatorio,Obligatorio,CodTipoPago,CodConcepto,CodCosto,Costo ";
            sql = sql + ")";
            sql = sql + " values (";
            sql = sql + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + FechaVencimiento.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + CodObligatorio.ToString();
            sql = sql + "," + "'" + Obligatorio + "'";
            sql = sql + "," + CodTipoPago.ToString();
            sql = sql + "," + CodConcepto.ToString();
            sql = sql + "," + CodCosto.ToString();
            sql = sql + "," + "'" + Costo + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);

        }

        public DataTable Consultar(DateTime FechaDesde , DateTime FechaHasta)
        {
            string sql = "";
            sql = "select p.CodPago, t.Nombre,p.Fecha ,p.FechaVencimiento ,p.Importe ,p.FechaPago,p.Obligatorio ";
            sql = sql + " from Pago p , TipoPago t ";
            sql = sql + " where p.CodTipoPago = t.CodTipoPago ";
            sql = sql + " and p.FechaVencimiento >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and p.FechaVencimiento <=" + "'" + FechaHasta.ToShortDateString () + "'";
            sql = sql + " and p.FechaPago is null ";
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetTotalPagosDiario(DateTime Fecha)
        {
            Double Importe = 0;
            string sql = "";
            sql = "select  isnull(sum(p.Importe),0) as Importe ";
            sql = sql + " from Pago p ";
            sql = sql + " where p.FechaVencimiento >=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " and p.FechaVencimiento <=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " and p.FechaPago is null ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Importe"].ToString ()!="")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }
            return Importe;
        }

        public void Eliminar(Int32 CodPago)
        {
            string sql = " delete from Pago ";
            sql = sql + " where CodPago =" + CodPago.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void ActualizarPago(Int32 CodPago, DateTime Fecha)
        {
            string sql = "update Pago set FechaPago=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetPagoxCodConcepto(Int32 CodConcepto)
        {
            string sql = "";
            sql = "select p.CodPago, t.Nombre,p.Fecha ,p.FechaVencimiento ,p.Importe ,p.FechaPago,p.Obligatorio , p.Costo ";
            sql = sql + " from Pago p , TipoPago t ";
            sql = sql + " where p.CodTipoPago = t.CodTipoPago ";
            sql = sql + " and p.CodConcepto =" + CodConcepto.ToString();
            sql = sql + " and p.FechaPago is null ";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
