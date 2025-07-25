using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cConcepto
    {
        public DataTable GetConceptos()
        {
            string sql = "";
            sql = "select CodConcepto, Nombre ";
            sql = sql + " from Concepto ";
            sql = sql + " order by Nombre ";
            return cDb.ExecuteDataTable(sql);
        }

        public string GetConceptoxCodigo(Int32 CodConcepto)
        {
            string Nombre = "";
            string sql = "";
            sql = "select CodConcepto, Nombre ";
            sql = sql + " from Concepto ";
            sql = sql + " where CodConcepto =" + CodConcepto.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["Nombre"].ToString ()!="")
                {
                    Nombre = trdo.Rows[0]["Nombre"].ToString();
                }
            }
            return Nombre;
            
        }
    }
}
