using CWRetail.Model;
using Microsoft.EntityFrameworkCore;

namespace CWRetail.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        { 
        }

        public DbSet<Product> Products { get; set; }   
    }
}
