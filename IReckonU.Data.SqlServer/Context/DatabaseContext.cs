using IReckonU.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IReckonU.Data.SqlServer.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
