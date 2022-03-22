using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceStore.Models;

namespace ServiceWebStore.Controllers
{
    public class ProductoController : Controller
    {
        string connectionString = @"Data Source = localhost; Initial Catalog = STORE; Integrated Security = True";
        // GET: Producto
        [HttpGet]
        public ActionResult Index()
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_PRODUCTOS", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ProductoModel producto = new ProductoModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetDecimal(2);
                productos.Add(producto);
            }
            connection.Close();

            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        //public ActionResult Create()
        //{
        //    List<CategoriaModel> categorias = new List<CategoriaModel>();
        //    DataTable dataTable = new DataTable();
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand command = new SqlCommand("PR_CONSULTAR_CATEGORIA", connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    connection.Open();
        //    SqlDataReader sqlDataReader = command.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        CategoriaModel categoria = new CategoriaModel();
        //        categoria.Id = sqlDataReader.GetInt32(0);
        //        categoria.Nombre = sqlDataReader.GetString(1);
        //        categorias.Add(categoria);
        //    }
        //    connection.Close();

        //    return Json(categorias, JsonRequestBehavior.AllowGet);
        //}

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductoModel producto)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_CREAR_PRODUCTO", connection);
                command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = producto.Nombre;
                command.Parameters.Add("@PRECIO", SqlDbType.Decimal).Value = producto.Precio;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
                // TODO: Add insert logic here
                connection.Close();
               

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                resultado = "incorrecto " + ex;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_PRODUCTO_CODIGO", connection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ProductoModel producto = new ProductoModel();
            while (sqlDataReader.Read())
            {
                
                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetDecimal(2);
            }
            connection.Close();

            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductoModel producto)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_ACTUALIZAR_PRODUCTO", connection);
                command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = producto.Nombre;
                command.Parameters.Add("@PRECIO", SqlDbType.Decimal).Value = producto.Precio;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
                // TODO: Add insert logic here
                connection.Close();

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado = "incorrecto " + ex;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_PRODUCTO_CODIGO", connection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ProductoModel producto = new ProductoModel();
            while (sqlDataReader.Read())
            {

                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetDecimal(2);

            }
            connection.Close();

            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductoModel producto)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_ELIMINAR_PRODUCTO", connection);
                command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
                // TODO: Add insert logic here
                connection.Close();

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado = "incorrecto " + ex;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetVenta()
        {
            List<VentaModel> ventas = new List<VentaModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTAR_VENTAS", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            
            while (sqlDataReader.Read())
            {
                VentaModel venta = new VentaModel();
                ProductoModel producto = new ProductoModel();
                ClienteModel cliente = new ClienteModel();
                venta.Id = sqlDataReader.GetInt32(0);
                producto.Id = sqlDataReader.GetInt32(1);
                producto.Nombre = sqlDataReader.GetString(2);
                producto.Precio = sqlDataReader.GetDecimal(3);
                cliente.Id = sqlDataReader.GetInt32(4);
                cliente.NumeroDocumento = sqlDataReader.GetString(5);
                cliente.Nombre = sqlDataReader.GetString(6);
                cliente.Apellido = sqlDataReader.GetString(7);
                cliente.Telefono = sqlDataReader.GetDecimal(8);
                venta.Cantidad = sqlDataReader.GetInt32(9);
                venta.ValorTotal = sqlDataReader.GetDecimal(10);

                venta.Producto = producto;
                venta.Cliente = cliente;

                ventas.Add(venta);
            }
            connection.Close();

            return Json(ventas, JsonRequestBehavior.AllowGet);
        }

        // GET: Producto/Venta/5
        public ActionResult Venta(int id)
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_PRODUCTO_CODIGO", connection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ProductoModel producto = new ProductoModel();
            while (sqlDataReader.Read())
            {

                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetDecimal(2);
            }
            connection.Close();

            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Venta/5
        [HttpPost]
        public ActionResult Venta(VentaModel venta)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_GUARDAR_VENTA", connection);
                command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = venta.Producto.Id;
                command.Parameters.Add("@ID_CLIENTE", SqlDbType.Int).Value = venta.Cliente.Id;
                command.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = venta.Cantidad;
                command.Parameters.Add("@VALOR_TOTAL", SqlDbType.Decimal).Value = venta.ValorTotal;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
                // TODO: Add insert logic here
                connection.Close();

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado = "incorrecto " + ex;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
