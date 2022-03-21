using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceStore.Models
{
    public class VentaModel
    {
        public int Id { get; set; }
        public ProductoModel Producto { get; set; }
        public ClienteModel Cliente { get; set; }
        public int Cantidad { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}