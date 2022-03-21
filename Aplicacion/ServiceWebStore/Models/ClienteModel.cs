using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceStore.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Decimal Telefono { get; set; }
    }
}