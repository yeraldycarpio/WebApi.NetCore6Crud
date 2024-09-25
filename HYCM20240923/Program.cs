using HYCM20240923.Properties.Endpoints;
using HYCM20240923.Properties.Models.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HYCMContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddScoped<ProductHYCMDAL>();

var app = builder.Build();

app.AddProductHYCMEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();