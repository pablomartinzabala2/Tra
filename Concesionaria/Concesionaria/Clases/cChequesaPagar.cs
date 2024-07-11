using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Concesionaria.Clases
{
    public  class cChequesaPagar
    {
        public double GetTotalChequesaPagar()
        {
            double Total =0;
            string sql = "select sum(Saldo) as Importe";
            sql = sql + " from ChequesPagar";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["Importe"].ToString() != "")
                    Total = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
            }
            return Total;
        }

        public DataTable GetChequesPagar(DateTime FechaDesde, DateTime FechaHasta, int Impago,string Patente, 
            string Numero, string Nombre, int Vencidas)
        {
            string sql = "select c.CodCheque, c.NroCheque,";
            sql = sql + "(select (cli.Nombre + ' ' + cli.Apellido)  from Cliente cli where cli.CodCliente =c.CodCliente) as Nombre ";
            sql = sql + ",(select cli.Apellido from Cliente cli where cli.CodCliente =c.CodCliente) as Apellido";
            sql = sql + ",(select bb.Nombre from Banco bb where bb.CodBanco =c.CodBanco) as Banco ";
            sql = sql + ",c.Fecha,c.Importe,c.Saldo, c.FechaPago,";
            sql = sql + "(select a.Patente from auto a where a.CodAuto = c.CodAuto) as Patente";
            sql = sql + ",(select a.Descripcion from auto a where a.CodAuto = c.CodAuto) as Descripcion";
            sql = sql + ",c.FechaVencimiento";
            sql = sql + " from ChequesPagar c";
           // sql = sql + " from ChequesPagar c, auto au";
           // sql = sql + " where c.CodAuto = au.CodAuto";
            sql = sql + " where c.Fecha>=" + "'" + FechaDesde.ToShortDateString () + "'" ;
            sql = sql + " and c.Fecha<=" + "'" + FechaHasta.ToShortDateString () + "'";
            if (Impago ==1)
                sql = sql + " and FechaPago is null ";
            if (Patente != "")
                sql = sql + " and au.Patente like " + "'%" + Patente + "%'";
            if (Numero !="")
                sql = sql + " and c.NroCheque like " + "'%" + Numero + "%'";
            if (Vencidas ==1)
            {
                DateTime FechaHoy = DateTime.Now;
                sql = sql + " and c.FechaPago is null ";
                sql = sql + " and c.FechaVencimiento <=" + "'" + FechaHoy.ToShortDateString() + "'";
            }
            sql = sql + " order by c.FechaVencimiento asc";
            if (Nombre !="")
            {
                sql = "select c.CodCheque, c.NroCheque,cli.Nombre,Cli.Apellido ";
               // sql = sql + "(select cli.Nombre from Cliente cli where cli.CodCliente =c.CodCliente) as Nombre ";
               // sql = sql + ",(select cli.Apellido from Cliente cli where cli.CodCliente =c.CodCliente) as Apellido";
                sql = sql + ",(select bb.Nombre from Banco bb where bb.CodBanco =c.CodBanco) as Banco ";
                sql = sql + ",c.Fecha,c.Importe,c.Saldo, c.FechaPago,";
                sql = sql + "(select a.Patente from auto a where a.CodAuto = c.CodAuto) as Patente";
                sql = sql + ",(select a.Descripcion from auto a where a.CodAuto = c.CodAuto) as Descripcion";
                sql = sql + ",c.FechaVencimiento";
                sql = sql + " from ChequesPagar c, Cliente cli";
                sql = sql + " where c.CodCliente = cli.CodCliente ";
                sql = sql + " and c.Fecha>=" + "'" + FechaDesde.ToShortDateString() + "'";
                sql = sql + " and c.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
                if (Impago == 1)
                    sql = sql + " and FechaPago is null ";
                if (Patente != "")
                    sql = sql + " and au.Patente like " + "'%" + Patente + "%'";
                if (Numero != "")
                    sql = sql + " and c.NroCheque like " + "'%" + Numero + "%'";
                if (Nombre !="")
                    sql = sql + " and (cli.Nombre + ' ' + cli.Apellido) like " + "'%" + Nombre + "%'";

                if (Vencidas == 1)
                {
                    DateTime FechaHoy = DateTime.Now;
                    sql = sql + " and c.FechaPago is null ";
                    sql = sql + " and c.FechaVencimiento <=" + "'" + FechaHoy.ToShortDateString() + "'";
                }
                sql = sql + " order by c.FechaVencimiento asc";
            }                
            return cDb.ExecuteDataTable (sql);
        }

        public DataTable GetChequesPagarxCodigo(Int32 CodCheque)
        {
            string sql = "select c.*,cli.Apellido,cli.Nombre";
            sql = sql + ",(select a.Patente from auto a where a.CodAuto=c.CodAuto) as Patente";
            sql = sql + " from chequespagar c,cliente cli ";
            sql = sql + " where c.CodCliente = cli.CodCliente";
            sql = sql + " and CodCheque=" + CodCheque.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public void PagarCheque(Int32 CodCheque, DateTime Fecha)
        {
            string sql = "Update ChequesPagar ";
            sql = sql + " set FechaPago=" + "'" + Fecha.ToShortDateString () + "'" ;
            sql = sql + " where CodCheque =" + CodCheque.ToString ();
            cDb.ExecutarNonQuery(sql);
        }

        public void AnularPagarCheque(Int32 CodCheque)
        {
            string sql = "Update ChequesPagar ";
            sql = sql + " set FechaPago=null";
            sql = sql + " where CodCheque =" + CodCheque.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetChequesxCodCompra(Int32 CodCompra)
        {
            string sql = "select c.NroCheque,c.Fecha, c.Importe,";
            sql = sql + "c.FechaPago,b.Nombre as Banco,c.CodBanco,c.FechaVencimiento";
            sql = sql + " From ChequesPagar c,Banco b";
            sql = sql + " where c.CodBanco = b.CodBanco";
            sql = sql + " and c.CodCompra=" + CodCompra.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetChequesxCodCompra2(Int32 CodCompra)
        {
            string sql = "select c.NroCheque as Cheque, c.Importe";
            sql = sql + ",c.FechaVencimiento,c.CodBanco";
            sql = sql + ",b.Nombre as Banco";
            sql = sql + " From ChequesPagar c,Banco b";
            sql = sql + " where c.CodBanco = b.CodBanco";
            sql = sql + " and c.CodCompra=" + CodCompra.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void InsertarCheque(string NroCheque,
            Double Importe,Int32? CodBanco,DateTime Fecha,DateTime FechaVencimiento, Int32? CodCLiente)
        {
            string sql = "insert into ChequesPagar(";
            sql = sql + "NroCheque,Importe,CodBanco,Fecha,FechaVencimiento,CodCliente,Saldo)";
            sql = sql + " Values(" + "'" + NroCheque + "'";
            sql = sql + "," + Importe.ToString().Replace(",",".");
            if (CodBanco != null)
                sql = sql + "," + CodBanco.ToString();
            else
                sql = sql + ",null"; 
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," +"'" + FechaVencimiento.ToShortDateString() + "'";
            if (CodCLiente != null)
                sql = sql + "," + CodCLiente.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void BorrarCheque(Int32 CodCheque)
        {
            string sql = "delete from ChequesPagar ";
            sql = sql + " where CodCheque=" + CodCheque.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
