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
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,Double Efectivo, string Concepto,Double ImporteCheque,Int32? CodCheque)
        {
            string sql = "insert into PagoProveedor(";
            sql = sql + "Fecha,Efectivo,Concepto,ImporteCheque,CodCheque)";
            sql = sql + " values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Concepto + "'";
            sql = sql + "," + ImporteCheque.ToString().Replace(",", ".");
            if (CodCheque != null)
                sql = sql + "," + CodCheque.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion (con, Transaccion, sql);
        }

        public  DataTable Buscar(DateTime FechaDesde, DateTime FevhaHasta)
        {
            string sql = "select CodPago,Fecha,Concepto,Efectivo ";
            sql = sql + " from PagoProveedor ";
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
