using CustomersService.DBAccessEntities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? dbUser = Environment.GetEnvironmentVariable("MYSQL_USER");
string? dbPass = Environment.GetEnvironmentVariable("MYSQL_PASS");

builder.Services.AddDbContext<CustomerContext>(opt => opt.UseMySql("server=localhost;uid=" + dbUser + ";pwd=" + dbPass + ";database=customers", 
    ServerVersion.AutoDetect("server=localhost;uid=" + dbUser + ";pwd=" + dbPass + ";database=customers")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
