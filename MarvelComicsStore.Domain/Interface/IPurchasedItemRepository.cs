using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface.Base;
using System.Collections.Generic;

namespace MarvelComicsStore.Domain.Interface
{
    public interface IPurchasedItemRepository : IBaseRepository<PurchasedItem>
    {
        IList<PurchasedItem> GetItemsAtCheckout(int id);
    }
}
