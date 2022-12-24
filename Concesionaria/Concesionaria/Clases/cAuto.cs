﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient ;
namespace Concesionaria.Clases
{
    public class cAuto
    {
        public void AgregarAuto(string Patente, Int32? CodMarca,
            string Descripcion, Int32? Kilometros,
            Int32? CodCiudad, int Propio, int Concesion,
            string Observacion, string Anio,Double? Importe,
            string Motor,string Chasis, string Color,Int32? CodTipoCombustible ,
            Int32? CodAnio
            )
        {
            string sql = "Insert into auto(";
            sql = sql + "Patente,CodMarca,Descripcion";
            sql = sql + ",Kilometros,CodCiudad,Propio,Concesion";
            sql = sql + ",Observacion,Anio,Importe,Motor,Chasis,Color,CodTipoCombustible";
            sql = sql + ",CodAnio";
            sql = sql + ")";
            sql = sql + "Values (";
            sql = sql + "'" + Patente + "'";
            if (CodMarca != null)
                sql = sql + "," + CodMarca.ToString();
            else
                sql = sql + ",null";

            sql = sql + "," + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + "," + Kilometros.ToString();
            else
                sql = sql + ",null";
            if (CodCiudad != null)
                sql = sql + "," + CodCiudad.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Propio.ToString();
            sql = sql + "," + Concesion.ToString();
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",null";
            else
                sql = sql + "," + Importe.ToString();
            sql = sql + "," + "'" + Motor +"'";
            sql = sql + "," + "'" + Chasis + "'";
            sql = sql + "," + "'" + Color + "'";
            if (CodTipoCombustible ==null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodTipoCombustible.ToString (); 
            if (CodAnio !=null)
            {
                sql = sql + "," + CodAnio.ToString(); 
            }
            else
            {
                sql = sql + ",null";
            }
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql); 
        }

        public string GetSqlAgregarAuto(string Patente, Int32? CodMarca,
            string Descripcion, Int32? Kilometros,
            Int32? CodCiudad, int Propio, int Concesion,
            string Observacion, string Anio, Double? Importe ,
            Int32? CodAnio , Int32? CodColor
            )
        {
            string sql = "Insert into auto(";
            sql = sql + "Patente,CodMarca,Descripcion";
            sql = sql + ",Kilometros,CodCiudad,Propio,Concesion";
            sql = sql + ",Observacion,Anio,Importe,";
            sql = sql + "CodAnio,CodColor";
            sql = sql + ")";
            sql = sql + "Values (";
            sql = sql + "'" + Patente + "'";
            if (CodMarca != null)
                sql = sql + "," + CodMarca.ToString();
            else
                sql = sql + ",null";

            sql = sql + "," + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + "," + Kilometros.ToString();
            else
                sql = sql + ",null";
            if (CodCiudad != null)
                sql = sql + "," + CodCiudad.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Propio.ToString();
            sql = sql + "," + Concesion.ToString();
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",null";
            else
                sql = sql + "," + Importe.ToString();
            if (CodAnio !=null)
            {
                sql = sql + "," + CodAnio.ToString();
            }
            else
            {
                sql = sql + ",null";
            }
             
            if (CodColor != null)
            {
                sql = sql + "," + CodColor.ToString();
            }
            else
            {
                sql = sql + ",null";
            }

            sql = sql + ")";
            return sql;
        }

