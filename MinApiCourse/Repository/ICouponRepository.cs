using MinApiCourse.Data.DTO;
using MinApiCourse.Models;

namespace MinApiCourse.Repository
{
    public interface ICouponRepository
    {
        Task<List<Coupon>> GetAll();
        Task<Coupon?> GetById(int id);
        Task<Coupon?> Create(CouponCreateDTO couponCreateDTO);
    }
}
