using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarvelComicsStore.Domain.Entities
{
    public class PurchasedItem : BaseModel
    {
        public string Title { get; set; }
        public int Unity { get; set; }
        public decimal Price { get; set; }
        public bool Rare { get; set; }
        public virtual Checkout Checkout { get; set; }
    }
}
