using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLogica;

namespace IUApp
{
    public partial class BuscarClientes : Form
    {
        private LogicaClientes C = new LogicaClientes();

        public BuscarClientes()
        {
            InitializeComponent();
        }

        private void BuscarClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
            dataGridView1.ClearSelection();
        }

        private void ListarClientes()
        {
            DataTable dt = new DataTable();
            dt = C.Listado();
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
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarCliente ventana = new RegistrarCliente();
            ventana.Show();
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //dataGridView1.ClearSelection();
                DataTable dt = new DataTable();
                
                try
                {
                    C.Nombre = txtNombre.Text;
                    C.PrimerApellido = textApellido.Text;
                    dt = C.BuscarCliente(C.Nombre, C.PrimerApellido);
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
                    }
                    
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
                }
                dataGridView1.ClearSelection();
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            textApellido.Clear();
            ListarClientes();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Factura F = new Factura();
            string idCliente = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //Program.IdCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            F.txtClienteID.Text = idCliente;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
