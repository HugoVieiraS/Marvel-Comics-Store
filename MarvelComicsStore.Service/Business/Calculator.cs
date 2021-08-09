using MarvelComicsStore.Domain.Entities;
using System.Linq;

namespace MarvelComicsStore.Service.Business
{
    public static class Calculator
    {
        #region Fields
        private const decimal RARE_COUPON = 0.3m;
        private const decimal COMMON_CUPON = 0.15m;
        #endregion

        #region Methods
        public static decimal TotalPrice(Checkout checkout)
        {
            if (!string.IsNullOrWhiteSpace(checkout.Coupon))
                checkout = CalculateDescount(checkout);

            return checkout.PurchasedItems.Sum(x => x.Price);
        }

        // Multiplicar a unidade x preço, para a partir dai fazer o desconto do cupom
        // Devolver o valor de desconto para salvar no checkout
        // Criar mock para validar os cupons
        private static Checkout CalculateDescount(Checkout checkout)
        {       
            if (checkout.Coupon.Substring(0,1) == "R")
            {
                foreach (var item in checkout.PurchasedItems.Where(x => x.Rare == true))
                {
                    item.Price = decimal.Subtract(item.Price, decimal.Multiply(item.Price, RARE_COUPON));
                }
            }

            if (checkout.Coupon.Substring(0, 1) == "C")
            {
                foreach (var item in checkout.PurchasedItems.Where(x => x.Rare == false))
                {
                    item.Price = decimal.Subtract(item.Price, decimal.Multiply(item.Price, COMMON_CUPON));
                }
            }

            return checkout;
        }
        #endregion
    }
}
