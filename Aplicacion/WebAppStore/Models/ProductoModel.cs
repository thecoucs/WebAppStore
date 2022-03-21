using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppStore.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Peso { get; set; }
        public CategoriaModel Categoria { get; set; }
        public int Stock { get; set; }
        [Display(Name ="Fecha de Creación")]
        public string Fecha_Creacion { get; set; }

    }
}