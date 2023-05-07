using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    public class MyDatabase:DbContext
    {
        public MyDatabase()
        {

        }
        public MyDatabase(DbContextOptions<MyDatabase> options) : base(options) { 
        
        }
        public DbSet<Mushteri> mushteris { get; set; }
    }
}
