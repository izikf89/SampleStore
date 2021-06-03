using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public enum OrderStatuses { OPEN, WAITING, IN_PROCESS, CLOSE}

    public class Order
    {
        [DisplayName("מספר הזמנה")]

        public int Id { get; set; }

        [DisplayName("מוצרים")]
        public List<Product> Prodacts { get; set; } = new List<Product>();

        [DisplayName("סך הכל")]
        public int Total { get; set; }

        public User user { get; set; }

        [DisplayName("סטטוס")]
        public OrderStatuses Status { get; set; } = OrderStatuses.OPEN;  
    }
}
