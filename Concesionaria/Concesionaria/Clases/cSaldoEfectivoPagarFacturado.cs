using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Concesionaria.Clases
{
    public  class cSaldoEfectivoPagarFacturado
    {
        public void InsertarSaldo(Int32 CodRegistro, DateTime Fecha, double Importe)
        {
            string sql = "Insert into SaldoEfectivoPagarFacturado(CodRegistro,Fecha,Importe)";
            sql = sql + "values(" + CodRegistro.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.ExecutarNonQuery(sql);
        }

        public void Borrar(Int32 CodRegistro)
        {
            string sql = "delete from SaldoEfectivoPagarFacturado where CodRegistro =" + CodRegistro.ToString();
            cDb.ExecutarNonQuery(sql);
        }

        public DataTable GetSaldos(Int32 CodRegistros)
        {
            string sql = "select * from SaldoEfectivoPagarFacturado ";
            sql = sql + " where CodRegistro=" + CodRegistros.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
