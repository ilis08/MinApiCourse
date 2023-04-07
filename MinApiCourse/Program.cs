using Microsoft.AspNetCore.Mvc;
using MinApiCourse;
using MinApiCourse.Data;
using MinApiCourse.Models;
using AutoMapper;
using MinApiCourse.Data.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<CouponStore>();

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

app.MapGet("api/coupon/", (CouponStore store) => store.GetCouponList());

app.MapGet("api/coupon/{id:int}", (CouponStore store, int id) =>
{
    var coupon = store.GetCoupon(id);

    if (coupon is null)
    {
        return Results.NotFound(coupon);
    }

    return Results.Ok(coupon);
});

app.MapPost("api/coupon/", (CouponStore store, [FromBody] CouponCreateDTO coupon) =>
{
    var createdCoupon = store.CreateCoupon(coupon);

    if (createdCoupon is null)
    {
        return Results.UnprocessableEntity(createdCoupon);
    }

    return Results.Created($"/api/coupon/{createdCoupon.Id}", createdCoupon);
});

app.Run();
