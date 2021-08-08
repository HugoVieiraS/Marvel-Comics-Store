using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Domain.ViewModel;
using MarvelComicsStore.Service.Interface;
using MarvelComicsStore.Service.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvelComicsStore.Service.Services
{
    public class CheckoutService : ICheckoutService
    {
        #region Fields
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IPurchasedItemRepository _itemsRepository;
        #endregion

        #region Constructor
        public CheckoutService(ICheckoutRepository checkoutRepository, IPurchasedItemRepository itemsRepository)
        {
            _checkoutRepository = checkoutRepository;
            _itemsRepository = itemsRepository;
        }
        #endregion

        #region Methods
        public CheckoutViewModel Get(int id)
        {
            var checkout = _checkoutRepository.Get(id);
            var items = _itemsRepository.GetAll();

            checkout.PurchasedItems = items != null
                ? items.Where(x => x.Checkout == checkout).ToList()
                : null;

            return checkout.ComicsToViewModel();
        }

        public IEnumerable<CheckoutViewModel> GetAll()
        {
            return _checkoutRepository.GetAll().ComicsToViewModel();
        }

        public void Insert(CheckoutViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(CheckoutViewModel model)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
