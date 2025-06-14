using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public class cArchivo
    {
        public string GetRuta()
        {
            //string Ruta = "D:\\Pablo\\";
            string Ruta = "C:\\Users\\SERVER\\Documents\\SERVER\\OneDrive\\Servidor\\RC\\";
            return Ruta;
        }

        public int GetCodigo()
        {
            int Codigo = 0;
            string sql = "select Codigo from Archivo ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0)
            {
                Codigo = Convert.ToInt32(trdo.Rows[0]["Codigo"].ToString());
            }
            return Codigo;
        }

        public void GrabarCodigo(int Codigo)
        {
            string sql = "update Archivo set Codigo =" + Codigo.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
