using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;

namespace School_api.Model
{
    public class ApplicationUser : IdentityUser
    {
        /*
         * IdentityUser already gives you:
        Id
        UserName
        Email
        PasswordHash
        PhoneNumber
        */
     

    }
}
