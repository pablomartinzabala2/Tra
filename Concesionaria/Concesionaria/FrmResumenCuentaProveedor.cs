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
    public partial class FrmResumenCuentaProveedor : FormularioBase
    {
        public FrmResumenCuentaProveedor()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            if (Principal.CodigoPrincipalAbm != null)
            {
                Int32 CodCuenta = Convert.ToInt32(Principal.CodigoPrincipalAbm);
                txtCodCuenta.Text = CodCuenta.ToString();
                cCuentaProveedor Cuenta = new Clases.cCuentaProveedor();
                DataTable trdo = Cuenta.GetDetalleCuentas(CodCuenta);
                if (trdo.Rows.Count > 0)
                {
                    txtProveedor.Text = trdo.Rows[0]["Proveedor"].ToString();
                    txtCuentaProveedor.Text = trdo.Rows[0]["Nombre"].ToString();
                    Cargar(CodCuenta);
                }
               
            }
        }

        private void FrmResumenCuentaProveedor_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Cargar(Int32 CodCuentaProveedor)
        {
            cFunciones fun = new Clases.cFunciones();
            cMovimientoProveedor mov = new Clases.cMovimientoProveedor();
            DataTable trdo = mov.GetResumen(CodCuentaProveedor);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;10;40;25;25");
        }
    }
}
