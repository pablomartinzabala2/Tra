using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cResponsabilidadCivil
    {
        public void ActualizarTexto(Int32 CodStock)
        {
            string Texto = GetTexto(CodStock);
            string Texto2 = GetTexto2(CodStock);
            string Texto3 = GetTexto3(CodStock);

            string sql = "update responsabilidadcivil ";
            sql = sql + " set Texto1=" + "'" + Texto + "'";
            sql = sql + ", Texto2=" + "'" + Texto2 + "'";
            sql = sql + ", Texto3=" + "'" + Texto3 + "'";
            sql = sql + " where CodStock=" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        private string GetTexto(Int32 CodStock)
        {
            string Texto = "";
            string sql = " select * ";
            sql = sql + " ,(select m.Nombre  from Marca m where a.codmarca = m.CodMarca) as Marca, ";
            sql = sql + " (select aa.Nombre from anio aa where aa.CodAnio = a.codanio) as anioanio ";
            sql = sql + " from stockauto s, auto a ";
            sql = sql + " where s.CodAuto=a.CodAuto ";
            sql = sql + " and s.CodStock=" + CodStock.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                Texto = " Marca: " + trdo.Rows[0]["Marca"].ToString();
                Texto = Texto + " Modelo: " + trdo.Rows[0]["Descripcion"].ToString();
                Texto = Texto + " Año: " + trdo.Rows[0]["anioanio"].ToString();
            }
            return Texto;
        }

        private string GetTexto2(Int32 CodStock)
        {
            string Texto = "";
            string sql = " select * ";
            sql = sql + " ,(select m.Nombre  from Marca m where a.codmarca = m.CodMarca) as Marca, ";
            sql = sql + " (select aa.Nombre from anio aa where aa.CodAnio = a.codanio) as anio ";
            sql = sql + " from stockauto s, auto a ";
            sql = sql + " where s.CodAuto=a.CodAuto ";
            sql = sql + " and s.CodStock=" + CodStock.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                Texto = " Con el siguiente Motor Nº: " + trdo.Rows[0]["Motor"].ToString();
                Texto = Texto + " Chasis Nº: " + trdo.Rows[0]["Chasis"].ToString();

            }
            return Texto;
        }

        private string GetTexto3(Int32 CodStock)
        {
            string Texto = "";
            string sql = " select * ";
            sql = sql + " ,(select m.Nombre  from Marca m where a.codmarca = m.CodMarca) as Marca, ";
            sql = sql + " (select aa.Nombre from anio aa where aa.CodAnio = a.codanio) as anio ";
            sql = sql + " from stockauto s, auto a ";
            sql = sql + " where s.CodAuto=a.CodAuto ";
            sql = sql + " and s.CodStock=" + CodStock.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                Texto = " Patente : " + trdo.Rows[0]["Patente"].ToString();


            }
            return Texto;
        }

        public void Insertar(SqlConnection con, SqlTransaction Transaccion,Int32 CodStock)
        {
            string sql = "Insert into ResponsabilidadCivil( ";
            sql = sql + "CodStock)";
            sql = sql + " values (" + CodStock.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);

        }
    }
}
