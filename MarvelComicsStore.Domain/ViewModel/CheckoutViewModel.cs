using System.Collections.Generic;

namespace MarvelComicsStore.Domain.ViewModel
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public string Coupon { get; set; }
        public decimal TotalPrice { get; set; }
        public List<PurcharsedItemViewModel> PurchasedItems { get; set; }
    }
}
