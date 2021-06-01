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

        [Required(ErrorMessage = "Please choose profile image")]        
        [NotMapped]
        public IFormFile img { get; set; }

        [DisplayName("תמונה")]
        public string imgPath { get; set; }

        public List<Product> Prodacts { get; set; } //M2M
    }
}
