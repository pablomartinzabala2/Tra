using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cPresupuesto
    {
        public void Insertar(Int32? CodAuto,Int32? CodCliente,DateTime Fecha,Double Total, string sTotal)
        {
            string sql = "Insert into Presupuesto(";
            sql = sql + "CodAuto,CodCliente,Fecha,Total,sTotal";
            sql = sql + ")";
            sql = sql + " Values(";
            sql = sql + CodAuto.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + sTotal + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }
    }
}
