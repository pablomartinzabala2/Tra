using Concesionaria.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Concesionaria
{
    public partial class FrmListadoGastos : Form
    {
        public FrmListadoGastos()
        {
            InitializeComponent();
        }

        private void FrmListadoGastos_Load(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            DateTime fechahoy = DateTime.Now;
            DateTime Desde = Convert.ToDateTime("01/01/2022");
           // txtFechaHasta.Text = fechahoy.ToShortDateString();
            dpFechaHasta.Value = fechahoy;
            fechahoy = fechahoy.AddMonths(-1);
            dpFechaDesde.Value = Desde;
            //txtFechaDesde.Text = fechahoy.ToShortDateString(); 
            fun.LlenarCombo(cmbCategoria, "CategoriaGastoTransferencia", "Descripcion", "Codigo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            Clases.cFunciones fun = new Clases.cFunciones();
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            int Impagos = 0;
            if (chkImpagos.Checked == true)
                Impagos = 1;

            string Categoria = "";
            if (cmbCategoria.SelectedIndex > 0)
                Categoria = cmbCategoria.Text;
            //Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cGastosPagar gasto = new Clases.cGastosPagar();
            DataTable trdo = gasto.GetGastosPagarxFecha2(FechaDesde, FechaHasta, txtPatente.Text, Impagos, Nombre, Apellido, Categoria);
            //   DataTable trdo = gasto.GetGastosPagarxFecha(FechaDesde, FechaHasta, txtPatente.Text, Impagos, Nombre, Apellido, Categoria);
            Double TotalTransferencia = fun.TotalizarColumna(trdo, "Importe");
            Double TotalCosto = fun.TotalizarColumna(trdo, "importepagado");
            Double TotalGanancia = fun.TotalizarColumna(trdo, "Ganancia");
            trdo = fun.TablaaMiles(trdo, "Importe");
            trdo = fun.TablaaMiles(trdo, "importepagado");
            trdo = fun.TablaaMiles(trdo, "Ganancia");
            txtTotal.Text = fun.FormatoEnteroMiles(TotalTransferencia.ToString());
            txtTotalCosto.Text = fun.FormatoEnteroMiles(TotalCosto.ToString());
            txtTotalGanancia.Text = fun.FormatoEnteroMiles(TotalGanancia.ToString());
            Grilla.DataSource = trdo;
            string Col = "0;10;10;10;10;10;10;10;10;10;10;0";
            fun.AnchoColumnas(Grilla, Col);
            txtCantidad.Text = trdo.Rows.Count.ToString();
            Grilla.Columns[8].HeaderText = "F. Entrega";
            Grilla.Columns[5].HeaderText = "F. Venta";
            Grilla.Columns[10].HeaderText = "Costo";
            Pintar();
        }

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", Clases.cMensaje.Mensaje()); 
                return;
            }

            Int32 CodGasto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString ());
            Principal.CodigoPrincipalAbm = CodGasto.ToString();
            FrmRegistrarPagoGastos frm = new FrmRegistrarPagoGastos();
            frm.ShowDialog();
        }


        private void Pintar()
        {
            
            DateTime Hoy = DateTime.Now;
            DateTime FechaVenta = DateTime.Now;
            string FechaTramite = "";
            for (int i = 0; i < Grilla.Rows.Count -1; i++)
            {
                FechaTramite = Grilla.Rows[i].Cells[6].Value.ToString();  
                FechaVenta = Convert.ToDateTime(Grilla.Rows[i].Cells[5].Value);
                var Dif = (Hoy - FechaVenta).Days;
                if (Dif>30)
                {
                    if (FechaTramite =="")
                    {
                        Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
            }

            txtVencida.BackColor = Color.LightPink;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int Orden = 0;
            string Campo1 = "", Campo2 = "", Campo3 = "", Campo4 = "";
            string Campo5 = "", Campo6 = "", Campo7 = "", Campo8 = "";
            string Campo9 = "", Campo10 = "";
            cReporte reporte = new cReporte();
            reporte.Borrar();
            for (int i = 0; i < Grilla.Rows.Count - 1 ; i++)
            {
                Orden++;
                Campo1 = Grilla.Rows[i].Cells[1].Value.ToString();
                Campo2 = Grilla.Rows[i].Cells[2].Value.ToString();
                Campo3 = Grilla.Rows[i].Cells[4].Value.ToString();
                Campo4 = Grilla.Rows[i].Cells[5].Value.ToString();
                if (Campo4.Length > 8)
                    Campo4 = Campo4.Substring(0, 10);

                Campo5 = Grilla.Rows[i].Cells[6].Value.ToString();

                if (Campo5.Length > 8)
                    Campo5 = Campo5.Substring(0, 10);
                Campo6 = Grilla.Rows[i].Cells[7].Value.ToString();
                if (Campo6.Length > 8)
                    Campo6 = Campo6.Substring(0, 10);  
                Campo7 = Grilla.Rows[i].Cells[7].Value.ToString();

                if (Campo5.Length > 8)
                    Campo5 = Campo5.Substring(0, 10);
                Campo8 = Grilla.Rows[i].Cells[8].Value.ToString();

                Campo9 = Grilla.Rows[i].Cells[9].Value.ToString();
                Campo10 = Grilla.Rows[i].Cells[10].Value.ToString();

                reporte.Insertar(Orden, Campo1, Campo2, Campo3, Campo4, Campo5,
                    Campo6, Campo7, Campo8, Campo9, Campo10, "", "", "", "");
            }

            FrmReporteGastosTransferencia frm = new FrmReporteGastosTransferencia();
            frm.Show();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmRegistrarGastosTransferencia frm = new FrmRegistrarGastosTransferencia();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarGasto_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccion ar un fila para continuar ");
                return;
            }

            string msj = "Confirma eliminar el registro ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            int b = 0;
            Int32 CodGasto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cGastosPagar Gasto = new cGastosPagar();
            DataTable trdo = Gasto.GetGastoSinVenta(CodGasto);
            if (trdo.Rows.Count >0)
            {
                if (trdo.Rows[0]["CodGasto"].ToString ()!="")
                {
                    if (trdo.Rows[0]["FechaPAGO"].ToString ()!="")
                    {
                        MessageBox.Show("El tramite no se puede eliminar");
                        b = 1;
                    }
                    else
                    {
                        Gasto.Eliminar(CodGasto);
                        MessageBox.Show("Registro Eliminado Correctamente");
                        b = 1;
                        Buscar();
                    }
                }
            }
            if (b ==0)
            {
                MessageBox.Show("El registro no se puede eliminar, tiene movimientos asociados");
            }

        }
    }
}
