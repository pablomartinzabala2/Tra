using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Concesionaria.Clases
{
    public class cRecibo
    {
        public void InsertarDetalle(SqlConnection con, SqlTransaction Transaccion, Int32 CodRecibo, string Campo1,
           string Campo2, string Campo3, string Campo4, int Orden)
        {
            string sql = "insert into ReporteRecibo(";
            sql = sql + "CodRecibo,Campo1,Campo2,Campo3,Campo4,Orden)";
            sql = sql + " Values (" + CodRecibo.ToString();
            sql = sql + "," + "'" + Campo1 + "'";
            sql = sql + "," + "'" + Campo2 + "'";
            sql = sql + "," + "'" + Campo3 + "'";
            sql = sql + "," + "'" + Campo4 + "'";
            sql = sql + "," + Orden.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion, DateTime Fecha, Int32 CodCliente,Double  Saldo, string SSaldo,string Concepto,Double Total, string sTotal, Double Efectivo, Int32 CodEmpleado )
        {
            string sql = "Insert into Recibo(CodCliente,Fecha,Saldo,sSaldo,Concepto,Total,sTotal";
            sql = sql + ",Efectivo,CodEmpleado)";
            sql = sql + " Values(" + CodCliente.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Saldo.ToString().Replace(",", ".");
            sql = sql + "," + "'" + SSaldo + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + sTotal + "'";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + "," + CodEmpleado.ToString();
            sql = sql + ")";
            return  cDb.EjecutarEscalarTransaccion (con, Transaccion, sql);
        }

        public string GetNroRecibo(Int32 CodRecibo)
        {
            string NroRecibo = "";
            switch(CodRecibo.ToString ().Length)
            {
                case 1:
                    NroRecibo = "0000000" + CodRecibo.ToString();
                    break;

                case 2:
                    NroRecibo = "000000" + CodRecibo.ToString();
                    break;
                case 3:
                    NroRecibo = "00000" + CodRecibo.ToString();
                    break;
                case 4:
                    NroRecibo = "0000" + CodRecibo.ToString();
                    break;
                case 5:
                    NroRecibo = "000" + CodRecibo.ToString();
                    break;
                case 6:
                    NroRecibo = "00" + CodRecibo.ToString();
                    break;
                case 7:
                    NroRecibo = "0" + CodRecibo.ToString();
                    break;
                case 8:
                    NroRecibo = CodRecibo.ToString();
                    break;
            }
            return NroRecibo;
        }

        public void  ActualizarNroRecibo(SqlConnection con, SqlTransaction Transaccion, Int32 CodRecibo,string NroRecibo)
        {
            string sql = "update Recibo set NroRecibo=" + "'" + NroRecibo + "'";
            sql = sql + " where CodRecibo=" + CodRecibo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }


        public DataTable GetRecibos(DateTime FechaDesde,DateTime FechaHasta, string Nombre)
        {
            string sql = " select r.CodRecibo,c.Apellido ,c.Nombre ";
            sql = sql + " ,r.Fecha,r.Concepto, r.Total,NroRecibo ";
            sql = sql + ", (select ve.Nombre from Vendedor ve where ve.CodVendedor =r.CodEmpleado) as Empleado";
            sql = sql + " from recibo r , cliente c ";
            sql = sql + " where r.CodCliente = c.CodCliente ";
            sql = sql + " and r.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and r.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Nombre !="")
            {
                sql = sql + " and c.Nombre like " + "'%" + Nombre + "%'";
            }
            sql = sql + " order by r.CodRecibo desc";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            return trdo;

        }

        public void Borrrar(SqlConnection con, SqlTransaction Transaccion, Int32 CodRecibo)
        {
            string sql = "delete from Recibo where CodRecibo=" + CodRecibo.ToString();
            cDb.EjecutarNonQueryTransaccion(con,Transaccion,sql);
            sql = "delete from ReporteRecibo where CodRecibo=" + CodRecibo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
            sql = "delete from chequecobrar where CodRecibo=" + CodRecibo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
            sql = "delete from transferencia where CodRecibo=" + CodRecibo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public Double GetImporteRecibo(Int32 CodRecibo)
        {
            Double Importe = 0;
            string sql = "select isnull(Efectivo,0) as Efectivo ";
            sql = sql + " from Recibo ";
            sql = sql + " where CodRecibo=" + CodRecibo.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Efectivo"].ToString ()!="")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Efectivo"].ToString());
                }
            }
            return Importe;

        }

    }
}
