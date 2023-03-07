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
    public partial class FrmRecibo : FormularioBase
    {
        DataTable tbTransferencia;
        DataTable tbCobranza;

        public FrmRecibo()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            string sqlDoc = "select * from TipoDocumento order by CodTipoDoc";
            DataTable tbDoc = cDb.ExecuteDataTable(sqlDoc);
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(cmbDocumento, tbDoc, "Nombre", "CodTipoDoc");
            fun.LlenarCombo(CmbBanco, "Banco", "Nombre", "CodBanco");
            fun.LlenarCombo(cmbBancoTransferencia, "Banco", "Nombre", "CodBanco");
            tbTransferencia = fun.CrearTabla("CodBanco;Nombre;Numero;Importe;Fecha");
            tbCobranza = new DataTable();
            string ColCob = "Cuota;Importe;FechaVencimiento;FechaPago;Saldo;CodCobranza";
            tbCobranza = fun.CrearTabla(ColCob);
            CargarEmpleado();
        }

        private void CargarEmpleado()
        { 
            Clases.cVendedor ven = new Clases.cVendedor();
            DataTable tvend = ven.GetVendedores();
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(cmbEmpleado, tvend, "Apellido", "CodVendedor");
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            Int32 CodTipoDoc = 0;
            if (cmbDocumento.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmbDocumento.SelectedValue);
            string nroDocumento = txtNroDoc.Text;
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientesxNroDoc(CodTipoDoc, nroDocumento);
            if (trdo.Rows.Count > 0)
            {
                b = 1;
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                txtCodCLiente.Text = trdo.Rows[0]["CodCliente"].ToString();
            }
            if (b == 0)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtCodCLiente.Text = "";
            }
        }

        private void BtnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (txtCheque.Text == "")
            {
                MessageBox.Show("Debe ingresr un número de cheque", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtImporteCheque.Text == "")
            {
                MessageBox.Show("Debe ingresr un importe de cheque", Clases.cMensaje.Mensaje());
                return;
            }

            if (CmbBanco.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar un banco para continuar", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();


            DataTable tbCheques = new DataTable();
            tbCheques.Columns.Add("NroCheque");
            tbCheques.Columns.Add("Importe");
            tbCheques.Columns.Add("FechaVencimiento");
            tbCheques.Columns.Add("CodBanco");
            tbCheques.Columns.Add("Banco");
            int i = 0;
            for (i = 0; i < GrillaCheques.Rows.Count - 1; i++)
            {
                string Cheque = GrillaCheques.Rows[i].Cells[0].Value.ToString();
                string Importe = GrillaCheques.Rows[i].Cells[1].Value.ToString();
                string FechaVencimiento = GrillaCheques.Rows[i].Cells[2].Value.ToString();
                string CodBanco = GrillaCheques.Rows[i].Cells[3].Value.ToString();
                string sBanco = GrillaCheques.Rows[i].Cells[4].Value.ToString();

                DataRow r = tbCheques.NewRow();
                r[0] = Cheque;
                r[1] = Importe;
                r[2] = FechaVencimiento;
                r[3] = CodBanco;
                r[4] = sBanco;
                tbCheques.Rows.Add(r);
            }
            Clases.cBanco objBanco = new Clases.cBanco();
            string banco = objBanco.GetBancoxCodigo(Convert.ToInt32(CmbBanco.SelectedValue));
            DataRow r1 = tbCheques.NewRow();
            r1[0] = txtCheque.Text;
            r1[1] = txtImporteCheque.Text;
            r1[2] = dpFechaVencimiento.Value.ToShortDateString();
            r1[3] = CmbBanco.SelectedValue;
            r1[4] = banco;
            tbCheques.Rows.Add(r1);
            GrillaCheques.DataSource = tbCheques;
            GrillaCheques.Columns[0].HeaderText = "Cheque";
            GrillaCheques.Columns[2].HeaderText = "Vencimiento";
            GrillaCheques.Columns[3].Visible = false;
            GrillaCheques.Columns[0].Width = 145;
            GrillaCheques.Columns[1].Width = 120;
            GrillaCheques.Columns[4].Width = 390;
            txtImporteCheque.Text = "";
            txtCheque.Text = "";

            double TotalCheques = 0;
            for (i = 0; i < tbCheques.Rows.Count; i++)
            {
                TotalCheques = TotalCheques + fun.ToDouble(tbCheques.Rows[i][1].ToString());
            }
            /*
            txtTotalCheque.Text = TotalCheques.ToString();
            //Clases.cFunciones fun = new Clases.cFunciones();
            txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);
            */

        }

        private void btnNuevaBanco_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodBanco";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Banco";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CampoIdSecundarioGenerado != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Banco":
                        fun.LlenarCombo(CmbBanco, "Banco", "Nombre", "CodBanco");
                        CmbBanco.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GrillaCheques.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una cheque para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            DataTable tbCheques = new DataTable();
            tbCheques.Columns.Add("NroCheque");
            tbCheques.Columns.Add("Importe");
            tbCheques.Columns.Add("FechaVencimiento");
            tbCheques.Columns.Add("CodBanco");
            tbCheques.Columns.Add("Banco");
            int i = 0;
            for (i = 0; i < GrillaCheques.Rows.Count - 1; i++)
            {
                string Cheque = GrillaCheques.Rows[i].Cells[0].Value.ToString();
                string Importe = GrillaCheques.Rows[i].Cells[1].Value.ToString();
                string FechaVencimiento = GrillaCheques.Rows[i].Cells[2].Value.ToString();
                string CodBanco = GrillaCheques.Rows[i].Cells[3].Value.ToString();
                string sBanco = GrillaCheques.Rows[i].Cells[4].Value.ToString();
                DataRow r = tbCheques.NewRow();
                r[0] = Cheque;
                r[1] = Importe;
                r[2] = FechaVencimiento;
                r[3] = CodBanco;
                tbCheques.Rows.Add(r);
            }

            string ChequeaBorrar = GrillaCheques.CurrentRow.Cells[0].Value.ToString();

            for (i = 0; i < tbCheques.Rows.Count; i++)
            {
                if (tbCheques.Rows[i]["NroCheque"].ToString() == ChequeaBorrar)
                {
                    tbCheques.Rows[i].Delete();
                    tbCheques.AcceptChanges();
                    i = tbCheques.Rows.Count;
                }
            }
            GrillaCheques.DataSource = tbCheques;

        }

        private void btnGuardarRecibo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre para continuar");
                return;
            }

            if (txtNroDoc.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de documento  para continuar");
                return;
            }

            if (cmbDocumento.SelectedIndex < 1)
            {
                MessageBox.Show("Debe ingresar un documento para continuar");
                return;
            }

            if (cmbEmpleado.SelectedIndex <1)
            {
                MessageBox.Show("Debe Seleccionar un empleado");
                return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            try
            {
                if (txtCodCLiente.Text =="")
                {
                    GuardarCliente(con, Transaccion);
                }
                GuardarRecibo(con, Transaccion);
                Transaccion.Commit();
                con.Close();
                FrmReporteRecibo frm = new Concesionaria.FrmReporteRecibo();
                frm.Show();
                Principal.CodRecibo = null;
            }
            catch (Exception)
            {
                Transaccion.Rollback();
                con.Close();
            }
        }

        private void GuardarRecibo(SqlConnection con, SqlTransaction Transaccion)
        {
            cFunciones fun = new cFunciones();
            Int32 CodEmpleado = 0;
            cRecibo recibo = new cRecibo();
            Int32 CodRecibo = 0;
            Double Efectivo = 0;
            Double Cheque = 0;
            Double Transferencia = 0;
            Double Saldo = 0;
            string sSaldo = "";
            int Orden = 1;
            string Concepto = "";
            Double Cobranza = 0;
            Double Total = 0;
            string sTotal = "";

            CodEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);

            DateTime Fecha = dpFecha.Value;
            string NroRecibo = "";

            if (txtSaldo.Text != "")
            {
                Saldo = fun.ToDouble(txtSaldo.Text);
            }

            if (Saldo > 0)
            {
                sSaldo = "$  " + txtSaldo.Text;
            }

            Concepto = txtConcepto.Text;

            if (txtEfectivo.Text != "")
            {
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            }

            Cheque = fun.CalcularTotalGrilla(GrillaCheques, "Importe");
            Transferencia = fun.CalcularTotalGrilla(GrillaTransferencia, "Importe");
            Cobranza = fun.CalcularTotalGrilla(GrillaCobranza, "Importe");
            Int32 CodCliente = Convert.ToInt32(txtCodCLiente.Text);
            Total = Efectivo + Cheque + Transferencia + Cobranza;

            if (Total >0)
            {
                sTotal = "$ " + fun.FormatoEnteroMiles(Total.ToString());
            }

            CodRecibo = recibo.Insertar(con, Transaccion, Fecha, CodCliente, Saldo, sSaldo, Concepto, Total, sTotal, Efectivo, CodEmpleado);
            NroRecibo = recibo.GetNroRecibo(CodRecibo);
            recibo.ActualizarNroRecibo(con, Transaccion, CodRecibo, NroRecibo);

            

           
            if (Efectivo > 0)
            {
                string sEfectivo = "$ " + txtEfectivo.Text;
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Efectivo", "", "", sEfectivo, Orden);
                Orden = Orden + 1;
                string Descripcion = "Recibo de " + txtNombre.Text + " " + txtApellido.Text;
                cMovimiento mov = new cMovimiento();
                mov.RegistrarMovimientoDescripcionTransaccion(con, Transaccion,
                    Principal.CodUsuarioLogueado, 0, Efectivo, 0, 0, 0, 0, Fecha, Descripcion, 0);
            }

            if (Cheque > 0)
            {
                cChequeCobrar cheque = new cChequeCobrar();
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Detalle de Cheque", "", "", "", Orden);
                Orden = Orden + 1;
                string sCheque = "";
                
                for (int i = 0; i < GrillaCheques.Rows.Count - 1; i++)
                {
                    string NroCheque = GrillaCheques.Rows[i].Cells[0].Value.ToString();
                    string Importe = GrillaCheques.Rows[i].Cells[1].Value.ToString();
                    string FechaVencimiento = GrillaCheques.Rows[i].Cells[2].Value.ToString();
                    string CodBanco = GrillaCheques.Rows[i].Cells[3].Value.ToString();
                    string sBanco = GrillaCheques.Rows[i].Cells[4].Value.ToString();
                    sCheque = "N° " + NroCheque + " " + sBanco;
                    sCheque = sCheque + " Vence " + FechaVencimiento;
                    string sImporte = "$ " + Importe;
                    recibo.InsertarDetalle(con, Transaccion, CodRecibo, "", sCheque, "", sImporte, Orden);
                    Orden = Orden + 1;
                    cheque.InsertarTransaccion(con, Transaccion, dpFecha.Value, Convert.ToDateTime(FechaVencimiento), fun.ToDouble(Importe), Convert.ToInt32(CodBanco), txtApellido.Text, txtNombre.Text, "","", NroCheque, CodRecibo);
                    
                }
            }

            if (Transferencia > 0)
            {
                cTransferencia Transfer = new cTransferencia();
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Detalle de Transferencia", "", "", "", Orden);
                Orden = Orden + 1;
                Double Monto = 0;
                string sTransfer = "";
                for (int i = 0; i < GrillaTransferencia .Rows.Count - 1; i++)
                {
                    string Numero = GrillaTransferencia.Rows[i].Cells[2].Value.ToString();
                    string Importe = GrillaTransferencia.Rows[i].Cells[3].Value.ToString();
                    Monto = fun.ToDouble(Importe);
                    string FechaVencimiento = GrillaTransferencia.Rows[i].Cells[4].Value.ToString();
                    string CodBanco = GrillaTransferencia.Rows[i].Cells[0].Value.ToString();
                    string sBanco = GrillaTransferencia.Rows[i].Cells[1].Value.ToString();
                    sTransfer = "N° " + Numero + " " + FechaVencimiento + " " + sBanco;
                    string sImporte = "$ " + Importe;
                    recibo.InsertarDetalle(con, Transaccion, CodRecibo, "", sTransfer, "", sImporte, Orden);
                    Orden = Orden + 1;
                    Transfer.Insertar(con, Transaccion, null, Convert.ToInt32(CodBanco), Numero, Monto, Fecha, Convert.ToInt32(CodRecibo));
                }
            }

            if (tbCobranza.Rows.Count >0)
            {
                Double TotalCobranza = fun.TotalizarColumna(tbCobranza, "Importe");
                string sImporte ="$ " + fun.FormatoEnteroMiles(TotalCobranza.ToString());
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "A Pagar", "", "", sImporte, Orden);
                Orden = Orden + 1;
            }

            if (Saldo >0)
            {
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Saldo ", "", "", sSaldo , Orden);
                Orden = Orden + 1;
            }

            Principal.CodRecibo = CodRecibo;

        }

        private void GuardarCliente(SqlConnection con, SqlTransaction Transaccion)
        {
            cCliente cli = new cCliente();
            Int32? CodTipoDoc = null;
            string NroDocumento = txtNroDoc.Text;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Telefono = txtTelefono.Text;
            if (cmbDocumento.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmbDocumento.SelectedValue);
            Int32 CodCliente = cli.InserterClienteId(con, Transaccion, CodTipoDoc,
                NroDocumento, Nombre, Apellido, Telefono);
            txtCodCLiente.Text = CodCliente.ToString();


        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
           
            if (txtEfectivo.Text != "")
            {
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
            }
           
        }

        private void txtImporteCheque_Leave(object sender, EventArgs e)
        {
            if (txtImporteCheque.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteCheque.Text = fun.FormatoEnteroMiles(txtImporteCheque.Text);
            }
        }

        private void btnAgregarTransferencia_Click(object sender, EventArgs e)
        {
            if (txtImporteTransferencia.Text == "")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }

            if (txtNumeroTransferencia.Text == "")
            {
                Mensaje("Debe ingresar un Número de transferencia");
                return;
            }

            if (cmbBancoTransferencia.SelectedIndex < 1)
            {
                Mensaje("debe seleccionar un banco");
                return;
            }

            cFunciones fun = new cFunciones();
            Double Importe = fun.ToDouble(txtImporteTransferencia.Text);
            string sImporte = fun.FormatoEnteroMiles(Importe.ToString());
            int CodBanco = Convert.ToInt32(cmbBancoTransferencia.SelectedValue);
            string Nombre = cmbBancoTransferencia.Text;
            string Nro = txtNumeroTransferencia.Text;
            DateTime FechaTransferencia = dpFechaTransferencia.Value;
            string Val = "";
            Val = CodBanco.ToString();
            Val = Val + ";" + Nombre;
            Val = Val + ";" + Nro;
            Val = Val + ";" + sImporte;
            Val = Val + ";" + FechaTransferencia.ToShortDateString();
            tbTransferencia = fun.AgregarFilas(tbTransferencia, Val);
            // tbTransferencia = fun.TablaaMiles(tbTransferencia, "Importe");
            GrillaTransferencia.DataSource = tbTransferencia;
            fun.AnchoColumnas(GrillaTransferencia, "0;40;20;20;20");
            txtImporteTransferencia.Text = "";
            txtNumeroTransferencia.Text = "";
            Double Transferencia = 0;
            Transferencia = fun.TotalizarColumna(tbTransferencia, "Importe");
           
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnquitarTransferencia_Click(object sender, EventArgs e)
        {
            if (GrillaTransferencia.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un elemento");
                return;
            }
            cFunciones fun = new cFunciones();
            Double Importe = fun.ToDouble(GrillaTransferencia.CurrentRow.Cells[3].Value.ToString());
            string Numero = GrillaTransferencia.CurrentRow.Cells["Numero"].Value.ToString();

            tbTransferencia = fun.EliminarFila(tbTransferencia, "Numero", Numero);
            Double Transferencia = 0;
            Transferencia = fun.TotalizarColumna(tbTransferencia, "Importe");

        }

        private void BtnAgregarCobranza_Click(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            if (txtImporteCobranza.Text == "")
            {
                Mensaje("Debe ingresar el importe de la cobranza");
                return;
            }
            if (txtCuotasCobranza.Text == "")
            {
                Mensaje("Debe ingresar el número de cuotas");
                return;
            }


            Double Capital = fun.ToDouble(txtImporteCobranza.Text);
            int Cuotas = Convert.ToInt32(txtCuotasCobranza.Text);
            Double ImporteCuota = Capital / Cuotas;
            string val = "";
            string NroCuota = "";
            string FechaPago = "";
            string CodCob = "0";
            DateTime Fecha = dpFechaCompromiso.Value;
            for (int i = 0; i < Cuotas; i++)
            {
                NroCuota = (i + 1).ToString();
                // val = NroCuota + ";" + fun.FormatoEnteroMiles(ImporteCuota.ToString()) + ";" + Fecha.ToShortDateString() + ";" + FechaPago + ";" + ImporteCuota.ToString();
                val = NroCuota + ";" + (ImporteCuota.ToString()) + ";" + Fecha.ToShortDateString() + ";" + FechaPago + ";" + ImporteCuota.ToString();
                val = val + ";" + CodCob;
                tbCobranza = fun.AgregarFilas(tbCobranza, val);
                Fecha = Fecha.AddMonths(1);
            }

            tbCobranza = fun.TablaaFechas(tbCobranza, "Importe");
            tbCobranza = fun.TablaaFechas(tbCobranza, "Saldo");

            Double TotalCobranza = fun.TotalizarColumna(tbCobranza, "Importe");
            // tbCobranza = fun.TablaaMiles(tbCobranza, "Importe");
            GrillaCobranza.DataSource = tbCobranza;
            // txtTotalCobranza.Text = TotalCobranza.ToString();
            
            GrillaCobranza.Columns[0].Width = 180;
            GrillaCobranza.Columns[1].Width = 180;
            GrillaCobranza.Columns[4].Width = 190;
            GrillaCobranza.Columns[5].Visible = false;
        }

        private void txtImporteCobranza_Leave(object sender, EventArgs e)
        {
            if (txtImporteCobranza.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteCobranza.Text = fun.FormatoEnteroMiles(txtImporteCobranza.Text);
            }
        }

        private void txtSaldo_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();  
            if (txtSaldo.Text != "")
            {
                txtSaldo.Text = fun.FormatoEnteroMiles(txtSaldo.Text);
            }
        }

        private void FrmRecibo_Load(object sender, EventArgs e)
        {
            if (Principal.CodCliente!=null)
            {
                BuscarCliente(Convert.ToInt32(Principal.CodCliente));
            }
        }

        private void BuscarCliente(Int32 CodCliente)
        {
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientesxCodigo(CodCliente);
            if (trdo.Rows.Count >0)
            {
                cmbDocumento.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
            }

            if (Principal.Importe !=null)
            {
                cFunciones fun = new cFunciones();
                txtEfectivo.Text = Principal.Importe.ToString();
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
            }
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumento.SelectedIndex > 0)
            {
                int CodTipoDoc = Convert.ToInt32(cmbDocumento.SelectedValue);
                OcultarTipoDoc(CodTipoDoc);
            }
        }

        private void OcultarTipoDoc(int CodTipoDoc)
        {
            switch (CodTipoDoc)
            {
                case 1:
                    lblApellido.Visible = true;
                    txtApellido.Visible = true;
                    lblNombre.Text = "Nombre";
                   
                    break;
                case 2:
                    lblApellido.Visible = false;
                    txtApellido.Visible = false;
                    lblNombre.Text = "Razón Social";
                    
                    break;
                case 3:
                    lblApellido.Visible = false;
                    txtApellido.Visible = false;
                    lblNombre.Text = "Razón Social";
                   
                    break;

            }
        }

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscadorCliente frm = new FrmBuscadorCliente();
            frm.FormClosing += new FormClosingEventHandler(FrmBuscarCliente);
            frm.Show();
        }

        private void FrmBuscarCliente(object sender, FormClosingEventArgs e)
        {
            Int32 CodCliente = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            BuscarCLiente(CodCliente);
        }

        private void BuscarCLiente(Int32 CodCLiente)
        {
            cCliente cli = new cCliente();
            DataTable tb = cli.GetClientesxCodigo(CodCLiente);
            if (tb.Rows.Count >0)
            {
                if (tb.Rows[0]["CodCliente"].ToString ()!="")
                {
                    txtCodCLiente.Text = tb.Rows[0]["CodCliente"].ToString();
                    txtApellido.Text = tb.Rows[0]["Apellido"].ToString();
                    txtNombre.Text = tb.Rows[0]["Nombre"].ToString();
                    txtTelefono.Text = tb.Rows[0]["Telefono"].ToString();
                    if (tb.Rows[0]["CodTipoDoc"].ToString()!="")
                    {
                        cmbDocumento.SelectedValue = tb.Rows[0]["CodTipoDoc"].ToString();
                    }
                    txtNroDoc.Text = tb.Rows[0]["NroDocumento"].ToString();
                }
            }
        }

        private void txtCodCLiente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
