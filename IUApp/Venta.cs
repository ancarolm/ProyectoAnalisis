using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUApp
{
    class Venta
    {
        public int IdFactura { get; set; }
        public int IdVendedor { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public int IdCliente { get; set; }
        public decimal SubTotal { get; set; }

        public Venta()
        {
            IdVendedor = 0;
            Detalle = "";
            Precio = 0;
            IdFactura = 0;
            IdCliente = 0;
            SubTotal = 0;
        }
        public Venta(int idFactura, int idVendedor, string detalle, decimal precio,
            int idCliente, decimal subtotal)
        {
            IdFactura = IdFactura;
            IdVendedor = idVendedor;
            Detalle = detalle;
            Precio = precio;
            IdCliente = idCliente;
            SubTotal = subtotal;
        }
    }
}
