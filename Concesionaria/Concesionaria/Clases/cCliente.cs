using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
namespace Concesionaria.Clases
{
    public class cCliente
    {
        public DataTable GetClientesxNroDoc(Int32 CodTipoDoc, string NroDocumento)
        {
            string sql ="select * from cliente";
            sql = sql + " where NroDocumento =" + "'" + NroDocumento + "'";
            sql = sql + " and CodTipoDoc=" + CodTipoDoc.ToString ();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetClientesxNroDocSolo(string NroDocumento)
        {
            string sql = "select * from cliente";
            sql = sql + " where NroDocumento =" + "'" + NroDocumento + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public void InsertarCliente(Int32? CodTipoDoc,string NroDocumento,
            string Nombre,string Apellido,string Telefono,string Celular,
            string Calle, string Altura, Int32? CodBarrio
            )
        {
            string NomApe = Nombre + " " + Apellido;
            string sql = "Insert into Cliente(CodTipoDoc,NroDocumento,Nombre,Apellido";
            sql = sql + ",Telefono,Celular, Calle,  Numero, CodBarrio,NomApe)";
            sql = sql + "Values(";
            if (CodTipoDoc == null)
                sql = sql + "null";
            else
                sql = sql + CodTipoDoc.ToString();
            sql = sql + "," + "'" + NroDocumento  + "'" ;
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + Celular + "'";
            sql = sql + "," + "'" + Calle + "'";
            sql = sql + "," + "'" + Altura  + "'";
            if (CodBarrio == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodBarrio.ToString();
            sql = sql + "," + "'" + NomApe + "'";
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public string  GetSqlInsertarCliente(Int32? CodTipoDoc, string NroDocumento,
            string Nombre, string Apellido, string Telefono, string Celular,
            string Calle, string Altura, Int32? CodBarrio, string Observacion,
            string RutaImagen, DateTime? FechaNacimiento , Int32? CodCategoria , Int32? CodEstado , string Email
            )
        {
            string NomApe = Nombre + " " + Apellido;
            string sql = "Insert into Cliente(CodTipoDoc,NroDocumento,Nombre,Apellido";
            sql = sql + ",Telefono,Celular, Calle,  Numero, CodBarrio,Observacion,RutaImagen,FechaNacimiento,CodCategoria, CodEstado,NomApe,Email)";
            sql = sql + "Values(";
            if (CodTipoDoc == null)
                sql = sql + "null";
            else
                sql = sql + CodTipoDoc.ToString();
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + Celular + "'";
            sql = sql + "," + "'" + Calle + "'";
            sql = sql + "," + "'" + Altura + "'";
            if (CodBarrio == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodBarrio.ToString();
            sql = sql + "," + "'" + Observacion + "'";
            sql = sql + "," + "'" + RutaImagen + "'";
            if (FechaNacimiento!=null)
            {
                DateTime FechaNac = Convert.ToDateTime(FechaNacimiento);
                sql = sql + "," + "'" + FechaNac.ToShortDateString() + "'";
            }
            else
            {
                sql = sql + ",null";
            }
            if (CodCategoria != null)
                sql = sql + "," + CodCategoria.ToString();
            else
                sql = sql + ",null";

            if (CodEstado != null)
                sql = sql + "," + CodEstado.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + NomApe + "'";
            sql = sql + "," + "'" + Email + "'";
            sql = sql + ")";
            return sql;
        }

        public DataTable GetClientexNroDoc(Int32? CodTipoDoc, string NroDocumento)
        {
            string sql = "select * from cliente";
            sql = sql + " where CodTipoDoc =" + CodTipoDoc.ToString();
            sql = sql + " and NroDocumento =" + "'" + NroDocumento + "'";
            DataTable trdo = cDb.ExecuteDataTable (sql);
            return trdo ;
        }

        public void ModificarCliente(Int32 CodCliente, Int32? CodTipoDoc, string NroDocumento,
            string Nombre, string Apellido, string Telefono, string Celular,
            string Calle, string Numero, Int32? CodBarrio)
        {
            string sql = "Update Cliente ";
            
            sql = sql + "set NroDocumento =" + "'" + NroDocumento + "'";
            if (CodTipoDoc == null)
                sql = sql + ",CodTipoDoc =null";
            else
                sql = sql + ",CodTipoDoc=" + CodTipoDoc.ToString();
            sql = sql + ",Nombre =" + "'" + Nombre + "'";
            sql = sql + ",Apellido=" + "'" + Apellido + "'";
            sql = sql + ",Telefono=" + "'" + Telefono + "'";
            sql = sql + ",Celular=" + "'" + Celular + "'";
            sql = sql + ",Calle=" + "'" + Calle + "'";
            sql = sql + ",Numero=" + "'" + Numero + "'";
            if (CodBarrio == null)
                sql = sql + ",CodBarrio =null";
            else
                sql = sql + ",CodBarrio =" + CodBarrio.ToString();
            sql = sql + " where CodCliente=" + CodCliente.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public string GetSqlModificarCliente(Int32 CodCliente, Int32? CodTipoDoc, string NroDocumento,
            string Nombre, string Apellido, string Telefono, string Celular,
            string Calle, string Numero, Int32? CodBarrio, string Observacion,string RutaImagen, Int32? CodEstado, string Email)
        {
            string sql = "Update Cliente ";

            sql = sql + "set NroDocumento =" + "'" + NroDocumento + "'";
            if (CodTipoDoc == null)
                sql = sql + ",CodTipoDoc =null";
            else
                sql = sql + ",CodTipoDoc=" + CodTipoDoc.ToString();
            sql = sql + ",Nombre =" + "'" + Nombre + "'";
            sql = sql + ",Apellido=" + "'" + Apellido + "'";
            sql = sql + ",Telefono=" + "'" + Telefono + "'";
            sql = sql + ",Celular=" + "'" + Celular + "'";
            sql = sql + ",Calle=" + "'" + Calle + "'";
            sql = sql + ",Numero=" + "'" + Numero + "'";
            if (CodBarrio == null)
                sql = sql + ",CodBarrio =null";
            else
                sql = sql + ",CodBarrio =" + CodBarrio.ToString();
            sql = sql + ",Observacion=" + "'" + Observacion + "'";
            sql = sql + ",RutaImagen=" + "'" + RutaImagen + "'";
            
            if (CodEstado == null)
                sql = sql + ",CodEstado =null";
            else
                sql = sql + ",CodEstado =" + CodEstado.ToString();
             
            sql = sql + ",Email=" + "'" + Email + "'";
            sql = sql + " where CodCliente=" + CodCliente.ToString();
            return sql;
        }

        public Int32 GetMaxCliente()
        {
            string sql = "select max(CodCliente) as CodCliente from Cliente";
            return Convert.ToInt32 (cDb.ExecuteScalar(sql, "CodCliente"));
        }

        public DataTable GetClientesxCodigo(Int32 CodCLiente)
        {
            //  string sql = "select * from cliente where CodCLiente =" + CodCLiente.ToString();
            string sql = " select c.*, ";
            sql = sql + " (select t.Nombre from TipoDocumento t where t.CodTipoDoc = c.CodTipoDoc) as TipoDoc ";
            sql = sql + " from cliente c ";
            sql = sql + " where c.CodCliente =" + CodCLiente.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable BuscarCliente(string NroDocumento, string Apellido, string Nombre)
        {
            int UsoWhere = 0;
            string sql = "select CodCliente, NroDocumento as Documento ,Apellido,Nombre,Telefono as Teléfono,Celular";
            sql = sql + " from Cliente ";
            if (NroDocumento != "")
            {
                sql = sql + " Where NroDocumento =" + "'" + NroDocumento + "'";
                UsoWhere = 1;
            }

            if (Apellido != "")
            {
                if (UsoWhere == 1)
                {
                    sql = sql + " and Apellido =" + "'" + Apellido + "'";
                }
                else{
                    sql = sql + " where Apellido =" + "'" + Apellido + "'";
                }
                UsoWhere = 1;
            }

            if (Nombre != "")
            {
                if (UsoWhere == 1)
                {
                    sql = sql + " and Nombre =" + "'" + Nombre + "'";
                }
                else
                {
                    sql = sql + " where Nombre =" + "'" + Nombre + "'";
                }
                UsoWhere = 1;
            }
            return cDb.ExecuteDataTable(sql);
        }

        public Boolean PuedeBorrar(Int32 CodCliente)
        {
            Boolean Borra = true  ;
            string sql = "select * from venta where CodCliente =" + CodCliente.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodVenta"].ToString() != "")
                    Borra = false;
            return Borra;
        }

        public void InsertarClienteTransaccion(SqlConnection con, SqlTransaction Transaccion, Int32? CodTipoDoc, string NroDocumento,
            string Nombre, string Apellido, string Telefono, string Celular,
            string Calle, string Altura, Int32? CodBarrio,
            DateTime? FechaNacimiento,string Email,string Observacion 
            
            )
        {
            string NomApe = Nombre + " " + Apellido;
            string sql = "Insert into Cliente(CodTipoDoc,NroDocumento,Nombre,Apellido";
            sql = sql + ",Telefono,Celular, Calle,  Numero, CodBarrio";
            sql = sql + ",FechaNacimiento,Email,Observacion,NomApe)";
            sql = sql + "Values(";
            if (CodTipoDoc == null)
                sql = sql + "null";
            else
                sql = sql + CodTipoDoc.ToString();
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + "," + "'" + Celular + "'";
            sql = sql + "," + "'" + Calle + "'";
            sql = sql + "," + "'" + Altura + "'";
            if (CodBarrio == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodBarrio.ToString();
            if (FechaNacimiento == null)
                sql = sql + ",null";
            else
                sql = sql + "," + "'" + FechaNacimiento.ToString() + "'";
            sql = sql + "," + "'" + Email + "'";
            sql = sql + ","  +"'" + Observacion + "'";
            sql = sql + "," + "'" + NomApe + "'";
            sql = sql + ")";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            comand.ExecuteNonQuery();
            //cDb.ExecutarNonQuery(sql);
        }

        public Int32 GetMaxClientetTransaccion(SqlConnection con,SqlTransaction Transaccion)
        {
            string sql = "select max(CodCliente) as CodCliente from Cliente";
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            Int32 Codigo = Convert.ToInt32(comand.ExecuteScalar());
            return Codigo;
        }

        public void ModificarClientetTransaccion(SqlConnection con,SqlTransaction Transaccion,Int32 CodCliente, Int32? CodTipoDoc, string NroDocumento,
           string Nombre, string Apellido, string Telefono, string Celular,
           string Calle, string Numero, Int32? CodBarrio, DateTime? FechaNacimiento, string Email, string Observacion)
        {
            string sql = "Update Cliente ";

            sql = sql + "set NroDocumento =" + "'" + NroDocumento + "'";
            if (CodTipoDoc == null)
                sql = sql + ",CodTipoDoc =null";
            else
                sql = sql + ",CodTipoDoc=" + CodTipoDoc.ToString();
            sql = sql + ",Nombre =" + "'" + Nombre + "'";
            sql = sql + ",Apellido=" + "'" + Apellido + "'";
            sql = sql + ",Telefono=" + "'" + Telefono + "'";
            sql = sql + ",Celular=" + "'" + Celular + "'";
            sql = sql + ",Calle=" + "'" + Calle + "'";
            sql = sql + ",Numero=" + "'" + Numero + "'";
            if (CodBarrio == null)
                sql = sql + ",CodBarrio =null";
            else
                sql = sql + ",CodBarrio =" + CodBarrio.ToString();

            if (FechaNacimiento ==null)
            {
                sql = sql + ",FechaNacimiento=null";
            }
            else
            {
                sql = sql + ",FechaNacimiento =" + "'" + FechaNacimiento.ToString() + "'";

            }
            sql = sql + ",Email =" + "'" + Email + "'";
            sql = sql + ",Observacion =" + "'" + Observacion + "'";

            sql = sql + " where CodCliente=" + CodCliente.ToString();
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.Transaction = Transaccion;
            comand.CommandText = sql;
            comand.ExecuteNonQuery();
            //cDb.ExecutarNonQuery(sql);
        }


        public DataTable GetClientexApellido(string Ape)
        {
            string sql = "select * from Cliente where Apellido like " + "'%" + Ape + "%'";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActuaizarCumpleanios()
        {
            Int32 CodCliente = 0;
            string sql2 = "";
            string sql = "select CodCliente,FechaNacimiento ";
            sql = sql + " from Cliente ";
            sql = sql + " where FechaNacimiento is not null";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            for (int i=0;i< trdo.Rows.Count;i++)
            {
                CodCliente = Convert.ToInt32(trdo.Rows[i]["CodCliente"]);
                if (trdo.Rows[i]["FechaNacimiento"].ToString ()!="")
                {
                    DateTime Hoy = DateTime.Now;
                    String FechaCumple = "";
                    DateTime FechaNac = Convert.ToDateTime(trdo.Rows[i]["FechaNacimiento"].ToString());
                    String Dia = FechaNac.ToShortDateString().Substring(0, 2);
                    String Mes = FechaNac.ToShortDateString().Substring(3, 2);
                    String Anio = Hoy.Year.ToString();
                    if (Mes =="02" && Dia =="29")
                    {
                        Mes = "03";
                        Dia = "01";
                    }

                    FechaCumple = Dia + "/" + Mes + "/" + Anio;
                   // MessageBox.Show(FechaCumple);
                    DateTime Fec = Convert.ToDateTime(FechaCumple);
                    sql2 = "update Cliente set FechaCumple=" + "'" + Fec.ToShortDateString () + "'";
                    sql2 = sql2 + " where CodCliente=" + CodCliente.ToString();
                    cDb.ExecutarNonQuery(sql2);
                }
            }
        }

        public DataTable GetCumpleanios(DateTime FechaDesde, DateTime FechaHasta)
        {
            string sql = "select * from Cliente ";
            sql = sql + " where FechaCumple >=" + "'" + FechaDesde.ToShortDateString() + "'";
            sql = sql + " and FechaCumple<=" + "'" + FechaHasta.ToShortDateString() + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 InserterClienteId(SqlConnection con, SqlTransaction Transaccion, Int32? CodTipoDoc, string NroDocumento,
            string Nombre,string Apellido, string Telefono)
        {
            string sql = "Insert into Cliente(CodTipoDoc,NroDocumento,Nombre,Apellido";
            sql = sql + ",Telefono)";
            sql = sql + "Values(";
            if (CodTipoDoc == null)
                sql = sql + "null";
            else
                sql = sql + CodTipoDoc.ToString();
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + ")";

            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }

        public DataTable BuscarCliente(string Nombre,string Apellido)
        {
            string b = "";
            string b1 = "";

            if (Nombre != "")
                b = "1";
            else
                b = "0";

            if (Apellido != "")
                b1 = "1";
            else
                b1 = "0";

            string resul = b + b1;

            string sql = "select codcliente,Apellido,Nombre,Telefono ";
            sql = sql + " from Cliente ";
            switch(resul)
            {
                case  "10":
                    sql = sql + " where Nombre like " + "'%" + Nombre + "%'";
                    break;

                case "11":
                    sql = sql + " where Nombre like " + "'%" + Nombre + "%'";
                    sql = sql + " and Apellido like " + "'%" + Apellido + "%'";
                    break;

                case "01":
                    sql = sql + " where  Apellido like " + "'%" + Apellido + "%'";
                    break;
            }

            sql = sql + " Order by Apellido,Nombre ";
            return cDb.ExecuteDataTable(sql);

        }

        public DataTable GetClientes(Int32? CodTipoDoc, string Nombre)
        {
            string sql = "select c.CodCliente, (c.Apellido + ' ' + c.Nombre) as Cliente,c.Telefono, ";
            sql = sql + "c.Calle,c.Numero ";
            sql = sql + " from Cliente c";
            if (Nombre !="")
            {
                sql = sql + " where (c.Apellido + ' ' + c.Nombre) like " + "'%" + Nombre + "%'";
            }
            /*
            if (CodTipoDoc !=null)
            {
                sql = sql + " where c.CodTipoDoc=" + CodTipoDoc.ToString();
            }
            */
            sql = sql + " order by c.Apellido,c.Nombre ";
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 InserterClienteId2(Int32? CodTipoDoc, string NroDocumento,
           string Nombre, string Apellido, string Telefono)
        {
            string sql = "Insert into Cliente(CodTipoDoc,NroDocumento,Nombre,Apellido";
            sql = sql + ",Telefono)";
            sql = sql + "Values(";
            if (CodTipoDoc == null)
                sql = sql + "null";
            else
                sql = sql + CodTipoDoc.ToString();
            sql = sql + "," + "'" + NroDocumento + "'";
            sql = sql + "," + "'" + Nombre + "'";
            sql = sql + "," + "'" + Apellido + "'";
            sql = sql + "," + "'" + Telefono + "'";
            sql = sql + ")";

            return cDb.EjecutarEscalar(sql);
        }

        public void ActualizarVendedor(Int32 CodCliente, Int32 CodVendedor)
        {
            string sql = "update Cliente ";
            sql = sql + " set CodVendedor =" + CodVendedor.ToString();
            sql = sql + " where CodCliente =" + CodCliente.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public string GetVendedorxCodCliente(Int32 CodCliente)
        {
            string Nombre = "";
            string sql = "";
            sql = "select (v.Nombre + ' ' + v.Apellido) as Responsable ";
            sql = sql + " from Cliente cli, Vendedor v ";
            sql = sql + " where cli.CodVendedor = v.CodVendedor ";
            sql = sql + " and cli.CodCliente=" + CodCliente.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                Nombre = trdo.Rows[0]["Responsable"].ToString(); 
            }
            return Nombre;
        }

        public Int32  GetCodVendedorxCodCliente(Int32 CodCliente)
        {
            Int32 CodVendedor = 0;
            string sql = "";
            sql = "select CodVendedor ";
            sql = sql + " from Cliente cli  ";
            
            sql = sql + " where cli.CodCliente=" + CodCliente.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodVendedor"].ToString ()!="")
                    CodVendedor = Convert.ToInt32 (trdo.Rows[0]["CodVendedor"].ToString());
            }
            return CodVendedor;
        }


    }
}
