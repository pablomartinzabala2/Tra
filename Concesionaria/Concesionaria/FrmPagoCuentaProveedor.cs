using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Concesionaria.Clases;

namespace Concesionaria
{
    public partial class FrmPagoCuentaProveedor : FormularioBase
    {
        public FrmPagoCuentaProveedor()
        {
            InitializeComponent();
        }

        private void FrmPagoCuentaProveedor_Load(object sender, EventArgs e)
        {
            Buscar();
            if (Principal.Codigo !=null)
            {
                Int32 CodPago = Convert.ToInt32(Principal.Codigo);
                BuscarPago(CodPago);
            }
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            if (Principal.CodigoPrincipalAbm != null)
            {
                Int32 CodCuenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                txtCodCuenta.Text = CodCuenta.ToString();
                cCuentaProveedor Cuenta = new Clases.cCuentaProveedor();
                DataTable trdo = Cuenta.GetDetalleCuentas(CodCuenta);
                if (trdo.Rows.Count > 0)
                {
                    txtProveedor.Text = trdo.Rows[0]["Proveedor"].ToString();
                    txtCuentaProveedor.Text = trdo.Rows[0]["Nombre"].ToString();
                }
                Double Saldo = Cuenta.GetSaldo(CodCuenta);
                txtSaldo.Text = Saldo.ToString();
                txtSaldo.Text = fun.FormatoEnteroMiles(txtSaldo.Text);
                DataTable tbDeuda = Cuenta.GetDetalleDeuda(CodCuenta);
                tbDeuda = fun.TablaaMiles(tbDeuda, "Importe");
                tbDeuda = fun.TablaaMiles(tbDeuda, "Saldo");
                Grilla.DataSource = tbDeuda;
                fun.AnchoColumnas(Grilla, "0;50;25;25");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar()==false)
            {
                return;
            }
            cFunciones fun = new Clases.cFunciones();
            cPagoProveedor pago = new cPagoProveedor();
            cDeudaProveedor Deuda = new cDeudaProveedor();
            Double Efectivo = 0;
            Double TotalCheque = 0;
            Double Saldo = 0;
            Int32 CodPago = 0;
            Int32 CodDeuda = 0;
            Double SaldoDeuda = 0;
            DateTime Fecha = dpFecha.Value;
            string Concepto = txtConcepto.Text;
            if (txtEfectivo.Text != "")
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            if (txtSaldo.Text !="")
            {
                Saldo = fun.ToDouble(txtSaldo.Text);
            }

            if (txtImporteCheque.Text !="")
            {
                TotalCheque = fun.ToDouble(txtImporteCheque.Text);
            }
            Int32 CodCuentaProveedor = Convert.ToInt32(txtCodCuenta.Text);
            cCuentaProveedor cuentaProv = new Clases.cCuentaProveedor();
            cMovimiento mov = new Clases.cMovimiento();
            cMovimientoProveedor movProv = new cMovimientoProveedor();
            string Descripcion = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            try
            {
                if (Efectivo>0)
                {
                    Descripcion = "Pago Cuenta " + txtCuentaProveedor.Text;
                    mov.RegistrarMovimientoDescripcionTransaccion(con, Transaccion, 0,
                        Principal.CodUsuarioLogueado, (-1) * Efectivo,0,0,0,0,dpFecha.Value,Descripcion,0);
                    CodPago = pago.Insertar(con, Transaccion, Fecha, Efectivo, Concepto, 0, null, CodCuentaProveedor);
                    Double SaldoCuentaProv = movProv.GetSaldo(CodCuentaProveedor);
                    SaldoCuentaProv = SaldoCuentaProv + Efectivo;
                    movProv.InsertarTran(con, Transaccion, CodCuentaProveedor, Fecha, Concepto, 0, Efectivo, SaldoCuentaProv, 0, CodPago);
                    cuentaProv.ActuaizarSaldoTran(con, Transaccion,CodCuentaProveedor, SaldoCuentaProv);
                    for (int i = 0; i < Grilla.Rows.Count - 1; i++)
                    {    // salgo es la deuda total y saldo deuda es cada deuada individual
                        CodDeuda = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                        SaldoDeuda = fun.ToDouble(Grilla.Rows[i].Cells[3].Value.ToString());
                        if (Efectivo >0)
                        {
                            if (Efectivo>=SaldoDeuda)
                            {
                                Deuda.ActualizarSaldo(con, Transaccion, CodDeuda, SaldoDeuda, CodPago);
                                Efectivo = Efectivo - SaldoDeuda;
                                Saldo = Saldo - SaldoDeuda;
                            }
                            else
                            {
                                Deuda.ActualizarSaldo(con, Transaccion, CodDeuda, Efectivo, CodPago);
                                Efectivo = 0;
                            }                         
                        }
                    }
                    if (Efectivo>0)
                    {
                        //significa que sobro efectivo para abonar la deuda
                      //  movProv.InsertarTran(con ,Transaccion, Fecha,txtConcepto.Text,0,)

                    }
                }

                if (TotalCheque>0)
                {
                    cChequeCobrar cheque = new cChequeCobrar();
                    Int32? CodCheque = Convert.ToInt32(txtCodCheque.Text);
                    CodPago = pago.Insertar(con, Transaccion, Fecha, 0, Concepto, TotalCheque, CodCheque, CodCuentaProveedor);
                    Double SaldoCuentaProv = movProv.GetSaldo(CodCuentaProveedor);
                    SaldoCuentaProv = SaldoCuentaProv + TotalCheque;
                    movProv.InsertarTran(con, Transaccion, CodCuentaProveedor, Fecha, Concepto, 0, TotalCheque, SaldoCuentaProv, 0, CodPago);
                    cheque.ActualizarFechaCobro(con, Transaccion,Convert.ToInt32(CodCheque), Fecha);
                    for (int i = 0; i < Grilla.Rows.Count - 1; i++)
                    {    // salgo es la deuda total y saldo deuda es cada deuada individual
                        CodDeuda = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                        SaldoDeuda = fun.ToDouble(Grilla.Rows[i].Cells[3].Value.ToString());
                        if (TotalCheque > 0)
                        {
                            if (TotalCheque >= SaldoDeuda)
                            {
                                Deuda.ActualizarSaldo(con, Transaccion, CodDeuda, SaldoDeuda, CodPago);
                                TotalCheque = TotalCheque - SaldoDeuda;
                                Saldo = Saldo - SaldoDeuda;
                            }
                            else
                            {
                                Deuda.ActualizarSaldo(con, Transaccion, CodDeuda, TotalCheque, CodPago);
                                TotalCheque = 0;
                                
                            }
                        }
                    }
                }
               
                Transaccion.Commit();
                con.Close();
                MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
                Buscar();
            }
            catch (Exception ex)
            {
                string msj = "Hubo un error en el proceso " + ex.Message.ToString();
                MessageBox.Show(msj, Clases.cMensaje.Mensaje());
                Transaccion.Rollback();
                con.Close();
               
            }
        }

