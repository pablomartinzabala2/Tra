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
    public partial class FrmIngresoCaja : Form
    {
        cFunciones fun;
        public FrmIngresoCaja()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar ()==false)
            {
                return;
            }
            Int32 CodMovimiento = 0;
            cMovimientoCaja mov = new cMovimientoCaja();
            string Concepto = txtConcepto.Text;
            DateTime Fecha = Convert.ToDateTime(dpFechaHasta.Value);
            Int32? CodTipo = null;
            Double ImporteIngreso = 0;
            Double ImporteEgreso = 0;
            Int32 CodCuenta = 0;
            Int32? CodStock = null;
            string sImporteIngreso = "";
            string sImporteEgreso = "";
            Int32 CodUsuario = Principal.CodUsuarioLogueado;

            int TingoIngresoEgreso = Convert.ToInt32(cmbTipoIngresoEgreso.SelectedValue);
            if (txtImporte.Text != "")
            {
                if (TingoIngresoEgreso ==1)
                {
                    ImporteIngreso = fun.ToDouble(txtImporte.Text);
                    ImporteEgreso = 0;
                    sImporteIngreso = txtImporte.Text;
                    sImporteEgreso = "0";
                }
                    

                if (TingoIngresoEgreso == 2)
                {
                    ImporteEgreso = fun.ToDouble(txtImporte.Text);
                    sImporteEgreso = txtImporte.Text;
                    ImporteIngreso = 0;
                    sImporteIngreso = "0";
                }
                    
            }

            if (txtCodStock.Text != "")
                CodStock = Convert.ToInt32(txtCodStock.Text);
                
            if (CmbTipoMov.SelectedIndex > 0)
                CodTipo = Convert.ToInt32(CmbTipoMov.SelectedValue);
            if (txtCodCuenta.Text != "")
                CodCuenta = Convert.ToInt32(txtCodCuenta.Text);
            CodMovimiento = mov.InsertarId(Concepto, Fecha, CodTipo, ImporteIngreso, ImporteEgreso, CodCuenta, CodStock, sImporteIngreso, sImporteEgreso, CodUsuario);
            MessageBox.Show("Datos grabados correctamente ");
            CargarGrilla(Fecha);
            if (txtCodStock.Text !="")
            {
                int CodAuto = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                string Patente = txtPatente.Text;
                cCosto costo = new cCosto();
                costo.InsertarCosto(CodAuto, Patente, ImporteEgreso, Fecha.ToShortDateString(), Concepto, CodStock ,null , CodMovimiento,null);
            }
            Limpiar();
            
        }

        public Boolean Validar()
        {   
            if (txtConcepto.Text =="")
            {
                MessageBox.Show("Debe ingresar un concepto");
                return false;
            }
              
            if (txtImporte.Text == "")
            {
                MessageBox.Show("Debe ingresar un Importe");
                return false;
            }
             
            if (txtCodCuenta.Text == "")
            {
                MessageBox.Show("Debe ingresar una cuenta");
                return false;
            }

            if (CmbTipoMov.SelectedIndex<1)
            {
                MessageBox.Show("Debe seleccionar un tipo ");
                return false;

            }

            if (cmbTipoIngresoEgreso.SelectedIndex <1)
            {
                MessageBox.Show("Debe seleccionar un tipo de ingreso");
                return false;
            }

            return true;
        }

        private void FrmIngresoCaja_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            fun.LlenarCombo(CmbTipoMov, "TipoMovimiento", "Nombre", "CodTipo");
            DateTime Fecha = dpFechaHasta.Value;
            CargarComboIngresoEgreso();
            CargarGrilla(Fecha);
        }

        private void CargarComboIngresoEgreso()
        {
            DataTable trdo = new DataTable();
            trdo = fun.CrearTabla("Codigo;Nombre");
            trdo = fun.AgregarFilas(trdo,"1;Ingreso");
            trdo = fun.AgregarFilas(trdo,"2;Egreso");
            fun.LlenarComboDatatable(cmbTipoIngresoEgreso, trdo, "Nombre", "Codigo");
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            if (txtImporte.Text != "")
                txtImporte.Text = fun.FormatoEnteroMiles(txtImporte.Text);
        }
                      
        private void CargarGrilla(DateTime Fecha)
        {
            Double Ingreso = 0;
            Double Egreso = 0;
            Double Saldo = 0;
            cMovimientoCaja mov = new cMovimientoCaja();
            DataTable trdo = mov.GetMovimientoxFecha(Fecha,Fecha,"","","");
            Ingreso = fun.TotalizarColumna(trdo, "ImporteIngreso");
            Egreso = fun.TotalizarColumna(trdo, "ImporteEgreso");
            Saldo = Ingreso - Egreso;
            trdo = fun.TablaaMiles(trdo, "ImporteIngreso");
            trdo = fun.TablaaMiles(trdo, "ImporteEgreso");
            Grilla.DataSource = trdo;
            Grilla.Columns[6].HeaderText = "Ingreso";
            Grilla.Columns[7].HeaderText = "Egreso";
            fun.AnchoColumnas(Grilla, "0;0;35;15;15;15;10;10");
            txtIngresos.Text = fun.FormatoEnteroMiles(Ingreso.ToString());
            txtEgresos.Text = fun.FormatoEnteroMiles(Egreso.ToString());
            txtSaldo.Text = fun.FormatoEnteroMiles(Saldo.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime Fecha = dpFechaHasta.Value;
            CargarGrilla(Fecha);
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            FrmBuscadorCuentaProveedor frm = new FrmBuscadorCuentaProveedor();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar ");
                return;
            }

            string msj = "Confirma eliminar el Cliente ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            Int32 CodMovimiento = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cMovimientoCaja mov = new cMovimientoCaja();
            mov.Borrar(CodMovimiento);
            MessageBox.Show("Datos borrados correctamente");
            DateTime Fecha = dpFechaHasta.Value;
            CargarGrilla(Fecha);

        }

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            FrmBuscarAuto form = new FrmBuscarAuto();
            form.FormClosing += new FormClosingEventHandler(formBuscadorAuto_FormClosing);
            form.ShowDialog();
        }

        private void formBuscadorAuto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Int32 CodAuto = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            cAuto auto = new Clases.cAuto();
            BuscarAutoxCodigo(CodAuto);
        }

        private void BuscarAutoxCodigo(Int32 COdAuto)
        {
            Clases.cAuto auto = new Clases.cAuto();
            DataTable trdo = auto.GetAutoxCodigo(COdAuto);
            if (trdo.Rows.Count > 0)
            {
                txtCodStock.Text = Principal.CodStock.ToString();
                string NombreAuto = "";     
                string Descripcion = trdo.Rows[0]["Descripcion"].ToString();
                string Anio = trdo.Rows[0]["NombreAnio"].ToString();
                string Patente = trdo.Rows[0]["Patente"].ToString();
                txtPatente.Text = Patente;
                NombreAuto = Patente + " " + Descripcion + " " + Anio;
                txtVehiculo.Text = NombreAuto;
                txtConcepto.Text = NombreAuto;
            }
        }

        private void Limpiar()
        {
            txtCodStock.Text = "";
            txtVehiculo.Text = "";
            txtConcepto.Text = "";
            txtImporte.Text = "";
            txtCodCuenta.Text = "";
            txtProveedor.Text = "";
            txtCuentaProveedor.Text = "";
          //  cmbTipoIngresoEgreso.SelectedIndex = 0;
          //  CmbTipoMov.SelectedIndex = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ActualizarSaldo();
            ActualizarTotales();
            Principal.Fecha = dpFechaHasta.Value;
            FrmReporteCaja frm = new Concesionaria.FrmReporteCaja();
            frm.Show();
        }

        private void ActualizarSaldo()
        {
            cMovimientoCaja mov = new Clases.cMovimientoCaja();
            Int32 CodMovimiento = 0;
            string sSaldo = txtSaldo.Text;
            for (int i=0;i< Grilla.Rows.Count - 1;i++)
            {
                CodMovimiento = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                mov.ActualizarSaldo(CodMovimiento, sSaldo);
            }
        }

        private void ActualizarTotales()
        {
            cMovimientoCaja mov = new Clases.cMovimientoCaja();
            cFunciones fun = new cFunciones();
            Int32 CodMovimiento = 0;
            int CodTipo = 0;
            Double IngresoEfectivo = 0;
            Double EgresoEfectivo = 0;
            Double IngresoCheque = 0;
            Double EgresoCheque = 0;
            Double IngresoTransferencia = 0;
            Double EgresoTransferencia = 0;
            Double IngresoDolares = 0;
            Double EgresoDolares = 0;


            string sImporte = "";

            string sSaldo = txtSaldo.Text;
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                CodMovimiento = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                CodTipo = Convert.ToInt32(Grilla.Rows[i].Cells[8].Value);
                if (CodTipo ==1)
                {
                    //efectivo
                    if (Grilla.Rows[i].Cells[6].Value.ToString ()!="")
                    {
                        sImporte = Grilla.Rows[i].Cells[6].Value.ToString();
                        IngresoEfectivo = IngresoEfectivo + fun.ToDouble(sImporte);
                    }

                    if (Grilla.Rows[i].Cells[7].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[7].Value.ToString();
                        EgresoEfectivo = EgresoEfectivo + fun.ToDouble(sImporte);
                    }
                }

                if (CodTipo == 2)
                {
                    //transferencia
                    if (Grilla.Rows[i].Cells[6].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[6].Value.ToString();
                        IngresoTransferencia = IngresoTransferencia + fun.ToDouble(sImporte);
                    }

                    if (Grilla.Rows[i].Cells[7].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[7].Value.ToString();
                        EgresoTransferencia = EgresoTransferencia + fun.ToDouble(sImporte);
                    }
                }

                if (CodTipo == 3)
                {
                    //Cheque
                    if (Grilla.Rows[i].Cells[6].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[6].Value.ToString();
                        IngresoCheque = IngresoCheque + fun.ToDouble(sImporte);
                    }

                    if (Grilla.Rows[i].Cells[7].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[7].Value.ToString();
                        EgresoCheque = EgresoCheque + fun.ToDouble(sImporte);
                    }
                }

                if (CodTipo == 4)
                {
                    //Cheque
                    if (Grilla.Rows[i].Cells[6].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[6].Value.ToString();
                        IngresoDolares = IngresoDolares + fun.ToDouble(sImporte);
                    }
                     
                    if (Grilla.Rows[i].Cells[7].Value.ToString() != "")
                    {
                        sImporte = Grilla.Rows[i].Cells[7].Value.ToString();
                        EgresoDolares = EgresoDolares + fun.ToDouble(sImporte);
                    }
                }

            }

            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                CodMovimiento = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value);
                mov.ActualizarTotales(CodMovimiento, txtIngresos.Text, txtEgresos.Text,
                    fun.FormatoEnteroMiles(IngresoEfectivo.ToString ()), fun.FormatoEnteroMiles(EgresoEfectivo.ToString ()),
                    fun.FormatoEnteroMiles(IngresoCheque.ToString()),fun.FormatoEnteroMiles (EgresoCheque.ToString ()),
                    fun.FormatoEnteroMiles(IngresoTransferencia.ToString()), fun.FormatoEnteroMiles(EgresoTransferencia.ToString()),
                    fun.FormatoEnteroMiles(IngresoDolares.ToString()), fun.FormatoEnteroMiles(EgresoDolares.ToString()));
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elelemtno ");
                return;
            }
            Principal.ConceptoCaja = Grilla.CurrentRow.Cells[2].Value.ToString();
            FrmConceptoCaja frm = new FrmConceptoCaja();
            frm.ShowDialog();
        }
    }
}
