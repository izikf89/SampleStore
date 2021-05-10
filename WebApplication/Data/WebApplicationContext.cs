using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class WebApplicationContext : DbContext
    {
        public WebApplicationContext (DbContextOptions<WebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication.Models.Product> Product { get; set; }

        public DbSet<WebApplication.Models.Category> Category { get; set; }

        public DbSet<WebApplication.Models.Account> Account { get; set; }

        public DbSet<WebApplication.Models.Order> Order { get; set; }
    }
}
