using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAppStore.Models;

namespace WebAppStore.Controllers
{
    public class ProductoController : Controller
    {
        string dominio = "http://localhost:65150";
        // GET: Producto
        public ActionResult Index()
        {
            string apiUrl = dominio;

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            List<ProductoModel> productos = (new JavaScriptSerializer()).Deserialize<List<ProductoModel>>(json);
            return View(productos);
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
        public ActionResult Create(ProductoModel producto)
        {
            try
            {
                string apiUrl = dominio + "/Producto/Create";

                string parameters = (new JavaScriptSerializer()).Serialize(producto);
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string result = client.UploadString(apiUrl, parameters);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            string apiUrl = dominio + "/Producto/Edit?id=" + id;
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            ProductoModel producto = (new JavaScriptSerializer()).Deserialize<ProductoModel>(json);

            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductoModel producto)
        {
            try
            {
                string apiUrl = dominio + "/Producto/Edit?id=" + id;

                string parameters = (new JavaScriptSerializer()).Serialize(producto);
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string result = client.UploadString(apiUrl, parameters);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            string apiUrl = dominio + "/Producto/Delete?id=" + id;
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            ProductoModel producto = (new JavaScriptSerializer()).Deserialize<ProductoModel>(json);

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductoModel producto)
        {
            try
            {
                string apiUrl = dominio + "/Producto/Delete?id=" + id;

                string parameters = (new JavaScriptSerializer()).Serialize(producto);
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string result = client.UploadString(apiUrl, parameters);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Venta/5
        public ActionResult Venta(int id)
        {
            string apiUrl = dominio + "/Cliente/Index";

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            List<ClienteModel> clientes = (new JavaScriptSerializer()).Deserialize<List<ClienteModel>>(json);
            ViewBag.ListaClientes = clientes;

            apiUrl = dominio + "/Producto/Venta?id="+id;
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            json = client.DownloadString(apiUrl);
            ProductoModel producto = (new JavaScriptSerializer()).Deserialize<ProductoModel>(json);
            ViewBag.Producto = producto;
            return View();
        }

        // POST: Producto/Venta/5
        [HttpPost]
        public ActionResult Venta(int id, ProductoModel producto)
        {
            try
            {
                string apiUrl = dominio + "/Producto/Venta?id=" + id;

                string parameters = (new JavaScriptSerializer()).Serialize(producto);
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string result = client.UploadString(apiUrl, parameters);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
