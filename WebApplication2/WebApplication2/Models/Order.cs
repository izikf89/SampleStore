using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order
    {
        [Required, Key]
        public int Id { get; set; }
        public List<Prodact> Prodacts { get; set; }
        public int Total { get; set; }
        
    }
}
