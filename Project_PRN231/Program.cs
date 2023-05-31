using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project_PRN231.Mapper;
using Project_PRN231.Models;
using Project_PRN231.Repositories;
using Project_PRN231.Repositories.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PRN231_SUContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ProDB")));
builder.Services.AddScoped<PRN231_SUContext>();

//Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// DI
builder.Services.AddScoped< IWriterRepository, WriterRepository>();
builder.Services.AddScoped<ILeaderReporitory, LeaderRepository>();
builder.Services.AddScoped<IReporterRepository, ReporterRepository>();

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
