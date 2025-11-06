using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Concesionaria.Clases;
namespace Concesionaria
{
    public partial class FrmImportarPrecioAutos : FrmBase 
    {
        public FrmImportarPrecioAutos()
        {
            InitializeComponent();
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {    
                string ruta = ""; //file.FileName;
                ruta = file.FileName;
                //Imagen.Image = System.Drawing.Image.FromFile(ruta);
                //string RutaGrabar = "e:\\ARCHIVO\\" + file.SafeFileName.ToString();
                // string RutaGrabar = cRuta.GetRuta() + "\\" + file.SafeFileName.ToString();
                txtRuta.Text = ruta;
                Procesar();
                btnAbrirArchivo.Enabled = false;
                btnAbrirArchivo.Text = "Procesando";
                btnAbrirArchivo.Enabled = true;
                btnAbrirArchivo.Text = "Procesado";
            }
            else
            {
                txtRuta.Text = "";
            }
        }

        private void Procesar()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str = "";
            int rCnt = 0;
            int cCnt = 0;
            int rw = 0;
            int cl = 0;

            string Ruta = txtRuta.Text;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(Ruta, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;
           
            string  CodStock = "";          
            Double PrecioVenta = 0;
            Double Revista = 0;
            Double Mercado = 0;
            int Con = 0;

            cStockAuto stock = new cStockAuto();
                            
            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    
                    switch (cCnt)
                    {
                        
                        case 1:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                CodStock = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                CodStock = "0";
                            break;                 
                        case 7:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Revista = (Double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Revista = 0;
                            break;
                            
                        case 8:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                Mercado = (Double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                Mercado = 0;                     
                            break;
                        case 9:
                            if ((range.Cells[rCnt, cCnt] as Excel.Range).Value2 != null)
                                PrecioVenta = (Double)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                            else
                                PrecioVenta = 0;
                            break;

                    }
                }
                if (CodStock !="0")
                {
                    stock.ActualizarPreciosVariios(Convert.ToInt32(CodStock), Revista, Mercado, PrecioVenta);
                    Con = Con + 1;
                }
               
               
            }
            string msj = "Filas recorridos " + Con.ToString();
            txtProceso.Text = Con.ToString();
            MessageBox.Show(msj);
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            this.Close();
        }

    }
}
