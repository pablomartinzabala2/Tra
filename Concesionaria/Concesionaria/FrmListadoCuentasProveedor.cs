﻿using System;
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
    public partial class FrmListadoCuentasProveedor : FormularioBase
    {
        public FrmListadoCuentasProveedor()
        {
            InitializeComponent();
        }

        private void FrmListadoCuentasProveedor_Load(object sender, EventArgs e)
        {
            CargarOrden();
            Buscar("","");
        }

        private void CargarOrden()
        {
            cFunciones fun = new cFunciones();
            DataTable tbOrden = new DataTable();
            tbOrden = fun.CrearTabla("Codigo;Nombre");
            tbOrden = fun.AgregarFilas(tbOrden, "1;Asc");
            tbOrden = fun.AgregarFilas(tbOrden, "2;Desc");
            fun.LlenarComboDatatable(cmbOrden, tbOrden, "Nombre", "Codigo");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text.Trim();
            string Cuenta = txtCuenta.Text;
            Buscar(Cuenta , Nombre);
        }

        private void Buscar(string NombreCuenta, string Proveedor)
        {
            cFunciones fun = new cFunciones();
            int? Orden = null;
            if (cmbOrden.SelectedIndex > 0)
                Orden = Convert.ToInt32(cmbOrden.SelectedValue);

            cCuentaProveedor Cuenta = new Clases.cCuentaProveedor();
            DataTable trdo = Cuenta.GetCuentasResumidas(NombreCuenta, Proveedor, Orden);
            trdo = fun.TablaaMiles(trdo, "Importe");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "10;30;30;30");
        }

        private void btnCobroCheque_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                MessageBox.Show("Debe seleccionar un registro ");
                return;
            }
            Int32 CodCuenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodigoPrincipalAbm = CodCuenta.ToString();
            FrmPagoCuentaProveedor frm = new FrmPagoCuentaProveedor();
            frm.Show();
        }

        private void btnVerResumen_Click(object sender, EventArgs e)
        {
            Int32 CodCuenta = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value);
            Principal.CodigoPrincipalAbm = CodCuenta.ToString();
            FrmResumenCuentaProveedor frm = new FrmResumenCuentaProveedor();
            frm.Show();
        }
    }
}
