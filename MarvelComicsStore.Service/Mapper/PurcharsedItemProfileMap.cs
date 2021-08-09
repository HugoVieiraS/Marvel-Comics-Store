using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.ViewModel;
using System.Collections.Generic;
using MarvelComicsStore.Common.IntExtensionsMethods;

namespace MarvelComicsStore.Service.Mapper
{
    public static class PurcharsedItemProfileMap
    {
        #region Methods
        public static List<PurcharsedItemViewModel> ComicsToViewModel(IList<PurchasedItem> purchasedItems)
        {
            if (purchasedItems == null)
                return null;
            
            var itemsViewModel = new List<PurcharsedItemViewModel>();
            foreach (var item in purchasedItems)
            {
                itemsViewModel.Add(
                    new PurcharsedItemViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Price = item.Price,
                        Rare = item.Rare,
                        Unity = item.Unity,
                        CheckoutId = item.CheckoutId,
                    });
            }
            return itemsViewModel;
        }

        public static List<PurchasedItem> ViewModelToPurcharsedItem(List<PurcharsedItemViewModel> purchasedItems)
        {
            if (purchasedItems == null)
                return null;

            var items = new List<PurchasedItem>();
            foreach (var item in purchasedItems)
            {
                items.Add(
                    new PurchasedItem
                    {
                        Id = item?.Id.TryToIntOrDefault() ?? default(int),
                        Title = item.Title,
                        Price = item.Price,
                        Rare = item.Rare,
                        Unity = item.Unity,
                        CheckoutId = item.CheckoutId,
                    });
            }
            return items;
        }
        #endregion
    }
}
