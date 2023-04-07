using AutoMapper;
using MinApiCourse.Data.DTO;
using MinApiCourse.Models;

namespace MinApiCourse
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Coupon, CouponCreateDTO>().ReverseMap();
        }
    }
}
