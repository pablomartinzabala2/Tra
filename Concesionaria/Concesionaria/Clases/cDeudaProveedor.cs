using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cDeudaProveedor
    {
        public Int32 Insertar (Int32 CodCuentaProveedor, string COncepto,
            DateTime Fecha, DateTime FechaVto, Double Importe, string Observacion, Int32? CodStock)
        {
            string sql = "Insert into DeudaProveedor(";
            sql = sql + "CodCuentaProveedor,COncepto,Fecha,FechaVto,Importe,Observacion,Saldo,CodStock)";
            sql = sql + " values(" + CodCuentaProveedor.ToString();
            sql = sql + "," + "'" + COncepto + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + FechaVto.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            if (CodStock != null)
                sql = sql + "," + CodStock.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);
        }

        public DataTable GetDeuda(DateTime FechaDesde,DateTime FechaHasta, string Proveedor)
        {
            string sql = "select d.CodDeuda,p.Nombre as Proveedor,c.Nombre as Cuenta,d.Concepto,d.Importe,d.Saldo,d.CodPago,d.CodCuentaProveedor ";
            sql = sql + " from CuentaProveedor c,Proveedor p,DeudaProveedor d";
            sql = sql + " where c.CodProveedor=p.CodProveedor";
            sql = sql + " and d.CodCuentaProveedor=c.CodCuenta "; 
            sql = sql + " and d.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and d.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Proveedor != "")
                sql = sql + " and p.Nombre like " + "'%" + Proveedor +"%'";
            sql = sql + " order by CodDeuda Desc ";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarSaldo(SqlConnection con, SqlTransaction Transaccion,Int32 CodDeuda,Double Importe,Int32 CodPago)
        {
            string sql = "update DeudaProveedor ";
            sql = sql + " set Saldo = Saldo -" + Importe.ToString().Replace(",", ".");
            sql = sql + ", CodPago =" + CodPago.ToString();
            sql = sql + " where CodDeuda =" + CodDeuda.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);

        }

        public void Anular(SqlConnection con, SqlTransaction Transaccion,Int32 CodPago)
        {
            string sql = " update DeudaProveedor ";
            sql = sql + " set Saldo = Importe ";
            sql = sql + " , CodPago = null ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public void Borrrar(Int32 CodDeuda)
        {
            string sql = "delete from DeudaProveedor ";
            sql = sql + " where CodDeuda=" + CodDeuda.ToString();
            cDb.ExecutarNonQuery(sql);

        }

        public DataTable GetDeudaxCodigo(Int32 CodDeuda)
        {
            string sql = "select d.*,c.Nombre as Cuenta ,p.Nombre as Proveedor   ";
            sql = sql + " from DeudaProveedor d, CuentaProveedor c , Proveedor p";
            sql = sql + " where d.CodCuentaProveedor=c.CodCuenta" ;
            sql = sql + " and c.CodProveedor=p.CodProveedor ";
            sql = sql + " and CodDeuda=" + CodDeuda.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            return trdo;
        }

        public DataTable GetDeudaxCodPago(Int32 CodPago)
        {
            string sql = "select Concepto,Importe,Saldo ";
            sql = sql + " from DeudaProveedor ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDeudaxCodStock(Int32 CodStock)
        {
            string sql = "select p.Nombre as Proveedor,c.Nombre as Cuenta, ";
            sql = sql + " d.Concepto,d.Importe";
            sql = sql +" from DeudaProveedor d,CuentaProveedor c, Proveedor p";
            sql = sql + " where d.CodCuentaProveedor=c.CodCuenta ";
            sql = sql + " and p.CodProveedor = c.CodProveedor ";
            sql = sql + " and d.CodStock=" + CodStock.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
