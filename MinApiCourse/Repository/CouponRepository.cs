using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinApiCourse.Data;
using MinApiCourse.Data.DTO;
using MinApiCourse.Models;

namespace MinApiCourse.Repository
{
    public class CouponRepository : ICouponRepository
    {

        private readonly IMapper mapper;
        private readonly ApplicationContext context;

        public CouponRepository(IMapper _mapper, ApplicationContext context)
        {
            mapper = _mapper;
            this.context = context;
        }
        public async Task<List<Coupon>> GetAll()
        {
            return context.Coupons.ToList();
        }

        public async Task<Coupon> GetById(int id)
        {
            return await context.Coupons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Coupon> Create(CouponCreateDTO couponDTO)
        {
            var coupon = mapper.Map<Coupon>(couponDTO);

            await context.AddAsync(coupon);
            await context.SaveChangesAsync();

            return coupon;
        }
    }
}
