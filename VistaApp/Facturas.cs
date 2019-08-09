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
    public partial class Facturas : Form
    {
        private LogicaInventario F = new LogicaInventario();

        public Facturas()
        {
            InitializeComponent();
            CargarListado();
        }

        private void CargarListado()
        {
            DataTable dt = new DataTable();
            dt = F.ListarFacturas();
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
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][4].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

    }
}
