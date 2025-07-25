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
    public partial class FrmListadoConceptos : FrmBase
    {
        public FrmListadoConceptos()
        {
            InitializeComponent();
        }

        private void FrmListadoConceptos_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            cConcepto concepto = new Clases.cConcepto();
            DataTable trdo = concepto.GetConceptos();
            Grilla.DataSource = trdo;
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }

            int CodConcepto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Principal.Codigo = CodConcepto;
            FrmRegistrarPago frm = new FrmRegistrarPago();
            frm.Show();

        }
    }
}
