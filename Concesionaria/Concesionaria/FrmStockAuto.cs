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
    public partial class FrmStockAuto : Form
    {
        public FrmStockAuto()
        {
            InitializeComponent();
        }

        private void FrmStockAuto_Load(object sender, EventArgs e)
        {
           // PintarFormulario();
            Clases.cFunciones fun = new Clases.cFunciones();
            fun.LlenarCombo(cmbMarca, "Marca", "Nombre", "CodMarca");
            CargarEstado();
            txtTotalVehiculos.BackColor = cColor.CajaTexto();
            txtMontoTotal.BackColor = cColor.CajaTexto();
            DataTable tbOrden = new DataTable();
            tbOrden = fun.CrearTabla("Codigo;Nombre");
            tbOrden = fun.AgregarFilas(tbOrden, "1;Asc");
            tbOrden = fun.AgregarFilas(tbOrden, "2;Desc");
            fun.LlenarComboDatatable(cmbOrden, tbOrden, "Nombre", "Codigo");
            Buscar();
            PintarEstados();
            Grilla.Columns[12].Visible = false;
            //costo visible
            fun.AnchoColumnas(Grilla, "5;0;8;10;14;3;10;8;8;10;0;8;8;8;0");
            //costo invisible
            //  fun.AnchoColumnas(Grilla, "5;0;8;10;22;3;10;8;8;10;0;8;0;8;0");
            fun.AnchoColumnas(Grilla, "5;0;8;10;22;3;10;5;8;5;0;12;0;12;0");
        }

        private void BuscarAutosdeStock(string Patente, Int32? CodMarca, string Modelo)
        {
            int? OrdenaPrecio = null;
            if (cmbOrden.SelectedIndex > 0)
                OrdenaPrecio = Convert.ToInt32(cmbOrden.SelectedValue);
            Int32? Concesion = null;

            if (CmbEstado.SelectedIndex > 0)
                Concesion = Convert.ToInt32(CmbEstado.SelectedValue);
            double Total = 0;
            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cStockAuto stock = new Clases.cStockAuto();
            DataTable trdo = stock.GetStockDetalladosVigente(Patente, CodMarca, Modelo, OrdenaPrecio, Concesion);
            trdo = fun.TablaaMiles(trdo, "Costo");
            Total = fun.TotalizarColumna(trdo, "Costo");
            txtTotalVehiculos.Text = trdo.Rows.Count.ToString();
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[2].Width = 195;
            Grilla.Columns[3].Width = 280;
            Grilla.Columns[4].Width = 90;
            Grilla.Columns[5].Width = 200;
            Grilla.Columns[4].HeaderText = "Fecha";
            Grilla.Columns[5].HeaderText = "Ex Titular";
            Grilla.Columns[7].HeaderText = "Concesión";
            txtMontoTotal.Text = Total.ToString();
            if (txtMontoTotal.Text != "")
            {
                txtMontoTotal.Text = fun.SepararDecimales(txtMontoTotal.Text);
                txtMontoTotal.Text = fun.FormatoEnteroMiles(txtMontoTotal.Text);
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            int? OrdenaPrecio = null;
            if (cmbOrden.SelectedIndex > 0)
                OrdenaPrecio = Convert.ToInt32(cmbOrden.SelectedValue);

            Clases.cFunciones fun = new Clases.cFunciones();
            string Patente = txtPatente.Text;
            string Modelo = "";
            if (txtModelo.Text != "")
                Modelo = txtModelo.Text;
            Int32? CodMarca = null;
            if (cmbMarca.SelectedIndex > 0)
                CodMarca = Convert.ToInt32(cmbMarca.SelectedValue);
            Int32? Concesion = null;
            if (CmbEstado.SelectedIndex > 0)
                Concesion = Convert.ToInt32(CmbEstado.SelectedValue);

            Clases.cStockAuto stock = new Clases.cStockAuto();
            DataTable trdo = stock.GetStockDetalladosVigente(Patente, CodMarca, Modelo, OrdenaPrecio, Concesion);
            txtTotalVehiculos.Text = trdo.Rows.Count.ToString();
            trdo = fun.TablaaMiles(trdo, "Cs");
            trdo = fun.TablaaMiles(trdo, "Revista");
            trdo = fun.TablaaMiles(trdo, "PrecioVenta");
            trdo = fun.TablaaMiles(trdo, "km");
            Grilla.DataSource = trdo;
          
            Grilla.Columns[2].HeaderText = "Dominio";
            Grilla.Columns[3].HeaderText = "Marca";
            Grilla.Columns[5].HeaderText = "C";
            Double Total = fun.TotalizarColumna(trdo, "PrecioVenta");
            txtMontoTotal.Text = Total.ToString();


            txtMontoTotal.Text = Total.ToString();

            if (txtMontoTotal.Text != "")
            {
                txtMontoTotal.Text = fun.SepararDecimales(txtMontoTotal.Text);
                txtMontoTotal.Text = fun.FormatoEnteroMiles(txtMontoTotal.Text);
            }

            // fun.AnchoColumnas(Grilla, "5;0;8;10;23;8;10;8;8;10;0;10;0");
            // fun.AnchoColumnas(Grilla, "5;0;8;10;14;3;10;8;8;10;0;8;8;8;0");
          //  cFunciones fun = new cFunciones();
         
            PintarEstados();
        }

        private void PintarEstados()
        {
            string Estado = "";
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                Estado = Grilla.Rows[i].Cells[12].Value.ToString();
                switch (Estado)
                {
                    case "1":
                        Grilla.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                       // Grilla.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "2":
                        Grilla.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case "3":
                        Grilla.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        Grilla.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        break;
                }

            }
        }

        private void PintarFormulario()
        {
            foreach (Control c in this.Controls)
            {
                string name = c.Name;
                if (c is TextBox)
                    c.BackColor = Color.LightGray;
                if (c is GroupBox)
                {
                    foreach (Control g in c.Controls)
                    {
                        if (g is TextBox || g is MaskedTextBox)
                            g.BackColor = Clases.cConfiguracion.ColorTextBox();
                        //g.BackColor = System.Drawing.SystemColors.Control;   
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro para continuar", Clases.cMensaje.Mensaje());
                return;
            }
            string CodStock = Grilla.CurrentRow.Cells[1].Value.ToString();
            Principal.CodigoPrincipalAbm = CodStock.ToString();
            FrmDetalleAuto childForm = new FrmDetalleAuto();
            childForm.Text = "Detalle del vehículo";
            childForm.ShowDialog();
        }

        private void btnBajaStock_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un elemento para continuar", Clases.cMensaje.Mensaje());
                return;
            }

            string msj = "Confirma quitar el auto del stock ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            Int32 CodStock = Convert.ToInt32(Grilla.CurrentRow.Cells[1].Value);
            Int32 Concesion = Convert.ToInt32(Grilla.CurrentRow.Cells[7].Value);
            Clases.cStockAuto stock = new Clases.cStockAuto();
            stock.InsertarBajaStock(CodStock, DateTime.Now);
            MessageBox.Show("Datos grabados correctamente", Clases.cMensaje.Mensaje());
            Buscar();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Int32 CodStock = 0;
            string Descripcion = "";
            string Marca = "";
            string Patente = "";
            string Precio = "100.00";
            string Modelo = "";
            string Kilometros = "";
            string Combustible = "";
            string NumeroInterno = "";
            string Ubicacion = "";
            string Color = "";
            string Anio = "";
            string sql = "";

            Clases.cFunciones fun = new Clases.cFunciones();
            Clases.cDb.ExecutarNonQuery("delete from ReporteAuto");
            for (int i = 0; i < Grilla.Rows.Count - 1; i++)
            {
                CodStock = Convert.ToInt32(Grilla.Rows[i].Cells[1].Value.ToString());
                Modelo = GetModeloxCodStock(CodStock);
                Precio = GetPrecioxCodStock(CodStock);
                Kilometros = GetKilometrosxCodStock(CodStock);
                Combustible = GetCombustiblexCodStock(CodStock);
                if (Precio != "")
                {
                    Precio = fun.SepararDecimales(Precio);
                    Precio = fun.FormatoEnteroMiles(Precio);
                }


                Patente = Grilla.Rows[i].Cells[2].Value.ToString();
                NumeroInterno = GetNumeroInternoxPatente(Patente);
                //  Ubicacion = GetUbicacion (Patente);
                // Ubicacion = Grilla.Rows[i].Cells[11].Value.ToString();
                Descripcion = Grilla.Rows[i].Cells[4].Value.ToString();
                Marca = Grilla.Rows[i].Cells[3].Value.ToString();
                Color = Grilla.Rows[i].Cells[6].Value.ToString();
                Anio = Grilla.Rows[i].Cells[8].Value.ToString();

                sql = "Insert into ReporteAuto(Extra1,Descripcion,Marca,Modelo,Precio,Kilometros,Combustible,Extra2,Extra3)";
                sql = sql + "values(" + "'" + Patente + "'";
                sql = sql + "," + "'" + Descripcion + "'";
                sql = sql + "," + "'" + Marca + "'";
                sql = sql + "," + "'" + Modelo + "'";
                sql = sql + "," + "'" + Precio + "'";
                sql = sql + "," + "'" + Kilometros + "'";
                sql = sql + "," + "'" + Combustible + "'";
                sql = sql + "," + "'" + Anio + "'";
                sql = sql + "," + "'" + Color + "'";
                sql = sql + ")";
                Clases.cDb.ExecutarNonQuery(sql);
            }
            FrmReporteListaPrecio form = new FrmReporteListaPrecio();
            form.Show();
        }

        private string GetNumeroInternoxPatente(string Patente)
        {
            Clases.cAuto auto = new Clases.cAuto();
            DataTable trdo = auto.GetAutoxPatente(Patente);
            string NumeroInterno = "";
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodAuto"].ToString() != "")
                {
                    NumeroInterno = trdo.Rows[0]["NumeroInterno"].ToString();
                }
            }
            return NumeroInterno;
        }

        private string GetUbicacion(string Patente)
        {
            Clases.cAuto auto = new Clases.cAuto();
            DataTable trdo = auto.GetAutoxPatente(Patente);
            string Ubicacion = "";
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodAuto"].ToString() != "")
                {
                    Ubicacion = trdo.Rows[0]["Ubicacion"].ToString();
                }
            }
            return Ubicacion;
        }
        private string GetModeloxCodStock(Int32 CodStock)
        {
            Clases.cStockAuto obj = new Clases.cStockAuto();
            DataTable trdo = obj.GetStockxCodigo(CodStock);
            string Modelo = "";
            if (trdo.Rows.Count > 0)
            {
                Modelo = trdo.Rows[0]["Anio"].ToString();
            }
            return Modelo;
        }

        private string GetPrecioxCodStock(Int32 CodStock)
        {
            Clases.cStockAuto obj = new Clases.cStockAuto();
            DataTable trdo = obj.GetStockxCodigo(CodStock);
            string Precio = "";
            if (trdo.Rows.Count > 0)
            {
                Precio = trdo.Rows[0]["PrecioVenta"].ToString();
            }
            return Precio;
        }

        private string GetKilometrosxCodStock(Int32 CodStock)
        {
            Clases.cStockAuto obj = new Clases.cStockAuto();
            DataTable trdo = obj.GetStockxCodigo(CodStock);
            string Kilometros = "";
            if (trdo.Rows.Count > 0)
            {
                Kilometros = trdo.Rows[0]["Kilometros"].ToString();
            }
            return Kilometros;
        }

        private string GetCombustiblexCodStock(Int32 CodStock)
        {
            Clases.cStockAuto obj = new Clases.cStockAuto();
            DataTable trdo = obj.GetStockxCodigo(CodStock);
            string Combustible = "";
            if (trdo.Rows.Count > 0)
            {
                Combustible = trdo.Rows[0]["Combustible"].ToString();
            }
            return Combustible;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarEstado()
        {
            cFunciones fun = new cFunciones();
            DataTable trdo = fun.CrearTabla("Codigo;Nombre");
            string Val = "1;Concesion";
            trdo = fun.AgregarFilas(trdo, Val);
            Val = "2;Propio";
            trdo = fun.AgregarFilas(trdo, Val);
            Val = "2;Propio";
            fun.LlenarComboDatatable(CmbEstado, trdo, "Nombre", "Codigo");

        }

        private void btnAplicarIncremento_Click(object sender, EventArgs e)
        {
            if (txtPorcentaje.Text =="")
            {
                MessageBox.Show("Debe ingresar un porcentaje ");
                return;
            }
            Double Porcentaje = 0;
            int i = 0;
            int b = 0;
            Porcentaje = Convert.ToDouble(txtPorcentaje.Text);
            Int32 CodStock = 0;
            int Filas = Grilla.Rows.Count;
            foreach (DataGridViewRow r in Grilla.Rows)
            {
                if (i < Filas)
                {
                    if (Convert.ToBoolean(r.Cells["Sel"].Value) == true)
                    {
                        b = 1;
                        CodStock = Convert.ToInt32(r.Cells[1].Value);
                        AplicarPorcentaje(CodStock, Porcentaje);                     
                    }
                }
                i++;

            }

            if (b==1)
            {
                MessageBox.Show("Datos guardados correctamente ");
            }

            if (b ==0)
            {
                MessageBox.Show("Debe seleccionar un elemento ");
            }
        }

        private void AplicarPorcentaje (Int32 CodStock, Double Porcentaje)
        {
            cCosto Costo = new Clases.cCosto();
            cStockAuto stock = new cStockAuto();
            Int32 CodAuto = 0;
            DateTime Fecha = DateTime.Now;
            string Patente = "";
            Double? Importe = null;
            Double ImporteAplicado = 0;
            int? Inflacion = 1;
            Importe = stock.GetPrecioCompraInflacion(CodStock);
            ImporteAplicado = Convert.ToDouble (Importe) * Porcentaje / 100;
            string Descripcion = "Ajusto por inflación ";
            DataTable trdo = stock.GetStockxCodigo(CodStock);
            if (trdo.Rows.Count >0)
            {
                CodAuto = Convert.ToInt32(trdo.Rows[0]["CodAuto"]);
                Patente = trdo.Rows[0]["Patente"].ToString();
            }

            Costo.InsertarCosto(CodAuto, Patente, ImporteAplicado, Fecha.ToShortDateString() , Descripcion, CodStock, null, null, Inflacion);
        }

        private void BtnVerGanancia_Click(object sender, EventArgs e)
        {
            cFunciones fun = new cFunciones();
            if (Grilla.Columns[12].Visible == false)
            {
                Grilla.Columns[12].Visible = true;
               // fun.AnchoColumnas(Grilla, "5;0;8;10;14;3;10;8;8;10;0;8;8;8;0");
                fun.AnchoColumnas(Grilla, "5;0;8;10;10;3;10;5;8;5;0;12;12;12;0");

            }
            else
            {
                Grilla.Columns[12].Visible = false;
                //fun.AnchoColumnas(Grilla, "5;0;8;10;22;3;10;8;8;10;0;8;0;8;0");
                fun.AnchoColumnas(Grilla, "5;0;8;10;22;3;10;5;8;5;0;12;0;12;0");
            }
        }
    }
}
