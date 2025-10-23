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
   
    public partial class FrmRegistrarCobranzaGeneral : Form
    {
        DataTable tbCuota;
        public FrmRegistrarCobranzaGeneral()
        {
            InitializeComponent();
        }

        private void FrmRegistrarCobranzaGeneral_Load(object sender, EventArgs e)
        {
            CargarMonedas();
            cFunciones fun = new cFunciones();
            tbCuota = fun.CrearTabla("Vencimiento;Cuota;Importe");
            string sqlDoc = "select * from TipoDocumento order by CodTipoDoc";
            DataTable tbDoc = cDb.ExecuteDataTable(sqlDoc);
            fun.LlenarComboDatatable(cmbDocumento, tbDoc, "Nombre", "CodTipoDoc");
            if (cmbDocumento.Items.Count > 1)
                cmbDocumento.SelectedIndex = 1;
            SetearUltimodia();
        }

        private void CargarMonedas()
        {   
            cFunciones fun = new cFunciones();
            string sql = "select * from Moneda order by CodMoneda";
            DataTable dt = cDb.ExecuteDataTable(sql);
            fun.LlenarComboDatatable(CmbMoneda, dt, "Nombre", "CodMoneda");
            if (CmbMoneda.Items.Count > 1)
                CmbMoneda.SelectedIndex = 1;
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj, cMensaje.Mensaje());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (txtEfectivo.Text == "")
            {
                Mensaje("Debe ingresar un monto");
                return;
            }

            if (txtDescripcion.Text == "")
            {
                Mensaje("Debe ingresar una Descripción");
                return;
            }

            Int32? CodMoneda = null;
            Int32? CodCLi = 0;
            cCliente cli = new cCliente();
            DateTime Fecha = dpFecha.Value;
            DateTime FechaVencimiento = dpFechaVencimiento.Value;
            string Descripcion = txtDescripcion.Text ;
            double Importe = fun.ToDouble(txtEfectivo.Text);;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string NroDoc = txtNroDoc.Text;
            string Telefono = txtTelefono.Text;
            string Patente = txtPatente.Text;
            string Direccion = txtDireccion.Text;
            string Nombrecliente = txtNombre.Text + " " + txtApellido.Text;
            string Tipo = "";
            if (CmbMoneda.SelectedIndex > 0)
                CodMoneda = Convert.ToInt32(CmbMoneda.SelectedValue);

            cCobranzaGeneral cob = new cCobranzaGeneral();
            if (txtCodCLiente.Text =="")
            {
                CodCLi =  cli.InserterClienteId2(null, NroDoc, Nombre, Apellido, Telefono);
            }
            else
            {
                CodCLi = Convert.ToInt32(txtCodCLiente.Text);
            }
            if (Grilla.Rows.Count ==0)
            {
                Tipo = "CONT";
                cob.InsertarCobranza(Fecha, Descripcion, Importe, Nombrecliente, Telefono, Direccion, Patente, FechaVencimiento, CodCLi, CodMoneda,Tipo);
                Mensaje("Datos grabados correctamente");
                txtDescripcion.Text = "";
                txtEfectivo.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtCodCLiente.Text = "";
            }
            else
            {
                GuardarCuotas();
            }
           

        }

        private void GuardarCuotas()
        {
            cFunciones fun = new cFunciones();
            Int32? CodMoneda = null;
            Int32? CodCLi = 0;
            cCliente cli = new cCliente();
            DateTime Fecha = dpFecha.Value;
            DateTime FechaVencimiento = dpFechaVencimiento.Value;
            string Descripcion = txtDescripcion.Text;
            double Importe = fun.ToDouble(txtEfectivo.Text); ;
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string NroDoc = txtNroDoc.Text;
            string Telefono = txtTelefono.Text;
            string Patente = txtPatente.Text;
            string Direccion = txtDireccion.Text;
            string Nombrecliente = txtNombre.Text + " " + txtApellido.Text;
            int Grupo = 0;
            int Cuota = 0;
            if (CmbMoneda.SelectedIndex > 0)
                CodMoneda = Convert.ToInt32(CmbMoneda.SelectedValue);

            string Tipo = "FINAN";
            cCobranzaGeneral cob = new cCobranzaGeneral();
            Grupo = cob.GetMaxGrupo();
            Grupo = Grupo + 1;
            if (txtCodCLiente.Text == "")
            {
                CodCLi = cli.InserterClienteId2(null, NroDoc, Nombre, Apellido, Telefono);
            }
            else
            {
                CodCLi = Convert.ToInt32(txtCodCLiente.Text);
            }

            for (int i = 0; i < Grilla.Rows.Count -1 ; i++)
            {
                FechaVencimiento = Convert.ToDateTime(Grilla.Rows[i].Cells[0].Value.ToString());
                Importe = fun.ToDouble(Grilla.Rows[i].Cells[2].Value.ToString());
                Cuota = Convert.ToInt32(Grilla.Rows[i].Cells[1].Value.ToString());
                cob.InsertarCobranzaCuota(Fecha, Descripcion, Importe, Nombrecliente, Telefono, Direccion, Patente, FechaVencimiento, CodCLi, CodMoneda, Cuota ,Grupo, Tipo);
            }

           
            Mensaje("Datos grabados correctamente");
            txtDescripcion.Text = "";
            txtEfectivo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            tbCuota.Rows.Clear();
            txtCodCLiente.Text = "";
            Grilla.DataSource = tbCuota;
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (txtEfectivo.Text != "")
                txtEfectivo.Text = fun.FormatoEnteroMiles(txtEfectivo.Text);
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
                txtCodCLiente.Text = trdo.Rows[0]["CodCliente"].ToString();
                if (trdo.Rows[0]["CodTipoDoc"].ToString() != "")
                {
                    cmbDocumento.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
                }
            }
            else
            {
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtCodCLiente.Text = "";
            }
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            
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
                txtCodCLiente.Text = trdo.Rows[0]["CodCliente"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                txtNroDoc.Text = trdo.Rows[0]["NroDocumento"].ToString();
                if (trdo.Rows[0]["CodTipoDoc"].ToString()!="")
                {
                    cmbDocumento.SelectedValue = trdo.Rows[0]["CodTipoDoc"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMensajeCobranzas frm = new FrmMensajeCobranzas();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmMensajeCobranzas frm = new FrmMensajeCobranzas();
            frm.Show();
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
                txtPatente.Text = trdo.Rows[0]["Patente"].ToString();
                
              //  txtCodStock.Text = Principal.CodStock.ToString();
                string NombreAuto = "";
                string Descripcion = trdo.Rows[0]["Descripcion"].ToString();
                string Anio = trdo.Rows[0]["NombreAnio"].ToString();
                string Patente = trdo.Rows[0]["Patente"].ToString();
                txtPatente.Text = Patente;
                NombreAuto = Patente + " " + Descripcion + " " + Anio;
              //  txtVehiculo.Text = NombreAuto;
              //  txtConcepto.Text = NombreAuto;
                txtDescripcion.Text = NombreAuto;

            }
        }

        private void SetearUltimodia()
        {
            DateTime Fecha = DateTime.Now;
            int dia = Fecha.Day;
            int mes = Fecha.Month;
            int anio = Fecha.Year;
            string sFecha = "";
            switch(mes)
            {
                case 1:
                    dia = 31;
                    break;
                case 2:
                    dia = 28;
                    break;
                case 3:
                    dia = 31;
                    break;
                case 4:
                    dia = 30;
                    break;
                case 5:
                    dia = 31;
                    break;
                case 6:
                    dia = 30;
                    break;
                case 7:
                    dia = 31;
                    break;
                case 8:
                    dia = 31;
                    break;
                case 9:
                    dia = 30;
                    break;
                case 10:
                    dia = 31;
                    break;
                case 11:
                    dia = 30;
                    break;
                case 12:
                    dia = 31;
                    break;
            }
            sFecha = dia.ToString() + "/" + mes.ToString() + "/" + anio.ToString();
            Fecha = Convert.ToDateTime(sFecha);
            dpFechaVencimiento.Value = Fecha;

        }

        private void btnCuotas_Click(object sender, EventArgs e)
        {
            if (txtEfectivo.Text =="")
            {
                MessageBox.Show("Debe ingresar un mento para continuar ");
                return;
            }

            if (txtCuotas.Text =="")
            {
                MessageBox.Show("Debe ingresar una cantidad de cuotas para continuar");
                return;

            }

            Double Importe = Convert.ToDouble(txtEfectivo.Text);
            int Cuotas = Convert.ToInt32(txtCuotas.Text);
            DateTime Vencimiento = dpFechaVencimiento.Value;
            Double ImporteCuotta = 0;
            ImporteCuotta = Importe / Cuotas;
            cFunciones fun = new cFunciones();
           // DataTable tbCuota = fun.CrearTabla("Vencimiento;Cuota;Importe");
            string val = "";
            for (int i = 0; i < Cuotas ; i++)
            {
                val = Vencimiento.ToShortDateString();
                val = val + ";" + (i + 1).ToString();
                val = val + ";" + ImporteCuotta.ToString();
                tbCuota = fun.AgregarFilas(tbCuota, val);
                Vencimiento = Vencimiento.AddMonths(1);
            }
            tbCuota = fun.TablaaMiles(tbCuota, "Importe");
            Grilla.DataSource = tbCuota;
            fun.AnchoColumnas(Grilla, "30;30;40");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtEfectivo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            tbCuota.Rows.Clear();
            txtCodCLiente.Text = "";
            Grilla.DataSource = tbCuota;
        }
    }
}
