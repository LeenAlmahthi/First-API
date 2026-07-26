using Microsoft.EntityFrameworkCore;
using School_api.Data;
using School_api.Model;
using School_api.role;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

/*
    1 - Prepare the web server (Kestrel).
    2 - Load the configuration (appsettings.json, environment variables, command-line args).
    3 - Create an empty Dependency Injection (DI) container.
    4 - Set up logging.
           CreateBuilder() prepares everything, but it does NOT start the server.
*/
var builder = WebApplication.CreateBuilder(args);

//Registers DataContext in the DI container, so ASP.NET Core can create it automatically whenever a controller needs it.
builder.Services.AddDbContext<DataContext>();

//Register Identity in Program.cs
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// JWT Authentication

builder.Services.AddAuthentication(options =>
{
    /*1.AddJwtBearer()
           Registers the JWT authentication handler.
           Teaches ASP.NET how to validate a JWT.  
       2.DefaultAuthenticateScheme
           Tells ASP.NET which handler to use when authenticating.
       3.DefaultChallengeScheme
           Tells ASP.NET which handler should respond when authentication fails.
       4.DefaultScheme
           Tells ASP.NET which handler to use if no scheme is specified.*/

    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes("my_super_secret_key_for_school_api_123456")
        )
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("JWT ERROR:");
            Console.WriteLine(context.Exception.Message);

            return Task.CompletedTask;
        },

        OnTokenValidated = context =>
        {
            Console.WriteLine("JWT VALID");
            return Task.CompletedTask;
        }
    };

});

builder.Services.AddAuthorization();

//Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<GenerateJwt>();


//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Events.OnRedirectToLogin = context =>
//    {
//        context.Response.StatusCode = 401;
//        return Task.CompletedTask;
//    };
//});


//Registers the services needed for Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();   // Builds the application using all the registered services.


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

await SeedData.SeedRoles(roleManager);
}

//Middleware(app.Use. Every request passes through the middleware pipeline before it reaches the controller.
//can - Read the request.      -Modify the request.         -Stop the request.    -Pass it to the next middleware.

if (app.Environment.IsDevelopment())   // if it in the developer mode runs the swagger
{
    app.UseSwagger();       // Generate Swagger JSON
    app.UseSwaggerUI();     // Show the Swagger UI
}

app.UseHttpsRedirection();  // Redirects      http://   -->   https://
app.UseAuthentication();
app.UseAuthorization();  // Authorization by middleware 

app.MapControllers(); // Find all controllers and make their endpoints available

app.Run(); // // Starts the Kestrel web server and waits for HTTP requests.

/*
 Program.cs starts
      │
      ▼
WebApplication.CreateBuilder(args)
      │
      ▼
Creates an EMPTY DI Container
      │
      ▼
builder.Services.AddDbContext<DataContext>()
      │
      ▼
+----------------------+
|   DI Container       |
|----------------------|
| ✓ DataContext        |
+----------------------+

Later...

Browser
   │
   ▼
StudentsController
   │
   │ Needs DataContext
   ▼
DI Container
   │
   ▼
Creates DataContext
   │
   ▼
Gives it to the controller
 */