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
using AppLogica;

namespace IUApp
{
    public partial class ListaPlatillos : Form
    {
        int Listado = 0;
        private Platillo P = new Platillo();

        public ListaPlatillos()
        {
            InitializeComponent();
        }

        private void ListaPlatillos_Load(object sender, EventArgs e)
        {
            CargarListado();
            dataGridView1.ClearSelection();
        }

        private void CargarListado()
        {
            DataTable dt = new DataTable();
            dt = P.Listado();
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                //timer1.Stop();
            }
        }

        private void BusquedaProductos()
        {
            DataTable dt = new DataTable();
            try
            {
                P.Nombre = txtBuscarProducto.Text;
                dt = P.BuscarPlatillo(P.Nombre);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }
        


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //Program.IdProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //Program.Descripcion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //Program.Marca = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //Program.PrecioVenta = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            //Program.Stock = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            this.Close();
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BusquedaProductos();
                //timer1.Stop();
            }
            else
            {
                CargarListado();
                //timer1.Start();
            }
        }
    }
}
