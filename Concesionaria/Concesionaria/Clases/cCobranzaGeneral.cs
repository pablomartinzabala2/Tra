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
            string Nombre,string Telefono,string Direccion,string Patente,DateTime FechaCompromiso,Int32? CodCliente, Int32? CodMoneda, string Tipo)
        {
            string sql = "Insert into CobranzaGeneral(Fecha,Importe,Descripcion,Saldo,Cliente,Telefono,Direccion,Patente,FechaCompromiso,CodCliente,CodMoneda,Tipo)";
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

            if (CodMoneda !=null)
                sql = sql + "," + CodMoneda.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + Tipo + "'";
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

        public DataTable GetDedudaCobranzaGeneral(string Apellido,string Patente, DateTime FechaVencimiento, string Descripcion)
        {
            int b = 0;
            string sql = "select * from CobranzaGeneral ";
            sql = sql + " where Saldo >0 and FechaCompromiso is not null  ";
          //  sql = sql + " and FechaCompromiso <" + "'" + FechaVencimiento.ToShortDateString() + "'";
            if (Apellido != "")
            {
                sql = sql + " and Cliente like " + "'%" + Apellido + "%'";
          
                b = 1;
            }
            
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

            if (Descripcion !="")
            {
                sql = sql + " and Descripcion like " + "'%" + Descripcion + "%'";
            }

            sql = sql + " order by Cliente ";

            return cDb.ExecuteDataTable(sql);
        }


        public DataTable GetDedudaCobranzaGeneralDetallada(string Apellido, string Patente, DateTime FechaVencimiento, 
            string Descripcion, Int32? CodMoneda, Int32? OrdenSaldo)
        {
            int b = 0;
            string sql = "select c.CodCobranza, 'Cobranza General',c.FechaCompromiso ,c.Cliente,c.Descripcion ,c.Importe ,c.Saldo , c.Patente  ";
            sql = sql + "  , c.Telefono  ";
            
            sql = sql + " ,(select m.Nombre from Moneda m where m.CodMoneda = c.CodMoneda) as Moneda ";
            sql = sql + " from CobranzaGeneral c  ";
            sql = sql + " where Saldo >0 and FechaCompromiso is not null  ";
            //  sql = sql + " and FechaCompromiso <" + "'" + FechaVencimiento.ToShortDateString() + "'";
            if (Apellido != "")
            {
                sql = sql + " and Cliente like " + "'%" + Apellido + "%'";

                b = 1;
            }

            if (Patente != "")
            {
                if (b == 0)
                {
                    sql = sql + " and Patente like " + "'%" + Patente + "%'";

                }
                else
                {
                    sql = sql + " and Patente like " + "'%" + Patente + "%'";
                }
            }

            if (Descripcion != "")
            {
                sql = sql + " and Descripcion like " + "'%" + Descripcion + "%'";
            }

            if (CodMoneda !=null)
            {
                sql = sql + " and CodMoneda =" + CodMoneda.ToString();
            }
            if (OrdenSaldo ==null)
                sql = sql + " order by FechaCompromiso asc, Cliente ";

            if (OrdenSaldo !=null)
            {
                int Orden = Convert.ToInt32(OrdenSaldo);
                if (Orden ==1)
                    sql = sql + " order by Saldo asc, Cliente ";

                if (Orden == 2)
                    sql = sql + " order by Saldo desc, Cliente ";

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

        public DataTable GetDeudaCliente(string Apellido, int? CodMoneda, Int32? CodVendedor, DateTime FechaCompromiso)
        {
            string sql = "select Cli.CodCliente,c.Cliente ,cli.Apellido,cli.Telefono ";
            sql = sql + " , sum(c.Saldo) as Saldo ,m.Nombre as Moneda";
            sql = sql + " from CobranzaGeneral c, Cliente Cli , Moneda m ";
            sql = sql + " where c.CodCliente = cli.CodCliente ";
            sql = sql + " and c.CodMoneda = m.CodMoneda ";
            sql = sql + " and c.Saldo > 0 ";
           // sql = sql + " and c.FechaCompromiso <=" + "'" + FechaCompromiso.ToShortDateString() + "'";
            if (Apellido !="")
            {
                sql = sql + " and c.Cliente like " + "'%" + Apellido + "%'";
            }

            if (CodMoneda != null)
            {
                sql = sql + " and m.CodMoneda=" + CodMoneda.ToString();
            }

            if (CodVendedor !=null)
            {
                sql = sql + " and cli.CodVendedor =" + CodVendedor.ToString();
            }

            sql = sql + " group by Cli.CodCliente,C.Cliente ,cli.Apellido,cli.Telefono , m.Nombre";
            if (CodMoneda !=null )
            {
                sql = sql + " order by sum(c.Saldo) desc ";
            }
            else
            {
                sql = sql + " order by  c.Cliente   ";
            }
           
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDedudaCobranzaGeneralDetalladaxCodCliente(string Apellido, string Patente, DateTime FechaVencimiento,
           string Descripcion, Int32? CodMoneda, Int32? OrdenSaldo, Int32? CodCliente)
        {
            int b = 0;
            string sql = "select c.CodCobranza, 'Cobranza General',c.FechaCompromiso ,c.Cliente,c.Descripcion ,c.Importe ,c.Saldo , c.Patente  ";
            sql = sql + "  , c.Telefono  ";

            sql = sql + " ,(select m.Nombre from Moneda m where m.CodMoneda = c.CodMoneda) as Moneda ";
            sql = sql + ", c.Cuota ";
            sql = sql + " from CobranzaGeneral c  ";
            sql = sql + " where Saldo >0 and FechaCompromiso is not null  ";
            //  sql = sql + " and FechaCompromiso <" + "'" + FechaVencimiento.ToShortDateString() + "'";
            if (Apellido != "")
            {
                sql = sql + " and Cliente like " + "'%" + Apellido + "%'";

                b = 1;
            }

            if (Patente != "")
            {
                if (b == 0)
                {
                    sql = sql + " and Patente like " + "'%" + Patente + "%'";

                }
                else
                {
                    sql = sql + " and Patente like " + "'%" + Patente + "%'";
                }
            }

            if (Descripcion != "")
            {
                sql = sql + " and Descripcion like " + "'%" + Descripcion + "%'";
            }

            if (CodCliente != null)
            {
                sql = sql + " and c.CodCliente = " + CodCliente.ToString();
            }

            if (CodMoneda != null)
            {
                sql = sql + " and CodMoneda =" + CodMoneda.ToString();
            }
            if (OrdenSaldo == null)
                sql = sql + " order by FechaCompromiso asc, Cliente ";

           

            if (OrdenSaldo != null)
            {
                int Orden = Convert.ToInt32(OrdenSaldo);
                if (Orden == 1)
                    sql = sql + " order by Saldo asc, Cliente ";

                if (Orden == 2)
                    sql = sql + " order by Saldo desc, Cliente ";

            }

            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDedudaCobranzaGeneralxCodCliente(Int32 CodCliente)
        {
            string sql = "select c.CodCobranza, 'Cobranza General',c.FechaCompromiso ,c.Cliente,c.Descripcion ,c.Importe ,c.Saldo , c.Patente  ";
            sql = sql + "  , c.Telefono  ";

            sql = sql + " ,(select m.Nombre from Moneda m where m.CodMoneda = c.CodMoneda) as Moneda ";
            sql = sql + " from CobranzaGeneral c  ";
            sql = sql + " ";
            sql = sql + " where Saldo >0 and FechaCompromiso is not null  ";
            sql = sql + " and CodCliente =" + CodCliente.ToString();
            //  sql = sql + " and FechaCompromiso <" + "'" + FechaVencimiento.ToShortDateString() + "'";
          
            return cDb.ExecuteDataTable(sql);
        }

        public string GetMenorFechaVencimiento(Int32 CodCliente)
        {
            string sql = " select min(c.FechaCompromiso) as Fecha ";
            sql = sql + " from CobranzaGeneral c where c.CodCliente = " + CodCliente.ToString();
            sql = sql + " and c.Saldo>0 ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            string sFecha = "";
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Fecha"].ToString ()!="")
                {
                    DateTime Fecha = Convert.ToDateTime(trdo.Rows[0]["Fecha"].ToString());
                    sFecha = Fecha.ToShortDateString();
                }
            }
            return sFecha;

        }

        public Int32 GetMaxGrupo()
        {
            int Grupo = 0;
            string sql = "select isnull(max(grupo),0) as Grupo from CobranzaGeneral ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                Grupo = Convert.ToInt32(trdo.Rows[0]["Grupo"].ToString ());
            }
            return Grupo;
        }

        public void InsertarCobranzaCuota(DateTime Fecha, string Descripcion, double Importe,
          string Nombre, string Telefono, string Direccion, string Patente, DateTime FechaCompromiso, Int32? CodCliente, Int32? CodMoneda, int Cuota, int Grupo, string Tipo)
        {
            string sql = "Insert into CobranzaGeneral(Fecha,Importe,Descripcion,Saldo,Cliente,Telefono,Direccion,Patente,FechaCompromiso,CodCliente,CodMoneda, Cuota, Grupo, Tipo)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + Direccion + "'";
            sql = sql + "," + "'" + Patente + "'";
            sql = sql + "," + "'" + FechaCompromiso.ToShortDateString() + "'";
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";

            if (CodMoneda != null)
                sql = sql + "," + CodMoneda.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Cuota.ToString();
            sql = sql + "," + Grupo.ToString();
            sql = sql + "," + "'" + Tipo + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public string GetTipo (Int32 CodCliente)
        {
            string Tipo = "";
            string d = "";
            string sql = " select distinct tipo  ";
            sql = sql + " from CobranzaGeneral ";
            sql = sql + " where CodCliente=" + CodCliente.ToString();
            sql = sql + " and tipo is not null ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    d = trdo.Rows[i]["Tipo"].ToString();
                    if (i == 0)
                        Tipo = d;
                    else 
                        Tipo = Tipo + "," + d;
                }
            }
            return Tipo;
        }
    }
}
