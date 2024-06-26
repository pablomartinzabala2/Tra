﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cEfectivoaPagar
    {
        public void Insertar(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha,double Importe,Int32 CodCompra,Int32? CodCliente,Int32 CodAuto, Double Facturado,Double Total, DateTime FechaVencimiento)
        {
            string sql = "insert into EfectivosaPagar(Fecha,Importe,Saldo,CodCompra,CodCliente,CodAuto,ImportePagado,Facturado,SaldoFacturado,Total,FechaVencimiento)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString () + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + CodCompra.ToString();
            if (CodCliente == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodAuto.ToString();
            sql = sql + ",0";
            sql = sql + "," + Facturado.ToString().Replace(",", ".");
            sql = sql + "," + Facturado.ToString().Replace(",", ".");
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + FechaVencimiento.ToShortDateString() + "'";
            sql = sql + ")"; 
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            comand.ExecuteNonQuery();
        }

        public DataTable GetEfectivosaPagarxFecha(DateTime FechaDesde, DateTime FechaHasta,string Patente,int SoloImpago, string Nombre, string Descriipcion, int Vencida)
        {
            DateTime Hoy = DateTime.Now;
            string sql = "select e.CodRegistro,e.FechaVencimiento,";
            sql = sql + "(select (c.Nombre + ' ' + c.Apellido) from Cliente c where c.CodCliente = e.CodCliente) as Apellido";
            sql = sql + ",(select a.Patente from auto a where a.CodAuto = e.CodAuto) as Patente";
            sql = sql + ",(select a.Descripcion from auto a where a.CodAuto = e.CodAuto) as Modelo ";
            sql = sql + ",e.Total,e.Importe as Efectivo,e.Saldo as SaldoEfectivo,e.Facturado, e.SaldoFacturado  ";
            sql = sql + " from EfectivosaPagar e,auto au,Cliente cli";
            sql = sql + " where e.CodAuto = au.CodAuto ";
            sql = sql + " and e.CodCliente = cli.CodCliente ";
            sql = sql + " and e.Fecha >=" + "'" + FechaDesde.ToShortDateString () + "'" ;
            sql = sql + " and e.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente != "")
                sql = sql + " and au.Patente like " + "'%" + Patente + "%'";
            if (SoloImpago == 1)
                sql = sql + " and ( e.Saldo + e.SaldoFacturado ) > 0 ";
            if (Nombre != "")
                sql = sql + " and cli.Nombre like " + "'%" + Nombre + "%'";
            /*
            if (CodTipo !=null)
            {
                sql = sql + " and e.CodTipo=" + CodTipo.ToString();
            }
            */
            if (Vencida == 1)
            {
                sql = sql + " and e.FechaVencimiento >=" + "'" + Hoy.ToShortDateString() + "'";
                sql = sql + " and e.FechaPago is null ";
            }
            if (Descriipcion != "")
                sql = sql + " and au.Descripcion like " + "'%" + Descriipcion + "%'";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetEfectivosaPagarxCodigo(Int32 CodRegistro)
        {
            string sql = " select e.*";
            sql = sql + ",c.Apellido,c.Nombre,a.Patente,a.Descripcion";
            sql = sql + " from EfectivosaPagar e,auto a,cliente c";
            sql = sql + " where e.CodCliente = c.CodCliente";
            sql = sql + " and e.CodAuto = a.CodAuto";
            sql = sql + " and e.CodRegistro=" + CodRegistro.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarPago(Int32 CodRegistro, DateTime Fecha,double Importe)
        {
            string sql = "Update EfectivosaPagar";
            sql = sql + " set Saldo = Saldo -" + Importe.ToString ().Replace (",",".");
            sql = sql + ",ImportePagado = ImportePagado + " + Importe.ToString ().Replace (",",".");
            sql = sql + ",FechaPago=" + "'" + Fecha.ToShortDateString () +"'";
            sql = sql + " where CodRegistro=" + CodRegistro.ToString ();
            cDb.ExecutarNonQuery (sql);
        }

        public void ActualizarPagoFacturado(Int32 CodRegistro, DateTime Fecha, double Importe)
        {
            string sql = "Update EfectivosaPagar";
            sql = sql + " set SaldoFacturado = SaldoFacturado -" + Importe.ToString().Replace(",", ".");
            sql = sql + ",ImportePagadoFacturado = ImportePagadoFacturado + " + Importe.ToString().Replace(",", ".");
            sql = sql + ",FechaPago=" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + " where CodRegistro=" + CodRegistro.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public Double TotalSaldo()
        {
            double Importe = 0;
            string sql = "select isnull(sum(Saldo),0) as Importe from EfectivosaPagar";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString ());
            }
            return Importe;
        }

        public void Anular(Int32 CodRegistro)
        {
            string sql = "update efectivosapagar";
            sql = sql + " set ImportePagado =0";
            sql = sql + ",Saldo = Importe";
            sql = sql + ",FechaPago =null";
            sql = sql + " where CodRegistro=" + CodRegistro.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void AnularFacturado(Int32 CodRegistro)
        {
            string sql = "update efectivosapagar";
            sql = sql + " set ImportePagadoFacturado =0";
            sql = sql + ",SaldoFacturado = Facturado ";
            sql = sql + ",FechaPago =null";
            sql = sql + " where CodRegistro=" + CodRegistro.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetEfectivoPagarxCodCompra(Int32 CodCompra)
        {
            string sql = "select * from EfectivosaPagar where CodCompra=" + CodCompra.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}

