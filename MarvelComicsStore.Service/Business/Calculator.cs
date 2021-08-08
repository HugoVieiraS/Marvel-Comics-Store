using MarvelComicsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelComicsStore.Service.Business
{
    public static class Calculator
    {
        #region Fields
        private const decimal RARE_COUPON = 0.1m;
        private const decimal COMMON_CUPON = 0.05m;
        #endregion

        #region Methods
        public static decimal TotalPrice(Checkout checkout)
        {
            var total = checkout.PurchasedItems.Sum(x => x.Price);
            var descont = TotalDescont(checkout);
            return decimal.Subtract(total, descont);
        }

        private static decimal TotalDescont(Checkout checkout)
        {
            decimal descont = default;

            if (string.IsNullOrWhiteSpace(checkout.Coupon))
                return descont;

            if (checkout.Coupon.Substring(0,1) == "R")
            {
                foreach (var item in checkout.PurchasedItems.Where(x => x.Rare == true))
                {
                    descont += decimal.Subtract(item.Price, decimal.Multiply(item.Price, RARE_COUPON));
                }
            }

            if (checkout.Coupon.Substring(0, 1) == "C")
            {
                foreach (var item in checkout.PurchasedItems.Where(x => x.Rare == false))
                {
                    descont += decimal.Subtract(item.Price, decimal.Multiply(item.Price, COMMON_CUPON));
                }
            }

            return descont;
        }
        #endregion
    }
}
