﻿using System;
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
    public partial class FrmVenta : Form
    {  //comentario
        DataTable tbListaPapeles;
        private Boolean GrabaClienteNuevo;
        private Int32 SigueMarca;
        private Int32 SigueCiudad;
        private Int32 SigueBarrio;
        DataTable tprenda;
        DataTable tbTarjeta;
        DataTable tbCobranza;
        DataTable tbFinaciacionCuota;
        DataTable tbTransferencia;
        //se utiliza para indicar en que combo debe seguir
        //cuadno regrese del alta basica y tengas dos
        //tablas iguales
        public FrmVenta()
        {
            InitializeComponent();
            InicializarComponentes();

        }

        private void InicializarComponentes()
        {
            tbFinaciacionCuota = new DataTable();
            tprenda = new DataTable();
            Clases.cFunciones fun = new Clases.cFunciones();
            string Lista = "CodEntidad;Nombre;Fecha;Importe;CodPrenda;FechaVencimiento";
            tprenda = fun.CrearTabla(Lista);
            tbFinaciacionCuota = fun.CrearTabla("CodTipo;Nombre;Importe");
            PintarFormulario();
            //Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
            fun.LlenarCombo(CmbEntidadPrendaria, "EntidadPrendaria", "Descripcion", "CodEntidad");
            fun.LlenarCombo(CmbMarca2, "Marca", "Nombre", "CodMarca");
            // fun.LlenarCombo(cmbCiudad, "Ciudad", "Nombre", "CodCiudad");
            if (cmbCiudad.Items.Count > 1)
                cmbCiudad.SelectedValue = 1;
            fun.LlenarCombo(CmbCiudad2, "Ciudad", "Nombre", "CodCiudad");
            string sqlDoc = "select * from TipoDocumento order by CodTipoDoc";
            DataTable tbDoc = cDb.ExecuteDataTable(sqlDoc);
            fun.LlenarComboDatatable(cmbDocumento, tbDoc, "Nombre", "CodTipoDoc");
            if (cmbDocumento.Items.Count > 1)
                cmbDocumento.SelectedIndex = 1;
            fun.LlenarCombo(CmbBarrio, "Barrio", "Nombre", "CodBarrio");
            fun.LlenarCombo(CmbGastosTransferencia, "CategoriaGastoTransferencia", "Descripcion", "Codigo");
            fun.LlenarCombo(CmbGastoRecepcion, "CategoriaGastoRecepcion", "Descripcion", "Codigo");
            fun.LlenarCombo(CmbBanco, "Banco", "Nombre", "CodBanco");
            fun.LlenarCombo(cmbBancoTransferencia, "Banco", "Nombre", "CodBanco");
            fun.LlenarCombo(cmbTarjeta, "Tarjeta", "Nombre", "CodTarjeta");
            fun.LlenarCombo(CmbTipoCombustible2, "TipoCombustible", "Nombre", "Codigo");
            fun.LlenarCombo(cmbProvincia2, "Provincia", "Nombre", "CodProvincia");
            fun.LlenarCombo(cmbTipoUtilitario, "TipoUtilitario", "Nombre", "CodTipo");
            fun.LlenarCombo(CmbProvinciaAuto, "Provincia", "Nombre", "CodProvincia");
            DataTable tbColor = cDb.ExecuteDataTable("select * from Color order by Nombre");
            fun.LlenarComboDatatable(cmbColor, tbColor, "Nombre", "CodColor");
            fun.LlenarComboDatatable(cmbColor2, tbColor, "Nombre", "CodColor");
            DataTable tbAnio = cDb.ExecuteDataTable("select * from anio Order by Nombre desc");
            fun.LlenarComboDatatable(cmbAnio, tbAnio, "Nombre", "CodAnio");
            LlenarFinanciacion();
            fun.LlenarComboDatatable(cmbAnio2, tbAnio, "Nombre", "CodAnio");
            CargarVendedor();
            tbTarjeta = fun.CrearTabla("CodTarjeta;Nombre;Importe");
            OcultarVendedor(false);
            tbTransferencia = fun.CrearTabla("CodBanco;Nombre;Numero;Importe");

            cPapeles papel = new cPapeles();
            DataTable tbPapeles = papel.GetPapeles();
            ListaPapeles.DataSource = tbPapeles;
            ListaPapeles.DisplayMember = "Nombre";
            ListaPapeles.ValueMember = "CodPapel";
            txtFechaEntregaPapel.Text = DateTime.Now.ToShortDateString();
            tbListaPapeles = new DataTable();
            tbListaPapeles.Columns.Add("CodPapel");
            tbListaPapeles.Columns.Add("Nombre");
            tbListaPapeles.Columns.Add("Entrego");
            tbListaPapeles.Columns.Add("Texto");
            tbListaPapeles.Columns.Add("Fecha");
            tbListaPapeles.Columns.Add("FechaVencimiento");
            if (Principal.CodigoPrincipalAbm != null)
            {
                txtCodVenta.Text = Principal.CodigoPrincipalAbm;
                string Cod = Principal.CodigoPrincipalAbm;
                BuscarVenta(Convert.ToInt32(Cod));
                GetVentaxtarjeta(Convert.ToInt32(Cod));
                //  btnGrabar.Visible = false;
                btnAnular.Visible = false;
                btnGrabarPreVenta.Visible = false;
                btnAgregarGarantias.Enabled = true;
                CargarGarantias(Convert.ToInt32(Cod));
                button3.Enabled = true;
                btnAgregarImpuesto.Enabled = true;
                btnQuitarImpuesto.Enabled = true;
                btnQuitarImpuesto.Enabled = true;
                btnAbrircPrenda.Visible = true;
                btnAbrirCuotas.Visible = true;
                txtPatente.Enabled = false;
                btnAbrirCobranzas.Visible = true;
                btnAbrirCheques.Visible = true;
                GetPapelesxcodVenta(Convert.ToInt32(Cod));
                GetPrendaxCodVenta(Convert.ToInt32(Cod));
                Principal.CodigoPrincipalAbm = null;
            }
            else
            {
                btnQuitarImpuesto.Enabled = false;
                btnQuitarImpuesto.Enabled = false;
            }
            if (Principal.CodigoSenia != null)
            {
                if (Principal.CodigoSenia != "")
                {
                    BuscarPreVenta(Convert.ToInt32(Principal.CodigoSenia));
                }
                Principal.CodigoSenia = null;
            }

            if (Principal.CodPresupuesto != null)
            {
                Int32 CodPresupuesto = Convert.ToInt32(Principal.CodPresupuesto);
                BuscarPresupuestoxCodigo(CodPresupuesto);
                Principal.CodPresupuesto = null;
               
            }
            txtTotalVehiculoPartePago.BackColor = System.Drawing.Color.LightGreen;
            txtTotalEfectivo.BackColor = System.Drawing.Color.LightGreen;
            txtTotalDocumentos.BackColor = System.Drawing.Color.LightGreen;
            txtTotalPrenda.BackColor = System.Drawing.Color.LightGreen;
            txtTotalCobranza.BackColor = System.Drawing.Color.LightGreen;
            txtTotalCheque.BackColor = System.Drawing.Color.LightGreen;
            txtTotalCheque.BackColor = System.Drawing.Color.LightGreen;
            txtTotalVenta.BackColor = System.Drawing.Color.LightGreen;
            txtSubTotal.BackColor = System.Drawing.Color.LightGreen;
            tbCobranza = new DataTable();
            string ColCob = "Cuota;Importe;FechaVencimiento;FechaPago;Saldo;CodCobranza";
            tbCobranza = fun.CrearTabla(ColCob);
            Principal.CodPresupuesto = null;
        }

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            string Patente = txtPatente.Text;
            if (Patente.Length > 4)
            {
                Clases.cAuto auto = new Clases.cAuto();
                DataTable trdo = auto.GetAutoxPatente(Patente);
                if (trdo.Rows.Count > 0)
                {
                    if (trdo.Rows[0]["Concesion"].ToString() == "1")
                    {
                        MessageBox.Show("El auto se encuentra en concesión, debe darlo de baja e ingresarlo nuevamente", Clases.cMensaje.Mensaje());
                        LimpiarAuto();
                        return;
                    }
                    b = 1;
                    Clases.cFunciones fun = new Clases.cFunciones();
                    txtRutaAuto.Text = trdo.Rows[0]["RutaImagen"].ToString();
                    txtDescripcion.Text = trdo.Rows[0]["Descripcion"].ToString();
                    if (trdo.Rows[0]["CodAnio"].ToString() != "")
                    {
                        cmbAnio.SelectedValue = trdo.Rows[0]["CodAnio"].ToString();
                    }
                    txtMotor.Text = trdo.Rows[0]["Motor"].ToString();
                    txtChasis.Text = trdo.Rows[0]["Chasis"].ToString();
                    txtKms.Text = trdo.Rows[0]["Kilometros"].ToString();
                    if (txtKms.Text != "")
                    {
                        txtKms.Text = fun.FormatoEnteroMiles(txtKms.Text);
                    }
                    txtCodAuto.Text = trdo.Rows[0]["CodAuto"].ToString();

                    if (trdo.Rows[0]["CodColor"].ToString() != "")
                    {
                        cmbColor.SelectedValue = trdo.Rows[0]["CodColor"].ToString();
                    }

                    if (trdo.Rows[0]["CodProvincia"].ToString() != "")
                    {
                        Int32 CodPro = Convert.ToInt32(trdo.Rows[0]["CodProvincia"].ToString());
                        cCiudad objCiudad = new cCiudad();
                        DataTable tbCiudad = objCiudad.GetCiudadxCodProvincia(CodPro);
                        fun.LlenarComboDatatable(cmbCiudad, tbCiudad, "Nombre", "CodCiudad");
                        if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                        {
                            cmbCiudad.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                        }
                    }

                    if (trdo.Rows[0]["CodMarca"].ToString() != "")
                    {
                        cmbMarca.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                    }

                    if (trdo.Rows[0]["Propio"].ToString() == "1")
                    {
                        radioPropio.Checked = true;
                        radioConcesion.Checked = false;
                    }

                    if (trdo.Rows[0]["Concesion"].ToString() == "1")
                    {
                        radioPropio.Checked = false;
                        radioConcesion.Checked = true;
                    }

                    Clases.cStockAuto stock = new Clases.cStockAuto();
                    DataTable trdo2 = stock.GetStockAutosVigentes(Convert.ToInt32(txtCodAuto.Text));
                    if (trdo2.Rows.Count > 0)
                    {
                        txtCodStock.Text = trdo2.Rows[0]["CodStock"].ToString();
                        // GetExTitular(Convert.ToInt32(trdo2.Rows[0]["CodCliente"].ToString()));
                        GetCostos(Convert.ToInt32(txtCodStock.Text));
                        CargarGastosGeneralesxCodStoxk(Convert.ToInt32(txtCodStock.Text));
                        if (trdo2.Rows[0]["CodCliente"].ToString() != "")
                        {
                            // txtCodCLiente.Text = trdo2.Rows[0]["CodCliente"].ToString();
                            // GetClientesxCodigo(Convert.ToInt32(txtCodCLiente.Text));
                        }

                    }

                    if (txtCodStock.Text == "")
                    {
                        MessageBox.Show("El vehículo no se encuentra en el stock ", Clases.cMensaje.Mensaje());
                        LimpiarAuto();
                        txtPatente.Text = "";
                    }
                }
            }
            if (b == 0)
                LimpiarPantalla(false);

        }

        private void GetExTitular(Int32 CodCliente)
        {
            Clases.cCliente cli = new Clases.cCliente();
            DataTable trdo = cli.GetClientesxCodigo(CodCliente);
            if (trdo.Rows.Count > 0)
            {
                string exTitular = trdo.Rows[0]["Nombre"].ToString();
                exTitular = exTitular + " " + trdo.Rows[0]["Apellido"].ToString();
                txtExTitular.Text = exTitular;
            }
            else
            {
                txtExTitular.Text = "";
            }

        }

        private void LimpiarAuto()
        {
            txtCodAuto.Text = "";
            txtCodStock.Text = "";
            cmbMarca.SelectedIndex = 0;
            txtDescripcion.Text = "";
            if (cmbAnio.SelectedIndex > 0)
            {
                cmbAnio.SelectedIndex = 0;
            }
            txtKms.Text = "";
            txtPrecioVenta.Text = "";
            txtImporteCompra.Text = "";
            GetCostos(-1);
            CargarGastosGeneralesxCodStoxk(-1);
            GrillaGastos.DataSource = null;
            txtTotalGasto.Text = "";
            GrillaVehiculos.DataSource = null;
            txtTotalEfectivo.Text = "";
            txtTotalVehiculoPartePago.Text = "";
            txtTotalCheque.Text = "";
            txtSubTotal.Text = "";
            txtTotalVenta.Text = "";
            txtTotalDocumentos.Text = "";
            GrillaCuotas.DataSource = null;
            txtTotalPrenda.Text = "";
            txtTotalCobranza.Text = "";

        }

        private void GetCostos(Int32 CodStock)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cCosto costo = new Clases.cCosto();
            DataTable trdo = costo.GetCostoxCodigoStock(CodStock);
            //agrego el precio de compra del auto
            Clases.cStockAuto objStock = new Clases.cStockAuto();
            DataTable tstock = objStock.GetStockxCodigo(CodStock);
            if (tstock.Rows.Count > 0)
            {
                DataRow r;
                r = trdo.NewRow();
                r["CodCosto"] = "0";
                r["Patente"] = tstock.Rows[0]["Patente"].ToString();
                r["Descripcion"] = "IMPORTE COMPRA";
                r["Fecha"] = Convert.ToDateTime(tstock.Rows[0]["FechaAlta"].ToString()).ToShortDateString();
                if (tstock.Rows[0]["ImporteCompra"].ToString() != "")
                    r["Importe"] = tstock.Rows[0]["ImporteCompra"].ToString();
                else
                    r["Importe"] = "0";
                trdo.Rows.Add(r);
            }
            double TotalCosto = 0;
            string Importe = "";
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                Importe = trdo.Rows[i]["Importe"].ToString();
                TotalCosto = TotalCosto + Convert.ToDouble(Importe);
            }
            Grilla.DataSource = fun.TablaaMiles(trdo, "Importe");
            Grilla.Columns[1].Visible = false;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].Width = 150;
            Grilla.Columns[3].Width = 90;
            Grilla.Columns[4].Width = 110;
            txtTotalCossto.Text = TotalCosto.ToString();
            if (txtTotalCossto.Text != "")
            {
                txtTotalCossto.Text = fun.FormatoEnteroMiles(txtTotalCossto.Text);
                txtImporteCompra.Text = txtTotalCossto.Text;
            }
            Grilla.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            Int32 CodTipoDoc = 0;
            if (cmbDocumento.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmbDocumento.SelectedValue);
            string nroDocumento = txtNroDoc.Text;
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientesxNroDoc(CodTipoDoc, nroDocumento);
            if (trdo.Rows.Count > 0)
            {
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
               
                txtCalle.Text = trdo.Rows[0]["Calle"].ToString();
                txtAltura.Text = trdo.Rows[0]["Numero"].ToString();
                txtEmail.Text = trdo.Rows[0]["Email"].ToString();
                txtObservacion.Text = trdo.Rows[0]["Observacion"].ToString();
                if (trdo.Rows[0]["RutaImagen"].ToString() != "")
                {
                    string Ruta = trdo.Rows[0]["RutaImagen"].ToString();
                    txtRutaImagenCliente.Text = Ruta;
                    imgFotoCliente.Image = System.Drawing.Image.FromFile(Ruta);
                }
                if (trdo.Rows[0]["FechaNacimiento"].ToString() != "")
                {
                    DateTime FechaNac = Convert.ToDateTime(trdo.Rows[0]["FechaNacimiento"].ToString());
                    txtFechaNacimiento.Text = FechaNac.ToShortDateString();
                }
                if (trdo.Rows[0]["CodBarrio"].ToString() != "")
                {
                    Int32 CodBarrio = Convert.ToInt32(trdo.Rows[0]["CodBarrio"].ToString());
                    cBarrio barrio = new cBarrio();
                    DataTable tbBarrio = barrio.GetBarrioxId(CodBarrio);
                    if (tbBarrio.Rows.Count > 0)
                    {
                        if (tbBarrio.Rows[0]["CodCiudad"].ToString() != "")
                        {
                            Int32 CodCiudad = Convert.ToInt32(tbBarrio.Rows[0]["CodCiudad"].ToString());
                            cCiudad objCiudad = new cCiudad();
                            DataTable tbCiudad = objCiudad.GetCiudadxId(CodCiudad);
                            if (tbCiudad.Rows.Count > 0)
                            {
                                if (tbCiudad.Rows[0]["CodProvincia"].ToString() != "")
                                {
                                    Int32 CodProvincia = Convert.ToInt32(tbCiudad.Rows[0]["CodProvincia"].ToString());
                                    cmbProvincia2.SelectedValue = CodProvincia.ToString();
                                    DataTable trCiudad = objCiudad.GetCiudadxCodProvincia(CodProvincia);
                                    cFunciones fun = new cFunciones();
                                    fun.LlenarComboDatatable(CmbCiudadCliente2, trCiudad, "Nombre", "CodCiudad");
                                    CmbCiudadCliente2.SelectedValue = CodCiudad.ToString();
                                    CmbBarrio.SelectedValue = CodBarrio.ToString();
                                }
                            }
                        }
                    }
                }

                txtCodCLiente.Text = trdo.Rows[0]["CodCliente"].ToString();
            }
            else
                LimpiarCliente();
        }

        private void LimpiarCliente()
        {
            txtCodCLiente.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            
            CmbBarrio.SelectedIndex = 0;
            txtCalle.Text = "";
            txtAltura.Text = "";
        }

        private void txtPatente2_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            string Patente = txtPatente2.Text;
            if (Patente.Length > 5)
            {
                Clases.cAuto auto = new Clases.cAuto();
                DataTable trdo = auto.GetAutoxPatente(Patente);
                if (trdo.Rows.Count > 0)
                {
                    b = 1;
                    txtDescripcion2.Text = trdo.Rows[0]["Descripcion"].ToString();
                    if (trdo.Rows[0]["CodAnio"].ToString() != null)
                    {
                        cmbAnio2.SelectedValue = trdo.Rows[0]["CodAnio"].ToString();
                    }

                    txtKms2.Text = trdo.Rows[0]["Kilometros"].ToString();
                    txtCodAuto2.Text = trdo.Rows[0]["CodAuto"].ToString();
                    if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                    {
                        CmbCiudad2.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                    }

                    if (trdo.Rows[0]["CodMarca"].ToString() != "")
                    {
                        CmbMarca2.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                    }

                    Clases.cStockAuto stock = new Clases.cStockAuto();
                    DataTable trdo2 = stock.GetStockAutosVigentes(Convert.ToInt32(txtCodAuto2.Text));
                    if (trdo2.Rows.Count > 0)
                    {
                        txtCodStock2.Text = trdo2.Rows[0]["CodStock"].ToString();
                        MessageBox.Show("El vehículo ya existe como stock", Clases.cMensaje.Mensaje());
                        LimpiarAuto2();
                    }
                }
            }
            if (b == 0)
                LimpiarAuto2();


        }

        private void PintarFormulario()
        {
            foreach (Control c in this.Controls)
            {
                string name = c.Name;
                if (c is TextBox)
                    c.BackColor = Color.LightGray;
                if (c is GroupBox)
                {
                    foreach (Control g in c.Controls)
                    {
                        if (g is TextBox || g is MaskedTextBox)
                            g.BackColor = Clases.cConfiguracion.ColorTextBox();
                        //g.BackColor = System.Drawing.SystemColors.Control;   
                    }
                }

                if (c is TabControl)
                {
                    foreach (Control g in c.Controls)
                    {
                        if (g is TabPage)
                        {
                            foreach (Control t in g.Controls)
                            {
                                if (t is GroupBox)
                                {
                                    foreach (Control gr in t.Controls)
                                    {
                                        if (gr is TextBox || gr is MaskedTextBox)
                                            gr.BackColor = Clases.cConfiguracion.ColorTextBox();
                                    }
                                }

                            }
                        }

                        //g.BackColor = System.Drawing.SystemColors.Control;   
                    }
                }
            }
        }

        private void LimpiarAuto2()
        {
            txtCodAuto2.Text = "";
            txtCodStock2.Text = "";
            CmbMarca2.SelectedIndex = 0;
            txtDescripcion2.Text = "";

            txtKms2.Text = "";
            txtImporteVehiculoCompra.Text = "";
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            txtTotalVenta.Text = txtPrecioVenta.Text;
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtImporteVehiculoCompra_TextChanged(object sender, EventArgs e)
        {
            txtTotalVehiculoPartePago.Text = txtImporteVehiculoCompra.Text;
        }

        private void btnCalcularCuotas_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();

            int n = 2;
            int x = 4;
            double r = Math.Pow(x, n);
            double Capital = 0;
            double Interes = 0;
            double Cuotas = 0;
            double ValorCuota = 0;


            if (txtCapital.Text == "")
            {
                MessageBox.Show("Debe ingresar un capital", Clases.cMensaje.Mensaje());
                return;
            }
            if (txtCapital.Text == "")
            {
                MessageBox.Show("Debe ingresar un capital", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtInteres.Text == "")
            {
                MessageBox.Show("Debe ingresar un interés", Clases.cMensaje.Mensaje());
                return;
            }

            if (Convert.ToDouble(txtInteres.Text) > 99)
            {
                MessageBox.Show("Debe ingresar un interés menor a 100", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtCuotas.Text == "")
            {
                MessageBox.Show("Debe ingresar una cantidad de cuotas para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtCapital.Text != "")
                Capital = fun.ToDouble(txtCapital.Text);
            if (txtCuotas.Text != "")
                Cuotas = fun.ToDouble(txtCuotas.Text);
            if (txtInteres.Text != "")
            {
                Interes = Convert.ToDouble(txtInteres.Text);
            }

            // PorAplicar = Cuotas * Interes / 12;
            // PorAplicar = Cuotas * Interes / 100;

            double d1 = Cuotas * Interes;
            d1 = d1 / 100;
            double d2 = Capital * d1;
            ValorCuota = (Capital + d2) / Cuotas;

            //CapitalConInteres = Capital + Capital * PorAplicar / 100;

            // ValorCuota = CapitalConInteres / Cuotas;
            Int32 ValorCuotaEntero = Convert.ToInt32(ValorCuota);
            Int32 ValorCuotaSinInteres = Convert.ToInt32(Capital / Cuotas);
            DateTime FechaVencimiento = dpFecha.Value;
            DataTable tcuotas = new DataTable();
            tcuotas.Columns.Add("Cuota");
            tcuotas.Columns.Add("Importe");
            tcuotas.Columns.Add("FechaVencimiento");
            tcuotas.Columns.Add("CuotasSinInteres");
            int i = 0;
            FechaVencimiento = FechaVencimiento.AddMonths(1);
            DataRow row;
            Int32 AcumuladorCuotasSinInteres = 0;
            for (i = 0; i < Convert.ToInt32(Cuotas); i++)
            {
                row = tcuotas.NewRow();
                row["Cuota"] = (i + 1).ToString();
                row["Importe"] = ValorCuotaEntero.ToString();
                row["FechaVencimiento"] = FechaVencimiento.ToShortDateString();

                AcumuladorCuotasSinInteres = AcumuladorCuotasSinInteres + ValorCuotaSinInteres;
                FechaVencimiento = FechaVencimiento.AddMonths(1);
                if (i == Cuotas - 1)
                {
                    //es la ultima cuota y le agrego la diferencia.
                    Int32 Dif = AcumuladorCuotasSinInteres - Convert.ToInt32(Capital);
                    ValorCuotaSinInteres = ValorCuotaSinInteres - Dif;
                }
                row["CuotasSinInteres"] = ValorCuotaSinInteres.ToString();
                tcuotas.Rows.Add(row);
            }
            GrillaCuotas.DataSource = tcuotas;
            GrillaCuotas.Columns[2].HeaderText = "Vencimiento";
            GrillaCuotas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            GrillaCuotas.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            GrillaCuotas.Columns[0].Width = 180;
            GrillaCuotas.Columns[1].Width = 195;
            GrillaCuotas.Columns[2].Width = 180;
            GrillaCuotas.Columns[3].Width = 210;
            GrillaCuotas.Columns[3].HeaderText = "Importe s/Interés";
            txtTotalDocumentos.Text = txtCapital.Text;
            CalcularSubTotal();
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtImporteVehiculoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCapital_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString ());
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar() == false)
            {
                return;
            }
            if (txtCodVenta.Text != "")
            {
                AnularVenta(txtCodVenta.Text);
            }
           // cFunciones fun = new Clases.cFunciones();
            Clases.cVenta objVenta = new Clases.cVenta();
            double GastosTotalxAuto = objVenta.GetCostosTotalesxCodStock(Convert.ToInt32(txtCodStock.Text));
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            SqlCommand Comand = new SqlCommand();
            Comand.Connection = con;
            Comand.Transaction = Transaccion;
            string sqlCLiente = "";
            string sqlIngresarAuto = "";
            double ImporteSenia = 0;

            if (txtCodPreVenta.Text != "")
                ImporteSenia = GetTotalSenia(Convert.ToInt32(txtCodPreVenta.Text));
            try
            {
                sqlCLiente = GetSqlClientes();
                Comand.CommandText = sqlCLiente;
                Comand.ExecuteNonQuery();
                //SI FUE UN CLIENTE NUEVO
                //DEBO OBTENER EL COD CLIETNE
                if (GrabaClienteNuevo == true)
                {
                    SqlCommand comand2 = new SqlCommand();
                    comand2.Connection = con;
                    comand2.Transaction = Transaccion;
                    comand2.CommandText = "select max(CodCliente) as CodCliente from Cliente";
                    txtCodCLiente.Text = comand2.ExecuteScalar().ToString();
                }

                //saco el auto del stock
                string sqlStock = "update StockAuto";
                sqlStock = sqlStock + " set FechaBaja =" + "'" + dpFecha.Value.ToShortDateString() + "'";
                sqlStock = sqlStock + " where CodAuto =" + txtCodAuto.Text;
                Comand.CommandText = sqlStock;
                Comand.ExecuteNonQuery();

                //grabo el auto en el stock

                //si pago con usado lo ingreso
                if (txtTotalVehiculoPartePago.Text != "")
                    if (txtTotalVehiculoPartePago.Text != "0")
                    {
                        string sqlInsertStock = "";
                        for (int k = 0; k < GrillaVehiculos.Rows.Count - 1; k++)
                        {
                            Clases.cFunciones fun = new Clases.cFunciones();
                            string codAuto = GrillaVehiculos.Rows[k].Cells[0].Value.ToString();
                            string ImporteCompra = GrillaVehiculos.Rows[k].Cells[4].Value.ToString();
                            string AutoPartePago = txtPatente.Text + " " + txtDescripcion.Text;
                            sqlInsertStock = "insert into StockAuto(CodAuto,FechaAlta,CodCliente,CodUsuario,ImporteCompra,DescripcionAutoPartePago)";
                            sqlInsertStock = sqlInsertStock + " values (" + codAuto.ToString();
                            sqlInsertStock = sqlInsertStock + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                            sqlInsertStock = sqlInsertStock + "," + txtCodCLiente.Text;
                            sqlInsertStock = sqlInsertStock + "," + Principal.CodUsuarioLogueado.ToString();
                            sqlInsertStock = sqlInsertStock + "," + fun.ToDouble(ImporteCompra).ToString();
                            sqlInsertStock = sqlInsertStock + "," + "'" + AutoPartePago + "'";
                            sqlInsertStock = sqlInsertStock + ")";
                            sqlInsertStock = sqlInsertStock + " select SCOPE_IDENTITY()";


                            SqlCommand comandStockAuto = new SqlCommand();
                            comandStockAuto.Connection = con;
                            comandStockAuto.Transaction = Transaccion;
                            comandStockAuto.CommandText = sqlInsertStock;
                            Int32 CodStockau = Convert.ToInt32(comandStockAuto.ExecuteScalar());
                            if (k == 0)
                            {
                                GrabarPapelesxStock(con, Transaccion, null, CodStockau);
                            }
                        }



                    }

                //grabo la venta del auto
                string sqlVenta = GetSqlVenta();
                SqlCommand comandVenta = new SqlCommand();
                comandVenta.Connection = con;
                comandVenta.Transaction = Transaccion;
                comandVenta.CommandText = sqlVenta;
                comandVenta.ExecuteNonQuery();

                //obtengo el codigo de la venta
                string CodVenta = "";
                SqlCommand comandMaxVenta = new SqlCommand();
                comandMaxVenta.Connection = con;
                comandMaxVenta.Transaction = Transaccion;
                comandMaxVenta.CommandText = "select max(CodVenta) as CodVenta from Venta";
                CodVenta = comandMaxVenta.ExecuteScalar().ToString();

                //grabo el plan de cuotas
                if (txtTotalDocumentos.Text != "")
                {
                    //grabo las cuotas
                    string Cuota = "";
                    string ImporteCuota = "";
                    string FechaVecimiento = "";
                    string ImporteSinInteres = "";
                    string sqlInsertCuota = "";
                    for (int i = 0; i < GrillaCuotas.Rows.Count - 1; i++)
                    {
                        Cuota = GrillaCuotas.Rows[i].Cells[0].Value.ToString();
                        ImporteCuota = GrillaCuotas.Rows[i].Cells[1].Value.ToString();
                        FechaVecimiento = GrillaCuotas.Rows[i].Cells[2].Value.ToString();
                        ImporteSinInteres = GrillaCuotas.Rows[i].Cells[3].Value.ToString();
                        sqlInsertCuota = "Insert into Cuotas(CodVenta,Cuota,Importe,FechaVencimiento,Saldo,ImporteSinInteres)";
                        sqlInsertCuota = sqlInsertCuota + " values (";
                        sqlInsertCuota = sqlInsertCuota + CodVenta.ToString();
                        sqlInsertCuota = sqlInsertCuota + "," + Cuota;
                        sqlInsertCuota = sqlInsertCuota + "," + ImporteCuota;
                        sqlInsertCuota = sqlInsertCuota + "," + "'" + FechaVecimiento + "'";
                        sqlInsertCuota = sqlInsertCuota + "," + ImporteCuota;
                        sqlInsertCuota = sqlInsertCuota + "," + ImporteSinInteres;
                        sqlInsertCuota = sqlInsertCuota + ")";
                        SqlCommand comandCuota = new SqlCommand();
                        comandCuota.Connection = con;
                        comandCuota.Transaction = Transaccion;
                        comandCuota.CommandText = sqlInsertCuota;
                        comandCuota.ExecuteNonQuery();
                    }
                }

                //grabos los autos que entrego como parte de pago

                if (txtTotalVehiculoPartePago.Text != "")
                {
                    if (txtTotalVehiculoPartePago.Text != "0")
                    {
                        string sqlVentaxAuto = "";
                        for (int k = 0; k < GrillaVehiculos.Rows.Count - 1; k++)
                        {
                            Clases.cFunciones fun = new Clases.cFunciones();
                            string CodStockAu = GrillaVehiculos.Rows[k].Cells[5].Value.ToString();
                            string codAutok = GrillaVehiculos.Rows[k].Cells[0].Value.ToString();
                            string sImporte = GrillaVehiculos.Rows[k].Cells[4].Value.ToString();
                            sqlVentaxAuto = "insert into VentasxAuto(CodAuto,CodVenta,Importe)";
                            sqlVentaxAuto = sqlVentaxAuto + " values (" + codAutok.ToString();
                            sqlVentaxAuto = sqlVentaxAuto + "," + CodVenta.ToString();
                            sqlVentaxAuto = sqlVentaxAuto + "," + fun.ToDouble(sImporte).ToString();
                            sqlVentaxAuto = sqlVentaxAuto + ")";
                            SqlCommand comandVentaxAuto = new SqlCommand();
                            comandVentaxAuto.Connection = con;
                            comandVentaxAuto.Transaction = Transaccion;
                            comandVentaxAuto.CommandText = sqlVentaxAuto;
                            comandVentaxAuto.ExecuteNonQuery();

                        }
                    }
                }

                //grabo la prenda
                if (txtTotalPrenda.Text != "")
                {
                    if (txtTotalPrenda.Text != "0")
                    {
                        GrabarPrenda(Convert.ToInt32(CodVenta), con, Transaccion);
                        /*
                        SqlCommand ComandPrenda = new SqlCommand();
                        ComandPrenda.Connection = con;
                        ComandPrenda.Transaction = Transaccion;
                        ComandPrenda.CommandText = GetSqlPrenda(Convert.ToInt32(CodVenta));
                        ComandPrenda.ExecuteNonQuery();
                         * */
                    }
                }

                //grabo los gatos de transferencia
                for (int k = 0; k < GrillaGastos.Rows.Count - 1; k++)
                {
                    Clases.cFunciones fun = new Clases.cFunciones();
                    string CodGastoTransferencia = GrillaGastos.Rows[k].Cells[0].Value.ToString();
                    Double Importe = fun.ToDouble(GrillaGastos.Rows[k].Cells[3].Value.ToString());
                    string sqlGastosTransferencia = "";
                    sqlGastosTransferencia = "insert into GastosTransferencia(CodVenta,CodGastoTranasferencia,Importe)";
                    sqlGastosTransferencia = sqlGastosTransferencia + "values(";
                    sqlGastosTransferencia = sqlGastosTransferencia + CodVenta;
                    sqlGastosTransferencia = sqlGastosTransferencia + "," + CodGastoTransferencia;
                    sqlGastosTransferencia = sqlGastosTransferencia + "," + Importe.ToString();
                    sqlGastosTransferencia = sqlGastosTransferencia + ")";
                    SqlCommand ComandTransferencia = new SqlCommand();
                    ComandTransferencia.Connection = con;
                    ComandTransferencia.Transaction = Transaccion;
                    ComandTransferencia.CommandText = sqlGastosTransferencia;
                    ComandTransferencia.ExecuteNonQuery();
                }

                //gastos de recepcion

                for (int k = 0; k < GrillaGastosRecepcion.Rows.Count - 1; k++)
                {
                    Clases.cFunciones fun = new Clases.cFunciones();
                    string CodGastoRecepcion = GrillaGastosRecepcion.Rows[k].Cells[0].Value.ToString();
                    Double Importe = fun.ToDouble(GrillaGastosRecepcion.Rows[k].Cells[3].Value.ToString());
                    string CodAuto = GrillaGastosRecepcion.Rows[k].Cells[4].Value.ToString();
                    string sqlGastosRecepcion = "";
                    sqlGastosRecepcion = "insert into GastosRecepcion(CodVenta,CodAuto,CodGasto,Importe)";
                    sqlGastosRecepcion = sqlGastosRecepcion + "values(";
                    sqlGastosRecepcion = sqlGastosRecepcion + CodVenta;
                    sqlGastosRecepcion = sqlGastosRecepcion + "," + CodAuto;
                    sqlGastosRecepcion = sqlGastosRecepcion + "," + CodGastoRecepcion;
                    sqlGastosRecepcion = sqlGastosRecepcion + "," + Importe.ToString();
                    sqlGastosRecepcion = sqlGastosRecepcion + ")";
                    SqlCommand ComandRecepcion = new SqlCommand();
                    ComandRecepcion.Connection = con;
                    ComandRecepcion.Transaction = Transaccion;
                    ComandRecepcion.CommandText = sqlGastosRecepcion;
                    ComandRecepcion.ExecuteNonQuery();
                }

                if (txtTotalCheque.Text != "")
                {
                    if (txtTotalCheque.Text != "0")
                    {
                        Clases.cFunciones fun = new Clases.cFunciones();
                        for (int j = 0; j < GrillaCheques.Rows.Count - 1; j++)
                        {
                            string sImporteCheque = GrillaCheques.Rows[j].Cells[1].Value.ToString();
                            string sqlCheque = "insert into Cheque(CodVenta,NroCheque,Importe,Fecha,FechaVencimiento,CodCliente,CodBanco)";
                            sqlCheque = sqlCheque + "values (" + CodVenta.ToString();
                            sqlCheque = sqlCheque + "," + "'" + GrillaCheques.Rows[j].Cells[0].Value.ToString() + "'";
                            sqlCheque = sqlCheque + "," + fun.ToDouble(sImporteCheque);
                            sqlCheque = sqlCheque + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                            sqlCheque = sqlCheque + "," + "'" + GrillaCheques.Rows[j].Cells[2].Value.ToString() + "'";
                            sqlCheque = sqlCheque + "," + txtCodCLiente.Text;
                            sqlCheque = sqlCheque + "," + CmbBanco.SelectedValue;
                            sqlCheque = sqlCheque + ")";

                            SqlCommand ComandCheque = new SqlCommand();
                            ComandCheque.Connection = con;
                            ComandCheque.Transaction = Transaccion;
                            ComandCheque.CommandText = sqlCheque;
                            ComandCheque.ExecuteNonQuery();
                        }



                    }
                }
                //grabo la cobranza
                if (txtTotalCobranza.Text != "")
                    if (txtTotalCobranza.Text != "0")
                    {
                        Clases.cFunciones fun = new Clases.cFunciones();
                        string sqlCobranza = "";
                        string FechaCompromisoPago = "";
                        string Cuota = "";
                        Double ImporteCobranzaCuota = 0;
                        for (int kk = 0; kk < tbCobranza.Rows.Count; kk++)
                        {
                            FechaCompromisoPago = tbCobranza.Rows[kk]["FechaVencimiento"].ToString();
                            ImporteCobranzaCuota = fun.ToDouble(tbCobranza.Rows[kk]["Importe"].ToString());
                            Cuota = tbCobranza.Rows[kk]["Cuota"].ToString();
                            //agregar la cuota en la tabla cobranza
                            sqlCobranza = "Insert into Cobranza(CodVenta,Importe,Fecha,CodAuto,CodCliente,FechaCompromiso,ImportePagado,Saldo,Cuota)";
                            sqlCobranza = sqlCobranza + " values (" + CodVenta.ToString();
                            sqlCobranza = sqlCobranza + "," + ImporteCobranzaCuota.ToString();
                            sqlCobranza = sqlCobranza + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                            sqlCobranza = sqlCobranza + "," + txtCodAuto.Text;
                            sqlCobranza = sqlCobranza + "," + txtCodCLiente.Text;
                            sqlCobranza = sqlCobranza + "," + "'" + FechaCompromisoPago + "'";
                            sqlCobranza = sqlCobranza + ",0";
                            sqlCobranza = sqlCobranza + "," + ImporteCobranzaCuota.ToString();
                            sqlCobranza = sqlCobranza + "," + Cuota.ToString();
                            sqlCobranza = sqlCobranza + ")";
                            SqlCommand ComandCobranza = new SqlCommand();
                            ComandCobranza.Connection = con;
                            ComandCobranza.Transaction = Transaccion;
                            ComandCobranza.CommandText = sqlCobranza;
                            ComandCobranza.ExecuteNonQuery();
                        }

                    }
                Clases.cFunciones func = new Clases.cFunciones();
                //grabo los gastos a pagar
                string sqlGastosPagar = "";
                for (int i = 0; i < GrillaGastos.Rows.Count - 1; i++)
                {
                    string sDescripcion = GrillaGastos.Rows[i].Cells[1].Value.ToString();
                    string sImporte = GrillaGastos.Rows[i].Cells[3].Value.ToString();
                    Int32 CodStock = Convert.ToInt32(txtCodStock.Text);
                    sqlGastosPagar = "Insert into GastosPagar(CodAuto,Descripcion";
                    sqlGastosPagar = sqlGastosPagar + ",Fecha,Importe,CodVenta,CodStock)";
                    sqlGastosPagar = sqlGastosPagar + "values (" + txtCodAuto.Text;
                    sqlGastosPagar = sqlGastosPagar + "," + "'" + sDescripcion + "'";
                    sqlGastosPagar = sqlGastosPagar + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                    sqlGastosPagar = sqlGastosPagar + "," + func.ToDouble(sImporte);
                    sqlGastosPagar = sqlGastosPagar + "," + CodVenta.ToString();
                    sqlGastosPagar = sqlGastosPagar + "," + CodStock.ToString();
                    sqlGastosPagar = sqlGastosPagar + ")";

                    SqlCommand comandGastosPagar = new SqlCommand();
                    comandGastosPagar.Connection = con;
                    comandGastosPagar.Transaction = Transaccion;
                    comandGastosPagar.CommandText = sqlGastosPagar;
                    comandGastosPagar.ExecuteNonQuery();
                }

                for (int i = 0; i < GrillaGastosRecepcion.Rows.Count - 1; i++)
                {
                    string sCodAuto = GrillaGastosRecepcion.Rows[i].Cells[4].Value.ToString();
                    Int32 CodStock = GetCodStockxCodAuto(Convert.ToInt32(sCodAuto), con, Transaccion);
                    string Descripcion = GrillaGastosRecepcion.Rows[i].Cells[1].Value.ToString();
                    string Importe = GrillaGastosRecepcion.Rows[i].Cells[3].Value.ToString();
                    sqlGastosPagar = "Insert into GastosPagar(CodAuto,Descripcion";
                    sqlGastosPagar = sqlGastosPagar + ",Fecha,Importe,CodStock,CodVenta)";
                    sqlGastosPagar = sqlGastosPagar + "values (" + sCodAuto;
                    sqlGastosPagar = sqlGastosPagar + "," + "'" + Descripcion + "'";
                    sqlGastosPagar = sqlGastosPagar + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                    sqlGastosPagar = sqlGastosPagar + "," + func.ToDouble(Importe);
                    sqlGastosPagar = sqlGastosPagar + "," + CodStock.ToString();
                    sqlGastosPagar = sqlGastosPagar + "," + CodVenta.ToString();
                    sqlGastosPagar = sqlGastosPagar + ")";

                    SqlCommand comandGastosPagar = new SqlCommand();
                    comandGastosPagar.Connection = con;
                    comandGastosPagar.Transaction = Transaccion;
                    comandGastosPagar.CommandText = sqlGastosPagar;
                    comandGastosPagar.ExecuteNonQuery();
                }

                //ACTUALIZO LA CODVENTA DE GASTOS PAGAR
                //CUANDO SE HAYA PAGADO LA RECEPCION ANTES QUE SE
                //VENDIERA EL AUTO
                Int32 CodStockActual = Convert.ToInt32(txtCodStock.Text);
                string sqlGasto = "update GastosPagar set CodVenta =" + CodVenta.ToString();
                sqlGasto = sqlGasto + " where CodStock=" + CodStockActual.ToString();
                SqlCommand comandGastos = new SqlCommand();
                comandGastos.Connection = con;
                comandGastos.Transaction = Transaccion;
                comandGastos.CommandText = sqlGasto;
                comandGastos.ExecuteNonQuery();

                string sqlSubCon = "(select CodVenta from GastosPagar ga where ga.CodGasto=DiferenciaTransferencia.CodGasto and ga.CodVenta=" + CodVenta.ToString() + ")";
                string sqlDif = "update DiferenciaTransferencia  set CodVenta=" + sqlSubCon;
                SqlCommand comandDif = new SqlCommand();
                comandDif.Connection = con;
                comandDif.Transaction = Transaccion;
                comandDif.CommandText = sqlDif;
                //comandDif.ExecuteNonQuery();

                //actualizo codventa en los gastos de recepcion que se registraron previamente
                ActualizarCodVentaEnGastosRecepcion(Convert.ToInt32(CodVenta), con, Transaccion);

                //grabo el movimientocon
                SqlCommand comandMovimiento = new SqlCommand();
                comandMovimiento.Connection = con;
                comandMovimiento.Transaction = Transaccion;
                comandMovimiento.CommandText = GetSqlMovimientos(Convert.ToInt32(CodVenta));
                comandMovimiento.ExecuteNonQuery();
                //grabo el movimiento para restar el importe del auto
                //ya que si vendo un auto se debe descontar en cuentas de autos

                SqlCommand comandMovimientoAuto = new SqlCommand();
                comandMovimientoAuto.Connection = con;
                comandMovimientoAuto.Transaction = Transaccion;
                comandMovimientoAuto.CommandText = GetSqlMovimientosAutoVendido(Convert.ToInt32(CodVenta), GastosTotalxAuto);
                comandMovimientoAuto.ExecuteNonQuery();

                if (txtComisionVendedor.Text != "")
                    if (txtComisionVendedor.Text != "0")
                    {
                        string Sqlcomision = GetSqlComision(CodVenta);
                        SqlCommand comandComision = new SqlCommand();
                        comandComision.Connection = con;
                        comandComision.Transaction = Transaccion;
                        comandComision.CommandText = Sqlcomision;
                        comandComision.ExecuteNonQuery();
                    }
                if (txtCodPreVenta.Text != "")
                {
                    string SqlSenia = "";
                    /* string SqlSenia = GetSqlRestarSeniaMovimientos(ImporteSenia);
                         SqlCommand comandSenia = new SqlCommand();
                         comandSenia.Connection = con;
                         comandSenia.Transaction = Transaccion;
                         comandSenia.CommandText = SqlSenia;
                         comandSenia.ExecuteNonQuery();*/
                    //actualizo la fecha
                    SqlSenia = "update PreVenta set FechaEjecucion=" + "'" + dpFecha.Value.ToShortDateString() + "'";
                    SqlSenia = SqlSenia + " where CodPreVenta=" + txtCodPreVenta.Text.ToString();
                    SqlCommand comandFecSenia = new SqlCommand();
                    comandFecSenia.Connection = con;
                    comandFecSenia.Transaction = Transaccion;
                    comandFecSenia.CommandText = SqlSenia;
                    comandFecSenia.ExecuteNonQuery();
                }

                if (txtMontoTarjeta.Text != "" && txtMontoTarjeta.Text != "0")
                {
                    string sqlTar = "";
                    for (int i = 0; i < GrillaTarjeta.Rows.Count - 1; i++)
                    {
                        Int32 CodTarjeta = Convert.ToInt32(GrillaTarjeta.Rows[i].Cells[0].Value.ToString());
                        Double ImporteTarjeta = func.ToDouble(GrillaTarjeta.Rows[i].Cells[2].Value.ToString());
                        sqlTar = "Insert into ventaxtarjeta(CodVenta";
                        sqlTar = sqlTar + ",CodTarjeta,Importe,Saldo)";
                        sqlTar = sqlTar + " Values(" + CodVenta.ToString();
                        sqlTar = sqlTar + "," + CodTarjeta.ToString();
                        sqlTar = sqlTar + "," + ImporteTarjeta.ToString().Replace(",", ".");
                        sqlTar = sqlTar + "," + ImporteTarjeta.ToString().Replace(",", ".");
                        sqlTar = sqlTar + ")";
                        SqlCommand comandTarjeta = new SqlCommand();
                        comandTarjeta.Connection = con;
                        comandTarjeta.Transaction = Transaccion;
                        comandTarjeta.CommandText = sqlTar;
                        comandTarjeta.ExecuteNonQuery();
                    }
                }
               
                
                if (tbTransferencia.Rows.Count >0)
                {
                    if (tbTransferencia.Rows[0]["CodBanco"].ToString ()!="")
                    {
                        DateTime Fecha = Convert.ToDateTime(dpFecha.Value);
                        cFunciones fun = new Clases.cFunciones();
                        cTransferencia transfer = new cTransferencia();
                        for (int i = 0; i < tbTransferencia.Rows.Count  ; i++)
                        {
                            int CodBanco = Convert.ToInt32(tbTransferencia.Rows[i]["CodBanco"]);
                            string Numero = tbTransferencia.Rows[i]["Numero"].ToString();
                            Double Importe = fun.ToDouble(tbTransferencia.Rows[i]["Importe"].ToString());
                            transfer.Insertar(con, Transaccion,Convert.ToInt32 (CodVenta), CodBanco, Numero, Importe,Fecha,null);
                        }
                    }
                }
               // GuardarRecibo(con, Transaccion);
                GuardarBoleto(con, Transaccion, Convert.ToInt32(CodVenta));
                Transaccion.Commit();
              
                con.Close();
                ActualizarDiferenciaTransferencia(Convert.ToInt32(CodVenta));
                MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
                FrmRecibo frm = new FrmRecibo();
                Int32 CodCliente = 0;
                if (txtCodCLiente.Text != "")
                    CodCliente = Convert.ToInt32(txtCodCLiente.Text);
                Principal.CodCliente = CodCliente;
                frm.Show();
                /*               
                FrmReporteRecibo frm = new Concesionaria.FrmReporteRecibo();
                frm.Show();
                Principal.CodRecibo = null;
                */
                LimpiarPantalla(true);
                Principal.CodCliente = null;

            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                MessageBox.Show("Hubo un error en el proceso de grabación", Clases.cMensaje.Mensaje());
            }
        }

        private void GuardarRecibo(SqlConnection con, SqlTransaction Transaccion)
        {
            cFunciones fun = new cFunciones();
            cRecibo recibo = new cRecibo();
            Int32 CodRecibo = 0;
            Double Efectivo = 0;
            Double Cheque = 0;
            Double Vehiculo = 0;
            DateTime Fecha = dpFecha.Value;
            string NroRecibo = "";
            int Orden = 1;
            Int32 CodEmpleado = 0;
            if (txtEfectivo.Text != "")
            {
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            }

            CodEmpleado = Convert.ToInt32(CmbVendedor.SelectedValue);

            Int32 CodCliente = Convert.ToInt32(txtCodCLiente.Text);
            CodRecibo = recibo.Insertar(con, Transaccion, Fecha, CodCliente, 0, "", "", 0, "", Efectivo, CodEmpleado);
            NroRecibo = recibo.GetNroRecibo(CodRecibo);
            recibo.ActualizarNroRecibo(con, Transaccion, CodRecibo, NroRecibo);
          
              
            if (txtTotalCheque.Text != "")
            {
                Cheque  = fun.ToDouble(txtTotalCheque.Text);
            }
             
            if (txtTotalVehiculoPartePago.Text != "")
            {
                Vehiculo = fun.ToDouble(txtTotalVehiculoPartePago.Text);
            }

            if (Efectivo >0)
            {
                string Descripcion = "Recibo de " + txtNombre.Text + " " + txtApellido.Text;
                string sEfectivo = "$ " + txtEfectivo.Text;
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Efectivo", "", "", sEfectivo, Orden);
                cMovimiento mov = new cMovimiento();
                mov.RegistrarMovimientoDescripcionTransaccion(con, Transaccion,
                    Principal.CodUsuarioLogueado,0, Efectivo, 0, 0, 0, 0, Fecha, Descripcion, 0);
            }

            if (Cheque >0)
            {
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
                }
            }

            if (Vehiculo >0)
            {
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Detalle de entrega Auto", "", "", "", Orden);
                Orden = Orden + 1;
                string sImporteAuto = "";
                string Auto = "";
                for (int i = 0; i < GrillaVehiculos.Rows.Count -1 ; i ++)
                {

                    Auto = GrillaVehiculos.Rows[i].Cells["Descripcion"].Value.ToString();
                    Auto = Auto + " " + GrillaVehiculos.Rows[i].Cells["Marca"].Value.ToString();
                    sImporteAuto = "$ " + GrillaVehiculos.Rows[i].Cells["Importe"].Value.ToString();

                    recibo.InsertarDetalle(con, Transaccion, CodRecibo, Auto, "", "", sImporteAuto, Orden);
                    Orden = Orden + 1;
                }
            }
            Principal.CodRecibo = CodRecibo;

        }

        private void GuardarBoleto(SqlConnection con, SqlTransaction Transaccion, Int32 CodVenta)
        {
            cReporteBoleto boleto = new cReporteBoleto();
            string Importe = txtTotalVenta.Text;
            boleto.Insertar(con, Transaccion, CodVenta, Importe);
        }
        private string GetSqlClientes()
        {
            string sql = "";
            Int32? CodTipoDoc = null;
            if (cmbDocumento.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmbDocumento.SelectedValue);
            string NroDocumento = txtNroDoc.Text;
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientexNroDoc(CodTipoDoc, NroDocumento);
            Boolean Nuevo = true;
            if (trdo.Rows.Count > 0)
            {
                Nuevo = false;
            }
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Telefono = txtTelefono.Text;
            string Celular = "";
            string Calle = txtCalle.Text;
            string Altura = txtAltura.Text;
            Int32? CodBarrio = null;
            string Observacion = txtObservacion.Text;
            string RutaImagen = txtRutaImagenCliente.Text;
            DateTime? FechaNacimiento = null;
            cFunciones func = new cFunciones();
            if (func.ValidarFecha(txtFechaNacimiento.Text) == true)
            {
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            }
            if (CmbBarrio.SelectedIndex > 0)
                CodBarrio = Convert.ToInt32(CmbBarrio.SelectedValue);

            if (Nuevo == true)
            {
                GrabaClienteNuevo = true;
                sql = cliente.GetSqlInsertarCliente(CodTipoDoc, NroDocumento, Nombre,
                      Apellido, Telefono, Celular, Calle, Altura, CodBarrio, Observacion, RutaImagen, FechaNacimiento);
                txtCodCLiente.Text = cliente.GetMaxCliente().ToString();
            }
            else
            {
                GrabaClienteNuevo = false;
                sql = cliente.GetSqlModificarCliente(Convert.ToInt32(txtCodCLiente.Text), CodTipoDoc, NroDocumento, Nombre,
                      Apellido, Telefono, Celular,
                      Calle, Altura, CodBarrio, Observacion, RutaImagen);
            }
            return sql;
        }

        private string GetSqlGrabaVehiculo()
        {
            string sql = "";
            if (txtPatente2.Text == "")
            {
                MessageBox.Show("Debe ingresar un véhículo como parte de pago para contiuar", Clases.cMensaje.Mensaje());
                return "";
            }

            if (txtDescripcion2.Text == "")
            {
                MessageBox.Show("Debe ingresar un véhículo como parte de pago para contiuar", Clases.cMensaje.Mensaje());
                return "";
            }

            string Patente = "";
            Int32? CodMarca = null;
            string Descripcion = "";
            Int32? Kilometros = null;
            Int32? CodCiudad = null;
            int Propio = 0;
            int Concesion = 0;
            string Observacion = "";
            string Anio = "";
            Double? Importe = 0;
            Int32? CodAnio = null;
            Int32? CodColor = null;

            Patente = txtPatente2.Text;
            if (CmbCiudad2.SelectedIndex > 0)
                CodCiudad = Convert.ToInt32(CmbCiudad2.SelectedValue);

            Descripcion = txtDescripcion2.Text;

            if (txtKms2.Text != "")
                Kilometros = Convert.ToInt32(txtKms2.Text);
            if (CmbMarca2.SelectedIndex > 0)
            {
                CodMarca = Convert.ToInt32(CmbMarca2.SelectedValue);
            }
            Propio = 1;
            Concesion = 0;
            if (txtImporteVehiculoCompra.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                Importe = fun.ToDouble(txtImporteVehiculoCompra.Text);
            }

            if (cmbAnio2.SelectedIndex > 0)
            {
                CodAnio = Convert.ToInt32(cmbAnio2.SelectedValue);
            }

            if (cmbColor2.SelectedIndex > 0)
            {
                CodColor = Convert.ToInt32(cmbColor2.SelectedValue);
            }

            Clases.cAuto auto = new Clases.cAuto();
            Boolean Graba = true;
            if (txtCodAuto2.Text != "")
                Graba = false;
            if (Graba)
            {
                //inserto el auto
                sql = auto.GetSqlAgregarAuto(Patente, CodMarca, Descripcion,
                     Kilometros, CodCiudad, Propio, Concesion, Observacion, Anio, Importe, CodAnio, CodColor);
                return sql;

            }
            else
            {
                sql = auto.GetSqlModificarAuto(Patente, CodMarca, Descripcion,
                      Kilometros, CodCiudad, Propio, Concesion, Observacion, Anio, Importe);
            }

            return sql;
        }

        private string GetSqlVenta()
        {
            string sql = "";
            DateTime Fecha = dpFecha.Value;
            Int32 CodAutoVendido = Convert.ToInt32(txtCodAuto.Text);
            Int32? CodAutoPartePago = null;
            Int32 CodStock = Convert.ToInt32(txtCodStock.Text);
            if (txtCodAuto2.Text != "")
            {
                CodAutoPartePago = Convert.ToInt32(txtCodAuto2.Text);
            }
            double ImporteVenta = 0;
            double ImporteAutoPartePago = 0;
            double ImporteCredito = 0;
            double ImporteEfectivo = 0;
            Int32 CodCliente = 0;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;
            double PrecioSenia = 0;

            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtPrecioVenta.Text != "")
                ImporteVenta = fun.ToDouble(txtPrecioVenta.Text);

            if (txtTotalDocumentos.Text != "")
                ImporteCredito = fun.ToDouble(txtTotalDocumentos.Text);
            
            if (txtEfectivo.Text != "")
                ImporteEfectivo = fun.ToDouble(txtEfectivo.Text);

            if (txtTotalPrenda.Text != "")
                ImportePrenda = fun.ToDouble(txtTotalPrenda.Text);

            if (txtCodCLiente.Text != "")
                CodCliente = Convert.ToInt32(txtCodCLiente.Text);

            if (txtImporteCobranza.Text != "")
                ImporteCobranza = fun.ToDouble(txtImporteCobranza.Text);

            if (txtTotalVehiculoPartePago.Text != "")
                ImporteAutoPartePago = fun.ToDouble(txtTotalVehiculoPartePago.Text);

            if (txtImporteSenia.Text != "")
                PrecioSenia = fun.ToDouble(txtImporteSenia.Text);



            Int32 CodVendedor = Convert.ToInt32(CmbVendedor.SelectedValue);
            //Principal.CodUsuarioLogueado 
            sql = "insert into Venta(Fecha,CodUsuario,CodCliente";
            sql = sql + ",CodAutoVendido,CodAutoPartePago,ImporteVenta,";
            sql = sql + "ImporteAutoPartePago,ImporteCredito,ImporteEfectivo,ImportePrenda,ImporteCobranza,ImporteBanco,CodVendedor,CodStock,PrecioSenia)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Principal.CodUsuarioLogueado.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodAutoVendido.ToString();
            if (CodAutoPartePago == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodAutoPartePago.ToString();
            sql = sql + "," + ImporteVenta.ToString();
            sql = sql + "," + ImporteAutoPartePago.ToString();
            sql = sql + "," + ImporteCredito.ToString();
            sql = sql + "," + ImporteEfectivo.ToString();
            sql = sql + "," + ImportePrenda.ToString();
            sql = sql + "," + ImporteCobranza.ToString();
            sql = sql + "," + ImporteBanco.ToString();
            sql = sql + "," + CodVendedor.ToString();
            sql = sql + "," + CodStock.ToString();
            sql = sql + "," + PrecioSenia.ToString();
            sql = sql + ")";
            return sql;
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            Double PrecioVenta = 0;
            Double Gastos = 0;
            Double TotalVenta = 0;
            if (txtPrecioVenta.Text != "")
            {
                PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                Gastos = CalcularTotaldeGastos();
                TotalVenta = PrecioVenta + Gastos;
                Clases.cFunciones fun = new Clases.cFunciones();
                txtPrecioVenta.Text = fun.FormatoEnteroMiles(PrecioVenta.ToString());
                txtTotalVenta.Text = fun.FormatoEnteroMiles(TotalVenta.ToString());
            }
            //CalcularSubTotal();
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Double Transferencia = 0;
            Transferencia = fun.TotalizarColumna(tbTransferencia, "Importe");
            if (txtEfectivo.Text != "")
            {
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
                Double Efectivo = fun.ToDouble(txtEfectivo.Text);
                Efectivo = Efectivo + Transferencia;
                txtEfectivo.Text = fun.FormatoEnteroMiles(Efectivo.ToString ());

            }
            txtTotalEfectivo.Text = txtEfectivo.Text;
            CalcularSubTotal();
        }

        private void txtImporteVehiculoCompra_Leave(object sender, EventArgs e)
        {
            if (txtImporteVehiculoCompra.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteVehiculoCompra.Text = fun.FormatoEnteroMiles(txtImporteVehiculoCompra.Text);
            }
        }

        private void txtCapital_Leave(object sender, EventArgs e)
        {
            if (txtCapital.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtCapital.Text = fun.FormatoEnteroMiles(txtCapital.Text);
            }
        }

        private void txtImportePrenda_Leave(object sender, EventArgs e)
        {
            if (txtImportePrenda.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImportePrenda.Text = fun.FormatoEnteroMiles(txtImportePrenda.Text);

            }
            else
                txtTotalPrenda.Text = "";
            //CalcularSubTotal();
        }

        private string GetSqlMovimientos(Int32 CodVenta)
        {
            string sql = "";
            string Fecha = dpFecha.Value.ToShortDateString();
            Int32 CodAutoVendido = Convert.ToInt32(txtCodAuto.Text);

            double ImporteAuto = 0;
            double ImporteDocumento = 0;
            double ImporteEfectivo = 0;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;

            Clases.cFunciones fun = new Clases.cFunciones();

            if (txtTotalPrenda.Text != "")
            {
                ImportePrenda = fun.ToDouble(txtTotalPrenda.Text);
            }

            if (txtTotalDocumentos.Text != "")
                ImporteDocumento = fun.ToDouble(txtTotalDocumentos.Text);

            if (txtTotalEfectivo.Text != "")
                ImporteEfectivo = fun.ToDouble(txtTotalEfectivo.Text);

            if (txtTotalPrenda.Text != "")
                ImportePrenda = fun.ToDouble(txtTotalPrenda.Text);


            if (txtTotalVehiculoPartePago.Text != "")
            {
                ImporteAuto = fun.ToDouble(txtTotalVehiculoPartePago.Text);
            }

            if (txtTotalCobranza.Text != "")
            {
                ImporteCobranza = fun.ToDouble(txtTotalCobranza.Text);
            }

            string Descripcion = "VENTA DE AUTO " + txtPatente.Text;

            ImporteDocumento = CalcularTotalCuotas();

            //Principal.CodUsuarioLogueado 
            sql = "insert into Movimiento(Fecha,CodUsuario";
            sql = sql + ",ImporteEfectivo,ImporteDocumento,ImportePrenda,ImporteAuto,CodVenta,ImporteCobranza,ImporteBanco,Descripcion)";
            sql = sql + "values(" + "'" + Fecha + "'";
            sql = sql + "," + Principal.CodUsuarioLogueado.ToString();
            sql = sql + "," + ImporteEfectivo.ToString();
            sql = sql + "," + ImporteDocumento.ToString();
            sql = sql + "," + ImportePrenda.ToString();
            sql = sql + "," + ImporteAuto.ToString();
            sql = sql + "," + CodVenta.ToString();
            sql = sql + "," + ImporteCobranza.ToString();
            sql = sql + "," + ImporteBanco.ToString();
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            return sql;
        }

        private void LimpiarPantalla(Boolean LimpiaPatente)
        {
            txtMontoTarjeta.Text = "";
            tbTarjeta.Clear();
            if (LimpiaPatente == true)
                txtPatente.Text = "";
            txtTotalCheque.Text = "";
            txtCodPreVenta.Text = "";
            GrillaVehiculos.DataSource = null;
            txtCodAuto.Text = "";
            txtCodStock.Text = "";
            cmbMarca.SelectedIndex = 0;
            CmbEntidadPrendaria.SelectedIndex = 0;
            txtDescripcion.Text = "";
            txtObservacion.Text = "";
            if (cmbAnio.SelectedIndex > 0)
            {
                cmbAnio.SelectedIndex = 0;
            }
            txtKms.Text = "";
            txtPrecioVenta.Text = "";
            GetCostos(-1);
            tprenda.Clear();
            txtNroDoc.Text = "";
            txtCodCLiente.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
          
            if (cmbProvincia2.Items.Count > 0)
                cmbProvincia2.SelectedIndex = 0;
            if (CmbProvinciaAuto.Items.Count > 0)
                CmbProvinciaAuto.SelectedIndex = 0;
            if (CmbBarrio.Items.Count > 0)
                CmbBarrio.SelectedIndex = 0;
            txtCalle.Text = "";
            txtAltura.Text = "";
            txtEfectivo.Text = "";
            txtCodAuto2.Text = "";
            txtCodStock2.Text = "";
            CmbMarca2.SelectedIndex = 0;
            txtDescripcion2.Text = "";
            txtKms2.Text = "";
            txtImporteVehiculoCompra.Text = "";
            GetCostos(-1);

            txtImportePrenda.Text = "";
            txtCapital.Text = "";
            txtCuotas.Text = "";
            txtInteres.Text = "";
            GrillaCuotas.DataSource = null;
            txtTotalEfectivo.Text = "";
            txtTotalVehiculoPartePago.Text = "";
            txtTotalDocumentos.Text = "";
            txtTotalPrenda.Text = "";
            GrillaGastos.DataSource = null;
            txtComisionVendedor.Text = "";
            if (CmbVendedor.SelectedIndex > 0)
                CmbVendedor.SelectedIndex = 0;

            txtTotalCobranza.Text = "";
            txtTotalVenta.Text = "";
            txtSubTotal.Text = "";
            GrillaGastosRecepcion.DataSource = null;
            GrillaGastos.DataSource = null;
            txtTotalGastosRecepcion.Text = "";
            txtTotalGasto.Text = "";
            txtImporteGastoRecepcion.Text = "";
            txtImporteGastoTransferencia.Text = "";
            GrillaCheques.DataSource = null;
            txtMotor.Text = "";
            txtChasis.Text = "";
            if (cmbCiudad.SelectedIndex > 0)
                cmbCiudad.SelectedIndex = 0;
            txtExTitular.Text = "";
            GrillaCheques.DataSource = null;
            txtImporteCobranza.Text = "";

            tbCobranza.Rows.Clear();
            tbListaPapeles.Rows.Clear();
            tbTransferencia.Rows.Clear();
            GrillaTransferencia.DataSource = tbTransferencia;
            txtEfectivoPresupuesto.Text = "";
            txtDocumentoPresupuesto.Text = "";
            txtCobranzaPresupuesto.Text = "";
            txtChequePresupuesto.Text = "";
            txtTransferenciaPresupuesto.Text = "";
        }

        private Double CalcularTotalCuotas()
        {
            double TotalCuotas = 0;
            Clases.cFunciones fun = new Clases.cFunciones();
            for (int i = 0; i < GrillaCuotas.Rows.Count - 1; i++)
            {
                TotalCuotas = TotalCuotas + fun.ToDouble(GrillaCuotas.Rows[i].Cells[1].Value.ToString());
            }
            return TotalCuotas;
        }

        private Boolean Validar()
        {
            if (txtCodAuto.Text == "")
            {
                MessageBox.Show("Debe ingresar un auto para vender", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente para continuar", Clases.cMensaje.Mensaje());
                return false;
            }

          

            if (txtNroDoc.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de documento del cliente para continuar", Clases.cMensaje.Mensaje());
                return false;
            }

            Clases.cFunciones fun = new Clases.cFunciones();





            if (txtTotalPrenda.Text != "")
            {
                if (txtTotalPrenda.Text != "0")
                {
                    if (CmbEntidadPrendaria.SelectedIndex < 1)
                    {
                        MessageBox.Show("Debe ingresar una entidad de prenda para continuar para continuar", Clases.cMensaje.Mensaje());
                        return false;
                    }
                }
            }
            if (CmbVendedor.SelectedIndex < 1)
            {
                MessageBox.Show("Debe ingresar un vendedor ", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtTotalVenta.Text == "")
            {
                MessageBox.Show("Debe ingresar un importe de venta para continuar", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtImporteCobranza.Text != "")
            {

            }

            if (txtImporteCheque.Text != "")
                if (txtImporteCheque.Text != "0")
                {
                    if (CmbBanco.SelectedIndex < 1)
                    {
                        MessageBox.Show("Debe seleccionar un banco para continuar", Clases.cMensaje.Mensaje());
                        return false;
                    }

                    if (txtCheque.Text == "")
                    {
                        MessageBox.Show("Debe seleccionar un cheque para continuar", Clases.cMensaje.Mensaje());
                        return false;
                    }
                    //Clases.cFunciones fun = new Clases.cFunciones();
                    if (fun.ValidarFecha(txtFechaVencimiento.Text) == false)
                    {
                        MessageBox.Show("Debe ingresar una fecha de vencimiento", Clases.cMensaje.Mensaje());
                        return false;
                    }
                }



            Clases.cFunciones fun2 = new Clases.cFunciones();
            double Subtotal = 0;
            if (txtTotalEfectivo.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtTotalEfectivo.Text);

            if (txtTotalVehiculoPartePago.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtTotalVehiculoPartePago.Text);

            if (txtTotalDocumentos.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtTotalDocumentos.Text);

            if (txtTotalPrenda.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtTotalPrenda.Text);



            if (txtTotalCobranza.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtTotalCobranza.Text);

            if (txtTotalCheque.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtTotalCheque.Text);

            if (txtMontoTarjeta.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtMontoTarjeta.Text);

            if (txtImporteSenia.Text != "")
                Subtotal = Subtotal + fun2.ToDouble(txtImporteSenia.Text);
            double Total = fun2.ToDouble(txtTotalVenta.Text);

            if (Subtotal != Total)
            {
                MessageBox.Show("No coinciden los subtatotales con el importe de la venta", Clases.cMensaje.Mensaje());
                return false;
            }


            return true;
        }

        private void btnBorrarCuotas_Click(object sender, EventArgs e)
        {
            GrillaCuotas.DataSource = null;
            txtCapital.Text = "";
            txtCuotas.Text = "";
            txtInteres.Text = "";
            txtTotalDocumentos.Text = "";
        }

        private void txtImporteCobranza_Leave(object sender, EventArgs e)
        {
            if (txtImporteCobranza.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteCobranza.Text = fun.FormatoEnteroMiles(txtImporteCobranza.Text);
            }
            CalcularSubTotal();
        }

        private void txtImporteCobranza_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            FrmAnularVenta frm = new FrmAnularVenta();
            frm.ShowDialog();
        }

        private void txtImporteBanco_Leave(object sender, EventArgs e)
        {

        }



        private void txtPatente_Leave(object sender, EventArgs e)
        {
            txtPatente.Text = txtPatente.Text.ToUpper();
        }

        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            SigueCiudad = 1;
            Principal.CampoIdSecundario = "CodCiudad";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Ciudad";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {   //

            if (Principal.CampoIdSecundarioGenerado != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Ciudad":
                        if (SigueCiudad == 1)
                        {
                            fun.LlenarCombo(cmbCiudad, "Ciudad", "Nombre", "CodCiudad");
                            cmbCiudad.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }
                        if (SigueCiudad == 2)
                        {
                            Int32 CodCiudad = Convert.ToInt32(Principal.CampoIdSecundarioGenerado);
                            Int32 CodProvincia = Convert.ToInt32(CmbProvinciaAuto.SelectedValue);
                            cCiudad city = new Clases.cCiudad();
                            city.ActualizarProvincia(CodCiudad, CodProvincia);
                            DataTable tbCiudad = city.GetCiudadxCodProvincia(CodProvincia);
                            fun.LlenarComboDatatable(CmbCiudad2, tbCiudad, "Nombre", "CodCiudad");
                            CmbCiudad2.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }
                        if (SigueCiudad == 3)
                        {
                            Int32 CodCiudad = Convert.ToInt32(Principal.CampoIdSecundarioGenerado);
                            Int32 CodProvincia = Convert.ToInt32(cmbProvincia2.SelectedValue);
                            cCiudad city = new Clases.cCiudad();
                            city.ActualizarProvincia(CodCiudad, CodProvincia);
                            DataTable tbCiudad = city.GetCiudadxCodProvincia(CodProvincia);
                            fun.LlenarComboDatatable(CmbCiudadCliente2, tbCiudad, "Nombre", "CodCiudad");
                            CmbCiudadCliente2.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }
                        break;
                    case "Barrio":
                        if (SigueBarrio == 2)
                        {
                            Int32 CodCity = Convert.ToInt32(CmbCiudadCliente2.SelectedValue);
                            Int32 CodBarrio = Convert.ToInt32(Principal.CampoIdSecundarioGenerado);
                            cBarrio obj = new cBarrio();
                            obj.ActualizarCiudad(CodBarrio, CodCity);
                            DataTable tbBarrio = obj.GetBarrioxCiudad(CodCity);
                            fun.LlenarComboDatatable(CmbBarrio, tbBarrio, "Nombre", "CodBarrio");
                            // fun.LlenarCombo(CmbBarrio, "Barrio", "Nombre", "CodBarrio");
                            CmbBarrio.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }
                        break;
                    case "Marca":
                        if (SigueMarca == 1)
                        {
                            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
                            cmbMarca.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }

                        if (SigueMarca == 2)
                        {
                            fun.LlenarCombo(CmbMarca2, "Marca", "Nombre", "CodMarca");
                            CmbMarca2.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }

                        break;
                    case "Marca2":
                        fun.LlenarCombo(CmbMarca2, "Marca", "Nombre", "CodMarca");
                        CmbMarca2.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "EntidadPrendaria":
                        fun.LlenarCombo(CmbEntidadPrendaria, "EntidadPrendaria", "Descripcion", "CodEntidad");
                        CmbEntidadPrendaria.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "Tarjeta":
                        fun.LlenarCombo(cmbTarjeta, "Tarjeta", "Nombre", "CodTarjeta");
                        cmbTarjeta.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "CategoriaGastoRecepcion":
                        fun.LlenarCombo(CmbGastoRecepcion, "CategoriaGastoRecepcion", "Descripcion", "Codigo");
                        CmbGastoRecepcion.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "CategoriaGastoTransferencia":
                        fun.LlenarCombo(CmbGastosTransferencia, "CategoriaGastoTransferencia", "Descripcion", "Codigo");
                        CmbGastosTransferencia.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "Banco":
                        fun.LlenarCombo(CmbBanco, "Banco", "Nombre", "CodBanco");
                        CmbBanco.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                    case "PreVenta":
                        if (Principal.CodigoSenia != null)
                            if (Principal.CodigoSenia != "")
                            {
                                BuscarPreVenta(Convert.ToInt32(Principal.CodigoSenia));
                            }
                        break;
                    case "Provincia":
                        if (Principal.CodigoPrincipalAbm == "1")
                        {
                            fun.LlenarCombo(CmbProvinciaAuto, "Provincia", "Nombre", "CodProvincia");
                            CmbProvinciaAuto.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }

                        if (Principal.CodigoPrincipalAbm == "2")
                        {
                            fun.LlenarCombo(cmbProvincia2, "Provincia", "Nombre", "CodProvincia");
                            cmbProvincia2.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        }
                        break;
                    case "Papeles":
                        cPapeles papel = new cPapeles();
                        DataTable tbPapeles = papel.GetPapeles();
                        ListaPapeles.DataSource = tbPapeles;
                        ListaPapeles.DisplayMember = "Nombre";
                        ListaPapeles.ValueMember = "CodPapel";
                        break;

                    case "tipofinanciacion":
                        string sql = "select * from tipofinanciacion ";
                        DataTable tb = cDb.ExecuteDataTable(sql);
                        fun.LlenarComboDatatable(cmbFinanciacion, tb, "Nombre", "CodTipo");
                        cmbFinanciacion.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SigueMarca = 1;
            Principal.CampoIdSecundario = "CodMarca";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Marca";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnNuevoBarrio_Click(object sender, EventArgs e)
        {
            if (CmbCiudadCliente2.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una ciudad");
                return;
            }
            SigueBarrio = 2;
            Principal.CampoIdSecundario = "CodBarrio";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Barrio";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void BtnAgregarMarca2_Click(object sender, EventArgs e)
        {
            SigueMarca = 2;
            Principal.CampoIdSecundario = "CodMarca";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Marca";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnAgregarAuto_Click(object sender, EventArgs e)
        {
            if (txtPatente2.Text == "")
            {
                MessageBox.Show("Debe ingresar una patente para continuar ", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtDescripcion2.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción del vehículo para continuar ", Clases.cMensaje.Mensaje());
                return;
            }

            if (CmbMarca2.SelectedIndex < 1)
            {
                MessageBox.Show("Debe ingresar una marca para continuar.", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtImporteVehiculoCompra.Text == "")
            {
                MessageBox.Show("Debe ingresar una importe de vehículo.", Clases.cMensaje.Mensaje());
                return;
            }
            string Patente = "";
            Int32? CodMarca = null;
            string Descripcion = "";
            Int32? Kilometros = null;
            Int32? CodCiudad = null;
            int Propio = 1;
            int Concesion = 0;
            string Observacion = "";
            string Anio = "";
            Double? Importe = 0;

            Int32 CodAuto = 0;
            string Motor = txtMotor2.Text;
            string Chasis = txtChasis2.Text;


            Patente = txtPatente2.Text;
            if (CmbCiudad2.SelectedIndex > 0)
                CodCiudad = Convert.ToInt32(CmbCiudad2.SelectedValue);

            Descripcion = txtDescripcion2.Text;
            Anio = "";
            if (txtKms2.Text != "")
                Kilometros = Convert.ToInt32(txtKms2.Text.Replace(".", ""));
            if (CmbMarca2.SelectedIndex > 0)
            {
                CodMarca = Convert.ToInt32(CmbMarca2.SelectedValue);
            }


            if (txtImporteVehiculoCompra.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                Importe = fun.ToDouble(txtImporteVehiculoCompra.Text);
            }

            Int32? CodAnio = null;
            if (cmbAnio2.SelectedIndex > 0)
            {
                CodAnio = Convert.ToInt32(cmbAnio2.SelectedValue);
            }

            Int32? CodTipoCombustible2 = null;
            if (CmbTipoCombustible2.SelectedIndex > 0)
                CodTipoCombustible2 = Convert.ToInt32(CmbTipoCombustible2.SelectedValue);

            string Color = "";
            Clases.cAuto auto = new Clases.cAuto();
            Boolean Graba = true;
            if (txtCodAuto2.Text != "")
                Graba = false;
            if (Graba)
            {
                //inserto el auto
                auto.AgregarAuto(Patente, CodMarca, Descripcion,
                    Kilometros, CodCiudad, Propio, Concesion, Observacion, Anio, Importe, Motor, Chasis, Color, CodTipoCombustible2, CodAnio);
                CodAuto = auto.GetMaxCodAuto();
                txtCodAuto2.Text = CodAuto.ToString();

            }
            else
            {
                cStockAuto sta = new Clases.cStockAuto();
                auto.ModificarAuto(Patente, CodMarca, Descripcion,
                    Kilometros, CodCiudad, Propio, Concesion, Observacion, Anio, Importe, Motor, Chasis, Color);

            }

            AgregarAutoGrilla(Convert.ToInt32(txtCodAuto2.Text), 1, 0);
            CalcularTotalAutosPartePago();
            CalcularSubTotal();
        }

        private void AgregarAutoGrilla(Int32 CodAuto, int muestraMensaje, Int32 CodStock)
        {
            for (int i = 0; i < GrillaVehiculos.Rows.Count - 1; i++)
            {
                if (GrillaVehiculos.Rows[i].Cells[0].Value.ToString() == CodAuto.ToString())
                {
                    MessageBox.Show("El vehículo ya se ha ingresado", Clases.cMensaje.Mensaje());
                    return;
                }
            }
            string sCodAuto = "";
            string Descripcion = "";
            string Patente = "";
            string Marca = "";
            string Importe = "0";
            string sCodStock = "";

            DataTable tListado = new DataTable();
            tListado.Columns.Add("CodAuto");
            tListado.Columns.Add("Patente");
            tListado.Columns.Add("Descripcion");
            tListado.Columns.Add("Marca");
            tListado.Columns.Add("Importe");
            tListado.Columns.Add("CodStock");

            for (int i = 0; i < GrillaVehiculos.Rows.Count - 1; i++)
            {
                sCodAuto = GrillaVehiculos.Rows[i].Cells[0].Value.ToString();
                Patente = GrillaVehiculos.Rows[i].Cells[1].Value.ToString();
                Descripcion = GrillaVehiculos.Rows[i].Cells[2].Value.ToString();
                Marca = GrillaVehiculos.Rows[i].Cells[3].Value.ToString();
                Importe = GrillaVehiculos.Rows[i].Cells[4].Value.ToString();
                sCodStock = GrillaVehiculos.Rows[i].Cells[5].Value.ToString();

                DataRow r;
                r = tListado.NewRow();
                r[0] = sCodAuto;
                r[1] = Patente;
                r[2] = Descripcion;
                r[3] = Marca;
                r[4] = Importe;
                r[5] = sCodStock;
                tListado.Rows.Add(r);
            }
            //agregamos el aute ingresado
            Clases.cAuto objAuto = new Clases.cAuto();
            DataTable tauto = objAuto.GetAutoxCodigo(CodAuto);
            if (tauto.Rows.Count > 0)
            {
                Descripcion = tauto.Rows[0]["Descripcion"].ToString();
                Marca = tauto.Rows[0]["Marca"].ToString();
                Patente = tauto.Rows[0]["Patente"].ToString();
            }

            Importe = txtImporteVehiculoCompra.Text;
            DataRow r1;
            r1 = tListado.NewRow();
            r1[0] = CodAuto.ToString();
            r1[1] = Patente;
            r1[2] = Descripcion;
            r1[3] = Marca;
            r1[4] = Importe;
            r1[5] = CodStock.ToString();

            tListado.Rows.Add(r1);
            GrillaVehiculos.DataSource = tListado;
            if (muestraMensaje == 1)
                MessageBox.Show("Datos agregados correctamete", Clases.cMensaje.Mensaje());
            txtPatente2.Text = "";
            txtDescripcion2.Text = "";
            txtKms2.Text = "";
            txtCodAuto2.Text = "";
            txtKms2.Text = "";

            if (CmbCiudad2.Items.Count > 0)
            {
                CmbCiudad2.SelectedIndex = 0;
            }
            txtImporteVehiculoCompra.Text = "";
            CmbMarca2.SelectedIndex = 0;
            GrillaVehiculos.Columns[0].Visible = false;
            GrillaVehiculos.Columns[1].Width = 100;
            GrillaVehiculos.Columns[2].Width = 240;
            GrillaVehiculos.Columns[3].Width = 235;
            GrillaVehiculos.Columns[4].Width = 150;

        }

        private void txtPatente2_TextChanged_1(object sender, EventArgs e)
        {
            int b = 0;
            string Patente = txtPatente2.Text;
            if (Patente.Length > 5)
            {
                Clases.cAuto auto = new Clases.cAuto();
                DataTable trdo = auto.GetAutoxPatente(Patente);
                if (trdo.Rows.Count > 0)
                {
                    b = 1;
                    txtDescripcion2.Text = trdo.Rows[0]["Descripcion"].ToString();
                    if (trdo.Rows[0]["CodAnio"].ToString() != "")
                    {
                        cmbAnio2.SelectedValue = trdo.Rows[0]["CodAnio"].ToString();
                    }

                    txtKms2.Text = trdo.Rows[0]["Kilometros"].ToString();
                    txtCodAuto2.Text = trdo.Rows[0]["CodAuto"].ToString();
                    txtMotor2.Text = trdo.Rows[0]["Motor"].ToString();
                    txtChasis2.Text = trdo.Rows[0]["Chasis"].ToString();
                    if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                    {
                        CmbCiudad2.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                    }

                    if (trdo.Rows[0]["CodMarca"].ToString() != "")
                    {
                        CmbMarca2.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                    }

                    if (trdo.Rows[0]["CodColor"].ToString() != "")
                    {
                        cmbColor2.SelectedValue = trdo.Rows[0]["CodColor"].ToString();
                    }

                    if (trdo.Rows[0]["CodAnio"].ToString() != "")
                    {
                        cmbAnio2.SelectedValue = trdo.Rows[0]["CodAnio"].ToString();
                    }

                    Clases.cStockAuto stock = new Clases.cStockAuto();
                    DataTable trdo2 = stock.GetStockAutosVigentes(Convert.ToInt32(txtCodAuto2.Text));
                    if (trdo2.Rows.Count > 0)
                    {
                        txtCodStock2.Text = trdo2.Rows[0]["CodStock"].ToString();
                        if (Principal.CodigoPrincipalAbm == null)
                        {
                            MessageBox.Show("El vehículo ya existe como stock", Clases.cMensaje.Mensaje());
                            LimpiarAuto2();
                            txtPatente2.Text = "";
                        }

                    }
                }
                else
                {
                    txtDescripcion2.Text = "";
                    CmbMarca2.SelectedIndex = 0;
                    txtKms2.Text = "";

                    CmbCiudad2.SelectedIndex = 0;
                    txtImporteVehiculoCompra.Text = "";
                }
            }





        }

        private void txtImporteVehiculoCompra_Leave_1(object sender, EventArgs e)
        {
            if (txtImporteVehiculoCompra.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteVehiculoCompra.Text = fun.FormatoEnteroMiles(txtImporteVehiculoCompra.Text);
            }
        }

        private void btnEliminarAuto_Click(object sender, EventArgs e)
        {
            if (GrillaVehiculos.Rows.Count < 2)
                return;

            string CodAutoBorrar = GrillaVehiculos.CurrentRow.Cells[0].Value.ToString();

            string Lista = "CodAuto;Descripcion;Marca;Importe";
            Clases.cFunciones fun = new Clases.cFunciones();
            DataTable trdo = fun.CrearTabla(Lista);
            string ListaValores = "";

            for (int i = 0; i < GrillaVehiculos.Rows.Count - 1; i++)
            {
                string CodAuto = GrillaVehiculos.Rows[i].Cells[0].Value.ToString();
                string Descripcion = GrillaVehiculos.Rows[i].Cells[1].Value.ToString();
                string Marca = GrillaVehiculos.Rows[i].Cells[2].Value.ToString();
                string Importe = GrillaVehiculos.Rows[i].Cells[3].Value.ToString();
                ListaValores = CodAuto + ";" + Descripcion + ";" + Marca + ";" + Importe;
                trdo = fun.AgregarFilas(trdo, ListaValores);
            }

            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                if (trdo.Rows[i]["CodAuto"].ToString() == CodAutoBorrar)
                {
                    trdo.Rows[i].Delete();
                    i = 0;
                }
            }
            GrillaVehiculos.DataSource = trdo;
            CalcularTotalAutosPartePago();
        }

        private void CalcularTotalAutosPartePago()
        {
            string sImporte = "";
            Clases.cFunciones fun = new Clases.cFunciones();
            double Importe = 0;
            //Importe = fun.ToDouble(txtImporteVehiculoCompra.Text);
            for (int i = 0; i < GrillaVehiculos.Rows.Count - 1; i++)
            {
                sImporte = GrillaVehiculos.Rows[i].Cells[4].Value.ToString();
                Importe = Importe + fun.ToDouble(sImporte);
            }
            txtTotalVehiculoPartePago.Text = fun.FormatoEnteroMiles(Importe.ToString());
        }

        private void txtEfectivo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEntidadPrendaria_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodEntidad";
            Principal.CampoNombreSecundario = "Descripcion";
            Principal.NombreTablaSecundario = "EntidadPrendaria";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private string GetSqlPrenda(Int32 CodVenta)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            string CodEntidad = CmbEntidadPrendaria.SelectedValue.ToString();
            string CodCliente = txtCodCLiente.Text;
            double Importe = fun.ToDouble(txtTotalPrenda.Text);
            string sql = "Insert into Prenda(CodVenta,Importe,CodCliente,CodEntidad,Fecha,CodAuto,Saldo,Diferencia)";
            sql = sql + "Values (" + CodVenta.ToString();
            sql = sql + "," + Importe.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodEntidad.ToString();
            sql = sql + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
            sql = sql + "," + txtCodAuto.Text.ToString();
            sql = sql + "," + Importe.ToString();
            sql = sql + ",0";
            sql = sql + ")";
            return sql;
        }

        private void CalcularSubTotal()
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            double Subtotal = 0;

            if (txtTotalEfectivo.Text != "")
                Subtotal = Subtotal + fun.ToDouble(txtTotalEfectivo.Text);

            if (txtTotalVehiculoPartePago.Text != "")
                Subtotal = Subtotal + fun.ToDouble(txtTotalVehiculoPartePago.Text);

            if (txtTotalDocumentos.Text != "")
                Subtotal = Subtotal + fun.ToDouble(txtTotalDocumentos.Text);

            if (txtTotalPrenda.Text != "")
                Subtotal = Subtotal + fun.ToDouble(txtTotalPrenda.Text);



            // if (txtTotalGasto.Text != "")
            //     Subtotal = Subtotal + fun.ToDouble(txtTotalGasto.Text);

            if (txtTotalCobranza.Text != "")
                Subtotal = Subtotal + fun.ToDouble(txtTotalCobranza.Text);

            if (txtImporteSenia.Text != "")
                Subtotal = Subtotal + fun.ToDouble(txtImporteSenia.Text);

            if (txtTotalCheque.Text != "")
            {
                if (txtTotalCheque.Text != "")
                    Subtotal = Subtotal + fun.ToDouble(txtTotalCheque.Text);
            }

            if (txtMontoTarjeta.Text != "")
            {
                Subtotal = Subtotal + fun.ToDouble(txtMontoTarjeta.Text);
            }

            if (txtEfectivoPresupuesto.Text != "")
            {
                Subtotal = Subtotal + fun.ToDouble(txtEfectivoPresupuesto.Text);
            }


            if (txtChequePresupuesto.Text != "")
            {
                Subtotal = Subtotal + fun.ToDouble(txtChequePresupuesto.Text);
            }

            if (txtCobranzaPresupuesto.Text != "")
            {
                Subtotal = Subtotal + fun.ToDouble(txtCobranzaPresupuesto.Text);
            }

            if (txtTransferenciaPresupuesto.Text != "")
            {
                Double TrotalTransf = fun.TotalizarColumna(tbTransferencia, "Importe");
                Subtotal = Subtotal + TrotalTransf;
            }

            if (txtDocumentoPresupuesto.Text != "")
            {
                Subtotal = Subtotal + fun.ToDouble(txtDocumentoPresupuesto.Text);
            }

           

            txtSubTotal.Text = Subtotal.ToString();
            if (txtSubTotal.Text != "")
            {
                txtSubTotal.Text = fun.FormatoEnteroMiles(txtSubTotal.Text);
            }


        }

        private void BtnAgregarMarca2_Click_1(object sender, EventArgs e)
        {
            SigueMarca = 2;
            Principal.CampoIdSecundario = "CodMarca";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Marca";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnAgregarGastoTransferencia_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "Codigo";
            Principal.CampoNombreSecundario = "Descripcion";
            Principal.NombreTablaSecundario = "CategoriaGastoTransferencia";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnAgegarGastodeRecepcion_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "Codigo";
            Principal.CampoNombreSecundario = "Descripcion";
            Principal.NombreTablaSecundario = "CategoriaGastoRecepcion";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void bnAgegargastoTranasferencia_Click(object sender, EventArgs e)
        {
            if (CmbGastosTransferencia.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una categoria de gasto de transferencia ", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtImporteGastoTransferencia.Text == "")
            {
                MessageBox.Show("Debe ingresar un importe de gasto de transferencia ", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cGasto gasto = new Clases.cGasto();
            string Descripcion = gasto.GetNombreGastoTransferenciaxCodigo(Convert.ToInt32(CmbGastosTransferencia.SelectedValue));
            AgregarGasto(CmbGastosTransferencia.SelectedValue.ToString(), Descripcion, txtImporteGastoTransferencia.Text, "Transferencia");


        }

        private void AgregarGasto(string Codigo, string Descripcion, string Importe, string Tipo)
        {
            for (int i = 0; i < GrillaGastos.Rows.Count - 1; i++)
            {
                if (GrillaGastos.Rows[i].Cells[0].Value.ToString() == Codigo.ToString() && GrillaGastos.Rows[i].Cells[2].Value.ToString() == Tipo)
                {
                    MessageBox.Show("Ya se ha ingresado el gasto", Clases.cMensaje.Mensaje());
                    return;
                }
            }
            DataTable tListado = new DataTable();
            tListado.Columns.Add("Codigo");
            tListado.Columns.Add("Descripcion");
            tListado.Columns.Add("Tipo");
            tListado.Columns.Add("Importe");
            for (int i = 0; i < GrillaGastos.Rows.Count - 1; i++)
            {
                string sCodigo = GrillaGastos.Rows[i].Cells[0].Value.ToString();
                string sDescripcion = GrillaGastos.Rows[i].Cells[1].Value.ToString();
                string sTipo = GrillaGastos.Rows[i].Cells[2].Value.ToString();
                string sImporte = GrillaGastos.Rows[i].Cells[3].Value.ToString();
                DataRow r;
                r = tListado.NewRow();
                r[0] = sCodigo;
                r[1] = sDescripcion;
                r[2] = sTipo;
                r[3] = sImporte;
                tListado.Rows.Add(r);
            }
            DataRow r1;
            r1 = tListado.NewRow();
            r1[0] = Codigo;
            r1[1] = Descripcion;
            r1[2] = Tipo;
            r1[3] = Importe;
            tListado.Rows.Add(r1);
            GrillaGastos.DataSource = tListado;
            Clases.cFunciones fun = new Clases.cFunciones();
            txtTotalGasto.Text = fun.CalcularTotalGrilla(GrillaGastos, "Importe").ToString();
            if (txtTotalGasto.Text != "")
            {

                txtTotalGasto.Text = fun.FormatoEnteroMiles(txtTotalGasto.Text);
            }
            GrillaGastos.Columns[0].Visible = false;
            GrillaGastos.Columns[2].Visible = false;
            txtImporteGastoTransferencia.Text = "";
            txtImporteGastoRecepcion.Text = "";
            GrillaGastos.Columns[1].Width = 260;

            txtTotalGastosRecepcion.Text = fun.CalcularTotalGrilla(GrillaGastosRecepcion, "Importe").ToString();
            if (txtTotalGastosRecepcion.Text != "")
            {
                txtTotalGastosRecepcion.Text = fun.FormatoEnteroMiles(txtTotalGastosRecepcion.Text);
            }

            double TotalVenta = 0;
            double PrecioVenta = 0;
            double TotalGastos = 0;
            double TotalGastosRecepcion = 0;

            if (txtTotalVenta.Text != "")
            {
                PrecioVenta = fun.ToDouble(txtPrecioVenta.Text);
            }

            if (txtTotalGasto.Text != "")
            {
                TotalGastos = fun.ToDouble(txtTotalGasto.Text);
            }

            if (txtTotalGastosRecepcion.Text != "")
            {
                TotalGastosRecepcion = fun.ToDouble(txtTotalGastosRecepcion.Text);
            }

            TotalVenta = PrecioVenta + TotalGastos + TotalGastosRecepcion;
            txtTotalVenta.Text = TotalVenta.ToString();
            txtTotalVenta.Text = fun.FormatoEnteroMiles(txtTotalVenta.Text);
            //CalcularSubTotal(); 
        }

        private void AgregarGastoRecepcion(string Codigo, string Descripcion, string Importe, string Tipo, string CodAuto)
        {
            /*  for (int i = 0; i < GrillaGastosRecepcion.Rows.Count - 1; i++)
              {
                  if (GrillaGastosRecepcion.Rows[i].Cells[0].Value.ToString() == Codigo.ToString() && GrillaGastos.Rows[i].Cells[2].Value.ToString() == Tipo)
                  {
                      MessageBox.Show("Ya se ha ingresado el gasto", Clases.cMensaje.Mensaje());
                      return;
                  }
              }
             */
            DataTable tListado = new DataTable();
            tListado.Columns.Add("Codigo");
            tListado.Columns.Add("Descripcion");
            tListado.Columns.Add("Tipo");
            tListado.Columns.Add("Importe");
            tListado.Columns.Add("CodAuto");

            for (int i = 0; i < GrillaGastosRecepcion.Rows.Count - 1; i++)
            {
                string sCodigo = GrillaGastosRecepcion.Rows[i].Cells[0].Value.ToString();
                string sDescripcion = GrillaGastosRecepcion.Rows[i].Cells[1].Value.ToString();
                string sTipo = GrillaGastosRecepcion.Rows[i].Cells[2].Value.ToString();
                string sImporte = GrillaGastosRecepcion.Rows[i].Cells[3].Value.ToString();
                string sCodAuto = GrillaGastosRecepcion.Rows[i].Cells[4].Value.ToString();

                DataRow r;
                r = tListado.NewRow();
                r[0] = sCodigo;
                r[1] = sDescripcion;
                r[2] = sTipo;
                r[3] = sImporte;
                r[4] = sCodAuto.ToString();

                tListado.Rows.Add(r);
            }
            DataRow r1;
            r1 = tListado.NewRow();
            r1[0] = Codigo;
            r1[1] = Descripcion;
            r1[2] = Tipo;
            r1[3] = Importe;
            r1[4] = CodAuto.ToString();

            tListado.Rows.Add(r1);
            GrillaGastosRecepcion.DataSource = tListado;
            Clases.cFunciones fun = new Clases.cFunciones();
            GrillaGastosRecepcion.Columns[0].Visible = false;
            GrillaGastosRecepcion.Columns[2].Visible = false;
            GrillaGastosRecepcion.Columns[4].Visible = false;
            txtImporteGastoTransferencia.Text = "";
            txtImporteGastoRecepcion.Text = "";
            GrillaGastosRecepcion.Columns[1].Width = 250;

            txtTotalGastosRecepcion.Text = fun.CalcularTotalGrilla(GrillaGastosRecepcion, "Importe").ToString();
            if (txtTotalGastosRecepcion.Text != "")
            {
                txtTotalGastosRecepcion.Text = fun.FormatoEnteroMiles(txtTotalGastosRecepcion.Text);
            }

            double TotalVenta = 0;
            double PrecioVenta = 0;
            double TotalGastos = 0;
            double TotalGastosRecepcion = 0;

            if (txtTotalVenta.Text != "")
            {
                PrecioVenta = fun.ToDouble(txtPrecioVenta.Text);
            }

            if (txtTotalGasto.Text != "")
            {
                TotalGastos = fun.ToDouble(txtTotalGasto.Text);
            }

            if (txtTotalGastosRecepcion.Text != "")
            {
                TotalGastosRecepcion = fun.ToDouble(txtTotalGastosRecepcion.Text);
            }

            TotalVenta = PrecioVenta + TotalGastos + TotalGastosRecepcion;
            txtTotalVenta.Text = TotalVenta.ToString();
            txtTotalVenta.Text = fun.FormatoEnteroMiles(txtTotalVenta.Text);
            GrillaGastosRecepcion.Columns[1].Width = 195;
            GrillaGastosRecepcion.Columns[3].Width = 80;
            //CalcularSubTotal();
        }

        private void btnAgregarGastodeRecepcion_Click(object sender, EventArgs e)
        {
            if (GrillaVehiculos.Rows.Count < 2)
            {
                MessageBox.Show("Debe seleccionar un vehículo en parte de pago ", Clases.cMensaje.Mensaje());
                return;
            }

            if (GrillaVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un vehículo en parte de pago ", Clases.cMensaje.Mensaje());
                return;
            }

            string CodAuto = GrillaVehiculos.CurrentRow.Cells[0].Value.ToString();
            if (CodAuto == "")
                return;
            if (CmbGastoRecepcion.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una categoría de gasto de recepción ", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtImporteGastoRecepcion.Text == "")
            {
                MessageBox.Show("Debe ingresar un importe de gasto de recepción ", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cGasto gasto = new Clases.cGasto();
            string Descripcion = gasto.GetNombreGastoRecepcionxCodigo(Convert.ToInt32(CmbGastoRecepcion.SelectedValue));
            AgregarGastoRecepcion(CmbGastoRecepcion.SelectedValue.ToString(), Descripcion, txtImporteGastoRecepcion.Text, "Recepcion", CodAuto);

        }

        private void txtImporteGastoTransferencia_Leave(object sender, EventArgs e)
        {
            if (txtImporteGastoTransferencia.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteGastoTransferencia.Text = fun.FormatoEnteroMiles(txtImporteGastoTransferencia.Text);
            }

        }

        private void txtImporteGastoRecepcion_Leave(object sender, EventArgs e)
        {
            if (txtImporteGastoRecepcion.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteGastoRecepcion.Text = fun.FormatoEnteroMiles(txtImporteGastoRecepcion.Text);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GrillaGastos.Rows.Count < 2)
                return;
            string Codigo = GrillaGastos.CurrentRow.Cells[0].Value.ToString();
            string Tipo = GrillaGastos.CurrentRow.Cells[2].Value.ToString();
            if (Codigo != "")
            {
                Clases.cGrilla.EliminarFilaxdosFiltros(GrillaGastos, "Codigo", Codigo, "Tipo", Tipo);
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            txtTotalGasto.Text = fun.CalcularTotalGrilla(GrillaGastos, "Importe").ToString();
            Double PrecioVenta = 0;
            Double Gastos = 0;
            if (txtPrecioVenta.Text != "")
            {
                PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                Gastos = CalcularTotaldeGastos();
                PrecioVenta = PrecioVenta + Gastos;

                txtTotalVenta.Text = fun.FormatoEnteroMiles(PrecioVenta.ToString());
            }
        }

        private void BtnVerCostoAuto_Click(object sender, EventArgs e)
        {
            if (lblImporteCompra.Visible == false)
            {
                lblImporteCompra.Visible = true;
                txtImporteCompra.Visible = true;
            }
            else
            {
                lblImporteCompra.Visible = false;
                txtImporteCompra.Visible = false;
            }
        }

        private void txtImporteVehiculoCompra_Leave_2(object sender, EventArgs e)
        {
            if (txtImporteVehiculoCompra.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteVehiculoCompra.Text = fun.FormatoEnteroMiles(txtImporteVehiculoCompra.Text);
            }
        }

        private void txtKms2_Leave(object sender, EventArgs e)
        {
            if (txtKms2.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtKms2.Text = fun.FormatoEnteroMiles(txtKms2.Text);
            }
        }

        private void btnEliminarGastoRecepcion_Click(object sender, EventArgs e)
        {
            if (GrillaGastosRecepcion.Rows.Count < 2)
                return;
            if (GrillaGastosRecepcion.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un gasto de recepción");
                return;
            }
            string Codigo = GrillaGastosRecepcion.CurrentRow.Cells[0].Value.ToString();
            string Tipo = GrillaGastosRecepcion.CurrentRow.Cells[2].Value.ToString();
            if (Codigo != "")
            {
                Clases.cGrilla.EliminarFilaxdosFiltros(GrillaGastosRecepcion, "Codigo", Codigo, "Tipo", Tipo);
            }
            Clases.cFunciones fun = new Clases.cFunciones();

            txtTotalGastosRecepcion.Text = fun.CalcularTotalGrilla(GrillaGastosRecepcion, "Importe").ToString();
            if (txtTotalGastosRecepcion.Text != "")
            {
                txtTotalGastosRecepcion.Text = fun.FormatoEnteroMiles(txtTotalGastosRecepcion.Text);
            }

            double TotalVenta = 0;
            double PrecioVenta = 0;
            double TotalGastos = 0;
            double TotalGastosRecepcion = 0;

            if (txtTotalVenta.Text != "")
            {
                PrecioVenta = fun.ToDouble(txtPrecioVenta.Text);
            }

            if (txtTotalGasto.Text != "")
            {
                TotalGastos = fun.ToDouble(txtTotalGasto.Text);
            }

            if (txtTotalGastosRecepcion.Text != "")
            {
                TotalGastosRecepcion = fun.ToDouble(txtTotalGastosRecepcion.Text);
            }

            TotalVenta = PrecioVenta + TotalGastos + TotalGastosRecepcion;
            txtTotalVenta.Text = TotalVenta.ToString();
            txtTotalVenta.Text = fun.FormatoEnteroMiles(txtTotalVenta.Text);
            //CalcularSubTotal();
        }

        private Double CalcularTotaldeGastos()
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Double GastosTransferencia = 0;
            GastosTransferencia = fun.CalcularTotalGrilla(GrillaGastos, "Importe");
            Double GastosRecepcion = 0;
            GastosRecepcion = fun.CalcularTotalGrilla(GrillaGastosRecepcion, "Importe");
            return (GastosTransferencia + GastosRecepcion);
        }

        private void txtImporteGastoRecepcion_Leave_1(object sender, EventArgs e)
        {
            if (txtImporteGastoRecepcion.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteGastoRecepcion.Text = fun.FormatoEnteroMiles(txtImporteGastoRecepcion.Text);
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {

        }

        private void txtImporteCheque_Leave(object sender, EventArgs e)
        {
            if (txtImporteCheque.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteCheque.Text = fun.FormatoEnteroMiles(txtImporteCheque.Text);
            }
            // txtTotalCheque.Text = txtImporteCheque.Text;

        }

        private void btnAgregarRadicacion_Click(object sender, EventArgs e)
        {
            SigueCiudad = 2;
            Principal.CampoIdSecundario = "CodCiudad";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Ciudad";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void CargarVendedor()
        {
            Clases.cVendedor ven = new Clases.cVendedor();
            DataTable tvend = ven.GetVendedores();
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(CmbVendedor, tvend, "Apellido", "CodVendedor");
        }

        private void btnGrabarVendedor_Click(object sender, EventArgs e)
        {
            if (txtNombreVen.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre de vendedor", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtApellidoVend.Text == "")
            {
                MessageBox.Show("Debe ingresar un apellido de vendedor", Clases.cMensaje.Mensaje());
                return;
            }
            string Ape = txtApellidoVend.Text.ToUpper();
            string Nom = txtNombreVen.Text.ToUpper();
            Clases.cVendedor ven = new Clases.cVendedor();
            ven.GrabarVendedor(Ape, Nom);
            Int32 CodVendedor = ven.GetMaxCodVendedor();
            CargarVendedor();
            CmbVendedor.SelectedValue = CodVendedor.ToString();
            OcultarVendedor(false);
        }

        private void OcultarVendedor(Boolean Op)
        {
            lblNombreVendedor.Visible = Op;
            lblApellidoVendedor.Visible = Op;
            txtNombreVen.Visible = Op;
            txtApellidoVend.Visible = Op;
            btnGrabarVendedor.Visible = Op;
            btnCancelarVendedor.Visible = Op;
        }

        private void btnCancelarVendedor_Click(object sender, EventArgs e)
        {
            OcultarVendedor(false);
        }

        private void btnAgregarVendedor_Click(object sender, EventArgs e)
        {
            OcultarVendedor(true);
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
            if (fun.ValidarFecha(txtFechaVencimiento.Text) == false)
            {
                MessageBox.Show("Debe ingresr una fecha de vencimiento para continuar", Clases.cMensaje.Mensaje());
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
                r[4] = sBanco;
                tbCheques.Rows.Add(r);
            }
            Clases.cBanco objBanco = new Clases.cBanco();
            string banco = objBanco.GetBancoxCodigo(Convert.ToInt32(CmbBanco.SelectedValue));
            DataRow r1 = tbCheques.NewRow();
            r1[0] = txtCheque.Text;
            r1[1] = txtImporteCheque.Text;
            r1[2] = txtFechaVencimiento.Text;
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
            txtFechaVencimiento.Text = "";
            double TotalCheques = 0;
            for (i = 0; i < tbCheques.Rows.Count; i++)
            {
                TotalCheques = TotalCheques + fun.ToDouble(tbCheques.Rows[i][1].ToString());
            }
            txtTotalCheque.Text = TotalCheques.ToString();
            //Clases.cFunciones fun = new Clases.cFunciones();
            txtTotalCheque.Text = fun.FormatoEnteroMiles(txtTotalCheque.Text);
            CalcularSubTotal();
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

        private string GetSqlMovimientosAutoVendido(Int32 CodVenta, double GastosTotales)
        {
            string sql = "";
            string Fecha = DateTime.Now.ToShortDateString();
            Int32 CodAutoVendido = Convert.ToInt32(txtCodAuto.Text);

            double ImporteAuto = 0;
            double ImporteDocumento = 0;
            double ImporteEfectivo = 0;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;

            Clases.cFunciones fun = new Clases.cFunciones();
            string Descripcion = "VENTA DE AUTO " + txtPatente.Text;

            ImporteAuto = -1 * GastosTotales;

            //Principal.CodUsuarioLogueado 
            sql = "insert into Movimiento(Fecha,CodUsuario";
            sql = sql + ",ImporteEfectivo,ImporteDocumento,ImportePrenda,ImporteAuto,CodVenta,ImporteCobranza,ImporteBanco,Descripcion)";
            sql = sql + "values(" + "'" + Fecha + "'";
            sql = sql + "," + Principal.CodUsuarioLogueado.ToString();
            sql = sql + "," + ImporteEfectivo.ToString();
            sql = sql + "," + ImporteDocumento.ToString();
            sql = sql + "," + ImportePrenda.ToString();
            sql = sql + "," + ImporteAuto.ToString();
            sql = sql + "," + CodVenta.ToString();
            sql = sql + "," + ImporteCobranza.ToString();
            sql = sql + "," + ImporteBanco.ToString();
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            return sql;
        }

        private void CargarGastosGeneralesxCodStoxk(Int32 CodStock)
        {
            double Total = 0;
            DataTable tGastos = new DataTable();
            tGastos.Columns.Add("CodGasto");
            tGastos.Columns.Add("Descripcion");
            tGastos.Columns.Add("Fecha");
            tGastos.Columns.Add("Importe");

            Clases.cGasto gasto = new Clases.cGasto();
            Clases.cGastosPagar GastosPagar = new Clases.cGastosPagar();
            DataTable trdo = gasto.GetGastosxCodStock(CodStock);
            //  DataTable trdo = GastosPagar.GetGastosPagarxCodStock(CodStock);
            int i = 0;

            for (i = 0; i < trdo.Rows.Count; i++)
            {
                string sImporte = trdo.Rows[i]["Importe"].ToString();
                if (sImporte != "")
                    Total = Total + Convert.ToDouble(sImporte);
                string sFecha = trdo.Rows[i]["Fecha"].ToString();
                string sDescripcion = trdo.Rows[i]["Nombre"].ToString();
                DataRow r = tGastos.NewRow();
                r["CodGasto"] = trdo.Rows[i]["CodCategoriaGasto"].ToString();
                r["Descripcion"] = sDescripcion;
                r["Fecha"] = sFecha;
                r["Importe"] = sImporte;
                tGastos.Rows.Add(r);

            }

            //   DataTable trdo2 = gasto.GetGastosRecepcionxCodStock(CodStock);

            /*   for (i = 0; i < trdo2.Rows.Count; i++)
               {
                   string sImporte = trdo2.Rows[i]["Importe"].ToString();
                   if (sImporte !="")
                       Total = Total + Convert.ToDouble (sImporte);
                   string sFecha = trdo2.Rows[i]["Fecha"].ToString();
                   string sDescripcion = trdo2.Rows[i]["Descripcion"].ToString();
                   DataRow r = tGastos.NewRow();
                   r["Descripcion"] = sDescripcion;
                   r["Fecha"] = sFecha;
                   r["Importe"] = sImporte;
                   tGastos.Rows.Add(r);
                
               }
             * */
            Clases.cFunciones fun2 = new Clases.cFunciones();
            tGastos = fun2.TablaaMiles(tGastos, "Importe");
            GrillaGastosGenerales.DataSource = tGastos;
            GrillaGastosGenerales.Columns[0].Width = 200;
            GrillaGastosGenerales.Columns[2].Width = 160;
            GrillaGastosGenerales.Columns[0].Visible = false;
            /*    if (b == 1)
                {
                    GrillaGastosGenerales.DataSource = tGastos;
                    GrillaGastosGenerales.Columns[0].Width = 200; 
                }
                
                else
                    GrillaGastosGenerales.DataSource = null;*/
            txtResumenGastos.Text = Total.ToString();
            Clases.cFunciones fun = new Clases.cFunciones();
            txtResumenGastos.Text = fun.FormatoEnteroMiles(txtResumenGastos.Text);


            txtImporteCompra.Text = TotalGastosxPatente(txtPatente.Text, CodStock).ToString();
            if (txtImporteCompra.Text != "")
                txtImporteCompra.Text = fun.FormatoEnteroMiles(txtImporteCompra.Text);
        }

        private double TotalGastosxPatente(string Patente, Int32 CodStock)
        {
            double Importe = 0;
            Clases.cStockAuto stock = new Clases.cStockAuto();
            DataTable trdo = stock.GetDetallexCodStock(Patente, CodStock);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["Costo"].ToString() != "")
                    Importe = Convert.ToDouble(trdo.Rows[0]["Costo"].ToString());
            return Importe;
        }

        private void BuscarVenta(Int32 CodVenta)
        {
            txtCodPreVenta.Text = CodVenta.ToString();
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cVenta objVenta = new Clases.cVenta();
            DataTable tVenta = objVenta.GetVentaxCodigo(CodVenta);
            if (tVenta.Rows.Count > 0)
            {
                DateTime FechaVenta = Convert.ToDateTime(tVenta.Rows[0]["Fecha"].ToString());
                dpFecha.Value = FechaVenta;
                txtCodStock.Text = tVenta.Rows[0]["CodStock"].ToString();
                txtPrecioVenta.Text = tVenta.Rows[0]["ImporteVenta"].ToString();
                string sImp = txtPrecioVenta.Text.Replace(",", ".");
                string[] vec = sImp.Split('.');
                txtPrecioVenta.Text = fun.FormatoEnteroMiles(vec[0]);
                if (tVenta.Rows[0]["CodVendedor"].ToString() != "")
                    CmbVendedor.SelectedValue = tVenta.Rows[0]["CodVendedor"].ToString();
                BuscarClientexCodigo(Convert.ToInt32(tVenta.Rows[0]["CodCliente"].ToString()));
                BuscarGastosTransferencia(CodVenta);
                BuscarAutoxCodVenta(CodVenta);
                BuscarChequesxCodVenta(CodVenta);
                CargarImpuestos(CodVenta);
                GetGastosdeRecepcionxCodVenta(CodVenta);
                string Patente = tVenta.Rows[0]["Patente"].ToString();
                txtPatente.Text = Patente;
               // BuscarAutoxPatente(Patente);
                if (tVenta.Rows[0]["CodAutoVendido"].ToString()!="")
                {
                    Int32 CodAuto = Convert.ToInt32 (tVenta.Rows[0]["CodAutoVendido"].ToString());
                    BuscarAutoxCodigo(CodAuto);
                }
                BuscarCuotasxCodVenta(CodVenta);
                BuscarPrenda(CodVenta);
                //if (tVenta.Rows[0]["CodEntidad"].ToString() != "")
                //CmbEntidadPrendaria.SelectedValue = tVenta.Rows[0]["CodEntidad"].ToString();
                if (tVenta.Rows[0]["ImporteEfectivo"].ToString() != "")
                {
                    string sImporte = tVenta.Rows[0]["ImporteEfectivo"].ToString().Replace(",", ".");
                    vec = sImporte.Split('.');
                    txtEfectivo.Text = fun.FormatoEnteroMiles(vec[0]);
                    txtTotalEfectivo.Text = txtEfectivo.Text;
                }
                else
                    txtEfectivo.Text = tVenta.Rows[0]["ImporteEfectivo"].ToString();

                if (tVenta.Rows[0]["ImporteAutoPartePago"].ToString() != "")
                {
                    string sImporte = tVenta.Rows[0]["ImporteAutoPartePago"].ToString().Replace(",", ".");
                    vec = sImporte.Split('.');
                    txtTotalVehiculoPartePago.Text = fun.FormatoEnteroMiles(vec[0]);
                }
                else
                    txtTotalVehiculoPartePago.Text = tVenta.Rows[0]["ImporteAutoPartePago"].ToString();

                if (tVenta.Rows[0]["ImportePrenda"].ToString() != "")
                {
                    string sImporte = tVenta.Rows[0]["ImportePrenda"].ToString().Replace(",", ".");
                    vec = sImporte.Split('.');
                    txtTotalPrenda.Text = fun.FormatoEnteroMiles(vec[0]);
                    txtImportePrenda.Text = fun.FormatoEnteroMiles(vec[0]);
                }
                else
                    txtTotalVehiculoPartePago.Text = tVenta.Rows[0]["ImporteAutoPartePago"].ToString();

                if (tVenta.Rows[0]["ImporteCredito"].ToString() != "")
                {
                    string sImporte = tVenta.Rows[0]["ImporteCredito"].ToString().Replace(",", ".");
                    vec = sImporte.Split('.');
                    txtTotalDocumentos.Text = fun.FormatoEnteroMiles(vec[0]);
                }
                else
                    txtTotalDocumentos.Text = tVenta.Rows[0]["ImporteCredito"].ToString();

                if (tVenta.Rows[0]["ImporteCobranza"].ToString() != "")
                {
                    string sImporte = tVenta.Rows[0]["ImporteCobranza"].ToString().Replace(",", ".");
                    vec = sImporte.Split('.');
                    txtImporteCobranza.Text = fun.FormatoEnteroMiles(vec[0]);
                    txtTotalCobranza.Text = txtImporteCobranza.Text;
                    dpFechaCompromiso.Value = Convert.ToDateTime(tVenta.Rows[0]["Fecha"].ToString());
                    cCobranza cobDet = new cCobranza(); ;
                    DataTable tbCob = cobDet.GetDetalleCobranzaxCodVenta(CodVenta);
                    GrillaCobranza.DataSource = tbCob;
                    GrillaCobranza.Columns[0].Width = 180;
                    GrillaCobranza.Columns[1].Width = 180;
                    GrillaCobranza.Columns[4].Width = 190;
                    GrillaCobranza.Columns[5].Visible = false;
                }
                else
                {
                    txtImporteCobranza.Text = tVenta.Rows[0]["ImporteCobranza"].ToString();
                }
                txtComisionVendedor.Text = tVenta.Rows[0]["ImporteVendedor"].ToString();
                if (txtComisionVendedor.Text != "")
                {
                    txtComisionVendedor.Text = fun.SepararDecimales(txtComisionVendedor.Text);
                    txtComisionVendedor.Text = fun.FormatoEnteroMiles(txtComisionVendedor.Text);
                }

                txtImporteSenia.Text = tVenta.Rows[0]["PrecioSenia"].ToString();
                if (txtImporteSenia.Text != "")
                {
                    txtImporteSenia.Text = fun.SepararDecimales(txtImporteSenia.Text);
                    txtImporteSenia.Text = fun.FormatoEnteroMiles(txtImporteSenia.Text);
                }
                BuscarAutosPartePago(CodVenta);
                CalcularSubTotal();
                //buscamos el ex titular
                Clases.cStockAuto stockA = new Clases.cStockAuto();
                DataTable tresul = stockA.GetStockAutos(Convert.ToInt32(tVenta.Rows[0]["CodAutoVendido"].ToString()));
                if (tresul.Rows.Count > 0)
                {
                    if (tresul.Rows[0]["CodCliente"].ToString() != "")
                    {
                        Int32 CodCliente = Convert.ToInt32(tresul.Rows[0]["CodCliente"].ToString());
                        Clases.cCliente cli = new Clases.cCliente();
                        DataTable tcli = cli.GetClientesxCodigo(CodCliente);
                        if (tcli.Rows.Count > 0)
                        {
                            txtExTitular.Text = tcli.Rows[0]["Nombre"].ToString();
                            txtExTitular.Text = txtExTitular.Text + " " + tcli.Rows[0]["Apellido"].ToString();
                        }
                    }

                }
            }
            cTransferencia tranfer = new cTransferencia();
            DataTable tbTransfer = tranfer.GetTransferenciaxCodVenta(CodVenta);
            tbTransfer = fun.TablaaMiles(tbTransfer, "Importe");
            GrillaTransferencia.DataSource = tbTransfer;
            fun.AnchoColumnas(GrillaTransferencia, "0;40;30;30");
            Double TotalTransferencia = fun.TotalizarColumna (tbTransfer,"Importe");
            if (txtTotalEfectivo.Text !="")
            {
                Double Eft = fun.ToDouble(txtTotalEfectivo.Text);
                Eft = Eft + TotalTransferencia;
                txtTotalEfectivo.Text = fun.FormatoEnteroMiles(Eft.ToString());
            }
        }

        private void BuscarPresupuestoxCodigo(Int32 CodPresupuesto)
        {
            cFunciones fun = new cFunciones();
            cPresupuesto Presupuesto = new Clases.cPresupuesto();
            DataTable trdo = Presupuesto.GetPresupuestoxCodigo(CodPresupuesto);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCliente = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    BuscarClientexCodigo(CodCliente);
                }

                if (trdo.Rows[0]["CodAuto"].ToString() != "")
                {
                    Int32 CodAuto = Convert.ToInt32(trdo.Rows[0]["CodAuto"].ToString());
                    BuscarAutoxCodigo(CodAuto);
                }

                if (trdo.Rows[0]["Total"].ToString() != "")
                {
                    Double Tot = Convert.ToDouble(trdo.Rows[0]["Total"].ToString());
                    txtPrecioVenta.Text = GetMiles(Tot);
                }

                    if (trdo.Rows[0]["ImporteEfectivo"].ToString() != "")
                {
                    Double Importe = Convert.ToDouble(trdo.Rows[0]["ImporteEfectivo"].ToString());
                    txtEfectivoPresupuesto.Text = GetMiles(Importe);
                    txtEfectivo.Text = GetMiles(Importe);
                    txtTotalEfectivo.Text = GetMiles(Importe);
                }

                if (trdo.Rows[0]["ImporteCobranza"].ToString() != "")
                {   
                    Double Importe = Convert.ToDouble(trdo.Rows[0]["ImporteCobranza"].ToString());
                    txtCobranzaPresupuesto.Text = GetMiles(Importe);
                }

                if (trdo.Rows[0]["ImporteCheque"].ToString() != "")
                {   
                    Double Importe = Convert.ToDouble(trdo.Rows[0]["ImporteCheque"].ToString());
                    txtChequePresupuesto.Text = GetMiles(Importe);
                }

                if (trdo.Rows[0]["ImporteDocumento"].ToString() != "")
                {  
                    Double Importe = Convert.ToDouble(trdo.Rows[0]["ImporteDocumento"].ToString());
                    txtDocumentoPresupuesto.Text = GetMiles(Importe);
                }

                if (trdo.Rows[0]["ImporteTransferencia"].ToString() != "")
                {   
                    Double Importe = Convert.ToDouble(trdo.Rows[0]["ImporteTransferencia"].ToString());
                    txtTransferenciaPresupuesto.Text = GetMiles(Importe);
                }
            }

            //busco los autos x presupuesto
            DataTable tbAuto = Presupuesto.GetPresupuestoxAuto(CodPresupuesto);
            if (tbAuto.Rows.Count >0)
            {
                if (tbAuto.Rows[0]["CodAuto"].ToString ()!="")
                {
                    string Patente = (tbAuto.Rows[0]["Patente"].ToString());
                    txtPatente2.Text = Patente;
                }

                if (tbAuto.Rows[0]["Importe"].ToString() != "")
                {
                    Double Imp = Convert.ToDouble(tbAuto.Rows[0]["Importe"].ToString());
                    txtImporteVehiculoCompra.Text = fun.FormatoEnteroMiles(Imp.ToString());
                }
            }
            
            DataTable tbGastos = Presupuesto.GetGastosTransferencia(CodPresupuesto);
            tbGastos = fun.TablaaMiles(tbGastos, "Importe");
            GrillaGastos.DataSource = tbGastos;
            fun.AnchoColumnas(GrillaGastos, "0;60;0;40");
            Double total = fun.TotalizarColumna(tbGastos, "Importe");
            txtTotalGasto.Text = total.ToString();
            if (txtTotalGasto.Text != "")
            {
                txtTotalGasto.Text = fun.FormatoEnteroMiles(txtTotalGasto.Text);
            }

        }

        private string GetMiles(Double Importe)
        {
            cFunciones fun = new cFunciones();
            string sImporte = Importe.ToString();
            sImporte = fun.SepararDecimales(sImporte);
            sImporte = fun.FormatoEnteroMiles(sImporte);
            return sImporte;
        }


        private void BuscarAutosPartePago(Int32 CodVenta)
        {
            cFunciones fun = new cFunciones();
            cVentaxAuto obj = new cVentaxAuto();

            DataTable trdo = obj.GetAutosxCodVenta(CodVenta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            GrillaVehiculos.DataSource = trdo;
            string Col = "0;15;35;35;15;0";
            fun.AnchoColumnas(GrillaVehiculos, Col);

        }

        private void BuscarAutoxPatente(string Patente)
        {
            int b = 0;

            if (Patente.Length > 4)
            {
                Clases.cAuto auto = new Clases.cAuto();
                DataTable trdo = auto.GetAutoxPatente(Patente);
                if (trdo.Rows.Count > 0)
                {
                    b = 1;
                    Clases.cFunciones fun = new Clases.cFunciones();
                    txtDescripcion.Text = trdo.Rows[0]["Descripcion"].ToString();

                    txtMotor.Text = trdo.Rows[0]["Motor"].ToString();
                    txtChasis.Text = trdo.Rows[0]["Chasis"].ToString();
                    txtKms.Text = trdo.Rows[0]["Kilometros"].ToString();
                    if (txtKms.Text != "")
                    {
                        txtKms.Text = fun.FormatoEnteroMiles(txtKms.Text);
                    }
                    txtCodAuto.Text = trdo.Rows[0]["CodAuto"].ToString();
                    if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                    {
                        cmbCiudad.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                    }

                    if (trdo.Rows[0]["CodMarca"].ToString() != "")
                    {
                        cmbMarca.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                    }

                    if (trdo.Rows[0]["Propio"].ToString() == "1")
                    {
                        radioPropio.Checked = true;
                        radioConcesion.Checked = false;
                    }

                    if (trdo.Rows[0]["Concesion"].ToString() == "1")
                    {
                        radioPropio.Checked = false;
                        radioConcesion.Checked = true;
                    }
                    if (txtCodStock.Text != "")
                    {
                        GetCostos(Convert.ToInt32(txtCodStock.Text));
                        CargarGastosGeneralesxCodStoxk(Convert.ToInt32(txtCodStock.Text));
                    }

                }
            }
            if (b == 0)
                LimpiarAuto();

        }

        private void BuscarAutoxCodigo(Int32 COdAuto)
        {

            Clases.cAuto auto = new Clases.cAuto();
            DataTable trdo = auto.GetAutoxCodigo(COdAuto);
            if (trdo.Rows.Count > 0)
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtDescripcion.Text = trdo.Rows[0]["Descripcion"].ToString();
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
                txtMotor.Text = trdo.Rows[0]["Motor"].ToString();
                txtChasis.Text = trdo.Rows[0]["Chasis"].ToString();
                txtKms.Text = trdo.Rows[0]["Kilometros"].ToString();
                if (txtKms.Text != "")
                {
                    txtKms.Text = fun.FormatoEnteroMiles(txtKms.Text);
                }
                txtCodAuto.Text = trdo.Rows[0]["CodAuto"].ToString();
                if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                {
                    cmbCiudad.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                }

                if (trdo.Rows[0]["CodMarca"].ToString() != "")
                {
                    cmbMarca.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                }

                if (trdo.Rows[0]["CodAnio"].ToString() != "")
                {
                    cmbAnio.SelectedValue = trdo.Rows[0]["CodAnio"].ToString();
                }
                
                if (trdo.Rows[0]["CodTipoUtilitario"].ToString() != "")
                {
                    cmbTipoUtilitario.SelectedValue = trdo.Rows[0]["CodTipoUtilitario"].ToString();
                }

                if (trdo.Rows[0]["CodColor"].ToString() != "")
                {
                    cmbColor.SelectedValue = trdo.Rows[0]["CodColor"].ToString();
                }

                if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                {
                    Int32 CodCiiudad = Convert.ToInt32(trdo.Rows[0]["CodCiudad"].ToString());
                    cCiudad citi = new cCiudad();
                    DataTable tbciudad = citi.GetCiudadxId(CodCiiudad);
                    fun.LlenarComboDatatable(cmbCiudad, tbciudad, "Nombre", "CodCiudad");
                    cmbCiudad.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                }


                if (trdo.Rows[0]["Propio"].ToString() == "1")
                {
                    radioPropio.Checked = true;
                    radioConcesion.Checked = false;
                }

                if (trdo.Rows[0]["Concesion"].ToString() == "1")
                {
                    radioPropio.Checked = false;
                    radioConcesion.Checked = true;
                }

                Clases.cStockAuto stock = new Clases.cStockAuto();
                DataTable trdo2 = stock.GetStockAutosVigentes(Convert.ToInt32(txtCodAuto.Text));
                if (trdo2.Rows.Count > 0)
                {
                    txtCodStock.Text = trdo2.Rows[0]["CodStock"].ToString();
                    // GetExTitular(Convert.ToInt32(trdo2.Rows[0]["CodCliente"].ToString()));
                    GetCostos(Convert.ToInt32(txtCodStock.Text));
                    //  CargarGastosGeneralesxCodStoxk(Convert.ToInt32(txtCodStock.Text));
                    if (trdo2.Rows[0]["CodCliente"].ToString() != "")
                    {
                        // txtCodCLiente.Text = trdo2.Rows[0]["CodCliente"].ToString();
                        // GetClientesxCodigo(Convert.ToInt32(txtCodCLiente.Text));
                    }

                }

                if (txtCodStock.Text != "")
                {
                    GetCostos(Convert.ToInt32(txtCodStock.Text));
                    CargarGastosGeneralesxCodStoxk(Convert.ToInt32(txtCodStock.Text));
                }

            }



        }

        private void BuscarClientexCodigo(Int32 CodCliente)
        {
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientesxCodigo(CodCliente);
            if (trdo.Rows.Count > 0)
            {
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
             
                txtCalle.Text = trdo.Rows[0]["Calle"].ToString();
                txtAltura.Text = trdo.Rows[0]["Numero"].ToString();
                if (trdo.Rows[0]["CodBarrio"].ToString() != "")
                    CmbBarrio.SelectedValue = trdo.Rows[0]["CodBarrio"].ToString();
                txtCodCLiente.Text = trdo.Rows[0]["CodCliente"].ToString();
            }
            else
                LimpiarCliente();
        }

        private void BuscarGastosTransferencia(Int32 CodVenta)
        {
            string[] vec;
            cFunciones fun = new cFunciones();
            Clases.cGastoTransferencia gasto = new Clases.cGastoTransferencia();
            DataTable trdo = gasto.GetGastoTransferenciaxCodVenta(CodVenta);
            if (trdo.Rows.Count > 0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    string Codigo = trdo.Rows[i]["CodGastoTranasferencia"].ToString();
                    string Descripcion = trdo.Rows[i]["Descripcion"].ToString();
                    string Importe = trdo.Rows[i]["Importe"].ToString().Replace(",", ".");
                    vec = Importe.Split('.');
                    Importe = fun.FormatoEnteroMiles(vec[0]);
                    AgregarGasto(Codigo, Descripcion, Importe, "Transferencia");
                }
            }
            //AgregarGasto(CmbGastosTransferencia.SelectedValue.ToString(), Descripcion, txtImporteGastoTransferencia.Text, "Transferencia");
        }

        public void BuscarAutoxCodVenta(Int32 CodVenta)
        {
            Clases.cVenta venta = new Clases.cVenta();
            Int32 CodAutoPartePago = 0;
            int b = 0;
            DataTable trdo = venta.GetAutosxCodVenta(CodVenta);
            if (trdo.Rows.Count > 0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    Int32 CodAuto = Convert.ToInt32(trdo.Rows[i]["CodAuto"].ToString());
                    if (i == 0)
                    {
                        //busco el 1 auto entregado como parte de pago
                        b = 1;
                        CodAutoPartePago = CodAuto;

                    }
                    AgregarAutoGrilla(CodAuto, 0, Convert.ToInt32(trdo.Rows[i]["CodStock"].ToString()));
                }
                if (b == 1)
                    BuscarAutoPartePago(CodAutoPartePago);
            }
        }

        public void GetGastosdeRecepcionxCodVenta(Int32 CodVenta)
        {
            cFunciones fun = new cFunciones();
            string[] vec;
            Clases.cVenta venta = new Clases.cVenta();
            DataTable trdo = venta.GetGastosRecepcionxCodVenta(CodVenta);
            if (trdo.Rows.Count > 0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    string sCodigo = trdo.Rows[i]["CodGasto"].ToString();
                    string sDescrip = trdo.Rows[i]["Descripcion"].ToString();
                    string sImporte = trdo.Rows[i]["Importe"].ToString().Replace(",", ".");
                    vec = sImporte.Split('.');
                    sImporte = fun.FormatoEnteroMiles(vec[0]);
                    string sCodAuto = trdo.Rows[i]["CodAuto"].ToString();
                    AgregarGastoRecepcion(sCodigo, sDescrip, sImporte, "Recepción", sCodAuto);
                }
            }
        }

        public void BuscarCuotasxCodVenta(Int32 CodVenta)
        {
            Clases.cVenta venta = new Clases.cVenta();
            DataTable trdo = venta.GetCuotaxCodVenta(CodVenta);
            GrillaCuotas.DataSource = trdo;
            GrillaCuotas.Columns[2].HeaderText = "Vencimiento";
            GrillaCuotas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            GrillaCuotas.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            //   GrillaCuotas.Columns[0].Width = 50;
            // GrillaCuotas.Columns[1].Width = 150;
            //GrillaCuotas.Columns[2].Width = 150;
            //GrillaCuotas.Columns[3].Width = 180;
            GrillaCuotas.Columns[0].Width = 180;
            GrillaCuotas.Columns[3].HeaderText = "Importe s/Interés";
            GrillaCuotas.Columns[1].Width = 195;
            GrillaCuotas.Columns[2].Width = 180;
            GrillaCuotas.Columns[3].Width = 210;
        }

        private void BuscarChequesxCodVenta(Int32 CodVenta)
        {
            double Total = 0;
            Clases.cVenta venta = new Clases.cVenta();
            DataTable trdo = venta.GetChequesxCodVenta(CodVenta);
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                if (trdo.Rows[i]["Importe"].ToString() != "")
                {
                    Total = Total + Convert.ToDouble(trdo.Rows[i]["Importe"].ToString());
                }
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            trdo = fun.TablaaMiles(trdo, "Importe");
            GrillaCheques.DataSource = trdo;
            txtTotalCheque.Text = fun.FormatoEnteroMiles(Total.ToString());
            GrillaCheques.Columns[3].Visible = false;
            GrillaCheques.Columns[0].Width = 145;
            GrillaCheques.Columns[1].Width = 120;
            GrillaCheques.Columns[4].Width = 390;
        }

        private void BuscarAutoPartePago(Int32 CodAuto)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cAuto auto = new Clases.cAuto();
            DataTable trdCar = auto.GetAutoxCodigo(CodAuto);
            if (trdCar.Rows.Count > 0)
            {
                txtPatente2.Text = trdCar.Rows[0]["Patente"].ToString();
                string Patente = txtPatente2.Text;
                if (Patente.Length > 0)
                {
                    // Clases.cAuto auto = new Clases.cAuto();
                    DataTable trdo = auto.GetAutoxPatente(Patente);
                    if (trdo.Rows.Count > 0)
                    {

                        txtDescripcion2.Text = trdo.Rows[0]["Descripcion"].ToString();
                        if (trdo.Rows[0]["CodAnio"].ToString() != "")
                        {
                            cmbAnio2.SelectedValue = trdo.Rows[0]["CodAnio"].ToString();
                        }

                        txtKms2.Text = trdo.Rows[0]["Kilometros"].ToString();
                        txtCodAuto2.Text = trdo.Rows[0]["CodAuto"].ToString();
                        txtMotor2.Text = trdo.Rows[0]["Motor"].ToString();
                        txtChasis2.Text = trdo.Rows[0]["Chasis"].ToString();
                        if (trdo.Rows[0]["CodCiudad"].ToString() != "")
                        {
                            CmbCiudad2.SelectedValue = trdo.Rows[0]["CodCiudad"].ToString();
                        }

                        if (trdo.Rows[0]["CodMarca"].ToString() != "")
                        {
                            CmbMarca2.SelectedValue = trdo.Rows[0]["CodMarca"].ToString();
                        }

                        Clases.cStockAuto stock = new Clases.cStockAuto();
                        DataTable trdo2 = stock.GetStockAutosVigentes(Convert.ToInt32(txtCodAuto2.Text));
                        if (trdo2.Rows.Count > 0)
                        {
                            txtCodStock2.Text = trdo2.Rows[0]["CodStock"].ToString();
                            txtImporteVehiculoCompra.Text = trdo2.Rows[0]["ImporteCompra"].ToString();
                            if (txtImporteVehiculoCompra.Text != "")
                            {
                                txtImporteVehiculoCompra.Text = fun.SepararDecimales(txtImporteVehiculoCompra.Text);
                                txtImporteVehiculoCompra.Text = fun.FormatoEnteroMiles(txtImporteVehiculoCompra.Text);
                            }

                        }
                    }

                }
            }
        }

        private void txtInteres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComisionVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtComisionVendedor_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtComisionVendedor.Text != "")
            {
                txtComisionVendedor.Text = fun.FormatoEnteroMiles(txtComisionVendedor.Text);
            }
        }

        private string GetSqlComision(string CodVenta)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Int32 CodVendedor = Convert.ToInt32(CmbVendedor.SelectedValue);
            double Importe = fun.ToDouble(txtComisionVendedor.Text);
            DateTime Fecha = dpFecha.Value;
            string sql = "Insert into ComisionVendedor(CodVenta,Importe,CodVendedor,Fecha)";
            sql = sql + " values (" + CodVenta.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + "," + CodVendedor.ToString();
            sql = sql + "," + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            return sql;
        }

        private Int32 GetCodStockxCodAuto(Int32 CodAuto, SqlConnection con, SqlTransaction Transaccion)
        {
            string sql = "select max(CodStock) as CodStock from StockAuto";
            sql = sql + " where CodAuto=" + CodAuto.ToString();
            SqlCommand comandVenta = new SqlCommand();
            comandVenta.Connection = con;
            comandVenta.Transaction = Transaccion;
            comandVenta.CommandText = sql;
            Int32 CodStock = Convert.ToInt32(comandVenta.ExecuteScalar());
            return CodStock;
        }

        private void txtImporteGarantias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtImporteGarantias_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            txtImporteGarantias.Text = fun.FormatoEnteroMiles(txtImporteGarantias.Text);
        }

        private void btnAgregarGarantias_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaGarantias.Text) == false)
            {
                MessageBox.Show("La fecha ingresada es incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtDescripcionGarantia.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtImporteGarantias.Text == "")
            {
                MessageBox.Show("Debe ingresar un importe para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            Int32 CodVenta = Convert.ToInt32(txtCodPreVenta.Text);
            double Importe = fun.ToDouble(txtImporteGarantias.Text);
            DateTime Fecha = Convert.ToDateTime(txtFechaGarantias.Text);
            Clases.cGarantia garantia = new Clases.cGarantia();
            string Descripcion = txtDescripcionGarantia.Text;
            garantia.Insertar(CodVenta, Descripcion, Fecha, Importe);
            //graboe l movimiento
            Clases.cMovimiento mov = new Clases.cMovimiento();
            string DescripMov = Descripcion + ", PAGO DE GARANTIA " + txtPatente.Text;
            mov.RegistrarMovimientoDescripcion(CodVenta, Principal.CodUsuarioLogueado, -1 * Importe, 0, 0, 0, 0, Fecha, DescripMov);
            CargarGarantias(CodVenta);
            MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
        }

        private void CargarGarantias(Int32 CodVenta)
        {
            Clases.cGarantia garantia = new Clases.cGarantia();
            Clases.cFunciones fun = new Clases.cFunciones();
            DataTable trdo = garantia.GetGarantias(CodVenta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            GrillaGarantias.DataSource = trdo;
            GrillaGarantias.Columns[2].Width = 500;
            GrillaGarantias.Columns[0].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GrillaGarantias.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaGarantias.Text) == false)
            {
                MessageBox.Show("Debe ingresa una fecha válida para continuar", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cGarantia garantia = new Clases.cGarantia();
            DateTime Fecha = Convert.ToDateTime(txtFechaGarantias.Text);
            //Clases.cFunciones fun = new Clases.cFunciones ();
            Int32 CodGarantia = Convert.ToInt32(GrillaGarantias.CurrentRow.Cells[0].Value);
            garantia.BorrarGarantias(CodGarantia);
            double Importe = fun.ToDouble(GrillaGarantias.CurrentRow.Cells[3].Value.ToString());
            string DescripMov = "ANULACIÓN DE PAGO DE GARANTIA " + txtPatente.Text;
            Int32 CodVenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
            Clases.cMovimiento mov = new Clases.cMovimiento();
            mov.RegistrarMovimientoDescripcion(CodVenta, Principal.CodUsuarioLogueado, Importe, 0, 0, 0, 0, Fecha, DescripMov);
            CargarGarantias(CodVenta);
            MessageBox.Show("Datos borrados correctamente", Clases.cMensaje.Mensaje());
        }

        private void txtImporteCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();

            fun.SoloEnteroConPunto(sender, e);
        }

        private void btnVerDetalleStock_Click(object sender, EventArgs e)
        {
            if (txtCodAuto.Text == "")
            {
                MessageBox.Show("Debe ingresar un auto para continuar", Clases.cMensaje.Mensaje());
                return;
            }
            Int32 CodAuto = Convert.ToInt32(txtCodAuto.Text);
            Clases.cStockAuto obj = new Clases.cStockAuto();
            DataTable trdo = obj.GetStockAutos(CodAuto);
            if (trdo.Rows.Count > 0)
            {
                Int32 CodStock = Convert.ToInt32(trdo.Rows[0]["CodStock"].ToString());
                Principal.CodigoPrincipalAbm = CodStock.ToString();
                FrmDetalleAuto childForm = new FrmDetalleAuto();
                childForm.Text = "Detalle del vehículo";
                childForm.ShowDialog();
            }
        }

        private void btnAgregarImpuesto_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaImpuesto.Text) == false)
            {
                MessageBox.Show("La fecha ingresada es incorrecta", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtDescripcionImpuesto.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripción para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            if (txtImporteImpuesto.Text == "")
            {
                MessageBox.Show("Debe ingresar un importe para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            Int32 CodVenta = Convert.ToInt32(txtCodPreVenta.Text);
            double Importe = fun.ToDouble(txtImporteImpuesto.Text);
            DateTime Fecha = Convert.ToDateTime(txtFechaImpuesto.Text);
            Clases.cImpuesto impuesto = new Clases.cImpuesto();
            string Descripcion = txtDescripcionImpuesto.Text;
            impuesto.Insertar(CodVenta, Descripcion, Fecha, Importe);
            //graboe l movimiento
            Clases.cMovimiento mov = new Clases.cMovimiento();
            string DescripMov = "PAGO DE IMPUESTO " + txtDescripcionImpuesto.Text + ", PATENTE " + txtPatente.Text;
            mov.RegistrarMovimientoDescripcion(CodVenta, Principal.CodUsuarioLogueado, -1 * Importe, 0, 0, 0, 0, Fecha, DescripMov);
            CargarImpuestos(CodVenta);
            MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());

        }

        private void CargarImpuestos(Int32 CodVenta)
        {
            Clases.cImpuesto impuesto = new Clases.cImpuesto();
            Clases.cFunciones fun = new Clases.cFunciones();
            DataTable trdo = impuesto.GetImpuestos(CodVenta);
            trdo = fun.TablaaMiles(trdo, "Importe");
            GrillaImpuestos.DataSource = trdo;
            GrillaImpuestos.Columns[2].Width = 500;
            GrillaImpuestos.Columns[0].Visible = false;
        }

        private void btnQuitarImpuesto_Click(object sender, EventArgs e)
        {
            if (GrillaImpuestos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cFunciones fun = new Clases.cFunciones();
            if (fun.ValidarFecha(txtFechaImpuesto.Text) == false)
            {
                MessageBox.Show("Debe ingresa una fecha válida para continuar", Clases.cMensaje.Mensaje());
                return;
            }
            Clases.cImpuesto Impuesto = new Clases.cImpuesto();
            DateTime Fecha = Convert.ToDateTime(txtFechaImpuesto.Text);
            //Clases.cFunciones fun = new Clases.cFunciones ();
            Int32 CodImpuesto = Convert.ToInt32(GrillaImpuestos.CurrentRow.Cells[0].Value);
            Impuesto.BorrarImpuesto(CodImpuesto);
            double Importe = fun.ToDouble(GrillaImpuestos.CurrentRow.Cells[3].Value.ToString());
            string DescripMov = "ANULACIÓN DE PAGO DE IMPUESTO, PATENTE " + txtPatente.Text;
            Int32 CodVenta = Convert.ToInt32(txtCodPreVenta.Text);
            Clases.cMovimiento mov = new Clases.cMovimiento();
            mov.RegistrarMovimientoDescripcion(CodVenta, Principal.CodUsuarioLogueado, Importe, 0, 0, 0, 0, Fecha, DescripMov);
            CargarImpuestos(CodVenta);
            MessageBox.Show("Datos borrados correctamente", Clases.cMensaje.Mensaje());
        }

        private void btnAbrircPrenda_Click(object sender, EventArgs e)
        {
            if (GrillaPrendas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Sistema");
                return;
            }
            Int32 CodPrenda = Convert.ToInt32(GrillaPrendas.CurrentRow.Cells[4].Value.ToString());
            Principal.CodigoPrincipalAbm = CodPrenda.ToString();
            FrmCobroPrenda form = new FrmCobroPrenda();
            form.ShowDialog();
        }

        private void btnAbrirCuotas_Click(object sender, EventArgs e)
        {
            string patente = txtPatente.Text;
            Principal.CodigoPrincipalAbm = patente.ToString();
            FrmCobroCuotas form = new FrmCobroCuotas();
            form.ShowDialog();
        }

        private void btnAbrirCobranzas_Click(object sender, EventArgs e)
        {
            if (GrillaCobranza.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodCobranza = GrillaCobranza.CurrentRow.Cells[5].Value.ToString();
            Principal.CodigoPrincipalAbm = CodCobranza;
            FrmCobroDocumentos cobro = new FrmCobroDocumentos();
            cobro.ShowDialog();
        }

        private void btnAbrirCheques_Click(object sender, EventArgs e)
        {
            Int32 CodVenta = Convert.ToInt32(txtCodPreVenta.Text);
            Clases.cVenta venta = new Clases.cVenta();
            DataTable trdo = venta.GetVentaxCodigo(CodVenta);
            //if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodAutoVendido"].ToString() != "")
                {
                    string CodAuto = trdo.Rows[0]["CodAutoVendido"].ToString();
                    Principal.CodigoPrincipalAbm = CodAuto;
                    FrmCobroCheque frm = new FrmCobroCheque();
                    frm.ShowDialog();
                }
            }
        }

        private Boolean ValidarPreVenta()
        {
            if (txtCodAuto.Text == "")
            {
                MessageBox.Show("Debe ingresar un auto para vender", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente para continuar", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido del cliente para continuar", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtNroDoc.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de documento del cliente para continuar", Clases.cMensaje.Mensaje());
                return false;
            }

            Clases.cFunciones fun = new Clases.cFunciones();




            if (CmbVendedor.SelectedIndex < 1)
            {
                MessageBox.Show("Debe ingresar un vendedor ", Clases.cMensaje.Mensaje());
                return false;
            }

            if (txtTotalVenta.Text == "")
            {
                MessageBox.Show("Debe ingresar un importe de venta para continuar", Clases.cMensaje.Mensaje());
                return false;
            }
            return true;
        }

        private void btnGrabarPreVenta_Click(object sender, EventArgs e)
        {
            string msj = "Confirma grabar la pre venta ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            if (txtCodPreVenta.Text != "")
            {
                MessageBox.Show("La venta ya es una seña", Clases.cMensaje.Mensaje());
                return;
            }
            if (ValidarPreVenta() == false)
            {
                return;
            }


            Clases.cVenta objVenta = new Clases.cVenta();
            double GastosTotalxAuto = objVenta.GetCostosTotalesxCodStock(Convert.ToInt32(txtCodStock.Text));
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            SqlCommand Comand = new SqlCommand();
            Comand.Connection = con;
            Comand.Transaction = Transaccion;
            string sqlCLiente = "";

            try
            {
                sqlCLiente = GetSqlClientes();
                Comand.CommandText = sqlCLiente;
                Comand.ExecuteNonQuery();
                //SI FUE UN CLIENTE NUEVO
                //DEBO OBTENER EL COD CLIETNE
                if (GrabaClienteNuevo == true)
                {
                    SqlCommand comand2 = new SqlCommand();
                    comand2.Connection = con;
                    comand2.Transaction = Transaccion;
                    comand2.CommandText = "select max(CodCliente) as CodCliente from Cliente";
                    txtCodCLiente.Text = comand2.ExecuteScalar().ToString();
                }

                //saco el auto del stock
                string sqlStock = "update StockAuto";
                sqlStock = sqlStock + " set FechaBaja =" + "'" + dpFecha.Value.ToShortDateString() + "'";
                sqlStock = sqlStock + " where CodAuto =" + txtCodAuto.Text;
                Comand.CommandText = sqlStock;
                Comand.ExecuteNonQuery();

                //grabo el auto en el stock

                //si pago con usado lo ingreso
                if (txtTotalVehiculoPartePago.Text != "")
                    if (txtTotalVehiculoPartePago.Text != "0")
                    {
                        string sqlInsertStock = "";
                        for (int k = 0; k < GrillaVehiculos.Rows.Count - 1; k++)
                        {
                            Clases.cFunciones fun = new Clases.cFunciones();
                            string codAutoStock = GrillaVehiculos.Rows[k].Cells[0].Value.ToString();
                            string ImporteCompra = GrillaVehiculos.Rows[k].Cells[4].Value.ToString();
                            string AutoPartePago = txtPatente.Text + " " + txtDescripcion.Text;
                            sqlInsertStock = "insert into StockAuto(CodAuto,FechaAlta,CodCliente,CodUsuario,ImporteCompra,DescripcionAutoPartePago)";
                            sqlInsertStock = sqlInsertStock + " values (" + codAutoStock.ToString();
                            sqlInsertStock = sqlInsertStock + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                            sqlInsertStock = sqlInsertStock + "," + txtCodCLiente.Text;
                            sqlInsertStock = sqlInsertStock + "," + Principal.CodUsuarioLogueado.ToString();
                            sqlInsertStock = sqlInsertStock + "," + fun.ToDouble(ImporteCompra).ToString();
                            sqlInsertStock = sqlInsertStock + "," + "'" + AutoPartePago + "'";
                            sqlInsertStock = sqlInsertStock + ")";
                            SqlCommand comandStockAuto = new SqlCommand();
                            comandStockAuto.Connection = con;
                            comandStockAuto.Transaction = Transaccion;
                            comandStockAuto.CommandText = sqlInsertStock;
                            comandStockAuto.ExecuteNonQuery();
                        }
                    }

                //grabo la venta del auto
                string sqlVenta = GetSqlPreVenta();
                SqlCommand comandVenta = new SqlCommand();
                comandVenta.Connection = con;
                comandVenta.Transaction = Transaccion;
                comandVenta.CommandText = sqlVenta;
                comandVenta.ExecuteNonQuery();

                //obtengo el codigo de la venta
                string CodPreVenta = "";
                SqlCommand comandMaxVenta = new SqlCommand();
                comandMaxVenta.Connection = con;
                comandMaxVenta.Transaction = Transaccion;
                comandMaxVenta.CommandText = "select max(CodPreVenta) as CodPreVenta from PreVenta";
                CodPreVenta = comandMaxVenta.ExecuteScalar().ToString();



                //grabos los autos que entrego como parte de pago

                if (txtTotalVehiculoPartePago.Text != "")
                {
                    if (txtTotalVehiculoPartePago.Text != "0")
                    {
                        string sqlVentaxAuto = "";
                        for (int k = 0; k < GrillaVehiculos.Rows.Count - 1; k++)
                        {
                            Clases.cFunciones fun = new Clases.cFunciones();
                            string codAutoStock = GrillaVehiculos.Rows[k].Cells[0].Value.ToString();
                            string sImporte = GrillaVehiculos.Rows[k].Cells[4].Value.ToString();
                            sqlVentaxAuto = "insert into VentasxAuto(CodAuto,CodVenta,Importe)";
                            sqlVentaxAuto = sqlVentaxAuto + " values (" + codAutoStock.ToString();
                            sqlVentaxAuto = sqlVentaxAuto + "," + CodPreVenta.ToString();
                            sqlVentaxAuto = sqlVentaxAuto + "," + fun.ToDouble(sImporte).ToString();
                            sqlVentaxAuto = sqlVentaxAuto + ")";
                            SqlCommand comandVentaxAuto = new SqlCommand();
                            comandVentaxAuto.Connection = con;
                            comandVentaxAuto.Transaction = Transaccion;
                            comandVentaxAuto.CommandText = sqlVentaxAuto;
                            // comandVentaxAuto.ExecuteNonQuery();
                        }
                    }
                }

                //GRABO EL MOVIMIENTO
                SqlCommand comandMovimientoAuto = new SqlCommand();
                comandMovimientoAuto.Connection = con;
                comandMovimientoAuto.Transaction = Transaccion;
                comandMovimientoAuto.CommandText = GetSqlMovimientosSeña();
                comandMovimientoAuto.ExecuteNonQuery();
                Transaccion.Commit();

                con.Close();

                MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
                LimpiarPantalla(true);

            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                MessageBox.Show("Hubo un error en el proceso de grabación", Clases.cMensaje.Mensaje());
            }
        }

        private string GetSqlPreVenta()
        {
            string sql = "";
            DateTime Fecha = dpFecha.Value;
            Int32 CodAutoVendido = Convert.ToInt32(txtCodAuto.Text);
            Int32? CodAutoPartePago = null;
            Int32 CodStock = Convert.ToInt32(txtCodStock.Text);
            if (txtCodAuto2.Text != "")
            {
                CodAutoPartePago = Convert.ToInt32(txtCodAuto2.Text);
            }
            double ImporteVenta = 0;
            double ImporteAutoPartePago = 0;
            double ImporteCredito = 0;
            double ImporteEfectivo = 0;
            Int32 CodCliente = 0;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;
            double ImporteSenia = 0;

            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtPrecioVenta.Text != "")
                ImporteVenta = fun.ToDouble(txtPrecioVenta.Text);

            if (txtTotalDocumentos.Text != "")
                ImporteCredito = fun.ToDouble(txtTotalDocumentos.Text);

            if (txtTotalEfectivo.Text != "")
                ImporteEfectivo = fun.ToDouble(txtTotalEfectivo.Text);

            if (txtTotalPrenda.Text != "")
                ImportePrenda = fun.ToDouble(txtTotalPrenda.Text);

            if (txtCodCLiente.Text != "")
                CodCliente = Convert.ToInt32(txtCodCLiente.Text);

            if (txtImporteCobranza.Text != "")
                ImporteCobranza = fun.ToDouble(txtImporteCobranza.Text);

            if (txtTotalVehiculoPartePago.Text != "")
                ImporteAutoPartePago = fun.ToDouble(txtTotalVehiculoPartePago.Text);

            if (txtImporteSenia.Text != "")
                ImporteSenia = fun.ToDouble(txtImporteSenia.Text);


            Int32 CodVendedor = Convert.ToInt32(CmbVendedor.SelectedValue);
            //Principal.CodUsuarioLogueado 
            sql = "insert into PreVenta(Fecha,CodUsuario,CodCliente";
            sql = sql + ",CodAutoVendido,CodAutoPartePago,ImporteVenta,";
            sql = sql + "ImporteAutoPartePago,ImporteCredito,ImporteEfectivo,ImportePrenda,ImporteCobranza,ImporteBanco,CodVendedor,CodStock,PrecioSenia)";
            sql = sql + "values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Principal.CodUsuarioLogueado.ToString();
            sql = sql + "," + CodCliente.ToString();
            sql = sql + "," + CodAutoVendido.ToString();
            if (CodAutoPartePago == null)
                sql = sql + ",null";
            else
                sql = sql + "," + CodAutoPartePago.ToString();
            sql = sql + "," + ImporteVenta.ToString();
            sql = sql + "," + ImporteAutoPartePago.ToString();
            sql = sql + "," + ImporteCredito.ToString();
            sql = sql + "," + ImporteEfectivo.ToString();
            sql = sql + "," + ImportePrenda.ToString();
            sql = sql + "," + ImporteCobranza.ToString();
            sql = sql + "," + ImporteBanco.ToString();
            sql = sql + "," + CodVendedor.ToString();
            sql = sql + "," + CodStock.ToString();
            sql = sql + "," + ImporteSenia.ToString();
            sql = sql + ")";
            return sql;
        }

        private string GetSqlMovimientosSeña()
        {
            string sql = "";
            string Fecha = dpFecha.Value.ToShortDateString();
            Int32 CodAutoVendido = Convert.ToInt32(txtCodAuto.Text);

            double ImporteAuto = 0;
            double ImporteDocumento = 0;
            double ImporteEfectivo = 0;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;

            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtImporteSenia.Text != "")
                ImporteEfectivo = fun.ToDouble(txtImporteSenia.Text);



            /*
                        if (txtTotalVehiculoPartePago.Text != "")
                        {
                            ImporteAuto = fun.ToDouble(txtTotalVehiculoPartePago.Text);
                        }
                        */


            string Descripcion = "SEÑA DE AUTO " + txtPatente.Text;

            //Principal.CodUsuarioLogueado 
            sql = "insert into Movimiento(Fecha,CodUsuario";
            sql = sql + ",ImporteEfectivo,ImporteDocumento,ImportePrenda,ImporteAuto,CodVenta,ImporteCobranza,ImporteBanco,Descripcion)";
            sql = sql + "values(" + "'" + Fecha + "'";
            sql = sql + "," + Principal.CodUsuarioLogueado.ToString();
            sql = sql + "," + ImporteEfectivo.ToString();
            sql = sql + "," + ImporteDocumento.ToString();
            sql = sql + "," + ImportePrenda.ToString();
            sql = sql + "," + ImporteAuto.ToString();
            sql = sql + ",NULL";
            sql = sql + "," + ImporteCobranza.ToString();
            sql = sql + "," + ImporteBanco.ToString();
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            return sql;
        }

        private void btnAbrirPreVenta_Click(object sender, EventArgs e)
        {
            Principal.CampoNombreSecundario = "PreVenta";
            Principal.CodigoSenia = "";
            Principal.NombreTablaSecundario = "PreVenta";
            FrmListadoPreVenta frm = new FrmListadoPreVenta();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void BuscarPreVenta(Int32 CodPreVenta)
        {
            txtCodPreVenta.Text = CodPreVenta.ToString();
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cPreVenta preVenta = new Clases.cPreVenta();
            DataTable trdo = preVenta.GetPreVentaxCodigo(CodPreVenta);
            if (trdo.Rows.Count > 0)
            {
                txtCodStock.Text = trdo.Rows[0]["CodStock"].ToString();
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCli = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    string Patente = trdo.Rows[0]["Patente"].ToString();
                    txtPatente.Text = Patente.ToString();
                    BuscarClientexCodigo(CodCli);
                    BuscarAutoxPatente(Patente);
                }
                if (trdo.Rows[0]["ImporteVenta"].ToString() != "")
                {
                    txtPrecioVenta.Text = trdo.Rows[0]["ImporteVenta"].ToString();
                    txtPrecioVenta.Text = fun.SepararDecimales(txtPrecioVenta.Text);
                    txtPrecioVenta.Text = fun.FormatoEnteroMiles(txtPrecioVenta.Text);
                }
                if (trdo.Rows[0]["ImporteEfectivo"].ToString() != "")
                {
                    txtEfectivo.Text = trdo.Rows[0]["ImporteEfectivo"].ToString();
                    txtEfectivo.Text = fun.SepararDecimales(txtEfectivo.Text);
                    txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
                }

                if (trdo.Rows[0]["PrecioSenia"].ToString() != "")
                {
                    txtImporteSenia.Text = trdo.Rows[0]["PrecioSenia"].ToString();
                    txtImporteSenia.Text = fun.SepararDecimales(txtImporteSenia.Text);
                    txtImporteSenia.Text = fun.FormatoEnteroMiles(txtImporteSenia.Text);
                }
            }
        }

        public double GetTotalSenia(Int32 CodPreVenta)
        {
            double Senia = 0;
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtImporteSenia.Text != "")
                Senia = fun.ToDouble(txtImporteSenia.Text);
            /*
            Clases.cPreVenta obj = new Clases.cPreVenta();
            DataTable trdo = obj.GetPreVentaxCodigo(CodPreVenta);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["ImporteEfectivo"].ToString() != "")
                    Senia = Convert.ToDouble(trdo.Rows[0]["ImporteEfectivo"].ToString());
            }
             * */
            return Senia;
        }

        private string GetSqlRestarSeniaMovimientos(double Importe)
        {
            string sql = "";
            string Fecha = dpFecha.Value.ToShortDateString();
            Int32 CodAutoVendido = Convert.ToInt32(txtCodAuto.Text);

            double ImporteAuto = 0;
            double ImporteDocumento = 0;
            double ImporteEfectivo = Importe;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;

            ImporteEfectivo = -1 * ImporteEfectivo;
            Clases.cFunciones fun = new Clases.cFunciones();
            string Descripcion = "CANCELACION DE SEÑA, PATENTE " + txtPatente.Text;



            //Principal.CodUsuarioLogueado 
            sql = "insert into Movimiento(Fecha,CodUsuario";
            sql = sql + ",ImporteEfectivo,ImporteDocumento,ImportePrenda,ImporteAuto,CodVenta,ImporteCobranza,ImporteBanco,Descripcion)";
            sql = sql + "values(" + "'" + Fecha + "'";
            sql = sql + "," + Principal.CodUsuarioLogueado.ToString();
            sql = sql + "," + ImporteEfectivo.ToString();
            sql = sql + "," + ImporteDocumento.ToString();
            sql = sql + "," + ImportePrenda.ToString();
            sql = sql + "," + ImporteAuto.ToString();
            sql = sql + ",null";
            sql = sql + "," + ImporteCobranza.ToString();
            sql = sql + "," + ImporteBanco.ToString();
            sql = sql + "," + "'" + Descripcion + "'";
            sql = sql + ")";
            return sql;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Principal.CodigoPrincipalAbm != null)
            {
                FrmMensajesVentas frm = new FrmMensajesVentas();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una venta para registrar mensajes", "Sistema");

            }
        }

        private void ActualizarDiferenciaTransferencia(Int32 CodVenta)
        {
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            Clases.cDiferenciaTransferencia dif = new Clases.cDiferenciaTransferencia();
            DataTable trdo = gasto.GetGastosPagarxCodVenta(CodVenta);
            for (int i = 0; i < trdo.Rows.Count; i++)
            {
                Int32 CodGasto = Convert.ToInt32(trdo.Rows[i]["CodGasto"].ToString());
                dif.ActualizarCodVenta(CodVenta, CodGasto);
            }
        }

        private void txtImporteSenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.SoloEnteroConPunto(this, e);
        }

        private void txtImporteSenia_Leave(object sender, EventArgs e)
        {
            if (txtImporteSenia.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteSenia.Text = fun.FormatoEnteroMiles(txtImporteSenia.Text);
            }
        }

        private void btnAgregarPrenda_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (txtImportePrenda.Text == "")
            {
                MessageBox.Show("Debe ingresar un monto de prenda", "Sistema");
                return;
            }
            if (CmbEntidadPrendaria.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una entidad prendaria", "Sistema");
                return;
            }

            string Importe = txtImportePrenda.Text;
            string CodEntidad = CmbEntidadPrendaria.SelectedValue.ToString();
            string FechaVencimiento = dpFechaVencimientoPrenda.Value.ToShortDateString();
            if (fun.Buscar(tprenda, "CodEntidad", CodEntidad) == true)
            {
                MessageBox.Show("Ya se ha ingresado la entidad");
                return;
            }
            string Nombre = CmbEntidadPrendaria.Text;
            string Fecha = DateTime.Now.ToShortDateString();
            string CodPrenda = "-1";

            string Valores = CodEntidad + ";" + Nombre + ";" + Fecha + ";" + Importe + ";" + CodPrenda;
            Valores = Valores + ";" + FechaVencimiento;
            tprenda = fun.AgregarFilas(tprenda, Valores);
            GrillaPrendas.DataSource = tprenda;
            double Total = fun.TotalizarColumna(tprenda, "Importe");
            txtTotalPrenda.Text = Total.ToString();
            if (txtTotalPrenda.Text != "")
            {
                txtTotalPrenda.Text = fun.FormatoEnteroMiles(txtTotalPrenda.Text);
            }
            GrillaPrendas.Columns[0].Visible = false;
            // GrillaPrendas.Columns[2].Visible = false;
            GrillaPrendas.Columns[1].Width = 425;
            GrillaPrendas.Columns[3].Width = 150;
            GrillaPrendas.Columns[4].Visible = false;
            GrillaPrendas.Columns[5].Width = 80;
            GrillaPrendas.Columns[5].HeaderText = "Vencimiento";
            CalcularSubTotal();
        }

        private void BuscarPrenda(Int32 CodVenta)
        {
            cPrenda Prenda = new cPrenda();
            DataTable tbPre = Prenda.GetDetallePredaxCodVenta(CodVenta);
            GrillaPrendas.DataSource = tbPre;
            GrillaPrendas.Columns[0].Visible = false;
            GrillaPrendas.Columns[1].Width = 425;
            GrillaPrendas.Columns[3].Width = 150;
            GrillaPrendas.Columns[4].Visible = false;
            GrillaPrendas.Columns[5].Width = 80;
            GrillaPrendas.Columns[5].HeaderText = "Vencimiento";
        }

        private void btnEliminarPrenda_Click(object sender, EventArgs e)
        {
            if (GrillaPrendas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Sistema");
                return;
            }
            string CodEntidad = GrillaPrendas.CurrentRow.Cells[0].Value.ToString();
            Clases.cFunciones fun = new Clases.cFunciones();
            tprenda = fun.EliminarFila(tprenda, "CodEntidad", CodEntidad);
            GrillaPrendas.DataSource = tprenda;
            double Total = fun.TotalizarColumna(tprenda, "Importe");
            txtTotalPrenda.Text = Total.ToString();
            if (txtTotalPrenda.Text != "")
            {
                txtTotalPrenda.Text = fun.FormatoEnteroMiles(txtTotalPrenda.Text);
            }
            CalcularSubTotal();
        }

        private void GrabarPrenda(Int32 CodVenta, SqlConnection con, SqlTransaction Transaccion)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            for (int i = 0; i < tprenda.Rows.Count; i++)
            {
                string CodEntidad = tprenda.Rows[i][0].ToString();
                string CodCliente = txtCodCLiente.Text;
                double Importe = fun.ToDouble(tprenda.Rows[i][3].ToString());
                string FechaVencimiento = tprenda.Rows[i]["FechaVencimiento"].ToString();
                string sql = "Insert into Prenda(CodVenta,Importe,CodCliente,CodEntidad,Fecha,CodAuto,Saldo,Diferencia,FechaVencimiento)";
                sql = sql + "Values (" + CodVenta.ToString();
                sql = sql + "," + Importe.ToString();
                sql = sql + "," + CodCliente.ToString();
                sql = sql + "," + CodEntidad.ToString();
                sql = sql + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                sql = sql + "," + txtCodAuto.Text.ToString();
                sql = sql + "," + Importe.ToString();
                sql = sql + ",0";
                sql = sql + "," + "'" + FechaVencimiento + "'";
                sql = sql + ")";
                SqlCommand ComandPrenda = new SqlCommand();
                ComandPrenda.Connection = con;
                ComandPrenda.Transaction = Transaccion;
                ComandPrenda.CommandText = sql;
                ComandPrenda.ExecuteNonQuery();
            }
        }

        private void GetPrendaxCodVenta(Int32 CodVenta)
        {/*
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cPrenda prenda = new Clases.cPrenda ();
            DataTable trdo = prenda.GetPrendaxCodVenta(CodVenta);
            string Values = "";
            if (trdo.Rows.Count > 0)
            {  
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    Values = trdo.Rows[i]["CodEntidad"].ToString();
                    Values = Values + ";" + trdo.Rows[i]["Descripcion"].ToString();
                    Values = Values + ";" + trdo.Rows[i]["Fecha"].ToString();
                    Values = Values + ";" + trdo.Rows[i]["Importe"].ToString();
                    Values = Values + ";" + trdo.Rows[i]["CodPrenda"].ToString();
                    tprenda = fun.AgregarFilas(tprenda, Values);
                }
                tprenda = fun.TablaaMiles(tprenda, "Importe");
                GrillaPrendas.DataSource = tprenda;
                GrillaPrendas.Columns[0].Visible = false;
                GrillaPrendas.Columns[2].Visible = false;
                GrillaPrendas.Columns[1].Width = 430;
                GrillaPrendas.Columns[4].Visible = false; 
                
            }
            */
        }

        private void ActualizarCodVentaEnGastosRecepcion(Int32 CodVenta, SqlConnection con, SqlTransaction Transaccion)
        {
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            for (int i = 0; i < GrillaGastosGenerales.Rows.Count - 1; i++)
            {
                if (GrillaGastosGenerales.Rows[i].Cells[0].Value.ToString() != "")
                {
                    Int32 CodGasto = Convert.ToInt32(GrillaGastosGenerales.Rows[i].Cells[0].Value.ToString());
                    gasto.ActualizarCodVenta(con, Transaccion, CodVenta, CodGasto);
                }
            }
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (cmbTarjeta.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una tarjeta", "Sistema");
                return;
            }
            if (txtImporteTarjeta.Text == "")
            {
                MessageBox.Show("Debe ingresar un monto de tarjeta", "Sistema");
                return;
            }
            string CodTarjeta = cmbTarjeta.SelectedValue.ToString();
            if (fun.Buscar(tbTarjeta, "CodTarjeta", CodTarjeta) == true)
            {
                MessageBox.Show("Ya se ha ingresado la tarjeta");
                return;
            }

            string Nombre = cmbTarjeta.Text;
            string Importe = txtImporteTarjeta.Text;
            string Val = CodTarjeta + ";" + Nombre + ";" + Importe;

            tbTarjeta = fun.AgregarFilas(tbTarjeta, Val);
            Double Total = fun.TotalizarColumna(tbTarjeta, "Importe");
            txtMontoTarjeta.Text = Total.ToString();
            txtMontoTarjeta.Text = fun.FormatoEnteroMiles(txtMontoTarjeta.Text);
            GrillaTarjeta.DataSource = tbTarjeta;
            CalcularSubTotal();
            GrillaTarjeta.Columns[0].Visible = false;
            GrillaTarjeta.Columns[1].Width = 640;
            GrillaTarjeta.Columns[2].Width = 120;
        }

        private void txtImporteTarjeta_Leave(object sender, EventArgs e)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            txtImporteTarjeta.Text = fun.FormatoEnteroMiles(txtImporteTarjeta.Text);
        }

        private void btnQuitarTarjeta_Click(object sender, EventArgs e)
        {
            if (GrillaTarjeta.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elememto para continuar ");
                return;
            }
            string CodTarjeta = cmbTarjeta.SelectedValue.ToString();
            Clases.cFunciones fun = new Clases.cFunciones();
            tbTarjeta = fun.EliminarFila(tbTarjeta, "CodTarjeta", CodTarjeta);
            GrillaTarjeta.DataSource = tbTarjeta;
            Double Total = fun.TotalizarColumna(tbTarjeta, "Importe");
            txtMontoTarjeta.Text = Total.ToString();
            txtMontoTarjeta.Text = fun.FormatoEnteroMiles(txtMontoTarjeta.Text);
            CalcularSubTotal();
        }

        private void GetVentaxtarjeta(Int32 CodVenta)
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cTarjeta tarjeta = new Clases.cTarjeta();
            DataTable trdo = tarjeta.GetTarjetaxCodVenta(CodVenta);
            if (trdo.Rows.Count > 0)
            {
                string val = "";
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    val = trdo.Rows[i]["CodTarjeta"].ToString();
                    val = val + ";" + trdo.Rows[i]["Nombre"].ToString();
                    val = val + ";" + trdo.Rows[i]["Importe"].ToString();
                    tbTarjeta = fun.AgregarFilas(tbTarjeta, val);
                    // DataRow r = tbTarjeta.NewRow();
                    // tbTarjeta.Rows.Add (r);
                }
                // Clases.cFunciones fun = new Clases.cFunciones();
                GrillaTarjeta.DataSource = tbTarjeta;
                Double Total = fun.TotalizarColumna(tbTarjeta, "Importe");
                txtMontoTarjeta.Text = Total.ToString();
                txtMontoTarjeta.Text = fun.FormatoEnteroMiles(txtMontoTarjeta.Text);
                GrillaTarjeta.DataSource = tbTarjeta;
                CalcularSubTotal();
                GrillaTarjeta.Columns[0].Visible = false;
                GrillaTarjeta.Columns[1].Width = 443;
            }
        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        private void CmbGastosTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, "Sistema");
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
            txtTotalCobranza.Text = fun.FormatoEnteroMiles(TotalCobranza.ToString());
            CalcularSubTotal();
            GrillaCobranza.Columns[0].Width = 180;
            GrillaCobranza.Columns[1].Width = 180;
            GrillaCobranza.Columns[4].Width = 190;
            GrillaCobranza.Columns[5].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbCobranza.Rows.Clear();
            GrillaCobranza.DataSource = tbCobranza;
            txtTotalCobranza.Text = "";
            txtImporteCobranza.Text = "";
            CalcularSubTotal();
        }

        private void cmbProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia2.SelectedIndex < 1)
            {
                return;
            }
            Int32 CodProvincia = Convert.ToInt32(cmbProvincia2.SelectedValue);
            cCiudad ciudad = new Clases.cCiudad();
            DataTable trdo = ciudad.GetCiudadxCodProvincia(CodProvincia);
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(CmbCiudadCliente2, trdo, "Nombre", "CodCiudad");
        }

        private void CmbCiudadCliente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCiudadCliente2.SelectedIndex < 1)
            {
                // MessageBox.Show("Seleccione una ciudad");
                return;
            }

            Int32 CodCiudad = Convert.ToInt32(CmbCiudadCliente2.SelectedValue);
            cBarrio barrio = new cBarrio();
            DataTable tbBarrio = barrio.GetBarrioxCiudad(CodCiudad);
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(CmbBarrio, tbBarrio, "Nombre", "CodBarrio");
        }

        private void btnAgregarProvincia2_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodProvincia";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Provincia";
            Principal.CodigoPrincipalAbm = "2";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnAgregarCiudad2_Click(object sender, EventArgs e)
        {
            if (cmbProvincia2.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar una provincia para continuar");
                return;
            }
            Principal.CodigoPrincipalAbm = "4";
            SigueCiudad = 3;
            Principal.CampoIdSecundario = "CodCiudad";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Ciudad";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void CmbProvinciaAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProvinciaAuto.SelectedIndex < 1)
            {
                return;
            }
            Int32 CodProvincia = Convert.ToInt32(CmbProvinciaAuto.SelectedValue);
            cCiudad ciudad = new Clases.cCiudad();
            DataTable trdo = ciudad.GetCiudadxCodProvincia(CodProvincia);
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(CmbCiudad2, trdo, "Nombre", "CodCiudad");
        }

        private void btnAgregarProvinciaAuto_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodProvincia";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Provincia";
            Principal.CodigoPrincipalAbm = "1";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnAgregarPapel_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            string CodPapel = ListaPapeles.SelectedValue.ToString();
            string Nombre = ListaPapeles.Text;
            string Entrego = "0";
            string Fecha = "";
            string Texto = "No";
            string FechaVencimiento = "";
            if (chkEntrego.Checked == true)
            {
                if (fun.ValidarFecha(txtFechaEntregaPapel.Text) == false)
                {
                    Mensaje("La fecha de entrega del documento es incorrecta");
                }
                Entrego = "1";
                Texto = "Si";
                Fecha = txtFechaEntregaPapel.Text;
            }
            string xx = txtFechaVtoPapel.Text;
            if (fun.ValidarFecha(txtFechaVtoPapel.Text) == true)
            {
                FechaVencimiento = txtFechaVtoPapel.Text;
            }

            if (fun.Buscar(tbListaPapeles, "CodPapel", CodPapel) == true)
            {
                Mensaje("Ya se ha ingresado el documento");
                return;
            }

            string Valor = CodPapel + ";" + Nombre;
            Valor = Valor + ";" + Entrego;
            Valor = Valor + ";" + Texto;
            Valor = Valor + ";" + Fecha;
            Valor = Valor + ";" + FechaVencimiento;
            tbListaPapeles = fun.AgregarFilas(tbListaPapeles, Valor);
            GrillaPapeles.DataSource = tbListaPapeles;
            GrillaPapeles.Columns[0].Visible = false;
            GrillaPapeles.Columns[2].Visible = false;
            GrillaPapeles.Columns[1].Width = 130;
            GrillaPapeles.Columns[3].Width = 80;
            GrillaPapeles.Columns[4].Width = 80;
            GrillaPapeles.Columns[5].Width = 90;
            GrillaPapeles.Columns[5].HeaderText = "Vencimiento";
            GrillaPapeles.Columns[3].HeaderText = "Entrego";
        }

        private void btnQuitarPapel_Click(object sender, EventArgs e)
        {
            if (GrillaPapeles.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodPapel = GrillaPapeles.CurrentRow.Cells[0].Value.ToString();
            cFunciones fun = new cFunciones();
            tbListaPapeles = fun.EliminarFila(tbListaPapeles, "CodPapel", CodPapel);
            GrillaPapeles.DataSource = tbListaPapeles;
        }

        private void btnNuevoPapel_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodPapel";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Papeles";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void GrabarPapelesxStock(SqlConnection con, SqlTransaction Transaccion, Int32? CodCompra, Int32 CodStock)
        {
            int i = 0;
            Int32 CodPapel = 0;
            string Entrego = "";
            string Texto = "";
            DateTime? Fecha = null;
            DateTime? FechaVencimiento = null;
            cFunciones fun = new cFunciones();
            cPapeles papel = new cPapeles();
            for (i = 0; i < tbListaPapeles.Rows.Count; i++)
            {
                CodPapel = Convert.ToInt32(tbListaPapeles.Rows[i]["CodPapel"]);
                Entrego = tbListaPapeles.Rows[i]["Entrego"].ToString();
                Texto = tbListaPapeles.Rows[i]["Texto"].ToString();
                if (fun.ValidarFecha(tbListaPapeles.Rows[i]["Fecha"].ToString()) == true)
                {
                    Fecha = Convert.ToDateTime(tbListaPapeles.Rows[i]["Fecha"].ToString());
                }

                if (fun.ValidarFecha(tbListaPapeles.Rows[i]["FechaVencimiento"].ToString()) == true)
                {
                    FechaVencimiento = Convert.ToDateTime(tbListaPapeles.Rows[i]["FechaVencimiento"].ToString());
                }
                papel.InsertarPapeles(con, Transaccion, CodPapel, CodStock, Entrego, Texto, Fecha, FechaVencimiento, CodCompra);
            }

        }

        public void GetPapelesxcodVenta(Int32 CodVenta)
        {
            cPapeles papeles = new cPapeles();
            cVenta venta = new cVenta();
            DataTable trdo = venta.GetAutosxCodVenta(CodVenta);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodStock"].ToString() != "")
                {
                    Int32 CodStock = Convert.ToInt32(trdo.Rows[0]["CodStock"].ToString());
                    DataTable tbPapeles = papeles.GetPapelesxCodStock(CodStock);
                    GrillaPapeles.DataSource = tbPapeles;
                    GrillaPapeles.Columns[0].Visible = false;
                    GrillaPapeles.Columns[2].Visible = false;
                    GrillaPapeles.Columns[1].Width = 150;
                    GrillaPapeles.Columns[3].Width = 80;
                    GrillaPapeles.Columns[4].Width = 80;
                    GrillaPapeles.Columns[5].Width = 90;
                    GrillaPapeles.Columns[5].HeaderText = "Vencimiento";
                    GrillaPapeles.Columns[3].HeaderText = "Entrego";
                }
            }
        }

        private void BtnVerFoto_Click(object sender, EventArgs e)
        {
            if (txtCodAuto.Text == "")
            {
                Mensaje("Debe ingresar un vehículo");
                return;
            }
            Principal.RutaImagen = txtRutaAuto.Text;
            FrmVerFotos frm = new FrmVerFotos();
            frm.ShowDialog();
        }

        private void btnSubirFotoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                cImagen imgAuto = new cImagen();
                string NroImagen = imgAuto.GetProximaImagen().ToString();
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string ruta = file.FileName;
                    txtRutaImagenCliente.Text = ruta;
                    imgFotoCliente.Image = System.Drawing.Image.FromFile(ruta);
                    string Extension = System.IO.Path.GetExtension(file.FileName.ToString());
                    string RutaGrabar = imgAuto.GetRuta() + NroImagen + "." + Extension;
                    imgFotoCliente.Image.Save(RutaGrabar);
                    imgAuto.Grabar(Convert.ToInt32(NroImagen));
                    txtRutaImagenCliente.Text = RutaGrabar;
                }
                else
                {
                    txtRutaImagenCliente.Text = "";
                }
            }
            catch (Exception ex)
            {
                Mensaje("Hubo un error al intentar grabar la imagen");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtRutaImagenCliente.Text == "")
            {
                Mensaje("El cliente no tiene imagenes");
                return;
            }
            Principal.RutaImagen = txtRutaImagenCliente.Text;
            FrmVerFotos frm = new FrmVerFotos();
            frm.ShowDialog();
        }

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            if (ValidarPresupuesto() == false)
            {
                return;
            }
            cFunciones fun = new cFunciones();
            Int32 CodPresupuesto = 0;
            DateTime Fecha = dpFecha.Value;
            Int32? CodCliente = null;
            Int32? CodAuto = null;
            Double Total = 0;
            Double Cobranza = 0;
            Double Transferencia = 0;
            Double Cheque = 0;
            Double Documento = 0;
            Double ImporteGastoRecep = 0;
            int Orden = 1;

            Double TotalGastosTransferencia = 0;
            string sTotal = "";
            Total = fun.ToDouble(txtPrecioVenta.Text);
            sTotal = "$ " + txtPrecioVenta.Text;

            if (txtCodAuto.Text != "")
            {
                CodAuto = Convert.ToInt32(txtCodAuto.Text);
            }
            else
            {
                CodAuto = GrabarAutoxPresupuesto();
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            SqlCommand Comand = new SqlCommand();
            Comand.Connection = con;
            Comand.Transaction = Transaccion;
            string sqlCLiente = "";
            cPresupuesto presupuesto = new cPresupuesto();
            string Numero = "";
            cReportePresupuesto repPre = new cReportePresupuesto();
            try
            {
                sqlCLiente = GetSqlClientes();
                Comand.CommandText = sqlCLiente;
                Comand.ExecuteNonQuery();
                CodCliente = Convert.ToInt32(txtCodCLiente.Text);
                if (GrabaClienteNuevo == true)
                {
                    SqlCommand comand2 = new SqlCommand();
                    comand2.Connection = con;
                    comand2.Transaction = Transaccion;
                    comand2.CommandText = "select max(CodCliente) as CodCliente from Cliente";
                    txtCodCLiente.Text = comand2.ExecuteScalar().ToString();
                    CodCliente = Convert.ToInt32(txtCodCLiente.Text);
                }
                string Auto = cmbMarca.Text + " " + txtDescripcion.Text;
                if (cmbColor.SelectedIndex > 0)
                {
                    Auto = Auto + " " + cmbColor.Text;
                }

                if (cmbAnio.SelectedIndex > 0)
                {
                    Auto = Auto + " " + cmbAnio.Text;
                }

                string PrecioAuto = "$ " + txtPrecioVenta.Text;
                string NombreGasto = "          ";
                string sImporteGasto = "";
                Double ImporteEfectivo = 0;

                if (txtEfectivoPresupuesto.Text != "")
                    ImporteEfectivo = fun.ToDouble(txtEfectivoPresupuesto.Text);

                if (txtCobranzaPresupuesto.Text != "")
                    Cobranza = fun.ToDouble(txtCobranzaPresupuesto.Text);

                if (txtChequePresupuesto.Text != "")
                    Cheque = fun.ToDouble(txtChequePresupuesto.Text);

                if (txtTransferenciaPresupuesto.Text != "")
                    Transferencia = fun.ToDouble(txtTransferenciaPresupuesto.Text);

                if (txtDocumentoPresupuesto.Text != "")
                    Documento = fun.ToDouble(txtDocumentoPresupuesto.Text);

                //grabo el presupuesto

                CodPresupuesto = presupuesto.Insertar(con, Transaccion, CodAuto, CodCliente, Fecha, Total, sTotal, ImporteEfectivo, Cheque, Cobranza, Transferencia, Documento);
                Numero = presupuesto.GetNumeroPresupueseto(CodPresupuesto);
                presupuesto.ActualizarNumero(con, Transaccion, CodPresupuesto, Numero);
                repPre.Insertar(con, Transaccion, CodPresupuesto, "Unidad", "", "", "",Orden);
                Orden = Orden + 1;
                repPre.Insertar(con, Transaccion, CodPresupuesto, Auto, "", "", PrecioAuto, Orden);
                Orden = Orden + 1;
                //grabo gastos de transferencia
                //grabo los gatos de transferencia
                for (int k = 0; k < GrillaGastos.Rows.Count - 1; k++)
                {

                    string CodGastoTransferencia = GrillaGastos.Rows[k].Cells[0].Value.ToString();
                    Double Importe = fun.ToDouble(GrillaGastos.Rows[k].Cells[3].Value.ToString());
                    TotalGastosTransferencia = TotalGastosTransferencia + Importe;
                    string sImporte = GrillaGastos.Rows[k].Cells[3].Value.ToString();
                    string sqlGastosTransferencia = "";
                    sqlGastosTransferencia = "insert into GastosTransferenciaPresupuesto(CodPresupuesto,CodGastoTranasferencia,Importe,sImporte)";
                    sqlGastosTransferencia = sqlGastosTransferencia + "values(";
                    sqlGastosTransferencia = sqlGastosTransferencia + CodPresupuesto.ToString();
                    sqlGastosTransferencia = sqlGastosTransferencia + "," + CodGastoTransferencia;
                    sqlGastosTransferencia = sqlGastosTransferencia + "," + Importe.ToString();
                    sqlGastosTransferencia = sqlGastosTransferencia + "," + "'" + sImporte + "'";
                    sqlGastosTransferencia = sqlGastosTransferencia + ")";
                    SqlCommand ComandTransferencia = new SqlCommand();
                    ComandTransferencia.Connection = con;
                    ComandTransferencia.Transaction = Transaccion;
                    ComandTransferencia.CommandText = sqlGastosTransferencia;
                    ComandTransferencia.ExecuteNonQuery();

                    NombreGasto = GrillaGastos.Rows[k].Cells[1].Value.ToString();
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", NombreGasto, "", sImporte,Orden);
                    Orden = Orden + 1;

                }
                Double ImporteAuto = fun.ToDouble(txtTotalVehiculoPartePago.Text);
                Double Saldo = 0;
                Double Subtotal = 0;
                Total  = Total + TotalGastosTransferencia;
                Saldo = Total - ImporteAuto;

                string sImporteSubtotal = "";
                sImporteSubtotal = "$ " + fun.FormatoEnteroMiles(Total.ToString());
                repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Subtotal", sImporteSubtotal,Orden);
                Orden = Orden + 1;
                Int32 CodAutoPartePago = 0;
                Double ImpoteCompraAuto = 0;
                string NombreAuto = "";
                CPresupuestoxAuto preAuto = new CPresupuestoxAuto();
                string sqlGastoRecepcion = "";
                Double SubtotalGastoRecepcion = 0;
                //grabo los autos en parte de pago para presupuestar
                for (int k = 0; k < GrillaVehiculos.Rows.Count - 1; k++)
                {
                    CodAutoPartePago = Convert.ToInt32(GrillaVehiculos.Rows[k].Cells[0].Value.ToString());
                    string sImporteCompra = "$ " + GrillaVehiculos.Rows[k].Cells[4].Value.ToString();
                    ImpoteCompraAuto = fun.ToDouble(GrillaVehiculos.Rows[k].Cells[4].Value.ToString());
                    SubtotalGastoRecepcion = ImpoteCompraAuto;
                    preAuto.Insertar(con, Transaccion, CodPresupuesto, CodAutoPartePago, ImpoteCompraAuto);
                    NombreAuto = DescripcionAuto(CodAutoPartePago);
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "Entrega Unidad", "", "", "",Orden);
                    Orden = Orden + 1;
                    repPre.Insertar(con, Transaccion, CodPresupuesto, NombreAuto, "", "", sImporteCompra,Orden);
                    Orden = Orden + 1;

                    for (int i = 0; i < GrillaGastosRecepcion.Rows.Count - 1; i++)
                    {
                        string sDescripcion = GrillaGastosRecepcion.Rows[i].Cells[1].Value.ToString();
                        string sImporteGastoRecepcion = "$ " + GrillaGastosRecepcion.Rows[i].Cells[3].Value.ToString();
                        
                        ImporteGastoRecep = fun.ToDouble(GrillaGastosRecepcion.Rows[i].Cells[3].Value.ToString());
                        SubtotalGastoRecepcion = SubtotalGastoRecepcion + ImporteGastoRecep;
                        sqlGastoRecepcion = "Insert into PresupuestoGastosPagar(CodPresupuesto,CodAuto,Descripcion,Importe)";
                        sqlGastoRecepcion = sqlGastoRecepcion + " Values(" + CodPresupuesto.ToString();
                        sqlGastoRecepcion = sqlGastoRecepcion + "," + GrillaGastosRecepcion.Rows[i].Cells[4].Value.ToString();
                        sqlGastoRecepcion = sqlGastoRecepcion + "," + "'" + GrillaGastosRecepcion.Rows[i].Cells[1].Value.ToString() + "'";
                        sqlGastoRecepcion = sqlGastoRecepcion + "," + fun.ToDouble(ImporteGastoRecep.ToString()).ToString().Replace(",", ".");
                        sqlGastoRecepcion = sqlGastoRecepcion + ")";
                        repPre.Insertar(con, Transaccion, CodPresupuesto, "", sDescripcion, "", sImporteGastoRecepcion,Orden);
                        Orden = Orden + 1;

                        SqlCommand ComandRecepcion = new SqlCommand();
                        ComandRecepcion.Connection = con;
                        ComandRecepcion.Transaction = Transaccion;
                        ComandRecepcion.CommandText = sqlGastoRecepcion;
                        ComandRecepcion.ExecuteNonQuery();
                    }
                    sImporteSubtotal = "$ " + fun.FormatoEnteroMiles(SubtotalGastoRecepcion.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Subtotal", sImporteSubtotal,Orden);
                    Orden = Orden + 1;
                }
                //verificar que no esta restando bien
                // el SubtotalGastoRecepcion
                //INSERTO LA FICHA EN BLANCO
                repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "", "",Orden);
                Orden = Orden + 1;
                Total = CalcularTotalPresupuesto();
                sTotal = "$ " + fun.FormatoEnteroMiles(Total.ToString());
                repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Saldo", sTotal, Orden);
                Orden = Orden + 1;
                //Grabo la forma de pago
                repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "", "",Orden);
                Orden = Orden + 1;
                // repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "SubTotal", "");
                if (ImporteEfectivo > 0)
                {
                    string sImporteefectivo = "$ " + fun.FormatoEnteroMiles(ImporteEfectivo.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "Efectivo", "", sImporteefectivo,Orden);
                    Orden = Orden + 1;
                    Saldo = CalcularTotalSaldoPresupuesto();
                    string sSaldo = "$ " + fun.FormatoEnteroMiles(Saldo.ToString());
                    //   repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Saldo",sSaldo);
                }

                if (Cheque > 0)
                {
                    string sImporteeCheque = "$ " + fun.FormatoEnteroMiles(Cheque.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "Cheque", "", sImporteeCheque, Orden);
                    Orden = Orden + 1; 
                    Saldo = CalcularTotalSaldoPresupuesto();
                    string sSaldo = "$ " + fun.FormatoEnteroMiles(Saldo.ToString());
                    //   repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Saldo",sSaldo);
                }

              

                if (Transferencia > 0)
                {
                    string sImporteeTransferencia = "$ " + fun.FormatoEnteroMiles(Transferencia.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "Transferencia", "", sImporteeTransferencia,Orden);
                    Orden = Orden + 1;
                    Saldo = CalcularTotalSaldoPresupuesto();
                    string sSaldo = "$ " + fun.FormatoEnteroMiles(Saldo.ToString());
                    //   repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Saldo",sSaldo);
                }

                if (Documento > 0)
                {
                    string sImporteeDocumento = "$ " + fun.FormatoEnteroMiles(Documento.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "Documento", "", sImporteeDocumento,Orden);
                    Orden = Orden + 1;
                    Saldo = CalcularTotalSaldoPresupuesto();
                    string sSaldo = "$ " + fun.FormatoEnteroMiles(Saldo.ToString());
                }

                if (Cobranza > 0)
                {
                    string sImporteeCobranza = "$ " + fun.FormatoEnteroMiles(Cobranza.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "A Pagar", "", sImporteeCobranza, Orden);
                    Saldo = CalcularTotalSaldoPresupuesto();
                    string sSaldo = "$ " + fun.FormatoEnteroMiles(Saldo.ToString());
                    //   repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "A",sSaldo);
                }

                if (Saldo > 0)
                {
                    string sSaldo = "$ " + fun.FormatoEnteroMiles(Saldo.ToString());
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "", "Saldo", sSaldo,Orden);
                    Orden = Orden + 1;
                }

                //grabo el plan de cuotas
                if (tbFinaciacionCuota.Rows.Count > 0)
                {
                    repPre.Insertar(con, Transaccion, CodPresupuesto, "", "Financiación", "", "",Orden);
                    Orden = Orden + 1;
                    for (int f = 0; f < tbFinaciacionCuota.Rows.Count; f++)
                    {
                        string Nombre = tbFinaciacionCuota.Rows[f]["Nombre"].ToString();
                        string Precio = "$ " + tbFinaciacionCuota.Rows[f]["Importe"].ToString();
                        repPre.Insertar(con, Transaccion, CodPresupuesto, "", Nombre, Precio, "",Orden);
                        Orden = Orden + 1;
                    }
                }
                if (txtTotalDocumentos.Text != "")
                {
                    //grabo las cuotas
                    string Cuota = "";
                    string ImporteCuota = "";
                    string FechaVecimiento = "";
                    string ImporteSinInteres = "";
                    string sqlInsertCuota = "";
                    for (int i = 0; i < GrillaCuotas.Rows.Count - 1; i++)
                    {
                        Cuota = GrillaCuotas.Rows[i].Cells[0].Value.ToString();
                        ImporteCuota = GrillaCuotas.Rows[i].Cells[1].Value.ToString();
                        FechaVecimiento = GrillaCuotas.Rows[i].Cells[2].Value.ToString();
                        ImporteSinInteres = GrillaCuotas.Rows[i].Cells[3].Value.ToString();
                        sqlInsertCuota = "Insert into CuotasPresupuesto(CodPresupuesto,Cuota,Importe,FechaVencimiento,Saldo,ImporteSinInteres)";
                        sqlInsertCuota = sqlInsertCuota + " values (";
                        sqlInsertCuota = sqlInsertCuota + CodPresupuesto.ToString();
                        sqlInsertCuota = sqlInsertCuota + "," + Cuota;
                        sqlInsertCuota = sqlInsertCuota + "," + ImporteCuota;
                        sqlInsertCuota = sqlInsertCuota + "," + "'" + FechaVecimiento + "'";
                        sqlInsertCuota = sqlInsertCuota + "," + ImporteCuota;
                        sqlInsertCuota = sqlInsertCuota + "," + ImporteSinInteres;
                        sqlInsertCuota = sqlInsertCuota + ")";
                        SqlCommand comandCuota = new SqlCommand();
                        comandCuota.Connection = con;
                        comandCuota.Transaction = Transaccion;
                        comandCuota.CommandText = sqlInsertCuota;
                        comandCuota.ExecuteNonQuery();
                    }
                    string PlanCuotas = Cuota.ToString() + " Cuotas de $" + fun.FormatoEnteroMiles(ImporteCuota.ToString());
                    Double TotalCuotas = 0;
                    TotalCuotas = Convert.ToDouble(txtTotalDocumentos.Text);
                    string sTtotalCuotas = "$ " + fun.FormatoEnteroMiles(TotalCuotas.ToString());
                    //  repPre.Insertar(con, Transaccion, CodPresupuesto, "", PlanCuotas, "", sTtotalCuotas);
                }
                Transaccion.Commit();
                con.Close();
                CodCliente = Convert.ToInt32(txtCodCLiente.Text);
                
                Mensaje("Presupuesto grabado correctamente");
                LimpiarPresupuesto();
              //  LimpiarPantalla();
                Principal.CodPresupuesto = CodPresupuesto;
                FrmReportePresupuesto form = new FrmReportePresupuesto();
                form.Show();
                Principal.CodPresupuesto = null;
                
            }
            catch (Exception ex)
            {
                Mensaje("Hubo un error en el proceso Grabacion");
                Transaccion.Rollback();
                con.Close();
            }
        }

        private void LimpiarPresupuesto()
        {
            tbFinaciacionCuota.Rows.Clear();
            GrillaFinanciacionCuota.DataSource = tbFinaciacionCuota;
        }

        private Double CalcularTotalPresupuesto()
        {
            cFunciones fun = new Clases.cFunciones();
            Double PrecioAuto = 0;
            Double TotalGasto = 0;
            Double AutoPartePago = 0;
            Double GastoRecepcion = 0;
            Double Total = 0;

            if (txtPrecioVenta.Text != "")
                PrecioAuto = fun.ToDouble(txtPrecioVenta.Text);

            if (txtTotalGasto.Text != "")
            {
                TotalGasto = fun.ToDouble(txtTotalGasto.Text);
            }

            if (txtTotalVehiculoPartePago.Text != "")
                AutoPartePago = fun.ToDouble(txtTotalVehiculoPartePago.Text);

            if (txtTotalGastosRecepcion.Text != "")
                GastoRecepcion = fun.ToDouble(txtTotalGastosRecepcion.Text);

            Total = PrecioAuto + TotalGasto - AutoPartePago + GastoRecepcion;
            return Total;

        }

        private Double CalcularTotalSaldoPresupuesto()
        {
            cFunciones fun = new Clases.cFunciones();
            Double PrecioAuto = 0;
            Double TotalGasto = 0;
            Double AutoPartePago = 0;
            Double GastoRecepcion = 0;
            Double Efectivo = 0;
            Double Saldo = 0;
            Double Cobranza = 0;
            Double Cheque = 0;
            Double Transferencia = 0;
            Double Documento = 0;

            if (txtImporteCompra.Text != "")
                PrecioAuto = fun.ToDouble(txtPrecioVenta.Text);

            if (txtTotalGasto.Text != "")
            {
                TotalGasto = fun.ToDouble(txtTotalGasto.Text);
            }

            if (txtTotalVehiculoPartePago.Text != "")
                AutoPartePago = fun.ToDouble(txtTotalVehiculoPartePago.Text);

            if (txtTotalGastosRecepcion.Text != "")
                GastoRecepcion = fun.ToDouble(txtTotalGastosRecepcion.Text);

            if (txtEfectivoPresupuesto.Text != "")
                Efectivo = fun.ToDouble(txtEfectivoPresupuesto.Text);

            if (txtCobranzaPresupuesto.Text != "")
                Cobranza = fun.ToDouble(txtCobranzaPresupuesto.Text);

            if (txtChequePresupuesto.Text != "")
                Cheque = fun.ToDouble(txtChequePresupuesto.Text);

            if (txtTransferenciaPresupuesto.Text != "")
                Transferencia = fun.ToDouble(txtTransferenciaPresupuesto.Text);

            if (txtDocumentoPresupuesto.Text != "")
                Documento = fun.ToDouble(txtDocumentoPresupuesto.Text);

            Saldo = PrecioAuto + TotalGasto - AutoPartePago + GastoRecepcion - Efectivo - Cobranza - Cheque - Transferencia; // - Documento;

            return Saldo;

        }

        private string DescripcionAuto(Int32 CodAuto)
        {
            string Descripcion = "";
            cAuto auto = new Clases.cAuto();
            DataTable tbAuto = auto.GetAutoxCodigo(CodAuto);
            if (tbAuto.Rows.Count > 0)
            {
                if (tbAuto.Rows[0]["CodAuto"].ToString() != "")
                {
                    Descripcion =   tbAuto.Rows[0]["Marca"].ToString();
                    Descripcion = Descripcion + " " + tbAuto.Rows[0]["Descripcion"].ToString();
                    
                    Descripcion = Descripcion + " " + tbAuto.Rows[0]["NombreColor"].ToString();
                    Descripcion = Descripcion + " " + tbAuto.Rows[0]["NombreAnio"].ToString();
                }
            }
            return Descripcion;

        }
        private Boolean ValidarPresupuesto()
        {
            Boolean op = true;
            if (txtDescripcion.Text == "")
            {
                Mensaje("Debe ingresar un modelo para continuar");
                return false;
            }
            if (cmbMarca.SelectedIndex < 1)
            {
                Mensaje("Debe seleccionar una marca para continuar");
                return false;
            }
            if (txtNombre.Text == "")
            {
                Mensaje("Debe ingresar un nombre de un cliente");
                return false;
            }
           
            return op;
        }

        private Int32 GrabarAutoxPresupuesto()
        {
            cFunciones fun = new cFunciones();
            cAuto auto = new cAuto();
            string Patente = "";
            Int32? CodMarca = null;
            string Descripcion;
            Int32? Kilometros = null;
            Int32? CodCiudad = null;
            int Propio = 0;
            int Concesion = 0;
            string Observacion = "";
            string Anio = "";
            Double? Importe = 0;
            string Motor = "";
            string Chasis = "";
            string Color = "";
            Int32? CodTipoCombustible = null;
            Int32? CodTipoUtilitario = null;
            Int32? CodAnio = null;
            Patente = txtPatente.Text;
            if (cmbMarca.SelectedIndex > 0)
            {
                CodMarca = Convert.ToInt32(cmbMarca.SelectedValue);
            }
            Descripcion = txtDescripcion.Text;

            Anio = "";
            if (txtKms.Text != "")
            {
                Kilometros = Convert.ToInt32(txtKms.Text);
            }

            if (cmbCiudad.SelectedIndex > 0)
            {
                CodCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
            }

            if (txtImporteCompra.Text != "")
            {
                Importe = fun.ToDouble(txtImporteCompra.Text);
            }

            if (cmbTipoUtilitario.SelectedIndex > 0)
            {
                CodTipoUtilitario = Convert.ToInt32(cmbTipoUtilitario.SelectedValue);
            }
            Motor = txtMotor.Text;
            Chasis = txtChasis.Text;
            Int32 CodAuto = 0;
            CodAuto = auto.AgregarAutoId(Patente, CodMarca, Descripcion, Kilometros,
                CodCiudad, Propio, Concesion, Observacion, Anio, Importe, Motor,
                Chasis, Color, CodTipoCombustible, CodTipoUtilitario, CodAnio
                );
            return CodAuto;
        }

        private void btnBuscarAuto_Click(object sender, EventArgs e)
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

        private void btnNuevaEntidadPrendaria_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodEntidad";
            Principal.CampoNombreSecundario = "Descripcion";
            Principal.NombreTablaSecundario = "EntidadPrendaria";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodTarjeta";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Tarjeta";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void LlenarFinanciacion()
        {
            cFunciones fun = new cFunciones();
            string sql = "select * from tipofinanciacion ";
            DataTable tb = cDb.ExecuteDataTable(sql);
            fun.LlenarComboDatatable(cmbFinanciacion, tb, "Nombre", "CodTipo");

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgregarFinanciacion_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            //tbFinaciacionCuota = fun.CrearTabla("CodTipo;Nombre");
            if (cmbFinanciacion.SelectedIndex < 1)
            {
                Mensaje("Debe seleccionar un tipo de financiación");
                return;
            }

            if (txtImporteCuota.Text == "")
            {
                Mensaje("Debe ingresar un importe para continuar");
                return;
            }

            string CodTipo = cmbFinanciacion.SelectedIndex.ToString();
            string Nombre = cmbFinanciacion.Text;
            string Importe = txtImporteCuota.Text;
            string val = CodTipo + ";" + Nombre + ";" + Importe;
            tbFinaciacionCuota = fun.AgregarFilas(tbFinaciacionCuota, val);
            GrillaFinanciacionCuota.DataSource = tbFinaciacionCuota;
            fun.AnchoColumnas(GrillaFinanciacionCuota, "0;60;40");
            txtImporteCuota.Text = "";
        }

        private void txtImporteCuota_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage20_Click(object sender, EventArgs e)
        {

        }

        private void GrillaFinanciacionCuota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPrecioVenta_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtImporteCuota_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtImporteCuota_Leave(object sender, EventArgs e)
        {
            Double Precio = 0;
            if (txtImporteCuota.Text != "")
            {
                Precio = Convert.ToDouble(txtImporteCuota.Text);
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteCuota.Text = fun.FormatoEnteroMiles(Precio.ToString());

            }
        }

        private void btnQuitarFinanciacion_Click(object sender, EventArgs e)
        {
            if (GrillaFinanciacionCuota.CurrentRow == null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            string CodTipo = GrillaFinanciacionCuota.CurrentRow.Cells[0].Value.ToString();
            cFunciones fun = new cFunciones();
            tbFinaciacionCuota = fun.EliminarFila(tbFinaciacionCuota, "CodTipo", CodTipo);
            GrillaFinanciacionCuota.DataSource = tbFinaciacionCuota;
            fun.AnchoColumnas(GrillaFinanciacionCuota, "0;60;40");

        }

        private void btnNuevaTipoFinanciacion_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodTipo";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "tipofinanciacion";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void txtEfectivoPresupuesto_Leave(object sender, EventArgs e)
        {
            Double Efectivo = 0;

            if (txtEfectivoPresupuesto.Text != "")
            {
                Efectivo = Convert.ToDouble(txtEfectivoPresupuesto.Text);
                Clases.cFunciones fun = new Clases.cFunciones();
                txtEfectivoPresupuesto.Text = fun.FormatoEnteroMiles(Efectivo.ToString());
                CalcularSubTotal();
            }
        }

        private void txtChequePresupuesto_Leave(object sender, EventArgs e)
        {
            Double Cheque = 0;

            if (txtChequePresupuesto.Text != "")
            {
                Cheque = Convert.ToDouble(txtChequePresupuesto.Text);
                Clases.cFunciones fun = new Clases.cFunciones();
                txtChequePresupuesto.Text = fun.FormatoEnteroMiles(Cheque.ToString());
                CalcularSubTotal();
            }
        }

        private void txtCobranzaPresupuesto_Leave(object sender, EventArgs e)
        {
            Double Cobranza = 0;

            if (txtCobranzaPresupuesto.Text != "")
            {
                Cobranza = Convert.ToDouble(txtCobranzaPresupuesto.Text);
                Clases.cFunciones fun = new Clases.cFunciones();
                txtCobranzaPresupuesto.Text = fun.FormatoEnteroMiles(Cobranza.ToString());
                CalcularSubTotal();
            }
        }

        private void txtTransferenciaPresupuesto_Leave(object sender, EventArgs e)
        {
            Double Transferencia = 0;

            if (txtTransferenciaPresupuesto.Text != "")
            {
                Transferencia = Convert.ToDouble(txtTransferenciaPresupuesto.Text);
                Clases.cFunciones fun = new Clases.cFunciones();
                txtTransferenciaPresupuesto.Text = fun.FormatoEnteroMiles(Transferencia.ToString());
                CalcularSubTotal();
            }
        }

        private void txtDocumentoPresupuesto_Leave(object sender, EventArgs e)
        {
            Double Documento = 0;

            if (txtDocumentoPresupuesto.Text != "")
            {
                Documento = Convert.ToDouble(txtDocumentoPresupuesto.Text);
                Clases.cFunciones fun = new Clases.cFunciones();
                txtDocumentoPresupuesto.Text = fun.FormatoEnteroMiles(Documento.ToString());
                CalcularSubTotal();
            }
        }

        private void AnularVenta(string CodVenta)
        {
            // string Patente = Grilla.CurrentRow.Cells[4].Value.ToString();
            //string CodVenta = Grilla.CurrentRow.Cells[0].Value.ToString();

            string Patente = txtPatente.Text;
            Int32 CodAutoPartePago1 = 0;
            Int32 CodAutoPartePago2 = 0;
            double ImportePagadoCobranza = 0;
            double ImportePagadoCuotas = 0;
            double ImportePagadoPrenda = 0;
            double ImportePagadoCheque = 0;

            Clases.cVenta objVenta2 = new Clases.cVenta();
            Clases.cCobranza cobranza = new Clases.cCobranza();
            Clases.cPrenda prenda = new Clases.cPrenda();
            ImportePagadoCobranza = cobranza.GetImportePagado(Convert.ToInt32(CodVenta));
            Clases.cCuota cuota = new Clases.cCuota();
            Clases.cCheque cheque = new Clases.cCheque();
            ImportePagadoCuotas = cuota.ImportePagado(Convert.ToInt32(CodVenta));
            ImportePagadoPrenda = prenda.ImportePagado(Convert.ToInt32(CodVenta));
            ImportePagadoCheque = cheque.ImportePagado(Convert.ToInt32(CodVenta));
            DataTable tresult2 = objVenta2.GetAutosPartePago(Convert.ToInt32(CodVenta));
            for (int z = 0; z < tresult2.Rows.Count; z++)
            {
                if (z == 0)
                {
                    if (tresult2.Rows[0]["CodAuto"].ToString() != "")
                    {
                        CodAutoPartePago1 = Convert.ToInt32(tresult2.Rows[0]["CodAuto"].ToString());
                    }
                }

                if (z == 1)
                {
                    if (tresult2.Rows[0]["CodAuto"].ToString() != "")
                    {
                        CodAutoPartePago2 = Convert.ToInt32(tresult2.Rows[0]["CodAuto"].ToString());
                    }
                }
            }

            double ImporteAutoPartePago = 0;
            double ImporteCredito = 0;
            double ImporteEfectivo = 0;
            double ImportePrenda = 0;
            double ImporteCobranza = 0;
            double ImporteBanco = 0;
            double CodAutoVendido = -1;
            double CodAutoPartePago = -1;
            double ImporteAutoNegativo = 0;
            double ImporteSenia = 0;

            Clases.cVenta objVenta = new Clases.cVenta();

            if (CodVenta != "")
            {
                Clases.cMovimiento objMov = new Clases.cMovimiento();
                ImporteAutoNegativo = objMov.GetImporteAutoNegativoxCodVenta(Convert.ToInt32(CodVenta));
                ImporteAutoNegativo = -1 * ImporteAutoNegativo;

                DataTable trdo = objVenta.GetVentaxCodigo(Convert.ToInt32(CodVenta));
                if (trdo.Rows.Count > 0)
                {
                    ImporteCredito = Convert.ToDouble(trdo.Rows[0]["ImporteCredito"].ToString());
                    ImporteEfectivo = Convert.ToDouble(trdo.Rows[0]["ImporteEfectivo"].ToString());
                    ImportePrenda = Convert.ToDouble(trdo.Rows[0]["ImportePrenda"].ToString());
                    ImporteCobranza = Convert.ToDouble(trdo.Rows[0]["ImporteCobranza"].ToString());
                    if (trdo.Rows[0]["PrecioSenia"].ToString() != "")
                        ImporteSenia = Convert.ToDouble(trdo.Rows[0]["PrecioSenia"].ToString());
                    ImporteEfectivo = ImporteEfectivo + ImporteSenia;
                    if (trdo.Rows[0]["CodAutoVendido"].ToString() != "")
                    {
                        CodAutoVendido = Convert.ToInt32(trdo.Rows[0]["CodAutoVendido"].ToString());
                    }

                    if (trdo.Rows[0]["CodAutoPartePago"].ToString() != "")
                    {
                        CodAutoPartePago = Convert.ToInt32(trdo.Rows[0]["CodAutoPartePago"].ToString());
                    }

                    if (trdo.Rows[0]["ImporteAutoPartePago"].ToString() != "")
                    {
                        ImporteAutoPartePago = Convert.ToDouble(trdo.Rows[0]["ImporteAutoPartePago"].ToString());
                    }

                    if (trdo.Rows[0]["ImporteBanco"].ToString() != "")
                    {
                        ImporteBanco = Convert.ToDouble(trdo.Rows[0]["ImporteBanco"].ToString());
                    }
                }

                //importe total del credito en documentos usado mas abajo
                double ImporteTotalDocumento = 0;
                Clases.cCuota objCuotas = new Clases.cCuota();
                ImporteTotalDocumento = objCuotas.GetSaldoDeudaCuotas(Convert.ToInt32(CodVenta));
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Clases.cConexion.Cadenacon();
                con.Open();
                SqlTransaction Transaccion;
                Transaccion = con.BeginTransaction();
                SqlCommand Comand = new SqlCommand();
                Comand.Connection = con;
                Comand.Transaction = Transaccion;
                try
                {
                    //vuelvo el auto al stock
                    //string sql = "insert into StockAuto(CodAuto,FechaAlta,CodUsuario)";
                    //sql = sql + " values(" + CodAutoVendido.ToString();
                    //sql = sql + "," + "'" + DateTime.Now.ToShortDateString() + "'";
                    //sql = sql + "," + Principal.CodUsuarioLogueado;
                    //sql = sql + ")";
                    string sql = "update StockAuto  set FechaBaja = null";
                    sql = sql + " where CodStock=";
                    sql = sql + " (select max(CodStock) from StockAuto sa ";
                    sql = sql + " where sa.CodAuto =" + CodAutoVendido.ToString();
                    sql = sql + ")";
                    Comand.CommandText = sql;
                    Comand.ExecuteNonQuery();
                    //si pago con un auto le doy de baja
                    if (CodAutoPartePago > 0)
                    {
                        SqlCommand Comand2 = new SqlCommand();
                        Comand2.Connection = con;
                        Comand2.Transaction = Transaccion;
                        string sqlStock = "update StockAuto";
                        sqlStock = sqlStock + " set FechaBaja =" + "'" + DateTime.Now.ToShortDateString() + "'";
                        sqlStock = sqlStock + " where CodAuto =" + CodAutoPartePago;
                        Comand2.CommandText = sqlStock;
                        Comand2.ExecuteNonQuery();
                    }
                    //borro la venta
                    string sql3 = "delete from venta where CodVenta=" + CodVenta.ToString();
                    SqlCommand Comand3 = new SqlCommand();
                    Comand3.Connection = con;
                    Comand3.Transaction = Transaccion;
                    Comand3.CommandText = sql3;
                    Comand3.ExecuteNonQuery();

                    //borro las cuotas

                    string sql4 = "delete from cuotas where CodVenta=" + CodVenta.ToString();
                    SqlCommand Comand4 = new SqlCommand();
                    Comand4.Connection = con;
                    Comand4.Transaction = Transaccion;
                    Comand4.CommandText = sql4;
                    Comand4.ExecuteNonQuery();

                    //borro la prenda

                    string sqlPrenda = "delete from Prenda where CodVenta=" + CodVenta.ToString();
                    SqlCommand ComandPrenda = new SqlCommand();
                    ComandPrenda.Connection = con;
                    ComandPrenda.Transaction = Transaccion;
                    ComandPrenda.CommandText = sqlPrenda;
                    ComandPrenda.ExecuteNonQuery();

                    //borro los cheques

                    string sqlCheque = "delete from Cheque where CodVenta=" + CodVenta.ToString();
                    SqlCommand ComandCheque = new SqlCommand();
                    ComandCheque.Connection = con;
                    ComandCheque.Transaction = Transaccion;
                    ComandCheque.CommandText = sqlCheque;
                    ComandCheque.ExecuteNonQuery();

                    //si hubo un saldo de cobranza tb lo anulo
                    //ya que significa que habia pagado una cobranza
                    //y debo volver a sacar el efectivo cobrado

                    //borro las cobranzas

                    string sqlCobranza = "delete from Cobranza where CodVenta=" + CodVenta.ToString();
                    SqlCommand ComandCobranza = new SqlCommand();
                    ComandCobranza.Connection = con;
                    ComandCobranza.Transaction = Transaccion;
                    ComandCobranza.CommandText = sqlCobranza;
                    ComandCobranza.ExecuteNonQuery();



                    //borro las comisiones
                    if (ImportePagadoCobranza > 0)
                    {
                        //vuelvo el efectivo atraz
                        ImporteEfectivo = ImporteEfectivo + ImportePagadoCobranza;
                        //
                    }

                    if (ImportePagadoCuotas > 0)
                        ImporteEfectivo = ImporteEfectivo + ImportePagadoCuotas;

                    if (ImportePagadoPrenda > 0)
                        ImporteEfectivo = ImporteEfectivo + ImportePagadoPrenda;

                    if (ImportePagadoCheque > 0)
                        ImporteEfectivo = ImporteEfectivo + ImportePagadoCheque;

                    string sqlComision = "delete from ComisionVendedor where CodVenta=" + CodVenta.ToString();
                    SqlCommand ComandComision = new SqlCommand();
                    ComandComision.Connection = con;
                    ComandComision.Transaction = Transaccion;
                    ComandComision.CommandText = sqlComision;
                    ComandComision.ExecuteNonQuery();

                    //Inserto el movimiento con los valores opuesto
                    ImporteCredito = ImporteCredito * (-1);
                    ImporteTotalDocumento = ImporteTotalDocumento * (-1);
                    ImporteEfectivo = ImporteEfectivo * (-1);
                    ImportePrenda = ImportePrenda * (-1);
                    ImporteCobranza = ImporteCobranza * (-1);
                    ImporteBanco = ImporteBanco * (-1);
                    ImporteAutoPartePago = (-1) * ImporteAutoPartePago;


                    string Descrip = "ANULACION VENTA " + Patente.ToString();
                    string sql5 = "Insert into Movimiento(ImporteDocumento,ImporteEfectivo";
                    sql5 = sql5 + ",ImportePrenda,ImporteCobranza,CodUsuario,Fecha,ImporteAuto,ImporteBanco,Descripcion)";
                    sql5 = sql5 + "Values(" + ImporteTotalDocumento.ToString().Replace(",", ".");
                    sql5 = sql5 + "," + ImporteEfectivo.ToString().Replace(",", ".");
                    sql5 = sql5 + "," + ImportePrenda.ToString().Replace(",", ".");
                    sql5 = sql5 + "," + ImporteCobranza.ToString().Replace(",", ".");
                    sql5 = sql5 + "," + Principal.CodUsuarioLogueado.ToString();
                    sql5 = sql5 + "," + "'" + DateTime.Now.ToShortDateString() + "'";
                    sql5 = sql5 + "," + ImporteAutoPartePago.ToString().Replace(",", ".");
                    sql5 = sql5 + "," + ImporteBanco.ToString().Replace(",", ".");
                    sql5 = sql5 + "," + "'" + Descrip + "'";
                    sql5 = sql5 + ")";
                    //finalmente inserto el movimiento opuesto
                    //para que vuelva el valor de la cuenta vehiculo
                    SqlCommand Comand5 = new SqlCommand();
                    Comand5.Connection = con;
                    Comand5.Transaction = Transaccion;
                    Comand5.CommandText = sql5;
                    Comand5.ExecuteNonQuery();

                    string sql5b = "Insert into Movimiento(ImporteDocumento,ImporteEfectivo";
                    sql5b = sql5b + ",ImportePrenda,ImporteCobranza,CodUsuario,Fecha,ImporteAuto,ImporteBanco)";
                    sql5b = sql5b + "Values(" + ImporteTotalDocumento.ToString().Replace(",", ".");
                    sql5b = sql5b + ",0";
                    sql5b = sql5b + ",0";
                    sql5b = sql5b + ",0";
                    sql5b = sql5b + "," + Principal.CodUsuarioLogueado.ToString();
                    sql5b = sql5b + "," + "'" + DateTime.Now.ToShortDateString() + "'";
                    sql5b = sql5b + "," + ImporteAutoNegativo.ToString().Replace(",", ".");
                    sql5b = sql5b + ",0";
                    sql5b = sql5b + ")";
                    //finalmente inserto el movimiento opuesto del auto
                    //para que vuelva el valor de la cuenta vehiculo
                    SqlCommand Comand5b = new SqlCommand();
                    Comand5b.Connection = con;
                    Comand5b.Transaction = Transaccion;
                    Comand5b.CommandText = sql5b;
                    Comand5b.ExecuteNonQuery();

                    string sql6 = "delete from VentasxAuto where CodVenta =" + CodVenta.ToString();
                    SqlCommand Comand6 = new SqlCommand();
                    Comand6.Connection = con;
                    Comand6.Transaction = Transaccion;
                    Comand6.CommandText = sql6;
                    Comand6.ExecuteNonQuery();

                    string sql7 = "delete from GastosPagar where CodVenta =" + CodVenta.ToString();
                    SqlCommand Comand7 = new SqlCommand();
                    Comand7.Connection = con;
                    Comand7.Transaction = Transaccion;
                    Comand7.CommandText = sql7;
                    Comand7.ExecuteNonQuery();

                    string SQL9 = "delete from Transferencia where CodVenta =" + CodVenta.ToString();
                    SqlCommand Comand9 = new SqlCommand();
                    Comand9.Connection = con;
                    Comand9.Transaction = Transaccion;
                    Comand9.CommandText = SQL9;
                    Comand9.ExecuteNonQuery();

                    // doy de baja los autos del stock que ingresaron
                    // como parte de pago
                    if (CodAutoPartePago1 > 0)
                    {
                        string sql8 = "update StockAuto set FechaBaja=" + "'" + DateTime.Now.ToShortDateString() + "'";
                        sql8 = sql8 + " where CodAuto=" + CodAutoPartePago1.ToString();
                        SqlCommand Comand8 = new SqlCommand();
                        Comand8.Connection = con;
                        Comand8.Transaction = Transaccion;
                        Comand8.CommandText = sql8;
                        Comand8.ExecuteNonQuery();
                    }

                    Transaccion.Commit();
                    con.Close();

                }
                catch (Exception ex)
                {
                    Transaccion.Rollback();
                    MessageBox.Show("Hubo un error en el proceso de anulación de venta", Clases.cMensaje.Mensaje());
                }
            }
        }

        private void btnAgregarTransferencia_Click(object sender, EventArgs e)
        {
            if (txtImporteTransferencia.Text =="")
            {
                Mensaje("Debe ingresar un importe");
                return;
            }

            if (txtNumeroTransferencia.Text =="")
            {
                Mensaje("Debe ingresar un Número de transferencia");
                return;
            }

            if (cmbBancoTransferencia.SelectedIndex <1)
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
            string Val = "";
            Val = CodBanco.ToString();
            Val = Val + ";" + Nombre;
            Val = Val + ";" + Nro;
            Val = Val + ";" + sImporte;
            tbTransferencia = fun.AgregarFilas(tbTransferencia, Val);
           // tbTransferencia = fun.TablaaMiles(tbTransferencia, "Importe");
            GrillaTransferencia.DataSource = tbTransferencia;
            fun.AnchoColumnas(GrillaTransferencia, "0;40;30;30");
            txtImporteTransferencia.Text = "";
            txtNumeroTransferencia.Text = "";
            Double Transferencia = 0;
            Transferencia = fun.TotalizarColumna(tbTransferencia, "Importe");
            Double Efectivo = 0;
            if (txtTotalEfectivo.Text == "")
                txtTotalEfectivo.Text = "0";
            if (Importe > 0)
            {
                if (txtTotalEfectivo.Text !="")
                {
                    Efectivo = fun.ToDouble(txtTotalEfectivo.Text);
                    Efectivo = Efectivo + Importe;
                    txtTotalEfectivo.Text = fun.FormatoEnteroMiles(Efectivo.ToString());
                }
               // Subtotal = Subtotal + Transferencia;
            }
            CalcularSubTotal();
        }

        private void txtImporteTransferencia_Leave(object sender, EventArgs e)
        {   
            if (txtImporteTransferencia.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteTransferencia.Text = fun.FormatoEnteroMiles(txtImporteTransferencia.Text);
            }
        }

        private void btnquitarTransferencia_Click(object sender, EventArgs e)
        {
            if (GrillaTransferencia.CurrentRow==null)
            {
                Mensaje("Debe seleccionar un elemento");
                return;
            }
            cFunciones fun = new cFunciones();
            Double Importe = fun.ToDouble(GrillaTransferencia.CurrentRow.Cells[3].Value.ToString());
            string Numero = GrillaTransferencia.CurrentRow.Cells["Numero"].Value.ToString ();
           
            tbTransferencia = fun.EliminarFila(tbTransferencia, "Numero", Numero);
            Double Transferencia = 0;
            Transferencia = fun.TotalizarColumna(tbTransferencia, "Importe");
           
            Double Efectivo = 0;
            if (txtTotalEfectivo.Text != "")
            {
                Efectivo = fun.ToDouble(txtTotalEfectivo.Text);
                Efectivo = Efectivo - Importe;
                txtTotalEfectivo.Text = fun.FormatoEnteroMiles(Efectivo.ToString());
            }
            CalcularSubTotal();
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumento.SelectedIndex >0)
            {
                int CodTipoDoc = Convert.ToInt32(cmbDocumento.SelectedValue);
                OcultarTipoDoc(CodTipoDoc);
            }
        }

        private void OcultarTipoDoc(int CodTipo)
        {
            switch(CodTipo)
            {
                case 1:
                    lblNombre.Text = "Nombre";
                    txtApellido.Visible = true;
                    break;
                case 2:
                    lblNombre.Text = "Razón Social";
                    txtApellido.Visible = false;
                    break;
                case 3:
                    lblNombre.Text = "Razón Social";
                    txtApellido.Visible = false;
                    break;

            }
            
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
            BuscarClientexCodigo(CodCliente);
        }
    }
}




