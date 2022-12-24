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
    public partial class FrmCrearRecibo : FormularioBase
    {
        public FrmCrearRecibo()
        {
            InitializeComponent();
        }

        private void Inicializar()
        {
            string sqlDoc = "select * from TipoDocumento order by CodTipoDoc";
            DataTable tbDoc = cDb.ExecuteDataTable(sqlDoc);
            cFunciones fun = new Clases.cFunciones();
            fun.LlenarComboDatatable(cmbDocumento, tbDoc, "Nombre", "CodTipoDoc");
            fun.LlenarCombo(CmbBanco, "Banco", "Nombre", "CodBanco");
        }

        private void FrmCrearRecibo_Load(object sender, EventArgs e)
        {
            Inicializar();
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
                txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
            }
            if (b==0)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtCodCliente.Text = "";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

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

        private void txtImporteCheque_Leave(object sender, EventArgs e)
        {
            if (txtImporteCheque.Text != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                txtImporteCheque.Text = fun.FormatoEnteroMiles(txtImporteCheque.Text);
            }
        }

        private void btnGuardarRecibo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text =="")
            {
                MessageBox.Show("Debe ingresar un nombre para continuar");
                return;
            }
              
            if (txtNroDoc.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de documento  para continuar");
                return;
            }

            if (cmbDocumento.SelectedIndex<1)
            {
                MessageBox.Show("Debe ingresar un documento para continuar");
                return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Clases.cConexion.Cadenacon();
            con.Open();
            SqlTransaction Transaccion;
            Transaccion = con.BeginTransaction();
            try
            {
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
            cRecibo recibo = new cRecibo();
            Int32 CodRecibo = 0;
            Double Efectivo = 0;
            Double Cheque = 0;
            int Orden = 1;
           
            DateTime Fecha = dpFecha.Value;
            string NroRecibo = "";

            Cheque = fun.CalcularTotalGrilla(GrillaCheques, "Importe");
            
            Int32 CodCliente = Convert.ToInt32(txtCodCliente.Text);
            CodRecibo = recibo.Insertar(con, Transaccion, Fecha, CodCliente, 0, "", "", 0, "");
            NroRecibo = recibo.GetNroRecibo(CodRecibo);
            recibo.ActualizarNroRecibo(con, Transaccion, CodRecibo, NroRecibo);
            if (txtEfectivo.Text != "")
            {
                Efectivo = fun.ToDouble(txtEfectivo.Text);
            }

           
            if (Efectivo > 0)
            {
                string sEfectivo = "$ " + txtEfectivo.Text;
                recibo.InsertarDetalle(con, Transaccion, CodRecibo, "Efectivo", "", "", sEfectivo, Orden);
                Orden = Orden + 1;
            }

            if (Cheque > 0)
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

            Principal.CodRecibo = CodRecibo;

        }
    }
}
