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
    public partial class Factura : Form
    {
        private Platillo C = new Platillo();
        private LogicaVenta V = new LogicaVenta();

        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            ListarElementos();
            ListarPago();
        }

        private List<Venta> lst = new List<Venta>();

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes ventana = new BuscarClientes();
            ventana.Show();
        }
        private void ListarElementos()
        {
      
                cbxCategoria.DisplayMember = "Nombre";
                cbxCategoria.ValueMember = "idPlatillo";
                cbxCategoria.DataSource = C.Listado();
        }

        private void ListarPago()
        {

            comboBox.DisplayMember = "Tipo";
            comboBox.ValueMember = "idPago";
            comboBox.DataSource = V.Listado();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            try
            {
                C.idPlatillo = Convert.ToInt32(cbxCategoria.SelectedValue);
                dt = V.AgregarVenta(C.idPlatillo);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    //dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    //dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
                }

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }


        private void LlenarGrilla()
        {
            Decimal SumaSubTotal = 0; Decimal SumaIgv = 0; Decimal SumaTotal = 0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = lst[i].IdFactura;
                dataGridView1.Rows[i].Cells[1].Value = lst[i].IdCliente;
                dataGridView1.Rows[i].Cells[2].Value = lst[i].IdVendedor;
                dataGridView1.Rows[i].Cells[3].Value = lst[i].Detalle;
                dataGridView1.Rows[i].Cells[5].Value = lst[i].Precio;
                dataGridView1.Rows[i].Cells[6].Value = lst[i].SubTotal;
                SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                SumaIgv += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
