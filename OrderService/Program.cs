using Microsoft.EntityFrameworkCore;
using OrderService.Infraestructure;
using OrderService.Interface;
using OrderService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDbContext>(opt => opt.UseSqlServer("Server=MATHEUS\\SQLEXPRESS;DataBase=Orders;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddSingleton<BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
