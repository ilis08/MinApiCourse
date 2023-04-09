using Microsoft.AspNetCore.Mvc;
using MinApiCourse.Data.DTO;
using MinApiCourse.Repository;

namespace MinApiCourse.Endpoints
{
    public static class CouponEndpoints
    {
        public static void RegisterCouponEndpoints(this WebApplication app)
        {
            app.MapGet("api/coupon/", async (ICouponRepository store) => await store.GetAll());

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
        }
    }
}
