using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelComicsStore.Infrastructure.Data.Repository
{
    public class CheckoutRepository : ICheckoutRepository
    {
        #region Fields
        private IBaseRepository<Checkout> _baseRepository;
        #endregion

        #region Constructor
        public CheckoutRepository(IBaseRepository<Checkout> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        public IEnumerable<Checkout> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public Checkout Get(int id)
        {
            return _baseRepository.Get(id);
        }

        public void Insert(params Checkout[] obj)
        {
            _baseRepository.Insert(obj);
        }

        public void Remove(params Checkout[] obj)
        {
            _baseRepository.Remove(obj);
        }

        public void UpdateChanges(Checkout obj)
        {
            _baseRepository.UpdateChanges(obj);
        }
        #endregion
    }
}
