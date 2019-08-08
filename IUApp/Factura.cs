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
using System.Net;
using System.Net.Mail;
using AppLogica;

namespace IUApp
{
    public partial class Factura : Form
    {
        NetworkCredential login;
        SmtpClient cliente;
        MailMessage mensaje;

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
            ListarFranquicia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClientes ventana = new BuscarClientes();
            ventana.Show();
        }

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
            
            //Decimal SumaTotal = 0;

            dataGridView1.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
      
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = lst[i].IdPlatillo;
                dataGridView1.Rows[i].Cells[1].Value = lst[i].Nombre;
                dataGridView1.Rows[i].Cells[2].Value = lst[i].Categoria;
                dataGridView1.Rows[i].Cells[3].Value = lst[i].Detalle;
                dataGridView1.Rows[i].Cells[4].Value = lst[i].Precio;
                
            }

            

            dataGridView1.ClearSelection();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textFactura.Text.Trim() != "" || prodNom.Text.Trim() != "")
            {
                if (MessageBoxEx.Show("Factura en progreso, ¿está seguro que desea salir?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    this.Hide();
                    Login L = new Login();
                    L.Show();
                }
            } else
            {
                this.Hide();
                Login L = new Login();
                L.Show();
            }
            
            
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

        private void button6_Click(object sender, EventArgs e)
        {
            double total = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {

                total += Convert.ToDouble(fila.Cells["Precio"].Value);
            }

            textPrecio.Text = Convert.ToString(total);
        }

        private void ListarFranquicia()
        {

            cbxCategoria.DisplayMember = "Ubicacion";
            cbxCategoria.ValueMember = "idFranquicia";
            cbxCategoria.DataSource = V.ListarFranquicia();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (cbxCategoria.Text.Trim() != "")
            {
                if (textPrecio.Text.Trim() != "")
                {
                    if (textFactura.Text.Trim() != ""
                    || txtClienteID.Text.Trim() != "")
                    {

                        try
                        {
                            V.idFranquicia = Convert.ToInt32(cbxCategoria.SelectedValue);
                            V.Nombre = "Venta Realizada";
                            V.Precio = Convert.ToDecimal(textPrecio.Text);
                            V.Cantidad = dataGridView1.RowCount;
                            V.idFactura = Convert.ToInt32(textFactura.Text);
                            V.idCliente = Convert.ToInt32(txtClienteID.Text);
                            V.Fecha = Convert.ToDateTime(dateTimePicker2.Value);
                            V.Descripcion = textDetalle.Text;
                            V.idPlatillo = 1;
                            V.idVendedor = Convert.ToInt32(textVendedor.Text);
                            V.idPago = Convert.ToInt32(comboBox.SelectedValue);
                            mensaje = V.VentaDetalle();
                            if (mensaje == "Este registro ya existe.")
                            {
                                MessageBoxEx.Show(mensaje, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBoxEx.Show(mensaje, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                enviarEmail();
                                Limpiar();

                                dataGridView1.Rows.Clear();
                                dataGridView1.Update();

                            }

                        }
                        catch
                        {
                            MessageBoxEx.Show("Por favor verifique sus datos.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Ingrese los valores requeridos.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else
                {
                    MessageBoxEx.Show("Ingrese el total a pagar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textPrecio.Focus();
                }

            }
            else
            {
                MessageBoxEx.Show("Ingrese la sede de venta.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxCategoria.Focus();
            }

            
        }

        private void textFactura_DoubleClick(object sender, EventArgs e)
        {
            Random numero = new Random();
            int random = numero.Next(0, 10000);
            textFactura.Text = random.ToString();
        }

        public void enviarEmail()
        {
            login = new NetworkCredential("", "");
            cliente = new SmtpClient("smtp.gmail.com");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Credentials = login;
            mensaje = new MailMessage { From = new MailAddress("") };
            mensaje.To.Add(new MailAddress(""));
            mensaje.Body = textFactura.Text + "\n" + txtClienteID.Text + "\n" + textVendedor.Text +
                "\n" + Convert.ToString(dateTimePicker2)
                + "\n" + dataGridView1 + "\n" + textPrecio.Text + "\n" + textDetalle.Text;
            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.IsBodyHtml = true;
            mensaje.Priority = MailPriority.Normal;
            mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            cliente.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            cliente.SendAsync(mensaje, userstate);

        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(string.Format("Envio cancelado.", e.UserState), "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} {1}.", e.UserState), "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El correo ha sido enviado.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Limpiar()
        {
            textFactura.Clear();
            txtClienteID.Clear();
            Program.IdCliente = 0;
            textVendedor.Clear();
            prodNom.Clear();
            Program.Nombre = "";
            prodCat.Clear();
            Program.Categoria = "";
            prodPre.Clear();
            Program.Precio = 0;
            dataGridView1.Rows.Clear();
            textPrecio.Clear();
            textDetalle.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    }
}
