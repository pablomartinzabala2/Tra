using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    public  class cPagoProveedor
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,Double Efectivo, string Concepto,Double ImporteCheque,Int32? CodCheque, Int32 CodCuentaProveedor)
        {
            string sql = "insert into PagoProveedor(";
            sql = sql + "Fecha,Efectivo,Concepto,ImporteCheque,CodCheque,CodCuentaProveedor)";
            sql = sql + " values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + ImporteCheque.ToString().Replace(",", ".");
            if (CodCheque != null)
                sql = sql + "," + CodCheque.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + CodCuentaProveedor.ToString();
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion (con, Transaccion, sql);
        }

        public  DataTable Buscar(DateTime FechaDesde, DateTime FevhaHasta)
        {
            string sql = "select p.CodPago,p.Fecha";
            sql = sql + ",( select distinct pr.Nombre ";
            sql = sql + " from Proveedor pr, CuentaProveedor c, DeudaProveedor d ";
            sql = sql + " where pr.CodProveedor=c.CodProveedor ";
            sql = sql + " and c.CodCuenta=d.CodCuentaProveedor ";
            sql = sql + " and d.CodPago=p.CodPago ";
            sql = sql + ") as Proveedor ";
            sql = sql + ",( select distinct c.Nombre from CuentaProveedor c, DeudaProveedor d ";
            sql = sql + " where c.CodCuenta=d.CodCuentaProveedor ";
            sql = sql + " and d.CodPago=p.CodPago ";
            sql = sql + ") as Cuenta ";
            sql = sql + " ,p.Concepto,p.Efectivo ,p.CodCheque,p.ImporteCheque ";
            sql = sql + " from PagoProveedor p";
            sql = sql + " where Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and Fecha <=" + "'" + FevhaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);

        }

        public DataTable GetPagoxCodigo(Int32 CodPago)
        {
            string sql = " select * from PagoProveedor ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void Borrar(SqlConnection con, SqlTransaction Transaccion, Int32 CodPago)
        {
            string sql = " delete from PagoProveedor ";
            sql = sql + " where CodPago=" + CodPago.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }
    }
}
