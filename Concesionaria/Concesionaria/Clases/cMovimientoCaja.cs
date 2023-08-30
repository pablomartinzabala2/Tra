using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cMovimientoCaja
    {
        public void Insertar(string Concepto,DateTime Fecha, Int32? CodTipo, Double ImporteIngreso, Int32 CodCuentaProveedor)
        {
            string sql = "insert into MovimientoCaja(";
            sql = sql + "Concepto,Fecha,CodTipo,ImporteIngreso,CodCuentaProveedor";
            sql = sql + ")";
            sql = sql + " values (" + "'" + Concepto + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            if (CodTipo != null)
                sql = sql + "," + CodTipo.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + ImporteIngreso.ToString().Replace(",", ".");
            sql = sql + "," + CodCuentaProveedor.ToString();
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMovimientoxFecha(DateTime Fecha)
        {
            string sql = "select m.CodMovimiento,m.Fecha, m.Concepto, t.Nombre,m.ImporteIngreso ";
            sql = sql + " ,p.Nombre as Proveedor,c.Nombre as Cuenta ";
            sql = sql + " from MovimientoCaja m ,tipomovimiento t , CuentaProveedor c, Proveedor p";
            sql = sql + " where m.CodTipo = t.CodTipo ";
            sql = sql + " and m.CodCuentaProveedor = c.CodCuenta ";
            sql = sql + " and c.CodProveedor = p.CodProveedor ";
            sql = sql + " and m.Fecha >=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " and m.Fecha<= " + "'" + Fecha.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
