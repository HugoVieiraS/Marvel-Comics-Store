using System.Collections.Generic;

namespace MarvelComicsStore.Service.Business
{
    public static class Coupon
    {
        public static bool ValidateCoupon(string coupon)
        {
            var mockCoupon = new CouponMock();
            return mockCoupon.Coupons().Exists(x => x.Coupon == coupon);
        }
    }

    public class CouponMock
    {
        public string Coupon { get; set; }

        public List<CouponMock> Coupons()
        {
            return new List<CouponMock>
            {
                 new CouponMock { Coupon = "C00001" },
                 new CouponMock { Coupon = "R00002" }
            };
        }
    }
}
