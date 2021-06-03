using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new WebApplication2Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApplication2Context>>()))
            {
                SeedDB(context, "0");
            }
        }

        public static void SeedDB(WebApplication2Context context, string adminID)
        {
            if (!context.User.Any(u => u.Name == "admin"))
            {
                context.User.Add(new User() { Name = "admin", Password = "1", Type = TypeUser.admin });
                context.SaveChanges();
            }

            if (!context.Client.Any(u => u.Name == "user"))
            {
                context.Client.Add(new Client() { Name = "user", Password = "1", Type = TypeUser.client, Telephone = "0512345678" });
                context.SaveChanges();
            }
        }
    }
}
