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
        public Int32  Insertar(SqlConnection con, SqlTransaction Transaccion,Int32? CodAuto,Int32? CodCliente,DateTime Fecha,Double Total, string sTotal,Double ImporteEfectivo,
            Double ImporteCheque,Double ImporteCobranza,Double ImporteTransferencia,Double ImporteDocumento)
        {
            string sql = "Insert into Presupuesto(";
            sql = sql + "CodAuto,CodCliente,Fecha,Total,sTotal,ImporteEfectivo,";
            sql = sql + "ImporteCheque, ImporteCobranza, ImporteTransferencia, ImporteDocumento";
            sql = sql + ")";
            sql = sql + " Values(";
            sql = sql + CodAuto.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + "'" + sTotal + "'";
            sql = sql + "," + ImporteEfectivo.ToString().Replace(",", ".");
            sql = sql + "," + ImporteCheque.ToString().Replace(",", ".");
            sql = sql + "," + ImporteCobranza.ToString().Replace(",", ".");
            sql = sql + "," + ImporteTransferencia.ToString().Replace(",", ".");
            sql = sql + "," + ImporteDocumento.ToString().Replace(",", ".");
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public void ActualizarNumero(SqlConnection con, SqlTransaction Transaccion, Int32 CodPresupuesto, string Numero)
        {
            string sql = "Update Presupuesto set ";
            sql = sql + " Numero =" + "'" + Numero + "'";
            sql = sql + " where CodPresupuesto=" + CodPresupuesto.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetPresupuestos(DateTime FechaDesde, DateTime FechaHasta, string Nombre,string Apellido)
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
            sql = sql + " and p.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and p.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'"; 
            if (Nombre !="")
            {
                sql = sql + " and c.Nombre like " + "'%" + Nombre + "%'";
            }

            if (Apellido!="")
            {
                sql = sql + " and c.Apellido like " + "'%" + Apellido + "%'";
            }
            sql = sql + " order by c.Apellido,c.Nombre ";
            return cDb.ExecuteDataTable(sql);

        }

        public string GetNumeroPresupueseto(Int32 CodPresupuesto)
        {

            string Numero = "NP° ";
            switch(CodPresupuesto.ToString ().Length )
            {
                case 1:
                    Numero = Numero + " " + "000" + CodPresupuesto.ToString();
                    break;
                case 2:
                    Numero = Numero + " " + "00" + CodPresupuesto.ToString();
                    break;
                case 3:
                    Numero = Numero + " " + "0" + CodPresupuesto.ToString();
                    break;
                case 4:
                    Numero = Numero + " " + "" + CodPresupuesto.ToString();
                    break;
            }
            return Numero;
        }

        public DataTable GetPresupuestoxCodigo(Int32 CodPresupuesto)
        {
            string sql = "select * from Presupuesto p";
            sql = sql + " where p.CodPresupuesto=" + CodPresupuesto.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void Borrar(Int32 CodPresupuesto)
        {
            string sql = "delete from Presupuesto ";
            sql = sql + " where CodPresupuesto=" + CodPresupuesto.ToString();
            cDb.ExecutarNonQuery(sql);

            sql = "delete from ReportePresupuesto ";
            sql = sql + " where CodPresupuesto=" + CodPresupuesto.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetGastosTransferencia(Int32 CodPresupuesto)
        {
            string sql = "select c.Codigo,c.Descripcion,'Transferencia' as Tipo,g.Importe ";
            sql = sql + " from GastosTransferenciaPresupuesto g,CategoriaGastoTransferencia c";
            sql = sql + " where g.CodGastoTranasferencia=c.Codigo ";
            sql = sql + " and g.CodPresupuesto=" + CodPresupuesto.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetPresupuestoxAuto(Int32 CodPresupuesto)
        {
            string sql = "select p.* ";
            sql = sql + " ,(select a.Patente from auto a where a.CodAuto=p.CodAuto) as Patente ";
            sql = sql + " from PresupuestoxAuto p";
            sql = sql + " where p.CodPresupuesto =" + CodPresupuesto.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
