using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class CPresupuestoxAuto
    {
        public void Insertar (SqlConnection con, SqlTransaction Transaccion,Int32? CodPresupuesto, Int32 CodAuto, Double Importe)
        {
            string sql = "Insert into PresupuestoxAuto";
            sql = sql + "(CodPresupuesto,CodAuto,Importe)";
            sql = sql + " Values(" + CodPresupuesto.ToString();
            sql = sql + "," + CodAuto.ToString();
            sql = sql + "," + Importe.ToString();
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql); 
        }
    }
}
