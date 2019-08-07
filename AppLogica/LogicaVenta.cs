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
                lst.Add(new Data("@idVenta", idFactura));
                lst.Add(new Data("@idSede", idSede));
                lst.Add(new Data("@Nombre", Nombre));
                lst.Add(new Data("@Precio", Precio));
                lst.Add(new Data("@Cantidad", Cantidad));
                lst.Add(new Data("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));


                M.EjecutarSP("VentaDetalle", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }


    }
}
