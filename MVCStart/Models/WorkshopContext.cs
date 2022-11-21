using Microsoft.EntityFrameworkCore;

namespace MVCStart.Models
{
    public class WorkshopContext : DbContext
    {
        public WorkshopContext(DbContextOptions<WorkshopContext> options) : base(options) 
        { 

        }
        
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}

    }
}
