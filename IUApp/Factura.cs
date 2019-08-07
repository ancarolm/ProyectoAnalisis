﻿using System;
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
    public partial class Factura : Form
    {
        private Platillo C = new Platillo();
        private LogicaVenta V = new LogicaVenta();

        private List<Venta> lst = new List<Venta>();

        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            //ListarElementos();
            ListarPago();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes ventana = new BuscarClientes();
            ventana.Show();
        }
        /*private void ListarElementos()
        {
      
                cbxCategoria.DisplayMember = "Nombre";
                cbxCategoria.ValueMember = "idPlatillo";
                cbxCategoria.DataSource = C.Listado();
        }*/

        private void ListarPago()
        {

            comboBox.DisplayMember = "Tipo";
            comboBox.ValueMember = "idPago";
            comboBox.DataSource = V.Listado();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Venta V = new Venta();

            if (prodNom.Text.Trim() != "")
            {

                V.Nombre = prodNom.Text;
                V.Categoria = prodCat.Text;
                V.Precio = Convert.ToDecimal(prodPre.Text);
                lst.Add(V);
                LlenarTabla();

            } else
            {
                MessageBoxEx.Show("Por Favor Busque el Producto a Vender.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LlenarTabla()
        {
            /*Decimal SumaSubTotal = 0; Decimal SumaIgv=0;*/
            Decimal SumaTotal = 0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = lst[i].IdPlatillo;
                dataGridView1.Rows[i].Cells[1].Value = lst[i].Nombre;
                dataGridView1.Rows[i].Cells[2].Value = lst[i].Categoria;
                dataGridView1.Rows[i].Cells[3].Value = lst[i].Detalle;
                dataGridView1.Rows[i].Cells[4].Value = lst[i].Precio;
                //dataGridView1.Rows[i].Cells[5].Value = lst[i].IdProducto;
                //dataGridView1.Rows[i].Cells[6].Value = lst[i].Igv;
                //SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                //SumaIgv += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }

            /*dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            //dataGridView1.Rows[lst.Count + 1].Cells[3].Value = "SUB-TOTAL  S/.";
            //dataGridView1.Rows[lst.Count + 1].Cells[4].Value = SumaSubTotal;
            dataGridView1.Rows.Add();
            //dataGridView1.Rows[lst.Count + 2].Cells[3].Value = "      I.G.V.        %";
            //dataGridView1.Rows[lst.Count + 2].Cells[4].Value = SumaIgv;
            dataGridView1.Rows.Add();
            //dataGridView1.Rows[lst.Count + 3].Cells[3].Value = "     TOTAL     S/.";
            //SumaTotal += SumaSubTotal + SumaIgv;
            dataGridView1.Rows[lst.Count + 3].Cells[4].Value = SumaTotal;
            dataGridView1.ClearSelection();*/
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Factura_Activated(object sender, EventArgs e)
        {
            prodNom.Text = Program.Nombre;
            prodCat.Text = Program.Categoria;
            prodPre.Text = Program.Precio +"";
            txtClienteID.Text = Program.IdCliente+"";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListaPlatillos LP = new ListaPlatillos();
            LP.Show();
        }
    }
}
