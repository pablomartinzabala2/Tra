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
    public partial class FrmRegistrarPreciopFlete : FrmBase
    {
        public FrmRegistrarPreciopFlete()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cFunciones fun = new cFunciones();
            cDistancia dis = new Clases.cDistancia();
            DataTable trdo = dis.GetDistanciasDetallada();
            trdo = fun.TablaaMiles(trdo, "Completo");
            trdo = fun.TablaaMiles(trdo, "Media");
            trdo = fun.TablaaMiles(trdo, "Cuarto");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;0;0;40;15;15;15;15");
        }

        private void btnGrabarPrecio_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text =="")
            {
                MessageBox.Show("Debe ingresar un precio ");
                return;
            }

            cDistancia dis = new Clases.cDistancia();
            Double Precio = Convert.ToInt32(txtPrecio.Text);
            dis.ActualizarPrecio(Precio);
            MessageBox.Show("Datos actualizados correctamente ");
            Buscar(); 

        }

        private void FrmRegistrarPreciopFlete_Load(object sender, EventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            cDistancia dis = new Clases.cDistancia();
            Double Precio = dis.GetPrecio();
            txtPrecio.Text = Precio.ToString();
            if (txtPrecio.Text !="" && txtPrecio.Text !="0")
            {
                Buscar();
            }
        }

       
    }
}
