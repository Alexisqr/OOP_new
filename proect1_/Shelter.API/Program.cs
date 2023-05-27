using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Data;
using System.Data.SqlClient;
using Shelter.DAL.Repositories.Interfaces;
using Shelter.DAL.Repositories;
using ShelterEF.DAL.Data;
using ShelterEF.DAL.Repositories;
using ShelterDAL.Models;
using ShelterBLL.Services;
using Shelter.DAL.Filter;
using FluentValidation.AspNetCore;
using ShelterBLL.Validation;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
//Connection for EF database + DbContext

// Add services to the container.
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
//builder.Configuration.AddJsonFile("appsetings.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
  builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    //options.UseSqlServer(connectionString);
});
// Connection/Transaction for ADO.NET/DAPPER database

builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});
//Connection for EF database + DbContext
builder.Services.AddScoped<IComentGlobRepository, ComentGlobRepository>();
builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();

builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();
builder.Services.AddScoped<IKindOfAnimalsRepository, KindOfAnimalsRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAnimalsServices, AnimalsServices>();
// Dependendency Injection for Repositories/UOW from EF DAL

builder.Services.AddScoped<ValidationFilterAttribute>();



var app = builder.Build();

//////////////////////////////////////////
// MIDDLEWARE -  ŒÕ¬≈™– Œ¡–Œ¡ » «¿œ»“”
// Configure the HTTP request pipeline.
//////////////////////////////////////////


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
