using MarvelComicsStore.Domain.Entities;
using System.Linq;

namespace MarvelComicsStore.Service.Business
{
    public static class Calculator
    {
        #region Constants
        private const string COUPON_RARE = "R";
        private const string COUPON_COMMON = "C";
        private const decimal RARE_COUPON_DISCOUNT = 0.3m;
        private const decimal COMMON_CUPON_DISCOUNT = 0.15m;
        #endregion

        #region Methods
        public static decimal TotalPrice(Checkout checkout)
        {
            if (!string.IsNullOrWhiteSpace(checkout.Coupon) && Coupon.ValidateCoupon(checkout.Coupon))
                checkout = CalculateCoupounDiscounts(checkout);

            return checkout.PurchasedItems.Sum(x => x.Price);
        }

        private static Checkout CalculateCoupounDiscounts(Checkout checkout)
        {
            if (checkout.Coupon.Substring(0, 1) == COUPON_RARE)
            {
                foreach (var item in checkout.PurchasedItems)
                {
                    item.Price = CalculateDiscounts(item, RARE_COUPON_DISCOUNT);
                }
            }

            if (checkout.Coupon.Substring(0, 1) == COUPON_COMMON)
            {
                foreach (var item in checkout.PurchasedItems.Where(x => x.Rare == false))
                {
                    item.Price = CalculateDiscounts(item, COMMON_CUPON_DISCOUNT);
                }
            }

            return checkout;
        }

        private static decimal CalculateDiscounts(PurchasedItem item, decimal discount)
        {
            if (item.Unity > 1)
                item.Price *= item.Unity;

            return decimal.Subtract(item.Price, decimal.Multiply(item.Price, discount));
        }    
        #endregion
    }
}
