using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace Concesionaria.Clases
{
    public class cPresupuesto
    {
        public Int32  Insertar(SqlConnection con, SqlTransaction Transaccion,Int32? CodAuto,Int32? CodCliente,DateTime Fecha,Double Total, string sTotal,Double ImporteEfectivo)
        {
            string sql = "Insert into Presupuesto(";
            sql = sql + "CodAuto,CodCliente,Fecha,Total,sTotal,ImporteEfectivo";
            sql = sql + ")";
            sql = sql + " Values(";
            sql = sql + CodAuto.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + sTotal + "'";
            sql = sql + "," + ImporteEfectivo.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public DataTable GetPresupuestos()
        {
            string sql = "select p.CodPresupuesto,c.Apellido,c.Nombre,";
            sql = sql + "a.Descripcion as Modelo";
            sql = sql + ",m.Nombre as Marca";
            sql = sql + ",(select t.Nombre from TipoUtilitario t where t.CodTipo =a.CodTipoUtilitario) as Tipo ";
            sql = sql + ",p.Fecha,p.Total ";
            sql = sql + " from Presupuesto p,auto a,Marca m, Cliente c";
            sql = sql + " where p.CodAuto = a.CodAuto ";
            sql = sql + " and a.CodMarca = m.CodMarca";
            sql = sql + " and p.CodCliente=c.CodCliente";
            sql = sql + " order by p.CodPresupuesto desc";
            return cDb.ExecuteDataTable(sql);

        }
    }
}
