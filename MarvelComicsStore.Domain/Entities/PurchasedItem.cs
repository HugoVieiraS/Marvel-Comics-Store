using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Domain.Entities
{
    public class PurchasedItem : BaseModel
    {
        public string Title { get; set; }
        public int Unity { get; set; }
        public double Price { get; set; }
        public int IdCheckout { get; set; }
    }
}
