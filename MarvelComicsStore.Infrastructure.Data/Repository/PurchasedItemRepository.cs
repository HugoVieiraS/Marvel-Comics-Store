using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface;
using System.Collections.Generic;

namespace MarvelComicsStore.Infrastructure.Data.Repository
{
    public class PurchasedItemRepository : IPurchasedItemRepository
    {
        #region Fields
        private IBaseRepository<PurchasedItem> _baseRepository;
        #endregion

        #region Constructor
        public PurchasedItemRepository(IBaseRepository<PurchasedItem> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        public PurchasedItem Get(int id)
        {
            return _baseRepository.Get(id);
        }

        public IEnumerable<PurchasedItem> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public void Insert(params PurchasedItem[] obj)
        {
            _baseRepository.Insert(obj);
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
