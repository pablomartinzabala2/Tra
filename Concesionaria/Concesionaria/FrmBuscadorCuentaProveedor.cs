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
    public partial class FrmBuscadorCuentaProveedor : FormularioBase
    {
        public FrmBuscadorCuentaProveedor()
        {
            InitializeComponent();
        }

        private void FrmBuscadorCuentaProveedor_Load(object sender, EventArgs e)
        {
            Buscar("");
        }

        private void Buscar(string Proveedor)
        {
            cFunciones fun = new cFunciones();
            cCuentaProveedor cuenta = new cCuentaProveedor();
            DataTable trdo = cuenta.GetCuentasProveedores(Proveedor);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;50;50");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }
            Int32 CodCuenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
            Principal.CodigoPrincipalAbm = CodCuenta.ToString();
            this.Close();
        }
    }
}
