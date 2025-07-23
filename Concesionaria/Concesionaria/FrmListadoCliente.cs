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
    public partial class FrmListadoCliente : FormularioBase
    {
        public FrmListadoCliente()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        { /*
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmb_CodTipoDoc, "TipoDocumento", "Nombre", "CodTipoDoc");
            if (cmb_CodTipoDoc.Items.Count > 0)
                cmb_CodTipoDoc.SelectedIndex = 1;
                */
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar ()
        {
            Int32? CodTipoDoc = null;
            /*
            if (cmb_CodTipoDoc.SelectedIndex > 0)
                CodTipoDoc = Convert.ToInt32(cmb_CodTipoDoc.SelectedValue);
                */
            string Nombre = "";
            if (txtNonbre.Text != "")
                Nombre = txtNonbre.Text;

            cFunciones fun = new cFunciones();
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientes(CodTipoDoc, Nombre);
            Grilla.DataSource = trdo;
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla ,"0;50;15;25;10");

        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            if (Grilla.Rows.Count ==0)
            {
                MessageBox.Show("No hay registros");
                return;

            }

            string Ape = "";
            string Nom = "";
            string Telefono = "";
            string Calle = "";
            string Numero = "";
            int Orden = 0;
            cReporte report = new cReporte();
            report.Borrar();
            /*
            Clases.cDb.ExecutarNonQuery("delete from Reporte");
            string Ape = "";
            string Nom = "";
            string Telefono = "";
            string Calle = "";
            string Numero = "";
            string sql = "";
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                sql = "";
                Ape = Grilla.Rows[i].Cells[0].Value.ToString();
                Nom = Grilla.Rows[i].Cells[1].Value.ToString();
                Telefono = Grilla.Rows[i].Cells[2].Value.ToString();
                Calle = Grilla.Rows[i].Cells[3].Value.ToString();
                Numero = Grilla.Rows[i].Cells[4].Value.ToString();
                sql = "Insert into Reporte(PARTE1,PARTE2,PARTE3,";
                sql = sql + "PARTE4,PARTE6)";
                sql = sql + " Values(" + "'" + Ape + "'";
                sql = sql + "," + "'" + Nom + "'";
                sql = sql + "," + "'" + Telefono  + "'";
                sql = sql + "," + "'" + Calle + "'";
                sql = sql + "," + "'" + Numero + "'";
                sql = sql + ")";
                cDb.ExecutarNonQuery(sql);
            }
            FrmReporteCliente frm = new FrmReporteCliente();
            frm.Show();
            */

            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Orden++; 
                Nom = Grilla.Rows[i].Cells[1].Value.ToString();
                Telefono = Grilla.Rows[i].Cells[2].Value.ToString();
                Calle = Grilla.Rows[i].Cells[3].Value.ToString();
                Numero = Grilla.Rows[i].Cells[4].Value.ToString();
                report.Insertar(Orden, Nom, Telefono, Calle, Numero, "", "", "", "", "", "", "", "", "", "");       
            }
            FrmReporteClientes frm = new FrmReporteClientes();
            frm.Show();
        }

        private void ntmAbrirCliente_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            Principal.CodigoPrincipalAbm = Codigo;
            FrmAbmCliente frm = new FrmAbmCliente();
            frm.Show(); 
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {   
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe registrar primero el cliente para continuar ");
                return;
            }

            Int32 CodCliente = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodCliente = CodCliente;
            FrmPersonal frm = new FrmPersonal();
            frm.Show();

        }
    }
}
