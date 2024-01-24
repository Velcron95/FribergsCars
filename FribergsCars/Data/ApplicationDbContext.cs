using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FribergsCars.Data.Models;

namespace FribergsCars.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Order> Order { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
