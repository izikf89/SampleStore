using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Product
    {
        [Required]
        [DisplayName("מזהה מוצר")]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("שם מוצר")]
        public string Name { get; set; }

        [Required]
        [DisplayName("מחיר")]
        public int Price { get; set; }

        [DisplayName("תמונות")]
        public List<productImage> Pictuers { get; set; } = new List<productImage>();

        //public int CategoryId { get; set; }
        [DisplayName("קטגוריות")]
        public List<Category> Categories { get; set; } //M2M
        public List<Order> Orders { get; set; } //M2M
        
    }
}
