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
    public partial class FrmRegistrarGastosTransferencia : FrmBase 
    {
        public FrmRegistrarGastosTransferencia()
        {
            InitializeComponent();
        }

        private void Inicializar()
        {
            cFunciones fun = new cFunciones();
            string sqlDoc = "select * from TipoDocumento order by CodTipoDoc";
            DataTable tbDoc = cDb.ExecuteDataTable(sqlDoc);
            fun.LlenarComboDatatable(cmbDocumento, tbDoc, "Nombre", "CodTipoDoc");
            if (cmbDocumento.Items.Count > 1)
                cmbDocumento.SelectedIndex = 1;

            fun.LlenarCombo(cmbTipoUtilitario, "TipoUtilitario", "Nombre", "CodTipo");
            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
            DataTable tbColor = cDb.ExecuteDataTable("select * from Color order by Nombre");
            fun.LlenarComboDatatable(cmbColor, tbColor, "Nombre", "CodColor");
            DataTable tbAnio = cDb.ExecuteDataTable("select * from anio Order by Nombre desc");
            fun.LlenarComboDatatable(cmbAnio, tbAnio, "Nombre", "CodAnio");
            fun.LlenarCombo(CmbGastosTransferencia, "CategoriaGastoTransferencia", "Descripcion", "Codigo");
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

        private void BuscarClientexCodigo(Int32 CodCliente)
        {
            Clases.cCliente cliente = new Clases.cCliente();
            DataTable trdo = cliente.GetClientesxCodigo(CodCliente);
            if (trdo.Rows.Count > 0)
            {
                txtCodCLiente.Text = CodCliente.ToString();
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                if (trdo.Rows[0]["CodTipoDoc"].ToString() != "")
                    cmbDocumento.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
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
          
        }

        private void FrmRegistrarGastosTransferencia_Load(object sender, EventArgs e)
        {
            Inicializar();
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
                   // GetCostos(Convert.ToInt32(txtCodStock.Text));
                    //  CargarGastosGeneralesxCodStoxk(Convert.ToInt32(txtCodStock.Text));
                    if (trdo2.Rows[0]["CodCliente"].ToString() != "")
                    {
                        // txtCodCLiente.Text = trdo2.Rows[0]["CodCliente"].ToString();
                        // GetClientesxCodigo(Convert.ToInt32(txtCodCLiente.Text));
                    }

                }                

            }

        }

        private void chkNoIncluyeGastos_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void txtImporteGastoTransferencia_Leave(object sender, EventArgs e)
        {

        }

        private void CmbGastosTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bnAgegargastoTranasferencia_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarGastoTransferencia_Click(object sender, EventArgs e)
        {

        }

        private void bnAgegargastoTranasferencia_Click_1(object sender, EventArgs e)
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
           
            GrillaGastos.Columns[1].Width = 260;
            //CalcularSubTotal(); 
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
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
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodCLiente.Text =="")
            {
                MessageBox.Show("Debe seleccionar un cliente ");
                return;
            }

            if (txtCodStock.Text =="")
            {
                MessageBox.Show("Debe seleccionar un vehículo ");
                return;
            }

            if (GrillaGastos.Rows.Count <1)
            {
                MessageBox.Show("Debe ingresar un trámite  ");
                return;
            }
            string sqlGastosPagar = "";
            cFunciones fun = new cFunciones();
            int b = 0;
            //grabo los gatos de transferencia
            for (int k = 0; k < GrillaGastos.Rows.Count - 1; k++)
            {
                string sDescripcion = GrillaGastos.Rows[k].Cells[1].Value.ToString();
                string sImporte = GrillaGastos.Rows[k].Cells[3].Value.ToString();
                Int32 CodStock = Convert.ToInt32(txtCodStock.Text);
                sqlGastosPagar = "Insert into GastosPagar(CodAuto,Descripcion";
                sqlGastosPagar = sqlGastosPagar + ",Fecha,Importe,CodCliente,CodStock,sinventa)";
                sqlGastosPagar = sqlGastosPagar + "values (" + txtCodAuto.Text;
                sqlGastosPagar = sqlGastosPagar + "," + "'" + sDescripcion + "'";
                sqlGastosPagar = sqlGastosPagar + "," + "'" + dpFecha.Value.ToShortDateString() + "'";
                sqlGastosPagar = sqlGastosPagar + "," + fun.ToDouble(sImporte);
                sqlGastosPagar = sqlGastosPagar + "," + txtCodCLiente.Text;
                sqlGastosPagar = sqlGastosPagar + "," + CodStock.ToString();

                sqlGastosPagar = sqlGastosPagar + ",1)";
                cDb.ExecutarNonQuery(sqlGastosPagar);
                b = 1;
            }
            if (b ==1)
            {
                MessageBox.Show("Datos grabados correctamente ");
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtCodCLiente.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCodAuto.Text = "";
            txtCodStock.Text = "";
            txtPatente.Text = "";
            txtDescripcion.Text = "";
           // GrillaGastos.Rows.Clear();
             
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAgregarGastoTransferencia_Click_1(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "Codigo";
            Principal.CampoNombreSecundario = "Descripcion";
            Principal.NombreTablaSecundario = "CategoriaGastoTransferencia";
            Principal.CampoIdSecundarioGenerado = "";
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
                    case "CategoriaGastoTransferencia":
                        fun.LlenarCombo(CmbGastosTransferencia, "CategoriaGastoTransferencia", "Descripcion", "Codigo");
                        CmbGastosTransferencia.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;           

                }
            }

        }
    }
}
