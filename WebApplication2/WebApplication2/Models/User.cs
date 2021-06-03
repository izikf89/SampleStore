using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public enum TypeUser { client, admin}

    public class User
    {
        [Required]
        public int Id { get; set; }

        [MinLength(2, "מינמום 2 תווים")]
        [Required("שדה חובה")]
        [DisplayName("שם")]
        public string Name { get; set; }

        [MinLength(5, "מינמום 5 תווים")]
        [Required("שדה חובה")]
        [DisplayName("סיסמא")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("סוג")]
        public TypeUser Type { get; set; } = TypeUser.client;

        //public Client Client { get; set; }// O2O
    }
}
