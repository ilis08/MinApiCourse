using Microsoft.EntityFrameworkCore;
using MinApiCourse.Models;

namespace MinApiCourse.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    Name = "20OFF",
                    IsActive = true,
                    Percent = 20
                });
        }
    }
}
