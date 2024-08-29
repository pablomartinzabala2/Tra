using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cProveedor
    {
        public DataTable GetProveedor(Int32 CodProveedor)
        {
            string sql = "select * from Proveedor ";
            sql = sql + " where CodProveedor =" + CodProveedor.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetProveedorxNombre(string Nombre)
        {
            string sql = "select p.CodProveedor , p.Nombre ,p.Telefono ";
            sql = sql + " from Proveedor p";
            if (Nombre !="")
                sql = sql + " where p.Nombre like " + "'%" + Nombre + "%'";
            sql = sql + " order by p.Nombre ";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
