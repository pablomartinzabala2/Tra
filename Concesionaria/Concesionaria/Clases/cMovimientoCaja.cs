﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cMovimientoCaja
    {
        public void Insertar(string Concepto,DateTime Fecha, Int32? CodTipo, Double ImporteIngreso,Double ImporteEgreso, Int32 CodCuentaProveedor,Int32? CodStock)
        {
            string sql = "insert into MovimientoCaja(";
            sql = sql + "Concepto,Fecha,CodTipo,ImporteIngreso,ImporteEgreso,CodCuentaProveedor,CodStock";
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
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetMovimientoxFecha(DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "select m.CodMovimiento,m.Fecha, m.Concepto, t.Nombre ";
            sql = sql + " ,p.Nombre as Proveedor,c.Nombre as Cuenta,m.ImporteIngreso,m.ImporteEgreso ";
            sql = sql + " from MovimientoCaja m ,tipomovimiento t , CuentaProveedor c, Proveedor p";
            sql = sql + " where m.CodTipo = t.CodTipo ";
            sql = sql + " and m.CodCuentaProveedor = c.CodCuenta ";
            sql = sql + " and c.CodProveedor = p.CodProveedor ";
            sql = sql + " and m.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and m.Fecha<= " + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void Borrar(Int32 CodMovimiento)
        {   
            string sql = "delete from movimientocaja ";
            sql = sql + " where CodMovimiento=" + CodMovimiento.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}