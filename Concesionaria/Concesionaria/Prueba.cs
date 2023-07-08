using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;
using System.Data.SqlClient;

namespace Concesionaria
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String sql = "select CodCuenta from cuentaproveedor ";
            DataTable tb = cDb.ExecuteDataTable(sql);
            if (tb.Rows.Count >0)
            {
                for (int i =0;i< tb.Rows.Count;i++)
                {
                    int CodCuenta = Convert.ToInt32(tb.Rows[i]["CodCuenta"].ToString());
                    CorregirCuentas(CodCuenta);
                }
               
            }
            MessageBox.Show("Datso procesados ");
            
           // CorregirCuentas(22);

        }

        private void CorregirCuentas(int CodCuentaProveedor)
        {
            Double SaldoInicial = 0;
            int CodMovimiento = 0;
            Double Debe = 0, Haber = 0;
            Double Resta = 0;
            string sql = "select * from MovimientoProveedor ";
            sql = sql + " where CodCuentaProveedor=" + CodCuentaProveedor.ToString();
            sql = sql + " order by CodMovimiento asc ";

            int i = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();

            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count >0 && trdo.Rows[0]["CodCuentaProveedor"].ToString ()!="")
            {
                
                try
                {
                    for (i = 0; i < trdo.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            con.Open();
                            SqlTransaction Transaccion;
                            Transaccion = con.BeginTransaction();
                            SaldoInicial = Convert.ToDouble(trdo.Rows[0]["Debe"]);
                            CodMovimiento = Convert.ToInt32(trdo.Rows[0]["CodMovimiento"]);
                            sql = "update MovimientoProveedor ";
                            sql = sql + " set Saldo = Debe - Haber";
                            sql = sql + " where CodMovimiento=" + CodMovimiento.ToString();
                            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
                            Transaccion.Commit();
                            con.Close();
                            
                        }
                        else
                        {
                            con.Open();
                            SqlTransaction Transaccion;
                            Transaccion = con.BeginTransaction();
                            CodMovimiento = Convert.ToInt32(trdo.Rows[i]["CodMovimiento"]);
                           // SaldoInicial = Convert.ToDouble(trdo.Rows[i - 1]["Saldo"]);
                            Debe = Convert.ToDouble(trdo.Rows[i]["Debe"]);
                            Haber = Convert.ToDouble(trdo.Rows[i]["Haber"]);
                            Resta = Debe - Haber + SaldoInicial;
                            SaldoInicial = SaldoInicial + Debe - Haber;
                            sql = "update MovimientoProveedor ";
                            sql = sql + " set Saldo =  " + Resta.ToString().Replace(",", ".");
                            sql = sql + " where CodMovimiento=" + CodMovimiento.ToString();
                            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
                            Transaccion.Commit();
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
                
            }
            
           
        }
    }
}
