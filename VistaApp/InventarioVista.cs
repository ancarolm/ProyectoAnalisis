using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LogicaApp;

namespace VistaApp
{
    public partial class InventarioVista : Form
    {

        private LogicaInventario P = new LogicaInventario(); 

        public InventarioVista()
        {
            InitializeComponent();
        }

        private void InventarioVista_Load(object sender, EventArgs e)
        {
            
            CargarListado();
            dataGridView1.ClearSelection();
        }

        private void CargarListado()
        {
            DataTable dt = new DataTable();
            dt = P.Listar();
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
       
                P.IdProducto = Convert.ToInt32(txtProducto.Text);
                dt = P.EliminarInventario(P.IdProducto);
                txtProducto.Clear();
                MessageBox.Show("Eliminado de inventario.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                P.Name = txtProducto.Text;
                dt = P.BuscarInventario(P.Name);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtProducto.Text = row.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inventario ventana = new Inventario();
            ventana.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                InventarioEditar E  = new InventarioEditar();
                E.txtProducto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                E.txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                E.txtCategoria.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                E.txtDetalle.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                E.txtCantidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                E.txtMarca.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                E.txtProveedor.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                E.txtFranquicia.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                E.Show();

                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Debe Seleccionar la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtProducto.Clear();
            CargarListado();
        }
    }
}
