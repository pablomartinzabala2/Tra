using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cVencimiento
    {
        private void  CargarVencimientos()
        {
            cDb.ExecutarNonQuery("delete from Vencimiento");
            DateTime Fecha = DateTime.Now;
            Fecha = Fecha.AddDays(7);
            string sql = "select c.* ";
            sql = sql + " ,(select cli.Nombre from Cliente cli where cli.CodCliente=c.CodCliente) as Nombre ";
            sql = sql + " ,(select cli.Apellido from Cliente cli where cli.CodCliente=c.CodCliente) as Apellido ";
            sql = sql + ",(select  b.Nombre from Banco b where b.CodBanco=c.CodBanco) as Banco ";
            sql = sql + " from ChequesPagar c ";
            sql = sql + " where c.FechaPago is null ";
            sql = sql + " and c.FechaVencimiento <=" + "'" + Fecha.ToShortDateString() + "'";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                string Tabla = "";
                Double Importe = 0;
                DateTime FechaRegistro = DateTime.Now;
                DateTime FechaVto = DateTime.Now;
                string Nombre = "";
                string Apellido = "";
                string NomApe = "";
                string Banco = "";
                for (int i = 0; i < trdo.Rows.Count ; i++)
                {
                    Tabla = "Cheque a Pagar ";
                    Importe = Convert.ToDouble(trdo.Rows[i]["Importe"]);
                    FechaRegistro = Convert.ToDateTime(trdo.Rows[i]["Fecha"]);
                    FechaVto = Convert.ToDateTime(trdo.Rows[i]["FechaVencimiento"]);
                    Nombre = trdo.Rows[i]["Nombre"].ToString();
                    Apellido = trdo.Rows[i]["Apellido"].ToString();
                    NomApe = Nombre + " " + Apellido;
                    Banco = trdo.Rows[i]["Banco"].ToString();
                    InsertarVencimiento(Tabla, FechaRegistro, FechaVto, Importe,NomApe,Banco);
                    
                }

            }
        }

        private void InsertarVencimiento(string Tabla,DateTime Fecha,DateTime FechaVencimiento,Double Importe,string Cliente, string Banco)
        {
            string sql = "insert into Vencimiento (Tabla,Fecha,FechaVencimiento,Importe,Cliente,Banco)";
            sql = sql + " Values(" + "'" + Tabla + "'";
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + "'" + FechaVencimiento + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + "'" + Cliente + "'";
            sql = sql + "," + "'" + Banco + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetVencimiento()
        {
            CargarVencimientos();
            string sql = "select CodVencimiento,Tabla,Fecha,FechaVencimiento,Cliente,Importe,Banco from Vencimiento order by FechaVencimiento asc  ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            return trdo;
        }
    }
}
