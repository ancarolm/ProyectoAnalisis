using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionDB;
using System.Data;

namespace AppLogica
{
    public class Platillo
    {
        Conectividad M = new Conectividad();

        public int idPlatillo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }

        public DataTable Listado()
        {
            return M.Listado("ListarPlatillos", null);
        }

        public DataTable BuscarPlatillo(String objDatos)
        {
            DataTable dt = new DataTable();
            List<Data> lst = new List<Data>();
            try
            {
                lst.Add(new Data("@Nombre", objDatos));
                dt = M.Listado("BuscarPlatillo", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }






    }
}
