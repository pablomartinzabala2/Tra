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
    public partial class FrmListadoAlertas : Form
    {
        public FrmListadoAlertas()
        {
            InitializeComponent();
            DateTime fechahoy = DateTime.Now;
            int anio = DateTime.Now.Year;
            string sFecha = "31/12/" + anio.ToString();

            fechahoy = fechahoy.AddMonths(-1);
            dpFechaDesde.Value = fechahoy;
            dpFechaHasta.Value = Convert.ToDateTime(sFecha);
            
        }

        private void FrmListadoAlertas_Load(object sender, EventArgs e)
        { 
            DateTime fechahoy = DateTime.Now;
            int anio = DateTime.Now.Year;
            string sFecha = "31/12/" + anio.ToString();
            fechahoy = fechahoy.AddMonths(-1);
            dpFechaDesde.Value = fechahoy;
            fechahoy = fechahoy.AddMonths(-1);
            dpFechaHasta.Value = Convert.ToDateTime(sFecha);
            Buscar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            Clases.cFunciones fun = new Clases.cFunciones();


            DateTime FechaDesde = dpFechaDesde.Value;
            DateTime FechaHasta = dpFechaHasta.Value;
            string texto = txtDescripcion.Text;
            Clases.cAlarma alarma = new Clases.cAlarma();
            DataTable trdo = alarma.GetAlertasxRangoFecha(FechaDesde, FechaHasta, texto, txtPatente.Text.Trim(), txtNombreCliente.Text.Trim());
            Grilla.DataSource = trdo;
            Grilla.Columns[1].HeaderText = "Descripción";
            Grilla.Columns[1].Width = 200;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].Width = 100;
            Grilla.Columns[3].Width = 250;
            Grilla.Columns[4].Width = 90;

        }

        private void btnEditarAlerta_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }
            Principal.Comodin = "";
            Principal.CodigoPrincipalAbm = Grilla.CurrentRow.Cells[0].Value.ToString(); 
            FrmRegistrarAlarma frm = new FrmRegistrarAlarma();
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Sistema");
                return;
            }
            string msj = "Confirma eliminar el Cliente ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            Int32 CodAlarma = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Clases.cAlarma alarma = new Clases.cAlarma();
            alarma.EliminarAlarma(CodAlarma);
            Buscar();
        }

        private void btnAgregarAlerta_Click(object sender, EventArgs e)
        {
            FrmRegistrarAlarma frm = new FrmRegistrarAlarma();
            frm.ShowDialog();
        }

        
        
      
    }
}
