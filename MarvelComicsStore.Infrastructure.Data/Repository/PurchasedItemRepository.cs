using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Domain.Interface.Base;
using MarvelComicsStore.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace MarvelComicsStore.Infrastructure.Data.Repository
{
    public class PurchasedItemRepository : IPurchasedItemRepository
    {
        #region Fields
        private readonly IBaseRepository<PurchasedItem> _baseRepository;
        private readonly MySqlContext _mySqlContext;
        #endregion

        #region Constructor
        public PurchasedItemRepository(IBaseRepository<PurchasedItem> baseRepository, MySqlContext mySqlContext)
        {
            _baseRepository = baseRepository;
            _mySqlContext = mySqlContext;
        }
        #endregion

        #region Methods
        public IList<PurchasedItem> GetItemsAtCheckout(int id)
        {
            return _mySqlContext.PurchasedItem.Where(x => x.CheckoutId == id).ToList();
        }

        public PurchasedItem Get(int id)
        {
            return _baseRepository.Get(id);
        }

        public IEnumerable<PurchasedItem> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public PurchasedItem[] Insert(params PurchasedItem[] obj)
        {
            return _baseRepository.Insert(obj);
        }

        public void Remove(params PurchasedItem[] obj)
        {
            _baseRepository.Remove(obj);
        }

        public void UpdateChanges(PurchasedItem obj)
        {
            _baseRepository.UpdateChanges(obj);
        }
        #endregion
    }
}
