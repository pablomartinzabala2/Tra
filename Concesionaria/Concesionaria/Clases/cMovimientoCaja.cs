using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cMovimientoCaja
    {
        public void Insertar(string Concepto,DateTime Fecha, Int32? CodTipo, Double ImporteIngreso,Double ImporteEgreso, Int32? CodCuentaProveedor,Int32? CodStock,Int32? CodApertura, string sImporteIngreso, string sImporteEgreso)
        {
            string sql = "insert into MovimientoCaja(";
            sql = sql + "Concepto,Fecha,CodTipo,ImporteIngreso,ImporteEgreso,CodCuentaProveedor,CodStock";
            sql = sql + ",sImporteIngreso,sImporteEgreso";
            sql = sql + ")";
            sql = sql + " values (" + "'" + Concepto + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            if (CodTipo != null)
                sql = sql + "," + CodTipo.ToString();
            else
                sql = sql + ",null";
            if (ImporteIngreso > 0)
                sql = sql + "," + ImporteIngreso.ToString().Replace(",", ".");
            else
                sql = sql + ",null";
            if (ImporteEgreso > 0)  
                sql = sql + "," + ImporteEgreso.ToString().Replace(",", ".");
            else
                sql = sql + ",null";

            if (CodCuentaProveedor != null)
                sql = sql + "," + CodCuentaProveedor.ToString();
            else
                sql = sql + ",null";

            if (CodStock != null)
                sql = sql + "," + CodStock.ToString();
            else
                sql = sql + ",null";

            sql = sql + "," + "'" + sImporteIngreso + "'";
            sql = sql + "," + "'" + sImporteEgreso + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public Int32 InsertarId(string Concepto, DateTime Fecha, Int32? CodTipo, Double ImporteIngreso, Double ImporteEgreso, 
            Int32 CodCuentaProveedor, 
            Int32? CodStock, string sImporteIngreso, string sImporteEgreso, Int32 CodUsuario)
        {
            string sql = "insert into MovimientoCaja(";
            sql = sql + "Concepto,Fecha,CodTipo,ImporteIngreso,ImporteEgreso,CodCuentaProveedor,CodStock,sImporteIngreso,sImporteEgreso,CodUsuario";
            sql = sql + ")";
            sql = sql + " values (" + "'" + Concepto + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            if (CodTipo != null)
                sql = sql + "," + CodTipo.ToString();
            else
                sql = sql + ",null";
            if (ImporteIngreso > 0)
                sql = sql + "," + ImporteIngreso.ToString().Replace(",", ".");
            else
                sql = sql + ",null";
            if (ImporteEgreso > 0)
                sql = sql + "," + ImporteEgreso.ToString().Replace(",", ".");
            else
                sql = sql + ",null";

            sql = sql + "," + CodCuentaProveedor.ToString();

            if (CodStock != null)
                sql = sql + "," + CodStock.ToString();
            else
                sql = sql + ",null";  
            sql = sql + "," + "'" + sImporteIngreso + "'";
            sql = sql + "," + "'" + sImporteEgreso + "'";
            sql = sql + "," + CodUsuario.ToString();
            sql = sql + ")";
            return cDb.EjecutarEscalar(sql);
        }

        public DataTable GetMovimientoxFecha(DateTime FechaDesde,DateTime FechaHasta, string Proveedor, string Cuenta, string Concepto)
        {
            string sql = "select m.CodMovimiento,m.Fecha, m.Concepto, t.Nombre ";
            sql = sql + " ,p.Nombre as Proveedor,c.Nombre as Cuenta,m.ImporteIngreso,m.ImporteEgreso , t.CodTipo ";
            sql = sql + " from MovimientoCaja m ,tipomovimiento t , CuentaProveedor c, Proveedor p";
            sql = sql + " where m.CodTipo = t.CodTipo ";
            sql = sql + " and m.CodCuentaProveedor = c.CodCuenta ";
            sql = sql + " and c.CodProveedor = p.CodProveedor ";
            sql = sql + " and m.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and m.Fecha<= " + "'" + FechaHasta.ToShortDateString() + "'";
            if (Proveedor !="")
            {
                sql = sql + " and p.Nombre like " + "'%" + Proveedor + "%'";
            }
            if (Cuenta !="")
            {
                sql = sql + " and c.Nombre like " + "'%" + Cuenta + "%'";
            }

            if (Concepto != "")
            {
                sql = sql + " and m.Concepto like " + "'%" + Concepto + "%'";
            }

            return cDb.ExecuteDataTable(sql);
        }

        public void Borrar(Int32 CodMovimiento)
        {   
            string sql = "delete from movimientocaja ";
            sql = sql + " where CodMovimiento=" + CodMovimiento.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetResumenDiario(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select m.Fecha, sum(m.ImporteIngreso) as Ingreso , sum(importeegreso) as Egreso ";
            sql = sql + " from MovimientoCaja m ";
            sql = sql + " where m.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and m.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            sql = sql + " group by m.fecha ";
            sql = sql + " order by m.Fecha ";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarSaldo(Int32 CodMovimiento, string sSaldo)
        {
            string sql = "update MovimientoCaja ";
            sql = sql + " set sSaldo=" + "'" + sSaldo + "'";
            sql = sql + " where CodMovimiento =" + CodMovimiento.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void ActualizarTotales(Int32 CodMovimiento,
            string sTotalIngreso,string sTotalEgreso,string sIngresoEfectivo,
            string sEgresoEfectivo, string sIngresoCheque , 
            string sEgresoCheque , string sIngresoTrnasferencia , string sEgresoTransferencia,
            string sIngresoDolares,string sEgresoDolares)
        {
            string sql = "update MovimientoCaja ";
            sql = sql + " set sTotalIngreso=" + "'" + sTotalIngreso + "'";
            sql = sql + " , sTotalEgreso=" + "'" + sTotalEgreso + "'";
            sql = sql + " , sIngresoEfectivo=" + "'" + sIngresoEfectivo + "'";
            sql = sql + " , sEgresoEfectivo=" + "'" + sEgresoEfectivo + "'";
            sql = sql + " , sIngresoCheque=" + "'" + sIngresoCheque + "'";
            sql = sql + " , sEgresoCheque=" + "'" + sEgresoCheque + "'";
            sql = sql + " , sIngresoTrnasferencia=" + "'" + sIngresoTrnasferencia + "'";
            sql = sql + " , sEgresoTransferencia=" + "'" + sEgresoTransferencia + "'";
            sql = sql + " , sIngresoDolares=" + "'" + sIngresoDolares + "'";
            sql = sql + " , sEgresoDolares=" + "'" + sEgresoDolares + "'";
            sql = sql + " where CodMovimiento=" + CodMovimiento.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
