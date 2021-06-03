using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [DisplayName("שם")]
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "בחר תמונה")]        
        [NotMapped]
        public IFormFile img { get; set; }

        [DisplayName("תמונה")]
        public string imgPath { get; set; }

        public List<Product> Prodacts { get; set; } = new List<Product>(); //M2M

        [Required(ErrorMessage = "בחר מוצר")]
        [DisplayName("בחר מוצר")]
        [NotMapped]
        public List<int> ProductIdList { get; set; } //M2M
    }
}
