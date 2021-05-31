using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public CategoryImage Image { get; set; } //O2O
 
        public List<Product> Prodacts { get; set; } //M2M
    }
}
