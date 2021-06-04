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
        [Required(ErrorMessage ="שדה חובה")]
        [MinLength(9, ErrorMessage = "מינימום 9 ספרות")]
        [MaxLength(10, ErrorMessage = "מקסימום 10 ספרות")]
        [RegularExpression("([0-9]+)", ErrorMessage = "יש לכתוב ספרות בלבד")]
        [DisplayName("טלפון")]
        public string Telephone { get; set; }

        [DisplayName("אימייל")]
        [EmailAddress(ErrorMessage = "נא לכתוב כתובת מייל תקינה")]
        public string E_Mail { get; set; }

        [DisplayName("הזמנות")]
        public List<Order> Orders { get; set; } //O2M
    }
}
