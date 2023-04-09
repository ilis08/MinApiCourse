using Microsoft.AspNetCore.Mvc;
using MinApiCourse;
using MinApiCourse.Data;
using MinApiCourse.Models;
using AutoMapper;
using MinApiCourse.Data.DTO;
using Microsoft.EntityFrameworkCore;
using MinApiCourse.Repository;
using MinApiCourse.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<ICouponRepository, CouponRepository>();

builder.Services.AddDbContext<ApplicationContext>(opts =>
{
    opts.UseSqlite("Name=databaseSqlite");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterCouponEndpoints();

app.Run();
