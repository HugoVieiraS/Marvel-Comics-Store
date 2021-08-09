using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.ViewModel;
using System.Collections.Generic;

namespace MarvelComicsStore.Service.Mapper
{
    public static class CheckoutProfileMap
    {
        #region Methods
        public static IEnumerable<CheckoutViewModel> CheckoutToViewModel(this IEnumerable<Checkout> checkouts)
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
                    PurchasedItems = PurcharsedItemProfileMap.ComicsToViewModel(checkout.PurchasedItems),
                });
            }
            return checkoutViewModel;
        }

        public static CheckoutViewModel CheckoutToViewModel(this Checkout checkout)
        {
            return new CheckoutViewModel
            {
                Id = checkout.Id,
                Coupon = checkout.Coupon,
                TotalDiscount = checkout.TotalDiscount,
                TotalPrice = checkout.TotalPrice,
                PurchasedItems = PurcharsedItemProfileMap.ComicsToViewModel(checkout.PurchasedItems),
            };
        }

        public static Checkout ViewModelToCheckout(this CheckoutViewModel checkoutView)
        {
            return new Checkout
            {
                Id = checkoutView.Id,
                Coupon = checkoutView.Coupon,
                TotalDiscount = checkoutView.TotalDiscount,
                TotalPrice = checkoutView.TotalPrice,
                PurchasedItems = PurcharsedItemProfileMap.ViewModelToPurcharsedItem(checkoutView.PurchasedItems),
            };
        }
        #endregion
    }
}
