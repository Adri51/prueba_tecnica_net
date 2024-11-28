using Microsoft.EntityFrameworkCore;
using prueba_Adrian.Models;
using System.Collections.Generic;

namespace prueba_Adrian.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<DataBank> ApiData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
