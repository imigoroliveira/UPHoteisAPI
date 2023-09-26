using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionMysqlString = builder.Configuration.GetConnectionString("ConnectionMysql");

builder.Services.AddDbContext<HotelAPIDbContext>(option => option.UseMySql(
    connectionMysqlString, ServerVersion.Parse("10.4.28-MariaDB")
   )
);


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
