using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Client : User
    {
        //public int Id { get; set; }
        [Required]
        [DisplayName("טלפון")]
        public string Telephone { get; set; }

        [DisplayName("אימייל")]
        public string E_Mail { get; set; }

        [DisplayName("הזמנות")]
        public List<Order> Orders { get; set; } //O2M
    }
}
