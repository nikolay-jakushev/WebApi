using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Query> Query { get; set; }

        public StoreContext(DbContextOptions options) : base(options)
        {
        }
    }
}