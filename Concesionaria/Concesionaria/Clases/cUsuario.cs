﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cUsuario
    {
        public DataTable GetUsuario(string USUARIO, string CLAVE)
        {
            string sql = "select *";
            sql = sql + " from Usuario";
            sql = sql + " Where Nombre=" + "'" + USUARIO.ToString() + "'";
            sql = sql + " AND Clave=" + "'" + CLAVE + "'";
            return cDb.ExecuteDataTable(sql);
        }

        public string GetNombreUsuarioxCodUsuario(Int32 CodUsuario)
        {
            string user ="";
            string sql = "select * from Usuario";
            sql = sql + " where CodUsuario=" +CodUsuario.ToString ();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                user = trdo.Rows[0]["Nombre"].ToString();
            return user;
        }

        public DataTable GetUsuarioxCodigo(Int32 CodUsuario)
        {
            string sql = "select * from Usuario";
            sql = sql + " where CodUsuario=" + CodUsuario.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            return trdo;
        }

        public DataTable GetAllUsuarios()
        {
            string sql = "select * from Usuario ";
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarClave(Int32 CodUsuario, string Clave)
        {
            string sql = "Update usuario ";
            sql = sql + " set Clave =" + "'" + Clave + "'";
            sql = sql + " where CodUsuario =" + CodUsuario.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
