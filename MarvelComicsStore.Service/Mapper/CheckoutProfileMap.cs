using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Service.Mapper
{
    public static class CheckoutProfileMap
    {
        public static IEnumerable<CheckoutViewModel> ComicsToViewModel(this IEnumerable<Checkout> checkouts)
        {
            var checkoutViewModel = new List<CheckoutViewModel>();
            foreach (var checkout in checkouts)
            {
                checkoutViewModel.Add(new CheckoutViewModel
                {
                    Id = checkout.Id,
                    Coupon = checkout.Coupon,
                    TotalDiscount = checkout.TotalDiscount,
                    TotalPrice = checkout.TotalPrice,
                    PurchasedItems = checkout.PurchasedItems,
                });
            }
            return checkoutViewModel;
        }

        public static CheckoutViewModel ComicsToViewModel(this Checkout checkout)
        {          
            return new CheckoutViewModel 
            {
                Id = checkout.Id,
                Coupon = checkout.Coupon,
                TotalDiscount = checkout.TotalDiscount,
                TotalPrice = checkout.TotalPrice,
                PurchasedItems = checkout.PurchasedItems,
            };
        }
    }
}
