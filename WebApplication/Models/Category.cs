﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Category 
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Product> ListOfProducts { get; set; }
    }
}
