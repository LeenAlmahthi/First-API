using Microsoft.EntityFrameworkCore;
using School_api.Model;
namespace School_api.Data
{
    public class DataContext :DbContext
    {
        public DbSet<Students> students {get; set;}
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
                                             DataBase=test_db;
                                              Trusted_Connection=True;
                                                TrustServerCertificate=True;");

        }
    }
}
