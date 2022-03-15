using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppCafeteria.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }

        [Display (Name ="Categoria")]
        public string Nombre { get; set; }
    }
}