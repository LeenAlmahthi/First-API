using Cmod_Coffee.Application.Customer;
using Cmod_Coffee.Application.custtomer;
using Cmod_Coffee.Infrastructure;
using Cmod_Coffee.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<PostCoffee>(); 
builder.Services.AddScoped<DeleteOrder>();
builder.Services.AddScoped<GetOrder>();
builder.Services.AddScoped<PriceRule>(); 
builder.Services.AddScoped<SizeRule>(); 
builder.Services.AddScoped<OrderValidator>();
builder.Services.AddScoped<ICoffeeRepository, SqlCoffeeRepository >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Map Controllers
app.MapControllers();

app.Run();