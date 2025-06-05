using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cChofer
    {
        public DataTable GetChofer ()
        {
            string sql = " select CodChofer, (Nombre + ' ' + Apellido ) as Nombre ";
            sql = sql + " from Chofer ";
            sql = sql + " Order by Apellido, Nombre ";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
