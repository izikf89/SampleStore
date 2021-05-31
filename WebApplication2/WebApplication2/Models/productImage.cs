using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class productImage
    {
        [Required, Key]
        public int Id { get; set; }
        public string Image { get; set; }

    }
}
