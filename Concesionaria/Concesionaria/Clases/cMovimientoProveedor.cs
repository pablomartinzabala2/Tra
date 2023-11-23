using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Concesionaria.Clases
{
    public class cMovimientoProveedor
    {
        public void InsertarTran(SqlConnection con, SqlTransaction Transaccion,
            Int32 CodCuentaProveedor, DateTime Fecha, string Concepto,Double Debe, Double Haber,Double Saldo,Int32 CodDeuda,Int32 CodPago, Double SaldoAnterior )
        {
            string sql = "insert into MovimientoProveedor(CodCuentaProveedor,Fecha,Concepto,";
            sql = sql + "Debe,Haber,Saldo,CodDeuda,CodPago,SaldoAnterior)";
            sql = sql + " values (" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + "," + Saldo.ToString().Replace(",", ".");
            if (CodDeuda > 0)
                sql = sql + "," + CodDeuda.ToString();
            else
                sql = sql + ",null";
            if (CodPago > 0)
                sql = sql + "," + CodPago.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + SaldoAnterior.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void Insertar(
           Int32 CodCuentaProveedor, DateTime Fecha, string Concepto, Double Debe, Double Haber,Double Saldo, Int32 CodDeuda, Int32 CodPago,Double SaldoAnterior)
        {

            string sql = "insert into MovimientoProveedor(CodCuentaProveedor,Fecha,Concepto,";
            sql = sql + "Debe,Haber,Saldo,CodDeuda,CodPago,SaldoAnterior)";
            sql = sql + " values (" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + Debe.ToString().Replace(",", ".");
            sql = sql + "," + Haber.ToString().Replace(",", ".");
            sql = sql + "," + Saldo.ToString().Replace(",", ".");
            if (CodDeuda > 0)
                sql = sql + "," + CodDeuda.ToString();
            else
                sql = sql + ",null";
            if (CodPago > 0)
                sql = sql + "," + CodPago.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + SaldoAnterior.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

       public DataTable GetResumen(Int32 CodCuentaProveedor,DateTime FechaDesde,DateTime FechaHasta, string Concepto)
        {
            Double Saldo = 0;
            Double SaldoAnterior = 0;
            Saldo = GetSaldo(CodCuentaProveedor);
            SaldoAnterior = GetSaldoAnterior(CodCuentaProveedor,  FechaDesde, FechaHasta);
            string sql = " select 0 as CodCuentaProveedor,'' as Fecha,'Saldo Inicial' as Concepto";
            sql = sql + "," + SaldoAnterior.ToString().Replace(",", ".") + " as Debe ";
            sql = sql + ",0 as Haber ";
            sql = sql + "," + SaldoAnterior.ToString().Replace(",", ".") + " as Saldo ";
            sql = sql + ",0 as CodDeuda ,0 as CodPago ,0 as CodMovimiento ";
            sql = sql + " union ";
           // string sql = "";
            sql = sql + " select CodCuentaProveedor,Fecha,Concepto,Debe,Haber, Saldo,CodDeuda,CodPago,CodMovimiento";
            sql = sql + " from MovimientoProveedor "; 
            sql = sql + " where CodCuentaProveedor=" + CodCuentaProveedor.ToString();
            sql = sql + " and Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" +"'" + FechaHasta.ToShortDateString() + "'";
            if (Concepto != "")
                sql = sql + " and Concepto like " + "'%" + Concepto + "%'";
            sql = sql + " order by CodMovimiento asc ";
            // sql = sql + " order by Fecha asc ";
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetSaldoAnterior(Int32 CodCuentaProveedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Double SaldoAnterior = 0;
            string sql = "";
            sql = " select CodMovimiento,SaldoAnterior ";
            sql = sql + " from MovimientoProveedor ";
            sql = sql + " where CodCuentaProveedor=" + CodCuentaProveedor.ToString();
            sql = sql + " and Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " order by CodMovimiento asc ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["SaldoAnterior"].ToString ()!="")
                {
                    SaldoAnterior = Convert.ToDouble(trdo.Rows[0]["SaldoAnterior"].ToString());
                }
            }
            return SaldoAnterior;
        }

        public Double GetSaldo(Int32 CodCuenta)
        {
            Double Saldo = 0;
            string sql = "select isnull(Saldo,0) as Saldo from CuentaProveedor ";
            sql = sql + " where CodCuenta=" + CodCuenta.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Saldo"].ToString ()!="")
                {
                    Saldo = Convert.ToDouble(trdo.Rows[0]["Saldo"].ToString());
                }
            }
            return Saldo;
        }

        public void BorrarMovimientoxCodDeuda(Int32 CodDeuda)
        {
            string sql = "delete from MovimientoProveedor ";
            sql = sql + " where CodDeuda=" + CodDeuda.ToString();
            cDb.ExecutarNonQuery(sql);
        }
        public void BorrarMovimientoxCodPago(Int32 CodPago)
        {
            string sql = "delete from MovimientoProveedor ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void CorregirSaldo(int CodCuentaProveedor)
        {
            Int32 CodMovimiento = 0;
            Double Saldo = 0, Debe = 0, Haber = 0;
            string sql = "select * from MovimientoProveedor ";
            sql = sql + " where CodCuentaProveedor=" + CodCuentaProveedor.ToString();
            sql = sql + " order by CodMovimiento asc ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            for (int i = 0; i < trdo.Rows.Count ; i++)
            {
                if (i==0)
                {
                    CodMovimiento = Convert.ToInt32(trdo.Rows[i]["CodMovimiento"]);
                    Debe = Convert.ToDouble(trdo.Rows[i]["Debe"]);
                    Haber = Convert.ToDouble(trdo.Rows[i]["Haber"]);
                    Saldo = Debe - Haber;
                    sql = "Update MovimientoProveedor ";
                    sql = sql + " set Saldo =" + Saldo.ToString();
                    sql = sql + " where CodMovimiento =" + CodMovimiento.ToString();
                    cDb.ExecutarNonQuery(sql);
                }
                else
                {
                    CodMovimiento = Convert.ToInt32(trdo.Rows[i]["CodMovimiento"]);
                    Debe = Convert.ToDouble(trdo.Rows[i]["Debe"]);
                    Haber = Convert.ToDouble(trdo.Rows[i]["Haber"]);
                    Saldo = Saldo + Debe - Haber;
                    sql = "Update MovimientoProveedor ";
                    sql = sql + " set Saldo =" + Saldo.ToString();
                    sql = sql + " where CodMovimiento =" + CodMovimiento.ToString();
                    cDb.ExecutarNonQuery(sql);
                }
            }
        }


    }
}
