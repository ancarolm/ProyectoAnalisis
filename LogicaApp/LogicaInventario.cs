using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConexionBD;

using System.Data.SqlClient;

namespace LogicaApp
{/// <summary>
/// 
/// Se asignan los datos para la logica del inventario
/// </summary>
    public class LogicaInventario
    {
         Conexion M = new Conexion();

        private int idProducto;
        private string Nombre;
        private int idCategoria;
        private string Detalle;
        private int Cantidad;
        private string Marca;
        private int idProveedor;
        private int idFranquicia;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Name
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public string Detail
        {
            get { return Detalle; }
            set { Detalle = value; }
        }

        public int Quantity
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public string Brand
        {
            get { return Marca; }
            set { Marca = value; }
        }

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        public int IdFranquicia
        {
            get { return idFranquicia; }
            set { idFranquicia = value; }
        }

        public DataTable Listar()
        {
            return M.Listado("VerInventario", null);
        }

        public DataTable Listado()
        {
            return M.Listado("ListarFranquicias", null);
        }

        public DataTable ListarCat()
        {
            return M.Listado("ListarCategorias", null);
        }

        public DataTable ListarProv()
        {
            return M.Listado("ListarProveedores", null);
        }

        public DataTable ListarFacturas()
        {
            return M.Listado("ListarFacturas", null);
        }

        public String AgregarInventario()
        {
            List<Datos> lst = new List<Datos>();
            String Mensaje = "";

            try
            {
                lst.Add(new Datos("@idProducto", idProducto));
                lst.Add(new Datos("@Nombre", Nombre));
                lst.Add(new Datos("@idCategoria", idCategoria));
                lst.Add(new Datos("@Detalle", Detalle));
                lst.Add(new Datos("@Cantidad", Cantidad));
                lst.Add(new Datos("@Marca", Marca));
                lst.Add(new Datos("@idProveedor", idProveedor));
                lst.Add(new Datos("@idFranquicia", idFranquicia));
                lst.Add(new Datos("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("AgregarInventario", ref lst);
                Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BuscarInventario(String objDatos)
        {
            DataTable dt = new DataTable();
            List<Datos> lst = new List<Datos>();
            try
            {
                lst.Add(new Datos("@Nombre", objDatos));
                dt = M.Listado("BuscarInventario", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable EliminarInventario(int objDatos)
        {
            DataTable dt = new DataTable();
            List<Datos> lst = new List<Datos>();
            try
            {
                lst.Add(new Datos("@idProducto", objDatos));
                dt = M.Listado("EliminarInventario", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public String EditarInventario()
        {
            List<Datos> lst = new List<Datos>();
            String Mensaje = "";

            try
            {
                lst.Add(new Datos("@idProducto", idProducto));
                lst.Add(new Datos("@Nombre", Nombre));
                lst.Add(new Datos("@idCategoria", idCategoria));
                lst.Add(new Datos("@Detalle", Detalle));
                lst.Add(new Datos("@Cantidad", Cantidad));
                lst.Add(new Datos("@Marca", Marca));
                lst.Add(new Datos("@idProveedor", idProveedor));
                lst.Add(new Datos("@idFranquicia", idFranquicia));
                lst.Add(new Datos("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EditarInventario", ref lst);
                Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

    }
}
