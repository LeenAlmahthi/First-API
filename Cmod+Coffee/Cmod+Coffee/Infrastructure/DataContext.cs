using Microsoft.EntityFrameworkCore;
namespace Cmod_Coffee.Infrastructure
{
    public class DataContext : DbContext
    {
       public DbSet<CoffeeOrder> Data { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; 
                                            Database=test_bd; 
                                             Trusted_Connection=True;
                                              TrustServerCertificate=True;");
        }
    }
}
     