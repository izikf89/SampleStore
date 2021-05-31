using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DisplayName("מוצרים")]
        public List<Product> Prodacts { get; set; }

        [DisplayName("סך הכל")]
        public int Total { get; set; }
        
    }
}
