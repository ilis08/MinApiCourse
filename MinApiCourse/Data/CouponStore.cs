using AutoMapper;
using MinApiCourse.Data.DTO;
using MinApiCourse.Models;

namespace MinApiCourse.Data
{
    public class CouponStore
    {
        private readonly IMapper mapper;

        public CouponStore(IMapper _mapper)
        {
            mapper = _mapper;
        }

        private static List<Coupon> Coupons = new List<Coupon>
        {
              new Coupon { Id = 1, Name = "10OFF", Percent = 10, IsActive = true },
              new Coupon { Id = 2, Name = "20OFF", Percent = 20, IsActive = true }
        };
        public List<Coupon> GetCouponList()
        {
            return Coupons;
        }

        public Coupon GetCoupon(int id)
        {
            return Coupons.FirstOrDefault(x => x.Id == id);
        }

        public Coupon CreateCoupon(CouponCreateDTO couponDTO)
        {
            var coupon = mapper.Map<Coupon>(couponDTO);
            coupon.Id = Coupons.Select(x => x.Id).Max() + 1;

            Coupons.Add(coupon);

            return coupon;
        }
    }
}
