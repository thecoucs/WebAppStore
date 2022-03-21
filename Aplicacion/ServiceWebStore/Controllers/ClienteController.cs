using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceStore.Models;

namespace ServiceWebCafeteria.Controllers
{
    public class ClienteController : Controller
    {

        string connectionString = @"Data Source = localhost; Initial Catalog = Store; Integrated Security = True";
        // GET: Producto
        [HttpGet]
        public ActionResult Index()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_CLIENTES", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ClienteModel cliente = new ClienteModel();
                cliente.Id = sqlDataReader.GetInt32(0);
                cliente.NumeroDocumento = sqlDataReader.GetString(1);
                cliente.Nombre = sqlDataReader.GetString(2);
                cliente.Apellido = sqlDataReader.GetString(3);
                cliente.Telefono = sqlDataReader.GetDecimal(4);
                clientes.Add(cliente);
            }
            connection.Close();

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ClienteModel cliente)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_CREAR_CLIENTE", connection);
                command.Parameters.Add("@NUMERO_DOCUMENTO", SqlDbType.VarChar).Value = cliente.NumeroDocumento;
                command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = cliente.Nombre;
                command.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = cliente.Apellido;
                command.Parameters.Add("@TELEFONO", SqlDbType.Decimal).Value = cliente.Telefono;
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

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_CLIENTE_CODIGO", connection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ClienteModel cliente = new ClienteModel();
            while (sqlDataReader.Read())
            {

                CategoriaModel categoria = new CategoriaModel();
                cliente.Id = sqlDataReader.GetInt32(0);
                cliente.NumeroDocumento = sqlDataReader.GetString(1);
                cliente.Nombre = sqlDataReader.GetString(2);
                cliente.Apellido = sqlDataReader.GetString(3);
                cliente.Telefono = sqlDataReader.GetDecimal(4);
            }
            connection.Close();

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClienteModel cliente)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_ACTUALIZAR_CLIENTE", connection);
                command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@NUMERO_DOCUMENTO", SqlDbType.VarChar).Value = cliente.NumeroDocumento;
                command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = cliente.Nombre;
                command.Parameters.Add("@APELLIDO", SqlDbType.VarChar).Value = cliente.Apellido;
                command.Parameters.Add("@TELEFONO", SqlDbType.Decimal).Value = cliente.Telefono;
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
            List<ClienteModel> clientes = new List<ClienteModel>();
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PROC_CONSULTA_CLIENTE_CODIGO", connection);
            command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ClienteModel cliente = new ClienteModel();
            while (sqlDataReader.Read())
            {
                cliente.Id = sqlDataReader.GetInt32(0);
                cliente.NumeroDocumento = sqlDataReader.GetString(1);
                cliente.Nombre = sqlDataReader.GetString(2);
                cliente.Apellido = sqlDataReader.GetString(3);
                cliente.Telefono = sqlDataReader.GetDecimal(4);
            }
            connection.Close();

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ClienteModel cliente)
        {
            string resultado = "correcto";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("PROC_ELIMINAR_CLIENTE", connection);
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

        // GET: Producto/Venta/5
        //public ActionResult Venta(int id)
        //{
        //    List<ProductoModel> productos = new List<ProductoModel>();
        //    DataTable dataTable = new DataTable();
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand command = new SqlCommand("PR_CONSULTAR_PRODUCTO_CODIGO", connection);
        //    command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
        //    command.CommandType = CommandType.StoredProcedure;
        //    connection.Open();
        //    SqlDataReader sqlDataReader = command.ExecuteReader();
        //    ProductoModel producto = new ProductoModel();
        //    while (sqlDataReader.Read())
        //    {

        //        CategoriaModel categoria = new CategoriaModel();
        //        producto.Id = sqlDataReader.GetInt32(0);
        //        producto.Nombre = sqlDataReader.GetString(1);
        //        producto.Precio = sqlDataReader.GetInt32(2);
        //        producto.Peso = sqlDataReader.GetInt32(3);
        //        producto.Stock = sqlDataReader.GetInt32(6);
        //        producto.Fecha_Creacion = sqlDataReader.GetDateTime(7).Date.ToString("dd/MM/yyyy");
        //        categoria.Id = sqlDataReader.GetInt32(4);
        //        categoria.Nombre = sqlDataReader.GetString(5);
        //        producto.Categoria = categoria;

        //    }
        //    connection.Close();

        //    return Json(producto, JsonRequestBehavior.AllowGet);
        //}

        //// POST: Producto/Venta/5
        //[HttpPost]
        //public ActionResult Venta(int id, ProductoModel producto)
        //{
        //    string resultado = "correcto";
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(connectionString);
        //        SqlCommand command = new SqlCommand("PR_GUARDAR_VENTA", connection);
        //        command.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = id;
        //        command.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = producto.Stock;
        //        command.CommandType = CommandType.StoredProcedure;
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //        // TODO: Add insert logic here
        //        connection.Close();

        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = "incorrecto " + ex;
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
