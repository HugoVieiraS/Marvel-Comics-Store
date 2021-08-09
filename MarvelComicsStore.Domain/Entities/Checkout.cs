using MarvelComicsStore.Domain.Entities.Base;
using System.Collections.Generic;

namespace MarvelComicsStore.Domain.Entities
{
    public class Checkout : BaseModel
    {
        public string Coupon { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public virtual IList<PurchasedItem> PurchasedItems { get; set; }
    }
}
