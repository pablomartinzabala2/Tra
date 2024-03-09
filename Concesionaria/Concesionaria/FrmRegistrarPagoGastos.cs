using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concesionaria.Clases;

namespace Concesionaria
{
    public partial class FrmRegistrarPagoGastos : Form
    {
        public FrmRegistrarPagoGastos()
        {
            InitializeComponent();
            
        }

        private void FrmRegistrarPagoGastos_Load(object sender, EventArgs e)
        {
            
            if (Principal.CodigoPrincipalAbm != null)
            {
                CargarGasto(Convert.ToInt32(Principal.CodigoPrincipalAbm));
            }
        }

        private void CargarGasto(Int32 CodGasto)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            DataTable trdo = gasto.GetGastosPagarxCodGasto(CodGasto);
            if (trdo.Rows.Count > 0)
            {   
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
                txtImporte.Text = trdo.Rows[0]["Importe"].ToString();
                txtDescripcion.Text = trdo.Rows[0]["Descripcion"].ToString();
                txtCodVenta.Text = trdo.Rows[0]["CodVenta"].ToString();
                if (txtImporte.Text != "")
                {
                    txtImporte.Text = fun.SepararDecimales(txtImporte.Text);
                    txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
                    txtTope.Text = txtImporte.Text;
                }
                txtFechaPago.Text = trdo.Rows[0]["FechaPago"].ToString ();
                if (trdo.Rows[0]["FechaTramite"].ToString()!="")
                {
                    txtFechaTramite.Text = trdo.Rows[0]["FechaTramite"].ToString();
                }

                if (trdo.Rows[0]["FechaRetiro"].ToString() != "")
                {
                    txtFechaRetiro.Text = trdo.Rows[0]["FechaRetiro"].ToString();
                }
                
               //if (fun.ValidarFecha (txtFechaPago.Text)==true)
                if (fun.ValidarFecha (txtFechaTramite.Text)==true)

                {
                    btnAnular.Enabled = true ;
                    btnGrabar.Enabled = false ;
                    txtImporte.Enabled = false;
                 //   btnActualizarFechaPago.Visible = true;
                }
                else{
                   // btnActualizarFechaPago.Visible = false;
                    btnAnular.Enabled = false ;
                    btnGrabar.Enabled = true ;
                    txtImporte.Enabled = true;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //
            Clases.cFunciones fun = new Clases.cFunciones();
            // if (fun.ValidarFecha(txtFechaPago.Text) == false)
            if (fun.ValidarFecha(txtFechaTramite.Text) == false)
            {
                MessageBox.Show("Debe ingresar una fecha válida", Clases.cMensaje.Mensaje());
                return;
            }
            
            /*
            if (fun.ValidarFecha(txtFechaTramite.Text) == false)
            {
                MessageBox.Show("Debe ingresar una fecha válida", Clases.cMensaje.Mensaje());
                return;
            }
            */
            if (txtImporteCobrado.Text =="")
            {
                MessageBox.Show("Debe ingresaR un importe a cobrar", Clases.cMensaje.Mensaje());
                return;
            }
            double Importe = fun.ToDouble(txtImporte.Text);
            double ImporteCobrado = fun.ToDouble(txtImporteCobrado.Text);
            double Tope = fun.ToDouble(txtTope.Text);
            double dif = Tope - Importe;
            string Descrip2 = "";
            if (dif > 0)
                Descrip2 = "DIFERENCIA POSITVA DE TRANSFERENCIA, PATENTE " + txtPatente.Text;
            if (dif <0)
                Descrip2 = "DIFERENCIA NEGATIVA DE TRANSFERENCIA, PATENTE " + txtPatente.Text;

            if (dif < 0)
            {
                //paga el tope mas la diferencia negativa
                Importe = Tope;
            }

            if (dif > 0)
            {
                //paga el tope mas la diferencia negativa
                Importe = Tope;
            }

            string Descripcion = txtDescripcion.Text + " " + txtPatente.Text;
            Clases.cMovimiento mov = new Clases.cMovimiento();
          //  DateTime Fecha = Convert.ToDateTime(txtFechaPago.Text);
            DateTime Fecha = Convert.ToDateTime(txtFechaTramite.Text);  
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            gasto.ActualizarPago(Convert.ToInt32(Principal.CodigoPrincipalAbm), Fecha, ImporteCobrado);
            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado,-1* Importe, 0, 0, 0, 0, Fecha, Descripcion);
            if (dif != 0)
            {
                Int32? CodVenta = null;
                if (txtCodVenta.Text.Trim() != "")
                    CodVenta = Convert.ToInt32(txtCodVenta.Text);
                //hubo exedente o menor plata
                mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado, dif , 0, 0, 0, 0, Fecha, Descrip2 );
                Clases.cDiferenciaTransferencia obj = new Clases.cDiferenciaTransferencia();
                obj.Insertar(CodVenta, dif, Convert.ToInt32(Principal.CodigoPrincipalAbm)); 
            }
            MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
            btnGrabar.Enabled = false;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            string msj = "Confirma anular el pago";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            double Importe = fun.ToDouble(txtImporte.Text);
           
