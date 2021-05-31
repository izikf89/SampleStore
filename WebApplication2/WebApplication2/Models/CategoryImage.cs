using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CategoryImage
    {
        [Required, Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; } //O2O

    }
}
