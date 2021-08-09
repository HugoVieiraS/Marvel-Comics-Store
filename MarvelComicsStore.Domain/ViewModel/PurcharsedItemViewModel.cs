namespace MarvelComicsStore.Domain.ViewModel
{
    public class PurcharsedItemViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int Unity { get; set; }
        public decimal Price { get; set; }
        public bool Rare { get; set; }
        public virtual int CheckoutId { get; set; }
    }
}
