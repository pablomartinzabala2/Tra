using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Concesionaria.Clases;

namespace Concesionaria
{
    public partial class FrmAdjuntarArchivo : FrmBase
    {
        public FrmAdjuntarArchivo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cArchivo archivo = new Clases.cArchivo();
            cVenta venta = new cVenta();
            int Codigo = archivo.GetCodigo();
            string RutaNueva = "";
            string ArchivoNuevo = "";
            Codigo = Codigo + 1;
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            try
            {
                string Ruta = op.FileName;
                TXTrUTA.Text = Ruta;
                // string RutaNueva = "D:\\Pablo\\Prueba.pdf";
                RutaNueva = archivo.GetRuta();
                ArchivoNuevo = "RC-" + Codigo.ToString() + ".pdf";
                RutaNueva = RutaNueva + ArchivoNuevo;
                File.Copy(Ruta, RutaNueva);
                archivo.GrabarCodigo(Codigo);
                Int32 CodVenta = Convert.ToInt32(Principal.Codigo);
                venta.ActualizarArchivo(ArchivoNuevo, CodVenta);
                MessageBox.Show("Archivo guardado correctamente");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error, debe seleccionar un archivo pdf");       
            }


          
        }
    }
}
