﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace Concesionaria.Clases
{
    public  class cVenta
    {
        public DataTable GetVentas()
        {
            string sql = "select v.CodVenta,c.Apellido,c.Nombre,v.Fecha,a.Patente,a.Descripcion";
            sql = sql + " From Venta v,Cliente c,Auto a";
            sql = sql + " Where v.CodCliente = c.CodCliente";
            sql = sql + " and v.CodAutoVendido=a.CodAuto";
            sql = sql + " order by CodVenta desc";

            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetVentaxCodigo(Int32 CodVenta)
        {
            string sql = "";
            sql = "select v.*,a.Patente";
            //sql = sql + "( select p.CodEntidad from prenda p where p.CodVenta = v.CodVenta) as CodEntidad";
            sql = sql + ",(select top 1 cob.FechaCompromiso from Cobranza cob where cob.CodVenta = v.CodVenta) as FechaCompromiso";
            sql = sql + ",(select importe from ComisionVendedor comVen where comVen.CodVenta = v.CodVenta) as ImporteVendedor";
            sql = sql + " from venta v,auto a";
            sql = sql + " where v.CodAutoVendido=a.CodAuto";
            sql = sql + " and v.CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 GetMaximaCodVentaxAuto(Int32 CodAuto)
        {
            Int32 CodVenta = -1;
            string sql = "select max(CodVenta) as CodVenta from venta";
            sql = sql + " where CodAutoVendido =" + CodAuto.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodVenta"].ToString() != "")
                {
                    CodVenta = Convert.ToInt32(trdo.Rows[0]["CodVenta"].ToString());
                }
            }
            return CodVenta;
        }

        public DataTable GetVentasxFecha(DateTime FechaDesde, DateTime FechaHasta,string Patente,string Apellido, string Nombre, Int32? CodMarca, string Descripcion , int OrdenDescendente)
        {
            string sql = "";
            // sql = "select Distinct v.CodVenta,c.Apellido,(c.Nombre  + ' ' + c.Apellido) as Nombre ,a.Patente,a.Descripcion,sa.DescripcionAutoPartePago";
            //sql = "select Distinct v.CodVenta,c.Apellido,(c.Nombre  + ' ' + c.Apellido) as Nombre,a.Patente,";
            sql = "select Distinct v.CodVenta,v.Fecha,c.Apellido,v.Titulares as Nombre,a.Patente,";
            sql = sql + "(select mm.Nombre from Marca mm where mm.CodMarca=a.CodMarca) as Marca ";
            sql = sql + ", a.Descripcion";
            sql = sql + ",(select aaa.patente from auto aaa where aaa.CodAuto=(select max(sa.codauto) from VentasxAuto va, StockAuto sa where va.CodAuto = sa.CodAuto )) as DescripcionAutoPartePago ";
            
            sql = sql + ",(v.ImporteVenta + ";
            sql = sql + " (select isnull(sum(gg.Importe),0) from GastosTransferencia gg where gg.CodVenta=v.CodVenta)";
            sql = sql + " + (select isnull(sum(gr.Importe),0) from GastosRecepcion gr where gr.CodVenta=v.CodVenta)";
            sql = sql + ") as ImporteVenta ";
            sql = sql + ",ImporteEfectivo,v.ImporteAutoPartePago,v.ImporteCredito,v.ImportePrenda";
            sql = sql + ", (select sum(Importe) from Cheque che ";
            sql = sql + "  where che.CodVenta = v.CodVenta and che.CodPrenda is null) as Cheque";
          //  sql = sql + ", v.ImporteCobranza";
            sql = sql + ",(select isnull(sum(cobr.Saldo),0) from Cobranza cobr where cobr.CodVenta=v.CodVenta) as ImporteCobranza ";
            sql = sql + "," + "(isnull(v.ImporteVenta,0)";
            sql = sql + " - (select isnull(sum(ssa.ImporteCompra),0) from StockAuto ssa where ssa.CodStock = v.CodStock)";
            sql = sql + " - (select isnull(sum(Importe),0) from Costo cst where cst.CodStock = v.CodStock)";
            sql = sql + " -(select isnull(sum(Importe),0) from gasto gst where gst.CodStock = v.CodStock)";
            //sql = sql + " - (select isnull(sum(Importe),0) from GastosRecepcionxAuto gra where gra.CodStock = v.CodStock)";
            sql = sql + " - (select isnull(sum(Importe),0) from ComisionVendedor co where co.CodVenta = v.CodVenta )";
            sql = sql + " - (select isnull(sum(Importe),0) from Garantia gar where gar.CodVenta = v.CodVenta )";
            sql = sql + " + (select isnull(sum(Importe),0) from DiferenciaTransferencia dif where dif.CodVenta = v.CodVenta )";
            sql = sql + " + (select isnull(sum(Diferencia),0) from Prenda Pren where Pren.CodVenta = v.CodVenta )";
            sql = sql + " - (select isnull(sum(Importe),0) from Impuesto Imp where Imp.CodVenta = v.CodVenta )";
            sql = sql + " ) as Ganancia";
            sql = sql + ",v.CodCliente";
            sql = sql + ",'Venta' as TpoVenta ";
            sql = sql + ",(";
            sql = sql + " (select isnull(sum(Saldo),0) from Cuotas  where Cuotas.CodVenta = v.CodVenta)";
            sql = sql + " + (select isnull(sum(Importe),0) from cheque where cheque.codventa = v.CodVenta and cheque.FechaPago is null) ";
            sql = sql + " + (select isnull(sum(Saldo),0) from Prenda where Prenda.codventa = v.CodVenta ) ";
            sql = sql + " + (select isnull(sum(Saldo),0) from Cobranza  where Cobranza.CodVenta = v.CodVenta)";
            sql = sql + ") As Saldo ";
            sql = sql + ",v.Archivo";
            sql = sql + " from venta v,cliente c,auto a,stockauto sa";
            sql = sql + " where v.CodCliente = c.CodCliente";
            sql = sql + " and v.CodAutoVendido=a.CodAuto";
            sql = sql + " and a.CodAuto = sa.CodAuto";
            //AGREGO ESTA LINEA PARA NO DULICR EL VEH
            sql = sql + " and v.CodStock = sa.CodStock";
            sql = sql + " and v.Fecha >=" + "'" + FechaDesde.ToShortDateString() +"'";
            sql = sql + " and v.Fecha<=" + "'" + FechaHasta.ToShortDateString() + "'";
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'";
            if (Apellido != null)
                sql = sql + " and v.Titulares like" + "'%" + Apellido + "%'" ;
            if (Nombre  != null)
                sql = sql + " and v.Titulares like" + "'%" + Nombre + "%'";

            if (CodMarca !=null)
            {
                sql = sql + " and a.CodMarca =" + CodMarca.ToString();
            }

            if (Descripcion !="")
            {
                sql = sql + " and a.Descripcion like " + "'%" + Descripcion + "%'";
            }

            if (OrdenDescendente == 1)
            {
                sql = sql + " order by v.Fecha Desc ";
            }
            else
            {
                sql = sql + " order by v.Fecha Asc ";
            }

            
            return cDb.ExecuteDataTable(sql);  
        }

      

        public Double GetCostosTotalesxCodStock(Int32 CodStock)
        {
            Double Total = 0;
            string sql = "select ImporteCompra from StockAuto sa";
            sql = sql + " where sa.CodStock=" + CodStock.ToString ();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["ImporteCompra"].ToString() != "")
                    Total = Total + Convert.ToDouble(trdo.Rows[0]["ImporteCompra"].ToString());

            sql = "select sum(Importe) as Importe from Costo";
            sql = sql + " where CodStock =" + CodStock.ToString();
            DataTable trdo2 = cDb.ExecuteDataTable(sql);
            if (trdo2.Rows.Count > 0)
                if (trdo2.Rows[0]["Importe"].ToString() != "")
                    Total = Total + Convert.ToDouble(trdo2.Rows[0]["Importe"].ToString());

            sql = "select sum(Importe) as Importe from Gasto";
            sql = sql + " where CodStock =" + CodStock.ToString();
            DataTable trdo3 = cDb.ExecuteDataTable(sql);
            if (trdo3.Rows.Count > 0)
                if (trdo3.Rows[0]["Importe"].ToString() != "")
                    Total = Total + Convert.ToDouble(trdo3.Rows[0]["Importe"].ToString());

            return Total;
        }

        public DataTable GetAutosxCodVenta(Int32 CodVenta)
        {
            string sql = "select v.CodAuto,a.Patente,a.Descripcion, ";
            sql = sql + "(select m.Nombre from marca m where m.CodMarca = a.CodMarca) as Marca,";
            sql = sql + "v.Importe";
            sql = sql + ",v.CodAuto as CodStock,a.CodAuto";
           // sql = sql + ",(select sa.CodStock from stockauto sa where sa.CodStock=a.CodAuto) as CodStock";
            sql = sql + " from VentasxAuto v, auto a, stockauto sa";
            sql = sql + " where v.CodAuto = sa.CodStock";
            sql = sql + " and sa.CodAuto = a. CodAuto";
            sql = sql + " and v.CodVenta =" + CodVenta.ToString ();
            return cDb.ExecuteDataTable (sql);
        }

        public DataTable GetGastosRecepcionxCodVenta(Int32 CodVenta)
        {
            string sql = "select *";
            sql = sql + " from GastosRecepcion gr,CategoriaGastoRecepcion cat";
            sql = sql + " where gr.CodGasto = cat.codigo";
            sql = sql + " and gr.CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetCuotaxCodVenta(Int32 CodVenta)
        {
            string sql = "select c.Cuota,c.Importe,c.FechaVencimiento,c.ImporteSinInteres as CuotasSinInteres";
            sql = sql + " from Cuotas c";
            sql = sql + " where c.CodVenta =" + CodVenta.ToString (); ;
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetChequesxCodVenta(Int32 CodVenta)
        {
            string sql = "select c.NroCheque,c.Importe,c.FechaVencimiento";
            sql = sql + ",c.CodBanco,b.Nombre as Banco";
            sql = sql + " from Cheque c,Banco b";
            sql = sql + " where c.CodBanco = b.CodBanco";
            sql = sql + " and c.CodVenta =" + CodVenta.ToString();
            sql = sql + " and c.CodPrenda is null";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetAutosPartePago(Int32 CodVenta)
        {
            string sql = "select * from VentasxAuto";
            sql = sql + " where CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }
        public int TieneDeuda(Int32 CodVenta)
        {
            int Deuda = 0;
            string sql = "";
            sql = "select isnull(sum(saldo),0) as Saldo from Cuotas";
            sql = sql + " where CodVenta=" + CodVenta.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Saldo"].ToString() != "")
                {
                    Double Saldo = Convert.ToDouble(trdo.Rows[0]["Saldo"].ToString());
                    if (Saldo > 0)
                        Deuda = 1;
                }

            sql = "select isnull(sum(saldo),0) as Saldo from Prenda";
            sql = sql + " where CodVenta=" + CodVenta.ToString();
            DataTable trdo2 = cDb.ExecuteDataTable(sql);
            if (trdo2.Rows.Count > 0)
                if (trdo2.Rows[0]["Saldo"].ToString() != "")
                {
                    Double Saldo = Convert.ToDouble(trdo2.Rows[0]["Saldo"].ToString());
                    if (Saldo > 0)
                        Deuda = 1;
                }

            sql = "select * from Cheque";
            sql = sql + " where CodVenta=" + CodVenta.ToString();
            DataTable trdo3 = cDb.ExecuteDataTable(sql);
            if (trdo3.Rows.Count > 0)
                if (trdo3.Rows[0]["FechaPago"].ToString() == "")
                {
                    Deuda = 1;
                }

            sql = "select isnull(sum(saldo),0) as Saldo from Cobranza c";
            sql = sql + " where c.CodVenta=" + CodVenta.ToString();
            DataTable trdo4 = cDb.ExecuteDataTable(sql);
            if (trdo4.Rows.Count > 0)
                if (trdo4.Rows[0]["Saldo"].ToString() != "")
                {
                    Double Saldo = Convert.ToDouble(trdo4.Rows[0]["Saldo"].ToString());
                    if (Saldo > 0)
                        Deuda = 1;
                }

            return Deuda;
        }

        public DataTable GetClientesxCodVenta(Int32 CodVenta)
        {
            string sql = "select * from  VentaxCliente v, cliente cli ";
            sql = sql + " where v.CodCliente = cli.CodCliente ";
            sql = sql + " and v.CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarArchivo (string Archivo ,Int32 CodVenta)
        {
            string sql = "update Venta set Archivo =" + "'" + Archivo + "'";
            sql = sql + " where CodVenta =" + CodVenta.ToString();
            cDb.ExecutarNonQuery(sql);
        }


    }
}
