using Microsoft.AspNetCore.Mvc;
using MinApiCourse;
using MinApiCourse.Data;
using MinApiCourse.Models;
using AutoMapper;
using MinApiCourse.Data.DTO;
using Microsoft.EntityFrameworkCore;
using MinApiCourse.Repository;

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("api/coupon/",async (ICouponRepository store) => await store.GetAll());

app.MapGet("api/coupon/{id:int}", async (ICouponRepository store, int id) =>
{
    var coupon = await store.GetById(id);

    if (coupon is null)
    {
        return Results.NotFound(coupon);
    }

    return Results.Ok(coupon);
});

app.MapPost("api/coupon/", async (ICouponRepository store, [FromBody] CouponCreateDTO coupon) =>
{
    var createdCoupon = await store.Create(coupon);

    if (createdCoupon is null)
    {
        return Results.UnprocessableEntity(createdCoupon);
    }

    return Results.Created($"/api/coupon/{createdCoupon.Id}", createdCoupon);
});

app.Run();
