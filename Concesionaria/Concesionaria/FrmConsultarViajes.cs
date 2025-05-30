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
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            DateTime Desde = dpFechaDesde.Value;
            DateTime Hasta = dpFechaHasta.Value;
            cViaje viaje = new Clases.cViaje();
            DataTable trdo = viaje.GetViajes(Desde, Hasta);
            trdo = fun.TablaaMiles(trdo, "Gastos");
            trdo = fun.TablaaMiles(trdo, "Adelanto");
            trdo = fun.TablaaMiles(trdo, "KmIda");
            trdo = fun.TablaaMiles(trdo, "KmVuelta");
            Grilla.DataSource = trdo;
            string Col = "0;30;30;10;10;10;10";
            
            fun.AnchoColumnas(Grilla, Col);
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
    }
}
