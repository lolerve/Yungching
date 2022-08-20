using Microsoft.EntityFrameworkCore;
using Yungching.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(p => p.AddPolicy("Web", build => { 
build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<YungchingDemoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Product")));
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Web");
app.UseAuthorization();

app.MapControllers();

app.Run();