            string Descripcion = "PAGO ANULADO " + txtDescripcion.Text + " " + txtPatente.Text;
            Clases.cMovimiento mov = new Clases.cMovimiento();
            DateTime Fecha = Convert.ToDateTime(txtFechaPago.Text);
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            Clases.cDiferenciaTransferencia objDif = new Clases.cDiferenciaTransferencia();
            double ImporteDiferencia = objDif.GetImporteDiferenciaxCodGasto(Convert.ToInt32(Principal.CodigoPrincipalAbm));
            int positivo = 0;
            if (ImporteDiferencia > 0)
                positivo = 1;
            ImporteDiferencia = -1 * ImporteDiferencia;

            if (positivo == 1)
                Importe = Importe + ImporteDiferencia;

            gasto.ActualizarPago(Convert.ToInt32(Principal.CodigoPrincipalAbm), null, 0);
            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado, Importe, 0, 0, 0, 0, Fecha, Descripcion);
            //saco el exedente
            mov.RegistrarMovimientoDescripcion(-1, Principal.CodUsuarioLogueado, ImporteDiferencia , 0, 0, 0, 0, Fecha, "AJUSTE DE DIFERENCIA");
            MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
            objDif.Borrar(Convert.ToInt32(Principal.CodigoPrincipalAbm));
            btnAnular.Enabled = false; 

        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
        }

        private void BtnAgregarCheque_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha (txtFechaTramite.Text)==false)
            {
                MessageBox.Show("La fecha ingresada de tramite es incorrecta ");
                return;
            }
            DateTime FechaTramite = Convert.ToDateTime(txtFechaTramite.Text);
            Int32 CodGasto = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            cGastosPagar gasto = new cGastosPagar();
            gasto.ActualizarFechaTramite(CodGasto, FechaTramite);
            MessageBox.Show("Datos Actualizados correctamente ");

        }

        private void btnGrabarFechaRetiro_Click(object sender, EventArgs e)
        {   
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaRetiro.Text) == false)
            {
                MessageBox.Show("La fecha ingresada de Retiro es incorrecta ");
                return;
            }
            DateTime FechaRetiro = Convert.ToDateTime(txtFechaRetiro.Text);
            Int32 CodGasto = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            cGastosPagar gasto = new cGastosPagar();
            gasto.ActualizarFechaRetiro (CodGasto, FechaRetiro);
            MessageBox.Show("Datos Actualizados correctamente ");

        }

        private void btnActualizarFechaPago_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha (txtFechaPago.Text)==false)
            {
                MessageBox.Show("La fecha ingresada es incorrecta");
                return;
            }
            //ActualizarFechaPago
            DateTime Fecha = Convert.ToDateTime(txtFechaPago.Text);
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            gasto.ActualizarFechaPago(Convert.ToInt32(Principal.CodigoPrincipalAbm), Fecha);
            MessageBox.Show("Datos grabados correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 CodGasto = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            cGastosPagar gasto = new cGastosPagar();
            gasto.AnularFechaTramite(CodGasto);
            MessageBox.Show("Datos Actualizados correctamente ");
            CargarGasto(Convert.ToInt32(Principal.CodigoPrincipalAbm));
        }

        private void btnMensaje_Click(object sender, EventArgs e)
        {
            FrmMensajesGastosTransferencia frm = new FrmMensajesGastosTransferencia();
            frm.Show();
        }
    }
}
