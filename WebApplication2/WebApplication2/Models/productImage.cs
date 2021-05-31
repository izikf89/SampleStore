using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication2.Models
{
    public class productImage
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("תמונה")]
        public string Image { get; set; }

    }
}
