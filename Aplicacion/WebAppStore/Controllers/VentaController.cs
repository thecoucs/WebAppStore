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
    public class VentaController : Controller
    {
        string dominio = "http://localhost:65150";
        // GET: Venta
        public ActionResult Index()
        {
            string apiUrl = dominio + "/Producto/GetVenta";

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            List<VentaModel> ventas = (new JavaScriptSerializer()).Deserialize<List<VentaModel>>(json);
            return View(ventas);
        }

        // GET: Venta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Venta/Create
        public ActionResult Create(int id)
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

        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(VentaModel venta)
        {
            try
            {
                string apiUrl = dominio + "/Producto/Venta";

                string parameters = (new JavaScriptSerializer()).Serialize(venta);
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

        // GET: Venta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Venta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
