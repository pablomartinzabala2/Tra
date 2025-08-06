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
    public partial class FrmListadoVentas : Form
    {
        public FrmListadoVentas()
        {
            InitializeComponent();
            InicializarFechas();
            txtTotal.BackColor = cColor.CajaTexto();
            txtCantidadVentas.BackColor = cColor.CajaTexto();
            CargarMarca();
            Buscar();
        }

        private void CargarMarca()
        {
            cFunciones fun = new cFunciones();
            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
        }

        private void InicializarFechas()
        {
            DateTime Fecha = DateTime.Now;
            int dia = Fecha.Day;
            int Mes = Fecha.Month;
            Fecha =Fecha.AddDays(-dia);
            Fecha = Fecha.AddDays(1);
            dpFechaDesde.Value = Fecha;
            Fecha = Fecha.AddMonths(1);
            Fecha = Fecha.AddDays(-1);
            dpFechaHasta.Value = Fecha;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            if (Convert.ToDateTime(dpFechaDesde.Value) > Convert.ToDateTime(dpFechaHasta.Value))
            {
                MessageBox.Show("La fecha desde debe ser inferior a la fecha hasta", Clases.cMensaje.Mensaje());
                return;
            }
            string Descripcion = txtModelo.Text.Trim();
            string Apellido = null;
            Int32? CodMarca = null;
            if (cmbMarca.SelectedIndex > 0)
                CodMarca = Convert.ToInt32(cmbMarca.SelectedValue);
            string Nombre = null;
            if (txtNombre.Text != "")
                Nombre = txtNombre.Text;
            if (txtApellido.Text != "")
                Apellido = txtApellido.Text;
            Clases.cVenta objVenta = new Clases.cVenta();
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            int OrdenDescendente = 0;
            if (chkOrden.Checked == true)
                OrdenDescendente = 1;
            else
                OrdenDescendente = 0;
            DataTable trdo = objVenta.GetVentasxFecha(FechaDesde, FechaHasta, txtPatente.Text.Trim(), Apellido, Nombre, CodMarca, Descripcion, OrdenDescendente);
            Clases.cPreVenta objPreVenta = new Clases.cPreVenta();

            DataTable trdo2 = objPreVenta.GetPreVentasxFecha(FechaDesde, FechaHasta, txtPatente.Text.Trim(), Apellido, Nombre);
            //le agre[g
            string Dato = "";
            Int32 PosPintar = 0;
            PosPintar = trdo.Rows.Count;
            for (int i = 0; i < trdo2.Rows.Count; i++)
            {
                DataRow fila;
                fila = trdo.NewRow();
                for (int j = 0; j < trdo2.Columns.Count; j++)
                {
                    Dato = trdo2.Rows[i][j].ToString();
                    fila[j] = Dato;
                }
                trdo.Rows.Add(fila);
            }



            Int32 Cant = trdo.Rows.Count;
            txtCantidadVentas.Text = Cant.ToString();
            trdo = fun.TablaaMiles(trdo, "ImporteVenta");
            trdo = fun.TablaaMiles(trdo, "ImporteEfectivo");
            trdo = fun.TablaaMiles(trdo, "ImporteAutoPartePago");
            trdo = fun.TablaaMiles(trdo, "ImporteCredito");
            trdo = fun.TablaaMiles(trdo, "ImportePrenda");
            trdo = fun.TablaaMiles(trdo, "Cheque");
            trdo = fun.TablaaMiles(trdo, "ImporteCobranza");
            trdo = fun.TablaaMiles(trdo, "Ganancia");
            trdo = fun.TablaaMiles(trdo, "Saldo");
            txtTotal.Text = fun.TotalizarColumna(trdo, "Ganancia").ToString();
            txtTotal.Text = fun.FormatoEnteroMiles(txtTotal.Text);
            Grilla.DataSource = trdo;
            //
            Clases.cVenta ven = new Clases.cVenta();
            //pinto las ventas sin saldo
            for (int k = 0; k < Grilla.Rows.Count - 1; k++)
            {
                Int32 CodVenta = Convert.ToInt32(Grilla.Rows[k].Cells[0].Value.ToString());
                if (k < PosPintar)
                {
                    double ImporteDocumento = 0;
                    double Prenda = 0;
                    double Cheque = 0;
                    double Cobranza = 0;
                    if (Grilla.Rows[k].Cells[10].Value.ToString() != "")
                    {
                        ImporteDocumento = GetSaldoCuotaxCodVenta(CodVenta);
                    }

                    if (Grilla.Rows[k].Cells[11].Value.ToString() != "")
                    {
                        Prenda = GetSaldoPrendaxCodVenta(CodVenta);
                    }

                    if (Grilla.Rows[k].Cells[12].Value.ToString() != "")
                    {
                        Cheque = GetSaldoChequexCodVenta(CodVenta);
                    }

                    if (Grilla.Rows[k].Cells[13].Value.ToString() != "")
                    {
                        Cobranza = GetSaldoCobranza(CodVenta);
                    }
                    double Suma = (ImporteDocumento + Prenda + Cheque + Cobranza);
                    if (Suma == 0)
                    {
                        //pinto
                        Grilla.Rows[k].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    int TieneDeuda = ven.TieneDeuda(CodVenta);
                    if (TieneDeuda == 1)
                        Grilla.Rows[k].DefaultCellStyle.BackColor = Color.LightCyan;



                }
            }
            string Col = "0;10;0;20;10;30;10";
            Col = Col + ";0;10;0;0;0;0;0";
            Col = Col + ";0;0;0;0;0;10";
            fun.AnchoColumnas(Grilla, Col);

            Grilla.Columns[3].HeaderText = "Cliente";
            Grilla.Columns[4].HeaderText = "Marca";
            Grilla.Columns[5].HeaderText = "Modelo";
            Grilla.Columns[6].HeaderText = "Dominio";
            Grilla.Columns[18].HeaderText = "Deuda";


        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje());
                return;
            }

            string Tipo = Grilla.CurrentRow.Cells[17].Value.ToString();
            if (Tipo =="PreVenta")
            {
                string CodPreVenta = Grilla.CurrentRow.Cells[0].Value.ToString();
                Principal.CodigoPrincipalAbm = null;
                Principal.CodigoSenia = CodPreVenta;
                FrmVenta form = new FrmVenta();
                form.ShowDialog();
            }

            if (Tipo =="Venta")
            {
                string CodVenta = Grilla.CurrentRow.Cells[0].Value.ToString();
                Principal.CodigoPrincipalAbm = CodVenta;
                Principal.CodigoSenia = null;
                FrmVenta form = new FrmVenta();
                form.ShowDialog();
            }

          
            

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {  
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje());
                return;
            }
            string CodVenta = Grilla.CurrentRow.Cells[0].Value.ToString();
            GrabarBoletoTraut(Convert.ToInt32(CodVenta));
            Principal.CodigoPrincipalAbm = CodVenta;
            Principal.TablaPrincipal = Grilla.CurrentRow.Cells[8].Value.ToString();
            FrmBoletoTraut frm = new FrmBoletoTraut();
            frm.Show();         
            //  FrmVistaPrevia form = new FrmVistaPrevia();
           // form.Show();
        }

        public void GrabarBoletoTraut(Int32 CodVenta)
        {
            cBoletoTraut boleto = new cBoletoTraut();
            boleto.Borrar();
            string Domicilio ="Domicilio: " + GetDomicilio(CodVenta);
            string Adherente = GetNombre2Titular(CodVenta);
            string NrodocAdehrente = GetNro2Titular(CodVenta);
            string Titular ="Nombre / Razón Social " + GetNombrTitular(CodVenta);
            string Telefono = GetTelefonoAdherente(CodVenta);
            string Campo5 = "RESERVA / PEDIDO DE UNIDAD Nº " + CodVenta.ToString();
            string Campo7 = "";
            string ListadoAutoPartePago = GetAutosxPartePago(CodVenta);
            if (ListadoAutoPartePago !="")
            {
                Campo7 = "Datos de la unidad que entrega en parte de pago";
            }
            boleto.Insertar(CodVenta, Domicilio, Adherente, NrodocAdehrente, Telefono, Campo5, Titular, Campo7, ListadoAutoPartePago);
        }
        
        public string GetDomicilio(Int32 CodVenta)
        {
            string Domicilio = "";
            Int32 CodClietne = 0;
            cVenta venta = new cVenta();
            DataTable tbVenta = venta.GetVentaxCodigo(CodVenta);
            if (tbVenta.Rows.Count >0)
            {
                CodClietne = Convert.ToInt32(tbVenta.Rows[0]["CodCliente"].ToString());

            }
            string Calle = "", Altura = "";
            string Ciudad = "", Provincia = "";
            cCliente cliente = new cCliente();
            DataTable tbCli = cliente.GetClientesxCodigo(CodClietne);
            if (tbCli.Rows.Count >0)
            {
                Calle = tbCli.Rows[0]["Calle"].ToString();
                Altura = tbCli.Rows[0]["Numero"].ToString();
                if (tbCli.Rows[0]["CodBarrio"].ToString ()!="")
                {
                    Int32 CodBarrrio = Convert.ToInt32(tbCli.Rows[0]["CodBarrio"]);
                    cBarrio barrio = new cBarrio();
                    DataTable tbBarrio = barrio.GetBarrioCiudadProvincia(CodBarrrio);
                    if (tbBarrio.Rows.Count >0)
                    {
                        Ciudad = tbBarrio.Rows[0]["Ciudad"].ToString();
                        Provincia = tbBarrio.Rows[0]["Provincia"].ToString();
                    }
                }
            }
            Domicilio = Calle + " " + Altura + " " + Ciudad + " " + Provincia;
            return Domicilio;
        }

        public string GetNombre2Titular(Int32 CodVenta)
        {
            Int32  CodClienteTitular = 0;
            Int32 CodClienteSecundario = 0;
            string NombreAdeherente = "";
            cVenta venta = new cVenta();
            cCliente cli = new cCliente();
            //1 obtengo el titular
            DataTable tbventa = venta.GetVentaxCodigo(CodVenta);
            if (tbventa.Rows.Count >0)
            {
                CodClienteTitular = Convert.ToInt32(tbventa.Rows[0]["CodCliente"].ToString());
            }
            //2 obtengo los demas clientes 
            DataTable tbClientes = venta.GetClientesxCodVenta(CodVenta);
            if (tbClientes.Rows.Count >0)
            {
                for (int i = 0; i < tbClientes.Rows.Count ; i++)
                {
                    if (tbClientes.Rows[i]["CodCliente"].ToString ()!=CodClienteTitular.ToString () )
                    {
                        CodClienteSecundario = Convert.ToInt32(tbClientes.Rows[i]["CodCliente"]);
                        DataTable tbClie = cli.GetClientesxCodigo(CodClienteSecundario);
                        if (tbClie.Rows.Count >0)
                        {
                            string Nom = tbClie.Rows[0]["Nombre"].ToString();
                            string Ape = tbClie.Rows[0]["Apellido"].ToString();
                            NombreAdeherente = Nom + " " + Ape;
                        }
                    }
                }
            }
            return NombreAdeherente;
        }

        public string GetNombrTitular(Int32 CodVenta)
        {
            Int32 CodClienteTitular = 0;
            string Titular = "";
            cVenta venta = new cVenta();
            cCliente cli = new cCliente();
            //1 obtengo el titular
            DataTable tbventa = venta.GetVentaxCodigo(CodVenta);
            if (tbventa.Rows.Count > 0)
            {
                CodClienteTitular = Convert.ToInt32(tbventa.Rows[0]["CodCliente"].ToString());
            }

            DataTable tbClie = cli.GetClientesxCodigo(CodClienteTitular);
            if (tbClie.Rows.Count > 0)
            {
                string Nom = tbClie.Rows[0]["Nombre"].ToString();
                string Ape = tbClie.Rows[0]["Apellido"].ToString();
                Titular = Nom + " " + Ape;
            }           
            return Titular;
        }

        public string GetNro2Titular(Int32 CodVenta)
        {
            Int32 CodClienteTitular = 0;
            Int32 CodClienteSecundario = 0;
            string NroDocumento = "";
            cVenta venta = new cVenta();
            cCliente cli = new cCliente();
            //1 obtengo el titular
            DataTable tbventa = venta.GetVentaxCodigo(CodVenta);
            if (tbventa.Rows.Count > 0)
            {
                CodClienteTitular = Convert.ToInt32(tbventa.Rows[0]["CodCliente"].ToString());
            }
            //2 obtengo los demas clientes 
            DataTable tbClientes = venta.GetClientesxCodVenta(CodVenta);
            if (tbClientes.Rows.Count > 0)
            {
                for (int i = 0; i < tbClientes.Rows.Count; i++)
                {
                    if (tbClientes.Rows[i]["CodCliente"].ToString() != CodClienteTitular.ToString())
                    {
                        CodClienteSecundario = Convert.ToInt32(tbClientes.Rows[i]["CodCliente"]);
                        DataTable tbClie = cli.GetClientesxCodigo(CodClienteSecundario);
                        if (tbClie.Rows.Count > 0)
                        {
                            NroDocumento = tbClie.Rows[0]["NroDocumento"].ToString();
                        }
                    }
                }
            }
            return NroDocumento;
        }

        public string GetTelefonoAdherente(Int32 CodVenta)
        {
            Int32 CodClienteTitular = 0;
            Int32 CodClienteSecundario = 0;
            string Telefono = "";
            cVenta venta = new cVenta();
            cCliente cli = new cCliente();
            //1 obtengo el titular
            DataTable tbventa = venta.GetVentaxCodigo(CodVenta);
            if (tbventa.Rows.Count > 0)
            {
                CodClienteTitular = Convert.ToInt32(tbventa.Rows[0]["CodCliente"].ToString());
            }
            //2 obtengo los demas clientes 
            DataTable tbClientes = venta.GetClientesxCodVenta(CodVenta);
            if (tbClientes.Rows.Count > 0)
            {
                for (int i = 0; i < tbClientes.Rows.Count; i++)
                {
                    if (tbClientes.Rows[i]["CodCliente"].ToString() != CodClienteTitular.ToString())
                    {
                        CodClienteSecundario = Convert.ToInt32(tbClientes.Rows[i]["CodCliente"]);
                        DataTable tbClie = cli.GetClientesxCodigo(CodClienteSecundario);
                        if (tbClie.Rows.Count > 0)
                        {
                            Telefono = tbClie.Rows[0]["Telefono"].ToString();
                        }
                    }
                }
            }
            return Telefono;
        }

        private void BtnVerGanancia_Click(object sender, EventArgs e)
        {
            if (Grilla.Columns[14].Visible == false)
            {
                Grilla.Columns[14].Visible = true;
               // Grilla.Columns[2].Width = 100;
                lblGanancia.Visible = true;
                txtTotal.Visible = true; 
            }
            else
            {
                Grilla.Columns[14].Visible = false;
                Grilla.Columns[2].Width = 200;
                lblGanancia.Visible = false;
                txtTotal.Visible = false;
            }
             
        }

        private void FrmListadoVentas_Load(object sender, EventArgs e)
        {
            lblGanancia.Visible = false;
            txtTotal.Visible = false;
            CargarToolTip();
        }

        private void CargarToolTip()
        {
            ToolTip Var1 = new ToolTip();
            ToolTip Var2 = new ToolTip();
            ToolTip Var3 = new ToolTip();
            ToolTip Var4 = new ToolTip();
            ToolTip Var5 = new ToolTip();
            Var1.SetToolTip(btnBuscar, "Buscar ventas");
            Var2.SetToolTip(btnAbrirVenta, "Abrir la venta seleccionada");
            Var3.SetToolTip(btnImprimir, "Boleto Compra Venta");
            Var4.SetToolTip(btnReporte2, "Reporte de VCenta");
            Var5.SetToolTip(btnResponsabilidadCivil, "Reporte de responsabilidad social");

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            
            Clases.cDb.ExecutarNonQuery("delete from ReporteAuto");
            string sql = "";
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                string Modelo = (Grilla.Rows[i].Cells[4].Value.ToString());
                string Descripcion = (Grilla.Rows[i].Cells[6].Value.ToString());
                Int32 CodCliente = Convert.ToInt32(Grilla.Rows[i].Cells[16].Value.ToString());
                string Cliente = GetCliente(CodCliente, "NOMBRE");
                string Telefono = GetCliente(CodCliente, "TELEFONO");
                string Celular = GetCliente(CodCliente, "CELULAR");
                string Fecha = (Grilla.Rows[i].Cells[1].Value.ToString());
                if (Fecha.Length > 11)
                    Fecha = Fecha.Substring(0, 10);
                sql = "insert into ReporteAuto(Marca,Descripcion,Extra1,Extra2,Extra3,Extra4)";
                sql = sql + "values (" + "'" + Modelo + "'";
                sql = sql + "," + "'" + Descripcion + "'";
                sql = sql + "," + "'" + Cliente + "'";
                sql = sql + "," + "'" + Telefono + "'";
                sql = sql + "," + "'" + Celular + "'";
                sql = sql + "," + "'" + Fecha + "'";
                sql = sql + ")";
                Clases.cDb.ExecutarNonQuery(sql);
            }
            FrmReporteVenta frm = new FrmReporteVenta();
            frm.Show();
            
        }

        private string GetCliente(Int32 CodCLiente, string Campo)
        {
            string Dato = "";
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientesxCodigo(CodCLiente);
            if (trdo.Rows.Count > 0)
            {
                if (Campo == "NOMBRE")
                {
                    Dato = trdo.Rows[0]["Nombre"].ToString();
                    Dato = Dato + " " + trdo.Rows[0]["Apellido"].ToString();
                }
                if (Campo == "TELEFONO")
                {
                   Dato = trdo.Rows[0]["Telefono"].ToString();                
                }

                if (Campo == "CELULAR")
                {
                  Dato =  trdo.Rows[0]["Celular"].ToString();
                }
            }
            return Dato;
        }

        private double GetSaldoPrendaxCodVenta(Int32 CodVenta)
        {
            double Saldo = 0;
            Clases.cPrenda prenda = new Clases.cPrenda();
            DataTable tPrenda = prenda.GetPrendaxCodVenta(CodVenta);
            if (tPrenda.Rows.Count > 0)
                if (tPrenda.Rows[0]["Saldo"].ToString() != "")
                {
                    Saldo = Convert.ToDouble(tPrenda.Rows[0]["Saldo"].ToString()); 
                }
            return Saldo;
        }

        private double GetSaldoCuotaxCodVenta(Int32 CodVenta)
        {
            Clases.cCuota cuota = new Clases.cCuota();
            double Saldo = 0;
            Saldo  = cuota.GetSaldoDeudaCuotas(CodVenta);
            return Saldo; 
        }

        private double GetSaldoChequexCodVenta(Int32 CodVenta)
        {
            int ban = 0;
            Clases.cCheque cheque = new Clases.cCheque();
            DataTable tcheque = cheque.GetChequexCodVenta(CodVenta);
            if (tcheque.Rows.Count > 0)
            {
                for (int i = 0; i < tcheque.Rows.Count; i++)
                {
                    if (tcheque.Rows[i]["FechaPago"].ToString() == "")
                    {
                        ban = 1;
                    }
                }
            }
            if (ban == 1)
                return 1;
            else
                return 0;
        }

        private double GetSaldoCobranza(Int32 CodVenta)
        {
            double Saldo = 0;
            Clases.cCobranza cob = new Clases.cCobranza();
            DataTable tcob = cob.GetCobranzaxCodVenta(CodVenta);
            if (tcob.Rows.Count >0)
                if (tcob.Rows[0]["Saldo"].ToString() != "")
                {
                    Saldo = Convert.ToDouble(tcob.Rows[0]["Saldo"].ToString());
                }
            return Saldo;
        }

        private void btnResponsabilidadCivil_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }
            Int32 CodStock = 0;
            Int32 CodVenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cVenta venta = new cVenta();
            DataTable tbventa = venta.GetVentaxCodigo(CodVenta);
            if (tbventa.Rows.Count >0)
            {
                CodStock = Convert.ToInt32(tbventa.Rows[0]["CodStock"]);
            }
            cResponsabilidadCivil resp = new cResponsabilidadCivil();
            resp.ActualizarTexto(CodStock);
            Principal.CodStock = CodStock; 
            FrmReporteResponsabilidadCivil frm = new FrmReporteResponsabilidadCivil();
            frm.Show();
        }

        private string GetAutosxPartePago(Int32 CodVenta)
        {
            string Listado = "";
            Int32 CodAuto = 0;
            cVentaxAuto venta = new cVentaxAuto();
            DataTable trdo = venta.GetAutosxCodVenta(CodVenta);
            Double Precio = 0;
            if (trdo.Rows.Count >0)
            {
                for (int i = 0; i < trdo.Rows.Count ; i++)
                {
                    CodAuto = Convert.ToInt32 (trdo.Rows[i]["CodAuto"].ToString());
                    Precio = Convert.ToDouble(trdo.Rows[i]["Importe"]);
                    if (i == 0)
                        Listado = GetDetalleAuto(CodAuto, Precio);
                    else
                        Listado = Listado + " " + GetDetalleAuto(CodAuto, Precio);
                }
            }
            return Listado;
        }

        public string GetDetalleAuto(Int32 CodAuto, Double Precio)
        {
            cFunciones fun = new cFunciones();
            string Detalle = "";
            cAuto auto = new cAuto();
            DataTable trdo = auto.GetAutoxCodigo(CodAuto);
            if (trdo.Rows.Count >0)
            {   //NombreColor NombreAnio
                Detalle = "Modelo: " + trdo.Rows[0]["Descripcion"].ToString();
                Detalle = Detalle + " Dominio: " + trdo.Rows[0]["Patente"].ToString();
                Detalle = Detalle + " Año: " + trdo.Rows[0]["NombreAnio"].ToString();
                Detalle = Detalle +  " Marca: " + trdo.Rows[0]["Marca"].ToString();
                Detalle = Detalle + " Color: " + trdo.Rows[0]["NombreColor"].ToString();
                Detalle = Detalle + " Chasis: " + trdo.Rows[0]["Chasis"].ToString();
                Detalle = Detalle + " Motor: " + trdo.Rows[0]["Motor"].ToString();
                Detalle = Detalle + " " + "Precio $ " + fun.FormatoEnteroMiles(Precio.ToString()); 
            }
            return Detalle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar ");
                return;
            }

            Principal.Codigo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            FrmAdjuntarArchivo frm = new FrmAdjuntarArchivo();
            frm.FormClosing += new FormClosingEventHandler(form_FormClosing);
            frm.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Buscar();
        }
    }
}
