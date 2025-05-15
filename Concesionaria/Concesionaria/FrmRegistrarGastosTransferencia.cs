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
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                if (trdo.Rows[0]["CodTipoDoc"].ToString() != "")
                    cmbDocumento.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
                //aca
             
                //hsta aca
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
    }
}
