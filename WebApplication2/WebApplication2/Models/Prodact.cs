using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Prodact
    {
        [Required, Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<productImage> Pictuers{ get; set; }

        //public int CategoryId { get; set; }
        public List<Category> Categories { get; set; } //M2M
        
    }
}
