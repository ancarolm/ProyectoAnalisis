using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using LogicaApp;

namespace VistaApp
{
    public partial class Inventario : Form
    {
        LogicaInventario P = new LogicaInventario();

        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            ListarFranquicia();
            ListarCategoria();
            ListarProveedor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void ListarFranquicia()
        {

            cbxCategoria.DisplayMember = "Ubicacion";
            cbxCategoria.ValueMember = "idFranquicia";
            cbxCategoria.DataSource = P.Listado();
        }

        private void ListarCategoria()
        {

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "idCategoria";
            comboBox1.DataSource = P.ListarCat();
        }

        private void ListarProveedor()
        {

            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "idProveedor";
            comboBox2.DataSource = P.ListarProv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            if (txtProducto.Text.Trim() != "")
            {
                if (txtNombre.Text.Trim() != "")
                {
                    if (comboBox1.Text.Trim() != "")
                    {
                        if (txtDetalle.Text.Trim() != "")
                        {
                            if (txtCantidad.Text.Trim() != "")
                            {
                                if (Program.Evento == 0)
                                {
                                    P.IdProducto = Convert.ToInt32(txtProducto.Text);
                                    P.Name = txtNombre.Text;
                                    P.IdCategoria = Convert.ToInt32(comboBox1.SelectedValue);
                                    P.Detail = txtDetalle.Text;
                                    P.Quantity = Convert.ToInt32(txtCantidad.Text);
                                    P.Brand = txtMarca.Text;
                                    P.IdProveedor = Convert.ToInt32(comboBox2.SelectedValue);
                                    P.IdFranquicia = Convert.ToInt32(cbxCategoria.SelectedValue);
                                    Mensaje = P.AgregarInventario();
                                    if (Mensaje == "Este Producto ya ha sido Registrado.")
                                    {
                                        MessageBox.Show(Mensaje, "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        //MessageBox.Show("¡Producto agregado a inventario!");
                                        MessageBoxEx.Show(Mensaje, "Inventario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtProducto.Clear();
                                        txtMarca.Clear();
                                        txtNombre.Clear();
                                        //txtCategoria.Clear();
                                        txtDetalle.Clear();
                                        txtCantidad.Clear();
                                        //txtProveedor.Clear();
                                        //cbxCategoria.;
                                        txtProducto.Focus();
                                    }
                                }
                                else
                                {
                                    P.IdProducto = Convert.ToInt32(txtProducto.Text);
                                    P.Name = txtNombre.Text;
                                    P.IdCategoria = Convert.ToInt32(comboBox1.SelectedValue);
                                    P.Detail = txtDetalle.Text;
                                    P.Quantity = Convert.ToInt32(txtCantidad.Text);
                                    P.Brand = txtMarca.Text;
                                    P.IdProveedor = Convert.ToInt32(comboBox2.SelectedValue);
                                    P.IdFranquicia = Convert.ToInt32(cbxCategoria.SelectedValue);
                                    //MessageBoxEx.Show(P.ActualizarProductos(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        comboBox1.Focus();
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
            //txtCategoria.Clear();
            txtDetalle.Clear();
            txtCantidad.Clear();
            //txtProveedor.Clear();
            //txtFranquicia.Clear();
            txtProducto.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventarioVista IV = new InventarioVista();
            IV.Show();
        }

        
    }

}
