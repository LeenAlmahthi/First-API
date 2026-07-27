using Microsoft.EntityFrameworkCore;
using Cmod___Coffee;
namespace CmoCoffee.Data
{
    public class DataContext : DbContext
    {
       public DbSet<CoffeeAttribet> Data { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; 
                                            Database=test_bd; 
                                             Trusted_Connection=True;
                                              TrustServerCertificate=True;");
        }
    }
}
     