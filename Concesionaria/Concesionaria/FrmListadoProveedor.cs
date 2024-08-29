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
    public partial class FrmListadoProveedor : FrmBase 
    {
        public FrmListadoProveedor()
        {
            InitializeComponent();
        }

        private void FrmListadoProveedor_Load(object sender, EventArgs e)
        {

        }

        private void Buscar(string Nombre)
        {
            cFunciones fun = new cFunciones();
            cProveedor prov = new Clases.cProveedor();
            DataTable trdo = prov.GetProveedorxNombre(Nombre);
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;70;30");
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            string Nombre = "";
            if (txtNonbre.Text != "")
                Nombre = txtNonbre.Text;
            Buscar(Nombre);
        }
    }
}
