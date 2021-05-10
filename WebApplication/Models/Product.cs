using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Product 
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
    }
}
