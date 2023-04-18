using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    class cCuentaProveedor
    {
        public void Insertar(string Nombre,Int32 CodProveedor, Double Saldo)
        {
            string sql = "insert into CuentaProveedor( ";
            sql = sql + "Nombre,CodProveedor,Saldo)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            sql = sql + "," + CodProveedor.ToString();
            sql = sql + "," + Saldo.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetCuentas(Int32 CodProveedor)
        {
            string sql = " select CodCuenta,Nombre,CodProveedor from cuentaproveedor ";
            sql = sql + " where CodProveedor =" + CodProveedor.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetCuentasProveedores(string Proveedor, string Cuenta)
        {
            string sql = "select c.CodCuenta,p.Nombre as Proveedor,c.Nombre as Cuenta ";
            sql = sql + " from cuentaproveedor c,Proveedor p ";
            sql = sql + " where c.CodProveedor=p.CodProveedor";
            if (Proveedor !="")
            {
                sql = sql + " and p.Nombre like " + "'%" + Proveedor + "%'";
            }

            if (Cuenta !="")
            {
                sql = sql + " and c.Nombre like " + "'%" + Cuenta + "%'";
            }

            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDetalleCuentas(Int32 CodCuenta)
        {
            string sql = " select c.CodCuenta,c.Nombre,c.CodProveedor,p.Nombre as Proveedor from cuentaproveedor c, Proveedor p ";
            sql = sql + " where c.CodProveedor=p.CodProveedor ";
            sql = sql + " and  CodCuenta =" + CodCuenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetCuentasResumidas(string Cuenta, string NombreProveedor)
        {
           // string sql = "select c.CodCuenta,c.Nombre,P.Nombre as Proveedor,sum(d.Saldo) as Importe";
            string sql = "select c.CodCuenta,c.Nombre,P.Nombre as Proveedor ";
            sql = sql + ",(select (sum(m.Haber) - sum(m.Debe)) from MovimientoProveedor m where m.CodCuentaProveedor=c.CodCuenta) as Importe ";
            sql = sql + " from CuentaProveedor c,Proveedor p,deudaproveedor d ";
            sql = sql + " where c.CodProveedor = p.CodProveedor ";
            sql = sql + " and d.CodCuentaProveedor = c.CodCuenta ";

            if (NombreProveedor != "")
            {
                sql = sql + " and p.Nombre like " + "'%" + NombreProveedor + "%'";
            }

            if (Cuenta != "")
            {
                sql = sql + " and c.Nombre like " + "'%" + Cuenta + "%'";
            }

            sql = sql + " group by c.CodCuenta,c.Nombre,P.Nombre ";
            return cDb.ExecuteDataTable(sql);
        }

        public Double GetSaldo(Int32 CodCuenta)
        {
            Double Importe = 0;
            // string sql = "select isnull(sum(Saldo),0) as Importe from DeudaProveedor ";
            // sql = sql + " where CodCuentaProveedor=" + CodCuenta.ToString();
            string sql = " select(sum(m.Haber) - sum(m.Debe)) as Importe from MovimientoProveedor m";
            sql = sql + " where m.CodCuentaProveedor=" + CodCuenta.ToString(); 
           DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Importe"].ToString ()!="")
                {
                    Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                }
            }
            return Importe;
        }

        public DataTable GetDetalleDeuda(Int32 CodCuenta)
        {
            string sql = "select CodDeuda,Concepto,Importe,Saldo";
            sql = sql + " from DeudaProveedor ";
            sql = sql + " where CodCuentaProveedor=" + CodCuenta.ToString();
            sql = sql + " and Saldo >0 ";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActuaizarSaldo(Int32 CodCuenta, Double Importe)
        {
            string sql = " update CuentaProveedor ";
            sql = sql + " set Saldo=" + Importe.ToString().Replace(",", ".");
            sql = sql + " where CodCuenta=" + CodCuenta.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void ActuaizarSaldoTran(SqlConnection con, SqlTransaction Transaccion,Int32 CodCuenta, Double Importe)
        {
            string sql = " update CuentaProveedor ";
            sql = sql + " set Saldo=" + Importe.ToString().Replace(",", ".");
            sql = sql + " where CodCuenta=" + CodCuenta.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion,sql);
        }

        public void BorrrarCuenta(Int32 CodCuenta)
        {
            string sql = "delete from CuentaProveedor ";
            sql = sql + " where CodCuenta=" + CodCuenta.ToString();
            cDb.ExecutarNonQuery(sql);
        }

    }
}
