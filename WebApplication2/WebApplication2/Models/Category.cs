using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Category
    {
        [Required, Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public CategoryImage Image { get; set; } //O2O
 
        public List<Prodact> Prodacts { get; set; } //M2M
    }
}
