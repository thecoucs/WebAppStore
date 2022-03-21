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
        string connectionString = @"Data Source = localhost; Initial Catalog = Store; Integrated Security = True";
        // GET: Producto
        [HttpGet]
        public ActionResult Index()
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PR_CONSULTAR_PRODUCTO", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ProductoModel producto = new ProductoModel();
                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetInt32(2);
                producto.Peso = sqlDataReader.GetInt32(3);
                producto.Stock = sqlDataReader.GetInt32(6);
                producto.Fecha_Creacion = sqlDataReader.GetDateTime(7).Date.ToString("dd/MM/yyyy");
                categoria.Id = sqlDataReader.GetInt32(4);
                categoria.Nombre = sqlDataReader.GetString(5);
                producto.Categoria = categoria;
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
        public ActionResult Create()
        {
            List<CategoriaModel> categorias = new List<CategoriaModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PR_CONSULTAR_CATEGORIA", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                CategoriaModel categoria = new CategoriaModel();
                categoria.Id = sqlDataReader.GetInt32(0);
                categoria.Nombre = sqlDataReader.GetString(1);
                categorias.Add(categoria);
            }
            connection.Close();

            return Json(categorias, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductoModel producto)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PR_CREAR_PRODUCTO", connection);
                command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = producto.Nombre;
                command.Parameters.Add("@PRECIO", SqlDbType.Int).Value = producto.Precio;
                command.Parameters.Add("@PESO", SqlDbType.Int).Value = producto.Peso;
                command.Parameters.Add("@ID_CATEGORIA", SqlDbType.Int).Value = producto.Categoria.Id;
                command.Parameters.Add("@STOCK", SqlDbType.Int).Value = producto.Stock;
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
            SqlCommand command = new SqlCommand("PR_CONSULTAR_PRODUCTO_CODIGO", connection);
            command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ProductoModel producto = new ProductoModel();
            while (sqlDataReader.Read())
            {
                
                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetInt32(2);
                producto.Peso = sqlDataReader.GetInt32(3);
                producto.Stock = sqlDataReader.GetInt32(6);
                producto.Fecha_Creacion = sqlDataReader.GetDateTime(7).Date.ToString("dd/MM/yyyy");
                categoria.Id = sqlDataReader.GetInt32(4);
                categoria.Nombre = sqlDataReader.GetString(5);
                producto.Categoria = categoria;
                
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
                SqlCommand command = new SqlCommand("PR_ACTUALIZAR_PRODUCTO", connection);
                command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
                command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = producto.Nombre;
                command.Parameters.Add("@PRECIO", SqlDbType.Int).Value = producto.Precio;
                command.Parameters.Add("@PESO", SqlDbType.Int).Value = producto.Peso;
                command.Parameters.Add("@CAT_ID", SqlDbType.Int).Value = producto.Categoria.Id;
                command.Parameters.Add("@STOCK", SqlDbType.Int).Value = producto.Stock;
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
            SqlCommand command = new SqlCommand("PR_CONSULTAR_PRODUCTO_CODIGO", connection);
            command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ProductoModel producto = new ProductoModel();
            while (sqlDataReader.Read())
            {

                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetInt32(2);
                producto.Peso = sqlDataReader.GetInt32(3);
                producto.Stock = sqlDataReader.GetInt32(6);
                producto.Fecha_Creacion = sqlDataReader.GetDateTime(7).Date.ToString("dd/MM/yyyy");
                categoria.Id = sqlDataReader.GetInt32(4);
                categoria.Nombre = sqlDataReader.GetString(5);
                producto.Categoria = categoria;

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
                SqlCommand command = new SqlCommand("PR_ELIMINAR_PRODUCTO", connection);
                command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
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

        // GET: Producto/Venta/5
        public ActionResult Venta(int id)
        {
            List<ProductoModel> productos = new List<ProductoModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PR_CONSULTAR_PRODUCTO_CODIGO", connection);
            command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ProductoModel producto = new ProductoModel();
            while (sqlDataReader.Read())
            {

                CategoriaModel categoria = new CategoriaModel();
                producto.Id = sqlDataReader.GetInt32(0);
                producto.Nombre = sqlDataReader.GetString(1);
                producto.Precio = sqlDataReader.GetInt32(2);
                producto.Peso = sqlDataReader.GetInt32(3);
                producto.Stock = sqlDataReader.GetInt32(6);
                producto.Fecha_Creacion = sqlDataReader.GetDateTime(7).Date.ToString("dd/MM/yyyy");
                categoria.Id = sqlDataReader.GetInt32(4);
                categoria.Nombre = sqlDataReader.GetString(5);
                producto.Categoria = categoria;

            }
            connection.Close();

            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Venta/5
        [HttpPost]
        public ActionResult Venta(int id, ProductoModel producto)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PR_GUARDAR_VENTA", connection);
                command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
                command.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = producto.Stock;
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