        public DataTable GetAutoxPatente(string Patente)
        {
            string sql = "select a.* ";
            sql = sql + ",(select c.CodProvincia from Ciudad c where c.CodCiudad = a.CodCiudad) as CodProvincia" ;
            sql = sql + " from auto a ";
           sql = sql + " where patente=" + "'" + Patente + "'";
           return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetAutoxCodigoAuto(Int32 CodAuto)
        {
            string sql = "select a.* ";
            sql = sql + ",(select c.CodProvincia from Ciudad c where c.CodCiudad = a.CodCiudad) as CodProvincia";
            sql = sql + " from auto a ";
            sql = sql + " where CodAuto=" + CodAuto.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void  ModificarAuto(string Patente, Int32? CodMarca,
            string  Descripcion, Int32? Kilometros,
            Int32? CodCiudad, int Propio, int Concesion,
            string Observacion, string Anio, Double? Importe,string Motor,string Chasis,string Color)
        {
            string sql = "";
            sql = "update auto set";
            if (CodMarca != null)
                sql = sql + " CodMarca=" + CodMarca.ToString();
            else
                sql = sql + " CodMarca=null";
            sql = sql + ",Descripcion =" + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + ",Kilometros =" + Kilometros.ToString();
            else
                sql = sql + ",Kilometros =null ";

            if (CodCiudad != null)
                sql = sql + ",CodCiudad =" + CodCiudad.ToString();
            else
                sql = sql + ",CodCiudad=null";
            
            sql = sql + ",Propio = " + Propio.ToString();
            sql = sql + ",Concesion = " + Concesion.ToString();
            sql = sql + ",Observacion =" + "'" + Observacion + "'";
            sql = sql + ",Anio =" + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",Importe =null";
            else
                sql = sql + ",Importe =" + Importe.ToString();
            sql = sql + ",Motor =" + "'" + Motor + "'";
            sql = sql + ",Chasis =" + "'" + Chasis + "'";
            sql = sql + ",Color =" + "'" + Color +"'";
            sql = sql + " where patente =" + "'" + Patente + "'";
            
            cDb.ExecutarNonQuery(sql);
        }

        public string GetSqlModificarAuto(string Patente, Int32? CodMarca,
            string Descripcion, Int32? Kilometros,
            Int32? CodCiudad, int Propio, int Concesion,
            string Observacion, string Anio, Double? Importe)
        {
            string sql = "";
            sql = "update auto set";
            if (CodMarca != null)
                sql = sql + " CodMarca=" + CodMarca.ToString();
            else
                sql = sql + " CodMarca=null";
            sql = sql + ",Descripcion =" + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + ",Kilometros =" + Kilometros.ToString();
            else
                sql = sql + ",Kilometros =null ";

            if (CodCiudad != null)
                sql = sql + ",CodCiudad =" + CodCiudad.ToString();
            else
                sql = sql + ",CodCiudad=null";

            sql = sql + ",Propio = " + Propio.ToString();
            sql = sql + ",Concesion = " + Concesion.ToString();
            sql = sql + ",Observacion =" + "'" + Observacion + "'";
            sql = sql + ",Anio =" + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",Importe =null";
            else
                sql = sql + ",Importe =" + Importe.ToString();
            sql = sql + " where patente =" + "'" + Patente + "'";
            return sql;
        }

        public Int32 GetMaxCodAuto()
        {
            Int32 CodAuto = 0;
            string sql = "select max(codAuto) as CodAuto from auto";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                CodAuto = Convert.ToInt32(trdo.Rows[0]["CodAuto"].ToString()); 
            }
            return CodAuto;
        }

        public DataTable GetAutosCompradosxCodCliente(Int32 CodCliente)
        {
            string sql = "select a.CodAuto, a.Patente,a.Descripcion";
            sql =sql + " from Venta v, auto a";
            sql = sql + " where v.CodAutoVendido=a.CodAuto";
            sql = sql + " and v.CodCliente =" + CodCliente;
            sql = sql + " order by v.CodVenta desc";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetAutosCompradosxCuotasxCodCliente(Int32 CodCliente)
        {
            string sql = "select v.CodVenta, a.CodAuto, a.Patente,a.Descripcion";
            sql = sql + ", (select isnull(sum(ImporteSinInteres),0) from Cuotas where CodVenta=v.CodVenta) as Capital";
            sql = sql + " from Venta v, auto a";
            sql = sql + " where v.CodAutoVendido=a.CodAuto";
            sql = sql + " and v.CodCliente =" + CodCliente;
            sql = sql + " and v.ImporteCredito >0";
            sql = sql + " order by v.CodVenta desc";
            return cDb.ExecuteDataTable(sql);
        }

        public Boolean PuedeBorrar(Int32 CodAuto)
        {
            Boolean Borra = true;
            string sql = "select * from venta where CodAutoVendido =" + CodAuto.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodAutoVendido"].ToString() != "")
                    Borra = false;
            return Borra;
        }

        public DataTable GetAutos(string Patente)
        {
            string sql = "select a.CodAuto,a.Patente,a.Descripcion as Descripción,";
            sql = sql + "(select m.Nombre From Marca m where m.CodMarca=a.CodMarca) as Marca ";
            sql = sql + " from auto a";
            if (Patente != "")
            {
                sql = sql + " where a.Patente like" + "'%" + Patente + "%'";
            }
            sql = sql + " order by CodAuto";
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetAutoxCodigo(Int32 CodAuto)
        {
            string sql = "select a.*,m.nombre as Marca";
            sql = sql + ",(select c.CodProvincia from Ciudad c where c.CodCiudad = a.CodCiudad) as CodProvincia ";
            sql = sql + ",(select aa.Nombre from Anio aa where aa.CodAnio=a.CodAnio) as NombreAnio ";
            sql = sql + ",(select cc.Nombre from Color cc where cc.CodColor=a.CodColor) as NombreColor ";
            sql = sql + " from auto a,Marca m";
            sql = sql + " where a.CodMarca = m.CodMarca";
            sql = sql + " and CodAuto =" + CodAuto.ToString ();
            return cDb.ExecuteDataTable (sql);
        }

        public void AgregarAutoTransaccion(SqlConnection con,SqlTransaction Transaccion, string Patente, Int32? CodMarca,
            string Descripcion, Int32? Kilometros,
            Int32? CodCiudad, int Propio, int Concesion,
            string Observacion, string Anio, Double? Importe,
            string Motor, string Chasis, string Color, Int32? CodTipoCombustible
            ,Int32? CodSucursal,Int32? CodTipoUtilitario,string RutaImagen , int? CodColor,
            int? CodAnio
            )
        {
            string sql = "Insert into auto(";
            sql = sql + "Patente,CodMarca,Descripcion";
            sql = sql + ",Kilometros,CodCiudad,Propio,Concesion";
            sql = sql + ",Observacion,Anio,Importe,Motor,Chasis,Color,CodTipoCombustible";
            sql = sql + ",CodSucursal,CodTipoUtilitario,RutaImagen,CodColor";
            sql = sql + ",CodAnio";
            sql = sql + ")";
            sql = sql + "Values (";
            sql = sql + "'" + Patente + "'";
            if (CodMarca != null)
                sql = sql + "," + CodMarca.ToString();
            else
                sql = sql + ",null";

            sql = sql + "," + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + "," + Kilometros.ToString();
            else
                sql = sql + ",null";
            if (CodCiudad != null)
                sql = sql + "," + CodCiudad.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Propio.ToString();
            sql = sql + "," + Concesion.ToString();
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",null";
            else
                sql = sql + "," + Importe.ToString();
            sql = sql + "," + "'" + Motor + "'";
            sql = sql + "," + "'" + Chasis + "'";
            sql = sql + "," + "'" + Color + "'";
            if (CodTipoCombustible == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodTipoCombustible.ToString();
            if (CodSucursal == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodSucursal.ToString();
             
            if (CodTipoUtilitario == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodTipoUtilitario.ToString();
            sql = sql + "," + "'" + RutaImagen + "'";
            if (CodColor !=null)
            {
                sql = sql + "," + CodColor.ToString();
            }
            else
            {
                sql = sql + ",null";
            }

            if (CodAnio != null)
                sql = sql + "," + CodAnio.ToString();
            else
                sql = sql + ",null";

            sql = sql + ")";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            comand.ExecuteNonQuery();
        }

        public Int32 GetMaxCodAutoTransaccion(SqlConnection con,SqlTransaction Transaccion)
        {
            Int32 CodAuto = 0;
            string sql = "select max(codAuto) as CodAuto from auto";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
             CodAuto = Convert.ToInt32(comand.ExecuteScalar());
             return CodAuto;
            
        }

        public DataTable GetAutoxContenidoPatente(string Patente)
        {
            string sql = "select a.* from auto a";
            sql = sql + " where patente like " + "'%" + Patente + "%'";
            return cDb.ExecuteDataTable(sql);
        }

       
        public void ModificarAutoTransaccion(SqlConnection con, SqlTransaction Transaccion,string Patente, Int32? CodMarca,
          string Descripcion, Int32? Kilometros,
          Int32? CodCiudad, int Propio, int Concesion,
          string Observacion, string Anio, Double? Importe, string Motor, string Chasis, 
          string Color , Int32? CodSucursal, Int32? CodTipoUtilitario,string RutaImagen,int? CodAnio)
        {
            string sql = "";
            sql = "update auto set";
            if (CodMarca != null)
                sql = sql + " CodMarca=" + CodMarca.ToString();
            else
                sql = sql + " CodMarca=null";
            sql = sql + ",Descripcion =" + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + ",Kilometros =" + Kilometros.ToString();
            else
                sql = sql + ",Kilometros =null ";

            if (CodCiudad != null)
                sql = sql + ",CodCiudad =" + CodCiudad.ToString();
            else
                sql = sql + ",CodCiudad=null";

            sql = sql + ",Propio = " + Propio.ToString();
            sql = sql + ",Concesion = " + Concesion.ToString();
            sql = sql + ",Observacion =" + "'" + Observacion + "'";
            sql = sql + ",Anio =" + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",Importe =null";
            else
                sql = sql + ",Importe =" + Importe.ToString();


            sql = sql + ",Motor =" + "'" + Motor + "'";
            sql = sql + ",Chasis =" + "'" + Chasis + "'";
            sql = sql + ",Color =" + "'" + Color + "'";
             
            if (CodSucursal == null)
                sql = sql + ",CodSucursal =null";
            else
                sql = sql + ",CodSucursal =" + CodSucursal.ToString();
             
            if (CodTipoUtilitario == null)
                sql = sql + ",CodTipoUtilitario =null";
            else
                sql = sql + ",CodTipoUtilitario =" + CodTipoUtilitario.ToString();
            sql = sql + ",RutaImagen=" + "'" + RutaImagen + "'";

            if (CodAnio ==null)
                sql = sql + ",CodAnio =null";
            else
                sql = sql + ",CodAnio =" + CodAnio.ToString();

            sql = sql + " where patente =" + "'" + Patente + "'";

            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            comand.ExecuteNonQuery();
        }

        public Int32 AgregarAutoId(string Patente, Int32? CodMarca,
          string Descripcion, Int32? Kilometros,
          Int32? CodCiudad, int Propio, int Concesion,
          string Observacion, string Anio, Double? Importe,
          string Motor, string Chasis, string Color, Int32? CodTipoCombustible,
          Int32? CodTipoUtilitario , Int32? CodAnio
          )
        {
            string sql = "Insert into auto(";
            sql = sql + "Patente,CodMarca,Descripcion";
            sql = sql + ",Kilometros,CodCiudad,Propio,Concesion";
            sql = sql + ",Observacion,Anio,Importe,Motor,Chasis,Color,CodTipoCombustible,CodTipoUtilitario";
            sql = sql + ",CodAnio";
            sql = sql + ")";
            sql = sql + "Values (";
            sql = sql + "'" + Patente + "'";
            if (CodMarca != null)
                sql = sql + "," + CodMarca.ToString();
            else
                sql = sql + ",null";

            sql = sql + "," + "'" + Descripcion + "'";
            if (Kilometros != null)
                sql = sql + "," + Kilometros.ToString();
            else
                sql = sql + ",null";
            if (CodCiudad != null)
                sql = sql + "," + CodCiudad.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Propio.ToString();
            sql = sql + "," + Concesion.ToString();
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + "'" + Anio + "'";
            if (Importe == null)
                sql = sql + ",null";
            else
                sql = sql + "," + Importe.ToString();
            sql = sql + "," + "'" + Motor + "'";
            sql = sql + "," + "'" + Chasis + "'";
            sql = sql + "," + "'" + Color + "'";
            if (CodTipoCombustible == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodTipoCombustible.ToString();
            if (CodTipoUtilitario!=null)
            {
                sql = sql + "," + CodTipoUtilitario.ToString();
            }
            else
            {
                sql = sql + ",null";
            }
            if (CodAnio !=null)
            {
                sql = sql + "," + CodAnio.ToString();
            }
            else
            {
                sql = sql + ",null";
            }
            sql = sql + ")";
            return  cDb.EjecutarEscalar (sql);
        }

        public DataTable GetAutoResumido(string Patente, Int32? CodMarca)
        {
            string sql = "";
            sql = "select a.CodAuto,a.Patente";
            sql = sql + ",m.Nombre";
            sql = sql + ",a.Descripcion as Descripción";
            sql = sql + ",(select aa.Nombre from anio aa where aa.CodAnio = a.CodAnio) as Modelo ";
            sql = sql + " from auto a,marca m ";
           
            
            sql = sql + " where a.CodMarca = m.CodMarca";
           
            if (Patente != "")
                sql = sql + " and a.Patente like" + "'%" + Patente + "%'";
            if (CodMarca != null)
                sql = sql + " and a.CodMarca =" + CodMarca.ToString();
            sql = sql + " order by m.Nombre,a.Anio desc";
            return cDb.ExecuteDataTable(sql);
        }
    }
}
