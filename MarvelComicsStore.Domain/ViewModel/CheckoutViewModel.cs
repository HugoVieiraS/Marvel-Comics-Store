using MarvelComicsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Domain.ViewModel
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public string Coupon { get; set; }
        public double TotalPrice { get; set; }
        public double TotalDiscount { get; set; }
        public virtual IList<PurchasedItem> PurchasedItems { get; set; }
    }
}
