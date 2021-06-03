using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Models
{
    public class productImage
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("תמונה")]
        public string Image { get; set; }

        [Required(ErrorMessage = "בחר תמונה")]
        [NotMapped]
        public IFormFile img { get; set; }

        [DisplayName("תמונה1")]
        public string ProductId { get; set; }

    }
}
