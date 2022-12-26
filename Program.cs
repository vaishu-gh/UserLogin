using UserLogin.Models;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RegContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors();
var AllowOrigin = "_AllowOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5184", "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

//builder.Services.AddCors((setup) =>
//{
//    setup.AddPolicy("default", (options) =>
//    {
//        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
//    });
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors("default");
app.UseAuthorization();

app.MapControllers();
app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.Run();
