using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using School_api.Model;
using Domain.entity;
using Domain.entity.course;
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
        public DbSet<Students> Students { get; set;}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Doctors> Doctores { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
                                             DataBase=uni_db;
                                              Trusted_Connection=True;
                                                TrustServerCertificate=True;");

        }
    }
}