        private Boolean Validar()
        {
            Boolean op = true;
            Double Efectivo = 0;
            Double Saldo = 0;
            cFunciones fun = new Clases.cFunciones();
            Efectivo = fun.ToDouble(txtEfectivo.Text);
            Saldo = fun.ToDouble(txtSaldo.Text);
            /*
            if (Efectivo>Saldo)
            {
                MessageBox.Show("El saldo es inferior al importe efectivo");
                return false;
            }
            */
            if (txtConcepto.Text =="")
            {
                MessageBox.Show("Debe ingresar un concepto para continuar");
                return false;
            }
            return true;
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBuscarCheque frm = new FrmBuscarCheque();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.Show();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (Principal.CodCheque!=null)
            {
                Int32 CodCheque = Convert.ToInt32(Principal.CodCheque);
                cChequeCobrar cheque = new cChequeCobrar();
                DataTable trdo = cheque.GetChequexCodigo(CodCheque);
                if (trdo.Rows.Count >0)
                {
                    txtCodCheque.Text = CodCheque.ToString();
                    Double Importe = Convert.ToDouble(trdo.Rows[0]["Importe"].ToString());
                    txtImporteCheque.Text = Importe.ToString();
                    txtImporteCheque.Text = fun.FormatoEnteroMiles(txtImporteCheque.Text);
                }
            }
        }

        private void BuscarPago(Int32 CodPago)
        { 
            cFunciones fun = new cFunciones();
            cPagoProveedor Pago = new cPagoProveedor();
            cDeudaProveedor Deuda = new cDeudaProveedor();
            DataTable trdo = Pago.GetPagoxCodigo(CodPago);
            if (trdo.Rows.Count >0)
            {
                DateTime Fecha = Convert.ToDateTime(trdo.Rows[0]["Fecha"]);
                string Concepto = trdo.Rows[0]["Concepto"].ToString();
                Double Efectivo = Convert.ToDouble(trdo.Rows[0]["Efectivo"]);
                txtConcepto.Text = Concepto;
                dpFecha.Value = Fecha;
                txtEfectivo.Text = Efectivo.ToString();
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);

                DataTable tdeuda = Deuda.GetDeudaxCodPago(CodPago);
                tdeuda = fun.TablaaMiles(tdeuda, "Importe");
                tdeuda = fun.TablaaMiles(tdeuda, "Saldo");
                Grilla.DataSource = tdeuda;
               
                fun.AnchoColumnas(Grilla, "50;25;25");

                btnGuardar.Visible = false;
            }
        }
    }
}
