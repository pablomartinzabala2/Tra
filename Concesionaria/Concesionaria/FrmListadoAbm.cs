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
    public partial class FrmListadoAbm : FormularioBase
    {
        public FrmListadoAbm()
        {
            InitializeComponent();
        }

        private void FrmListadoAbm_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            cFunciones fun = new Clases.cFunciones();
            DataTable tb = new DataTable();
            tb = fun.CrearTabla("Codigo;Nombre");
            tb = fun.AgregarFilas(tb, "3;Categoria de Gasto");
            tb = fun.AgregarFilas(tb, "1;Colores");
            tb = fun.AgregarFilas(tb, "4;Entidad");
            tb = fun.AgregarFilas(tb, "2;Tipo de Financiaciòn");
            Grilla.DataSource = tb;
            fun.AnchoColumnas(Grilla, "0;100");
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Msj("Debe seleccionar un elemento");
                return;
            }
            int Codigo = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            switch(Codigo)
            {
                case 1:
                    FrmAbmColor frm = new FrmAbmColor();
                    frm.Show();
                    break;
                case 2:
                    FrmAbmTipoFinanciacion form = new FrmAbmTipoFinanciacion();
                    form.Show();
                    break;
                case 3:
                    FrmAbmCategoriaGasto frm2 = new FrmAbmCategoriaGasto();
                    frm2.Show();
                    break;
                case 4:
                    FrmAbmEntidad frmentidad = new FrmAbmEntidad();
                    frmentidad.Show();
                    break;
            }
            
        }
        
    }
}
