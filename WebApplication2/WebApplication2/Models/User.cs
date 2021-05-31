using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public enum TypeUser { client, admin}

    public class User
    {
        [Required, Key]
        public int Id { get; set; }

        public string name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }        

        public TypeUser type { get; set; }
        //public Client Client { get; set; }// O2O
    }
}
