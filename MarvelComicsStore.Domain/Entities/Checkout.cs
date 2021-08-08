using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Domain.Entities
{
    public class Checkout : BaseModel
    {
        public string Coupon { get; set; }
        public double TotalPrice { get; set; }
        public double TotalDiscount { get; set; }
        public IList<Item> PurchasedItems { get; set; }
    }
}
