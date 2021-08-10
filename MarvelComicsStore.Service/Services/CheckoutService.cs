using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Domain.ViewModel;
using MarvelComicsStore.Service.Business;
using MarvelComicsStore.Service.Interface;
using MarvelComicsStore.Service.Mapper;
using System;
using System.Collections.Generic;

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
            checkout.PurchasedItems = _itemsRepository.GetItemsAtCheckout(checkout.Id);
            return checkout.CheckoutToViewModel();
        }

        public IEnumerable<CheckoutViewModel> GetAll()
        {
            var checkout = _checkoutRepository.GetAll();
            return checkout.CheckoutToViewModel();
        }

        public void Insert(CheckoutViewModel model)
        {
            var checkout = model.ViewModelToCheckout();
            checkout.TotalPrice = Calculator.TotalPrice(checkout);
            _checkoutRepository.Insert(checkout);
        }

        public void Remove(int id)
        {
            var checkout = _checkoutRepository.Get(id);
            _checkoutRepository.Remove(checkout);
        }

        public void Update(CheckoutViewModel model)
        {
            var checkout = model.ViewModelToCheckout();
            checkout.TotalPrice = Calculator.TotalPrice(checkout);
            _checkoutRepository.UpdateChanges(checkout);
            foreach (var item in checkout.PurchasedItems)
            {
                var itemBase = _itemsRepository.Get(item.Id);
                if (itemBase == null)
                {
                    _itemsRepository.Insert(item);
                    return;
                }
                _itemsRepository.UpdateChanges(item);
            }
        }
        #endregion
    }
}
