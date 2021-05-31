﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Category> Category { get; set; }

        public DbSet<WebApplication2.Models.CategoryImage> CategoryImage { get; set; }

        public DbSet<WebApplication2.Models.Client> Client { get; set; }

        public DbSet<WebApplication2.Models.Order> Order { get; set; }

        public DbSet<WebApplication2.Models.Prodact> Prodact { get; set; }

        public DbSet<WebApplication2.Models.productImage> productImage { get; set; }

        public DbSet<WebApplication2.Models.User> User { get; set; }
    }
}