using LIBRARY_MANAGEMENT_SYSTEM.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LIBRARY_MANAGEMENT_SYSTEM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
