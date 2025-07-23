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
    public partial class FrmConsultarViajes : FrmBase 
    {
        public FrmConsultarViajes()
        {
            InitializeComponent();
        }

        private void FrmConsultarViajes_Load(object sender, EventArgs e)
        {
            InicializarFechas();
            CargarChoferes();
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime Desde = dpFechaDesde.Value;
            DateTime Hasta = dpFechaHasta.Value;
            Double Gastos = 0;
            Double Diferencias = 0;
            Double Adelantos = 0;
            Int32? CodChofer = null;
            if (cmbChofer.SelectedIndex > 0)
                CodChofer = Convert.ToInt32(cmbChofer.SelectedValue);
            cViaje viaje = new Clases.cViaje();
            DataTable trdo = viaje.GetViajes(Desde, Hasta, CodChofer);
            trdo = fun.TablaaMiles(trdo, "Gastos");
            trdo = fun.TablaaMiles(trdo, "Adelanto");
            trdo = fun.TablaaMiles(trdo, "KmIda");
            trdo = fun.TablaaMiles(trdo, "KmVuelta");
            trdo = fun.TablaaMiles(trdo, "Km");
            trdo = fun.TablaaFechas(trdo, "Fecha");
            Gastos = fun.TotalizarColumna(trdo, "Gastos");
            Adelantos = fun.TotalizarColumna(trdo, "Adelanto");
            Diferencias = fun.TotalizarColumna(trdo, "Km");
            Grilla.DataSource = trdo;
            string Col = "0;15;15;0;20;10;10;10;10;10;0";
            fun.AnchoColumnas(Grilla, Col);
            txtGasto.Text = fun.FormatoEnteroMiles(Gastos.ToString());
            txtDiferencia.Text = fun.FormatoEnteroMiles(Diferencias.ToString());
            txtAdelanto.Text = fun.FormatoEnteroMiles(Adelantos.ToString());
             
        }

        private void CargarChoferes()
        {
            cChofer chofer = new cChofer();
            DataTable trdo = chofer.GetChofer();
            cFunciones fun = new cFunciones();
            fun.LlenarComboDatatable(cmbChofer, trdo, "Nombre", "CodChofer");
        }

        private void InicializarFechas()
        {     
            DateTime Fecha = DateTime.Now;
            dpFechaHasta.Value = Fecha;
            Fecha = Fecha.AddDays(-7);
            dpFechaDesde.Value = Fecha;  
        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return; 
            }

            string msj = "Confirma eliminar el viaje ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            int CodViaje = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            cViaje viaje = new Clases.cViaje();
            viaje.Eliminar(CodViaje);
            MessageBox.Show("Datos borrados correctamente ");
            Buscar(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            cReporte rep = new cReporte();
            rep.Borrar();
            DateTime FechaHoy = DateTime.Now;
            string Fecha = "";
            string Chofer = "";
            string Destino ="";
            string Gastos = "";
            string Adelanto = "";
            string KmIda = "";
            string KmVuelta = "";
            string Diferencia = "";
            string TotalPagar = "";
            string Descripcion = "";
            TotalPagar = ArmarPieInforme();
            int b = 0;
            for (int i = 0; i < Grilla.Rows.Count - 1 ; i++)
            {
                Fecha = Grilla.Rows[i].Cells[1].Value.ToString();
                Chofer ="Chofer: " + Grilla.Rows[i].Cells[2].Value.ToString();
                Destino = Grilla.Rows[i].Cells[4].Value.ToString();
                Gastos = Grilla.Rows[i].Cells[5].Value.ToString();
                Adelanto = Grilla.Rows[i].Cells[6].Value.ToString();
                KmIda = Grilla.Rows[i].Cells[7].Value.ToString();
                KmVuelta = Grilla.Rows[i].Cells[8].Value.ToString();
                Diferencia = Grilla.Rows[i].Cells[9].Value.ToString();
                Descripcion = Grilla.Rows[i].Cells[10].Value.ToString();
                rep.Insertar(i, Fecha, Chofer, Destino, Gastos, Adelanto, KmIda, KmVuelta, Diferencia, FechaHoy.ToShortDateString (), TotalPagar,"",Descripcion,"","");
                b = 1;
            }

            if (b ==0)
            {
                MessageBox.Show("No Hay registros para imprimir ");
                return;
            }
            else
            {
                FrmReporteViaje frm = new Concesionaria.FrmReporteViaje();
                frm.Show();
            }
        }

        private string ArmarPieInforme()
        {
            cFunciones fun = new cFunciones();
            string Lista = "";
            Lista = "Kilómetros " + txtDiferencia.Text;
            Lista = Lista + " Valor Km " + fun.FormatoEnteroMiles(txtValorKm.Text);
            Lista = Lista + " Gastos " + txtGasto.Text;
            Lista = Lista + " Adelanto " + txtAdelanto.Text;
            Lista = Lista + " Total a Abonar " + txtTotalaPagar.Text;
            return Lista; 
        }
        private void btnCalcularTotalPagar_Click(object sender, EventArgs e)
        {
            if (Grilla.Rows.Count <1)
            {
                MessageBox.Show("No hay información para procesar ");
                return;
            }

            if (txtValorKm.Text =="")
            {
                MessageBox.Show("Debe ingresar un valor de km");
                return;
            }
            cFunciones fun = new Clases.cFunciones();
            Double ValorKm = Convert.ToDouble(txtValorKm.Text);
            Double KmRecorridos = 0;
            Double Adelanto = 0;
            Double Gastos = 0;
            Double TotalaPagar = 0;
            if (txtDiferencia.Text !="")
            {
                KmRecorridos = fun.ToDouble (txtDiferencia.Text);
            }
            
            if (txtAdelanto.Text != "")
            {
                Adelanto = fun.ToDouble(txtAdelanto.Text);
            }
            
            if (txtGasto.Text != "")
            {
                Gastos = fun.ToDouble(txtGasto.Text);
            }
            
            TotalaPagar = KmRecorridos * ValorKm + Gastos - Adelanto;
            txtTotalaPagar.Text = fun.FormatoEnteroMiles(TotalaPagar.ToString());
        }
    }
}
