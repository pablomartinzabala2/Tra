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
    public partial class FrmBuscarCheque : FormularioBase
    {
        public FrmBuscarCheque()
        {
            InitializeComponent();
        }

        private void FrmBuscarCheque_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            cChequeCobrar cheque = new cChequeCobrar();
            DataTable trdo = cheque.GetChequesImpagoss();
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            
            fun.AnchoColumnas(Grilla, "0;25;25;25;25");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Msj("Debe seleccionar un elemento");
                return;
            }
            Int32 CodCheque = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Principal.CodCheque = CodCheque;
            this.Close();
        }
    }
}
