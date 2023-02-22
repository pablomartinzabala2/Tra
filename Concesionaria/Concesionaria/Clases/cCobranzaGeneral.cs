using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cCobranzaGeneral
    {
        public void InsertarCobranza(DateTime Fecha, string Descripcion, double Importe,
            string Nombre,string Telefono,string Direccion,string Patente,DateTime FechaCompromiso,Int32? CodCliente)
        {
            string sql = "Insert into CobranzaGeneral(Fecha,Importe,Descripcion,Saldo,Cliente,Telefono,Direccion,Patente,FechaCompromiso,CodCliente)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString () +"'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Nombre +"'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + Direccion + "'";
            sql = sql + "," + "'" + Patente + "'";
            sql = sql + "," + "'" + FechaCompromiso.ToShortDateString() + "'";
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
             cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetCobranzasGeneralesxFecha(DateTime FechaDesde,DateTime FechaHasta,int SoloImpago,string Concepto,string Cliente)
        {
            string sql = "select CodCobranza,Descripcion,Importe,Fecha,ImportePagado,FechaPago,Saldo,Cliente";
            sql = sql + " from CobranzaGeneral ";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString () + "'" ;
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Concepto != "")
                sql = sql + " and Patente like" + "'%" + Concepto + "%'" ;
            if (SoloImpago == 1)
                sql = sql + " and Saldo >0";
            if (Cliente != "")
                sql = sql + " and Cliente like " + "'%" + Cliente  +"%'";
            sql = sql + " order by CodCobranza desc ";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetCobranzaxCodigo(Int32 CodCobranza)
        {
            string sql = "select *";
            sql = sql + " from CobranzaGeneral";
            sql = sql + " where CodCobranza=" + CodCobranza.ToString () ;
            return cDb.ExecuteDataTable(sql);
        }

        public void RegistrarCobro(Int32 CodCobranza, DateTime Fecha, double Importe)
        {
            string sql = "update CobranzaGeneral";
            sql = sql + " set ImportePagado =" + Importe.ToString ().Replace (",",".");
            sql = sql + ", Saldo = Saldo - " + Importe.ToString().Replace(",", ".");
            sql = sql + ", FechaPago =" + "'" + Fecha.ToShortDateString ()  +"'";
            sql = sql + " Where CodCobranza=" + CodCobranza.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public double GetTotalCobranza()
        {
            double Importe =0;
            string sql = "select sum(Saldo) as Importe from CobranzaGeneral";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            return Importe;
        }

        public void AnularCobranza(Int32 CodCobranza)
        {
            string sql = "Update CobranzaGeneral";
            sql = sql + " set Saldo = Importe";
            sql = sql + ", ImportePagado =null";
            sql = sql + ",FechaPago = null";
            sql = sql + " where CodCobranza =" + CodCobranza.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void PagarSaldo(Int32 CodCobranza, double Importe)
        {
            string sql = "Update CobranzaGeneral ";
            sql = sql + "Set Saldo = Saldo -" + Importe.ToString().Replace(",", ".") ;
            sql = sql + ", ImportePagado = ImportePagado +" + Importe.ToString ().Replace (",",".");
            sql = sql + " where CodCobranza =" + CodCobranza.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetDedudaCobranzaGeneral(string Apellido,string Patente, DateTime FechaVencimiento)
        {
            int b = 0;
            string sql = "select * from CobranzaGeneral ";
            sql = sql + " where Saldo >0 ";
          //  sql = sql + " and FechaCompromiso <" + "'" + FechaVencimiento.ToShortDateString() + "'";
            if (Apellido != "")
            {
                sql = sql + " and Cliente like " + "'%" + Apellido + "%'";
          
                b = 1;
            }
            sql = sql + " order by Cliente ";
            if (Patente != "")
            {
                if (b == 0)
                {
                    sql = sql + " and Patente like "  +"'%" + Patente + "%'";
             
                }
                else
                {
                    sql = sql + " and Patente like "  +"'%" + Patente + "%'";
                }
            }
            
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDedudaCobranzaGeneralxFecha(string Apellido, string Patente, DateTime FechaDesde, DateTime FechaHasta)
        {
            
            string Rdo = "";
            string a = "0", p = "0";

            if (Apellido != null)
            {
                if (Apellido != "")
                    a = "1";
            }

            if (Patente != "")
                p = "1";
            Rdo = a + p;
            string sql = " select * from CobranzaGeneral ";
            sql = sql + " where Saldo >0 ";
            switch (Rdo)
            {
                case "01":
                    sql = sql + " and Patente like " + "'%" + Patente + "%'";
                    break;
                case "10":
                    sql = sql + " and Apellido like " + "'%" + Apellido + "%'";
                    break;
                case "11":
                    sql = sql + " and Patente like " + "'%" + Patente + "%'";
                    sql = sql + " and Apellido like " + "'%" + Apellido + "%'";
                    break;
            }
            sql = sql + " and Fecha>=" + "'" + FechaDesde + "'";
            sql = sql + " and Fecha<=" + "'" + FechaHasta + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void BorrarCobranza(Int32 CodCobranza)
        {
            string sql = "delete from CobranzaGeneral  ";
            sql = sql + " where CodCobranza=" + CodCobranza.ToString();
            cDb.ExecutarNonQuery(sql);

        }
    }
}
