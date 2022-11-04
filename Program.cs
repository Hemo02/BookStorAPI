using BooksApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add my DataBase 
builder.Services.AddDbContext<BookConText>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Defualtconnection")));
//builder.Services.AddDbContext<BookConText>(op => op.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=books;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json",name:""));

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();//add
app.UseAuthentication();//add
app.UseRouting();//add
app.MapControllers();
app.Run();
