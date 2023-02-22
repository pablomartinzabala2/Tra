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
    }
}
