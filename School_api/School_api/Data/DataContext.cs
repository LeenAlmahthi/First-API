using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_api.Model;
namespace School_api.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        /*
         AspNetUsers
         AspNetRoles
         AspNetUserRoles
         AspNetUserClaims
         AspNetUserLogins
         AspNetUserTokens
         */
        public DbSet<Students> students {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
                                             DataBase=test_db;
                                              Trusted_Connection=True;
                                                TrustServerCertificate=True;");

        }
    }
}
