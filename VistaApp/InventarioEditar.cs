﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using LogicaApp;

namespace VistaApp
{
    public partial class InventarioEditar : Form
    {
        LogicaInventario P = new LogicaInventario();

        public InventarioEditar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            if (txtProducto.Text.Trim() != "")
            {
                if (txtNombre.Text.Trim() != "")
                {
                    if (txtCategoria.Text.Trim() != "")
                    {
                        if (txtDetalle.Text.Trim() != "")
                        {
                            if (txtCantidad.Text.Trim() != "")
                            {
                                if (Program.Evento == 0)
                                {
                                    P.IdProducto = Convert.ToInt32(txtProducto.Text);
                                    P.Name = txtNombre.Text;
                                    P.IdCategoria = Convert.ToInt32(txtCategoria.Text);
                                    P.Detail = txtDetalle.Text;
                                    P.Quantity = Convert.ToInt32(txtCantidad.Text);
                                    P.Brand = txtMarca.Text;
                                    P.IdProveedor = Convert.ToInt32(txtProveedor.Text);
                                    P.IdFranquicia = Convert.ToInt32(txtFranquicia.Text);
                                    Mensaje = P.AgregarInventario();
                                    if (Mensaje == "Este Producto ya ha sido Registrado.")
                                    {
                                        MessageBox.Show(Mensaje, "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        //MessageBox.Show("¡Producto agregado a inventario!");
                                        MessageBox.Show(Mensaje, "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtProducto.Clear();
                                        txtMarca.Clear();
                                        txtNombre.Clear();
                                        txtCategoria.Clear();
                                        txtDetalle.Clear();
                                        txtCantidad.Clear();
                                        txtProveedor.Clear();
                                        txtFranquicia.Clear();
                                        txtProducto.Focus();
                                    }
                                }
                                else
                                {
                                    P.IdProducto = Convert.ToInt32(txtProducto.Text);
                                    P.Name = txtNombre.Text;
                                    P.IdCategoria = Convert.ToInt32(txtCategoria.Text);
                                    P.Detail = txtDetalle.Text;
                                    P.Quantity = Convert.ToInt32(txtCantidad.Text);
                                    P.Brand = txtMarca.Text;
                                    P.IdProveedor = Convert.ToInt32(txtProveedor.Text);
                                    P.IdFranquicia = Convert.ToInt32(txtFranquicia.Text);
                                    MessageBox.Show(P.EditarInventario(), "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpiar();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por Favor Ingrese Stock del Producto.", "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtCantidad.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por Favor Ingrese Precio de Venta del Producto.", "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDetalle.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Ingrese Precio de Compra del Producto.", "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCategoria.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese Marca del Producto.", "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre del Producto.", "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
            }
        }

        private void Limpiar()
        {

            txtProducto.Clear();
            txtMarca.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtDetalle.Clear();
            txtCantidad.Clear();
            txtProveedor.Clear();
            txtFranquicia.Clear();
            txtProducto.Focus();
        }
    }
}
