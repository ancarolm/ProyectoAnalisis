using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
using System.Data;

namespace AppLogica
{
    public class LogicaVenta
    {
        Conectividad M = new Conectividad();

        
        public int idPlatillo { get; set; }
        public int idPago { get; set; }
        public string Tipo { get; set; }
        public int idFranquicia { get; set; }
        public int idSede { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int idVendedor { get; set; }
        public int idCategoria { get; set; }

        public DataTable Listado()
        {
            return M.Listado("ListarPago", null);
        }

        public DataTable ListarFranquicia()
        {
            return M.Listado("ListarFranquicias", null);
        }

        public DataTable AgregarVenta(int objDato)
        {
            DataTable dt = new DataTable();
            List<Data> lst = new List<Data>();
            lst.Add(new Data("@idPlatillo", objDato));
            return dt = M.Listado("VenderPlatillo", lst);
        }

        public String VentaDetalle()
        {
            List<Data> lst = new List<Data>();
            String Mensaje = "";

            try
            {
                lst.Add(new Data("@idFactura", idFactura));
                lst.Add(new Data("@idCliente", idCliente));
                lst.Add(new Data("@Fecha", Fecha));
                lst.Add(new Data("@Precio", Precio));
                lst.Add(new Data("@Descripcion", Descripcion));
                lst.Add(new Data("@idPlatillo", idPlatillo));
                lst.Add(new Data("@idVendedor", idVendedor));
                lst.Add(new Data("@idPago", idPago));
                lst.Add(new Data("@idCategoria", idCategoria));
                lst.Add(new Data("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));


                M.EjecutarSP("VentaDetalle", ref lst); //ejecución del proceso almacenado en base de datos
                Mensaje = lst[9].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }


    }
}
