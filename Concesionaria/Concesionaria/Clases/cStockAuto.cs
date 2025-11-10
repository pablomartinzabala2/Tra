using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient ;
namespace Concesionaria.Clases
{
    public  class cStockAuto
    {
        public void InsertarStockAuto(Int32 CodAuto, string Fecha,Int32? CodCliente,Int32 CodUsuario,Double? ImporteCompra)
        {
            string sql = "";
            sql = "insert into StockAuto(CodAuto,FechaAlta,CodCliente,CodUsuario,ImporteCompra)";
            sql = sql + " values(" + CodAuto.ToString();
            sql = sql + "," + "'" + Fecha + "'";
            if (CodCliente == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodUsuario.ToString();
            if (ImporteCompra !=null)
                sql = sql + "," + ImporteCompra.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public Int32 GetMaxCodStockxAuto(Int32 CodAuto)
        {
            Int32 CodStock =0;
            string sql = "select max(CodStock) as CodStock from StockAuto";
            sql = sql + " where CodAuto=" + CodAuto.ToString ();
            
            DataTable trdo = cDb.ExecuteDataTable (sql);
            if (trdo.Rows.Count >0)
                CodStock = Convert.ToInt32 (trdo.Rows[0]["CodStock"].ToString ());
        return CodStock;    
        }

        public Int32 GetMaxCodStockxAutoVigente(Int32 CodAuto)
        {
            Int32 CodStock = 0;
            string sql = "select max(CodStock) as CodStock from StockAuto";
            sql = sql + " where CodAuto=" + CodAuto.ToString();
            sql = sql + " and FechaBaja is null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodStock"].ToString() != "")
                    CodStock = Convert.ToInt32(trdo.Rows[0]["CodStock"].ToString());
            return CodStock;
        }

