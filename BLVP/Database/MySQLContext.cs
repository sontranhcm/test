using BLVP.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BLVP.Database
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Counter>? Counters { get; set; }
    }
}
