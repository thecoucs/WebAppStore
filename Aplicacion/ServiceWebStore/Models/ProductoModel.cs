﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceStore.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Decimal Precio { get; set; }
    }
}