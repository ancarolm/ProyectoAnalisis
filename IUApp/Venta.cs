using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUApp
{
    class Venta
    {
        public int IdPlatillo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        //public int IdCliente { get; set; }
        public decimal SubTotal { get; set; }

        public Venta()
        {
            IdPlatillo = 0;
            Detalle = "";
            Precio = 0;
            Nombre = "";
            Categoria = "";
            SubTotal = 0;
        }
        public Venta(int idPlatillo, string nombre, string detalle, string categoria, 
            decimal precio, decimal subtotal)
        {
            IdPlatillo = idPlatillo;
            Nombre = nombre;
            Detalle = detalle;
            Precio = precio;
            Categoria = categoria;
            SubTotal = subtotal;
        }
    }
}
