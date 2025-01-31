using AuthenticationAndAuthorization.Extensions;
using DistributedCaching.Abstraction;
using DistributedCaching.Data;
using DistributedCaching.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var psql = builder.Configuration.GetConnectionString("DefaultConnection");
var redis = builder.Configuration.GetConnectionString("Cache");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(psql));
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = redis);

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