        public DataTable GetStockAutosVigentes(Int32 CodAuto)
        {
            string sql = "select * from StockAuto s";
            sql = sql + " where s.CodAuto =" + CodAuto.ToString();
            sql = sql + " and s.FechaBaja is null";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetStockUltimo(Int32 CodAuto)
        {
            string sql = "select * from StockAuto s";
            sql = sql + " where s.CodAuto =" + CodAuto.ToString();
            sql = sql + " order by CodStock desc ";
            // sql = sql + " and s.FechaBaja is null";
            return cDb.ExecuteDataTable(sql);

        }

        public DataTable GetStockDetalladosVigente(string Patente,Int32? CodMarca, string Modelo, int? OrdenarPrecio ,Int32? Concesion , string Facturacion )
        {
            string sql = "";
            sql = "select sa.CodStock,a.Patente";
            sql = sql + ",m.Nombre";
            sql = sql + ",Descripcion as Modelo";
            sql = sql + ",(select aa.Nombre from Anio aa where aa.CodAnio=a.CodAnio) as Año";
            sql = sql + ",(select SUBSTRING(tc.Nombre,1,1) from TipoCombustible tc where tc.Codigo=a.CodTipoCombustible) as Combustible ";
            sql = sql + ",(select cc.Nombre from Color cc where cc.CodColor=a.CodColor) as Color";
            sql = sql + ",a.Kilometros as km ";
            sql = sql + ",(select tu.Nombre from TipoUtilitario tu where tu.CodTipo=a.CodTipoUtilitario) as Tipo ";
            sql = sql + ",a.Concesion";
            sql = sql + ",sa.EstadoFc ";
            sql = sql + ", (ImporteCompra + ";
            sql = sql + " (select isnull(sum(Importe),0) from Costo cos where cos.CodStock = sa.CodStock) ";
            sql = sql + " ) as Cs ";
            sql = sql + ",sa.PrecioRevista as Revista ";
            /*
            sql = sql + ",(Importe + (select isnull(sum(Importe),0) from Costo cos where "; 
            sql = sql + " cos.CodStock = sa.CodStock ) ";
            sql = sql + " + (select isnull(sum(Importe),0) from Gasto gas where gas.CodStock = sa.CodStock)";
            //sql = sql + " + (select isnull(sum(Importe),0) from GastosRecepcionxAuto gra where gra.CodStock = sa.CodStock)";
            sql = sql + " - (select isnull(sum(dif.Importe),0) from gastospagar gap, DiferenciaTransferencia dif";
            sql = sql + " where gap.CodGasto=dif.CodGasto  and gap.CodStock = sa.CodStock)";
            sql = sql + ") as Costo";
            */
            sql = sql + ",sa.PrecioMercado ";
            sql = sql + ",sa.PrecioVenta";
           
            sql = sql + ",sa.CodEstado";
            

            sql = sql + " from auto a, StockAuto sa,marca m";
            sql = sql + " where a.Codauto =sa.CodAuto ";
           // sql = sql + " and sa.CodCliente = cli.CodCliente";
            sql = sql + " and a.CodMarca = m.CodMarca";
            sql = sql + " and sa.FechaBaja is null ";
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'";
            if (CodMarca != null)
                sql = sql + " and a.CodMarca =" + CodMarca.ToString();
            if (Modelo != "")
                sql = sql + " and a.Descripcion like " + "'%" + Modelo + "%'";

            if (Concesion !=null)
            {
                if (Concesion ==1)
                {
                    sql = sql + " and a.Concesion =1";
                }

                if (Concesion == 2)
                {
                    sql = sql + " and a.Concesion !=1";
                }
            }

            if (Facturacion != "")
            {
                sql = sql + " and sa.EstadoFc=" + "'" + Facturacion + "'";
            }

            if (OrdenarPrecio !=null)
            {
                if (OrdenarPrecio ==1)
                    sql = sql + " order by sa.PrecioVenta asc";

                if (OrdenarPrecio == 2)
                    sql = sql + " order by sa.PrecioVenta desc";
            }
            else
            {
                sql = sql + " order by m.Nombre,a.Descripcion, a.Anio desc";
            }

            
                    
            return cDb.ExecuteDataTable(sql);
        }

        public string  GetSqlInsertarStockAuto(Int32 CodAuto, string Fecha, Int32? CodCliente, Int32 CodUsuario)
        {
            string sql = "";
            sql = "insert into StockAuto(CodAuto,FechaAlta,CodCliente,CodUsuario)";
            sql = sql + "values(" + CodAuto.ToString();
            sql = sql + "," + "'" + Fecha + "'";
            if (CodCliente == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodUsuario.ToString();
            sql = sql + ")";
            return sql;
        }

        public DataTable GetStockxCodigo(Int32 CodStock)
        {
            string sql = "select s.*,a.* ";
            sql = sql + ", (select Nombre from ciudad c where c.CodCiudad = a.CodCiudad) as Ciudad";
            sql = sql + ",(select (apellido + ' ' + nombre) from cliente cli where cli.CodCliente =s.CodCliente) as ApeNom";
            sql = sql + ",(select t.Nombre from TipoCombustible t where t.Codigo = a.CodTipoCombustible) as Combustible";
            sql = sql + ",(select com.CodCompra from Compra com where com.CodStockEntrada=s.CodStock) as CodCompra";
            sql = sql + " from StockAuto s,Auto a";
            sql = sql + " where s.CodAuto =a.CodAuto";
            sql = sql + " and CodStock =" + CodStock.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void InsertarStockAutoTransaccion(SqlConnection con,SqlTransaction Transaccion, Int32 CodAuto, string Fecha, Int32? CodCliente, Int32 CodUsuario, Double? ImporteCompra)
        {
            string sql = "";
            sql = "insert into StockAuto(CodAuto,FechaAlta,CodCliente,CodUsuario,ImporteCompra)";
            sql = sql + " values(" + CodAuto.ToString();
            sql = sql + "," + "'" + Fecha + "'";
            if (CodCliente == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodUsuario.ToString();
            if (ImporteCompra != null)
                sql = sql + "," + ImporteCompra.ToString();
            else
                sql = sql + ",null";
            sql = sql + ")";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            comand.ExecuteNonQuery();
            //cDb.ExecutarNonQuery(sql);
        }

        public Int32 GetMaxCodStockxAutoTransaccion(SqlConnection con,SqlTransaction Transaccion, Int32 CodAuto)
        {
            Int32 CodStock = 0;
            string sql = "select max(CodStock) as CodStock from StockAuto";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            CodStock  = Convert.ToInt32(comand.ExecuteScalar());
            return CodStock;
        }

        public DataTable GetStockxPatente(string Patente)
        {
            string sql = "select sa.CodStock,a.Descripcion,a.CodAuto";
            sql = sql + " from StockAuto sa, auto a";
            sql = sql + " where sa.CodAuto=a.CodAuto";
            sql = sql + " and sa.FechaBaja is null ";
            sql = sql + " and a.Patente =" + "'" + Patente + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void InsertarBajaStock(Int32 CodStock, DateTime Fecha)
        {
            string sql = " update StockAuto set FechaBaja=" + "'" + Fecha.ToShortDateString () + "'" ;
            sql = sql + " where CodStock=" + CodStock.ToString () ;
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetStockAutos(Int32 CodAuto)
        {
            string sql = "select * from StockAuto s";
            sql = sql + " where s.CodAuto =" + CodAuto.ToString();
            return cDb.ExecuteDataTable(sql);

        }

        public void ActualizarPrecioVenta(Int32 CodStock, double Importe)
        {
            string sql = "Update StockAuto ";
            sql = sql + " set PrecioVenta =" + Importe.ToString ().Replace (",",".") ;
            sql = sql + " where CodStock =" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetDetallexCodStock(string Patente, Int32 CodStock)
        {
            string sql = "";
            sql = "select sa.CodStock,a.Patente";
            sql = sql + ",m.Nombre";
            sql = sql + ",Descripcion as Descripción";
            sql = sql + ",sa.FechaAlta";
            sql = sql + ", (cli.Apellido + ' ' + Cli.Nombre) as Nombre";
            //sql = sql + ",Importe as Costo";
            sql = sql + ",(Importe + (select isnull(sum(Importe),0) from Costo cos where ";
            sql = sql + " cos.CodStock = sa.CodStock ) ";
            sql = sql + " + (select isnull(sum(Importe),0) from Gasto gas where gas.CodStock = sa.CodStock)";
            //sql = sql + " + (select isnull(sum(Importe),0) from GastosRecepcionxAuto gra where gra.CodStock = sa.CodStock)";
            sql = sql + " - (select isnull(sum(dif.Importe),0) from gastospagar gap, DiferenciaTransferencia dif";
            sql = sql + " where gap.CodGasto=dif.CodGasto  and gap.CodStock = sa.CodStock)";
            sql = sql + ") as Costo";
            sql = sql + ",Concesion";
            sql = sql + ",a.Ubicacion";
            sql = sql + " from auto a, StockAuto sa,cliente cli,marca m";
            sql = sql + " where a.Codauto =sa.CodAuto ";
            sql = sql + " and sa.CodCliente = cli.CodCliente";
            sql = sql + " and a.CodMarca = m.CodMarca";
            
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'";
            sql = sql + " and sa.CodStock=" + CodStock.ToString(); 
            sql = sql + " order by m.Nombre,a.Anio desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetStockResumidoVigente(string Patente, Int32? CodMarca, string Descripcion)
        {
            string sql = "";
            sql = "select a.CodAuto,a.Patente";
            sql = sql + ",m.Nombre";
            sql = sql + ",Descripcion as Descripción ";
            sql = sql + ",(select aa.Nombre from anio aa where aa.CodAnio = a.CodAnio) as Modelo ";
            sql = sql + ",sa.CodStock";
            // sql = sql + ",sa.FechaAlta as Fecha";
            // sql = sql + ", (cli.Apellido + ' ' + Cli.Nombre) as Cliente";
            // sql = sql + ", ('') as Cliente";
            //sql = sql + ",Importe as Costo";
            //  sql = sql + ",(Importe + (select isnull(sum(Importe),0) from Costo cos where ";
            // sql = sql + " cos.CodStock = sa.CodStock ) ";
            //  sql = sql + " + (select isnull(sum(Importe),0) from Gasto gas where gas.CodStock = sa.CodStock)";
            //sql = sql + " + (select isnull(sum(Importe),0) from GastosRecepcionxAuto gra where gra.CodStock = sa.CodStock)";
            //  sql = sql + " - (select isnull(sum(dif.Importe),0) from gastospagar gap, DiferenciaTransferencia dif";
            //  sql = sql + " where gap.CodGasto=dif.CodGasto  and gap.CodStock = sa.CodStock)";
            //  sql = sql + ") as Costo";
            //   sql = sql + ",Concesion";
            //   sql = sql + ",(select suc.Nombre from sucursal suc where suc.CodSucursal=a.CodSucursal) as Ubicacion";
            //    sql = sql + ",sa.PrecioVenta";
            //    sql = sql + ",(select suc.Nombre from sucursal suc where suc.CodSucursal=a.CodSucursal) as Ubicacion";

            sql = sql + " from auto a, StockAuto sa,marca m";
            sql = sql + " where a.Codauto =sa.CodAuto ";
            // sql = sql + " and sa.CodCliente = cli.CodCliente";
            sql = sql + " and a.CodMarca = m.CodMarca";
            sql = sql + " and sa.FechaBaja is null ";
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'";
            if (CodMarca != null)
                sql = sql + " and a.CodMarca =" + CodMarca.ToString();
            if (Descripcion != null)
                sql = sql + " and a.Descripcion like " + "'%" + Descripcion + "%'";
            sql = sql + " order by m.Nombre,a.Anio desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetStockDetalladosVigenteResumenCuenta(string Patente, Int32? CodMarca)
        {
            string sql = "";
            sql = "select sa.CodStock,a.Patente";
            sql = sql + ",m.Nombre";
            sql = sql + ",Descripcion as Descripción";
            sql = sql + ",sa.FechaAlta as Fecha";
            // sql = sql + ", (cli.Apellido + ' ' + Cli.Nombre) as Cliente";
            sql = sql + ", ('') as Cliente";
            //sql = sql + ",Importe as Costo";
            sql = sql + ",(Importe + (select isnull(sum(Importe),0) from Costo cos where ";
            sql = sql + " cos.CodStock = sa.CodStock ) ";
            sql = sql + " + (select isnull(sum(Importe),0) from Gasto gas where gas.CodStock = sa.CodStock)";
            //sql = sql + " + (select isnull(sum(Importe),0) from GastosRecepcionxAuto gra where gra.CodStock = sa.CodStock)";
            sql = sql + " - (select isnull(sum(dif.Importe),0) from gastospagar gap, DiferenciaTransferencia dif";
            sql = sql + " where gap.CodGasto=dif.CodGasto  and gap.CodStock = sa.CodStock)";
            sql = sql + ") as Costo";
            sql = sql + ",Concesion";
            sql = sql + ",(select suc.Nombre from sucursal suc where suc.CodSucursal=a.CodSucursal) as Ubicacion";
            sql = sql + ",sa.PrecioVenta";
            sql = sql + ",(select suc.Nombre from sucursal suc where suc.CodSucursal=a.CodSucursal) as Ubicacion";

            sql = sql + " from auto a, StockAuto sa,marca m";
            sql = sql + " where a.Codauto =sa.CodAuto ";
            // sql = sql + " and sa.CodCliente = cli.CodCliente";
            sql = sql + " and a.CodMarca = m.CodMarca";
            sql = sql + " and sa.FechaBaja is null ";
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'";
            if (CodMarca != null)
                sql = sql + " and a.CodMarca =" + CodMarca.ToString();
            sql = sql + " order by m.Nombre,a.Anio desc";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarEstadoAuto(Int32 CodStock, int CodEstado)
        {
            string sql = "update StockAuto ";
            sql = sql + " set CodEstado=" + CodEstado.ToString();
            sql = sql + " where CodStock=" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public Double GetPrecioCompraInflacion(Int32 CodStock)
        {
            Double ImporteCompra = 0;
            Double ImporteInflacion = 0;
            Double Importe = 0;
            Clases.cStockAuto stock = new Clases.cStockAuto();
            cCosto Costo = new cCosto();
            DataTable trdoAuto = stock.GetStockxCodigo(CodStock);
            if (trdoAuto.Rows.Count > 0)
            {
                ImporteCompra = Convert.ToDouble (trdoAuto.Rows[0]["ImporteCompra"].ToString());
            }

            ImporteInflacion = Costo.GetTotalInflacion(CodStock);
            Importe = ImporteCompra + ImporteInflacion;
            return Importe;
        }

        public void ActualizarPrecioRevistaVenta(Int32 CodStock, double Importe)
        {
            string sql = "Update StockAuto ";
            sql = sql + " set PrecioRevista =" + Importe.ToString().Replace(",", ".");
            sql = sql + " where CodStock =" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void ActualizarPrecioMercado(Int32 CodStock, double Importe)
        {
            string sql = "Update StockAuto ";
            sql = sql + " set PrecioMercado =" + Importe.ToString().Replace(",", ".");
            sql = sql + " where CodStock =" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void ActualizarPreciosVariios(Int32 CodStock, Double PrecioRevista,Double PrecioMercado,Double PrecioVenta)
        {
            string sql = "update stockauto ";
            sql = sql + " set PrecioRevista=" + PrecioRevista.ToString().Replace(",", ".");
            sql = sql + ", PrecioMercado=" + PrecioMercado.ToString().Replace(",", ".");
            sql = sql + ", PrecioVenta=" + PrecioVenta.ToString().Replace(",", ".");
            sql = sql + " where CodStock=" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public void GrabarEstadoFc(int CodStock, Double ValorFc,string EstadoFc)
        {
            string sql = "update stockauto ";
            sql = sql + " set ValorFc=" + ValorFc.ToString().Replace(",", ".");
            sql = sql + ", EstadoFc=" + "'" + EstadoFc + "'";
            sql = sql + " where Codstock =" + CodStock.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
