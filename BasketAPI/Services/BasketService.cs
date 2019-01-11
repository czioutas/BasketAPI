using System.Threading.Tasks;
using BasketAPI.Models;
using BasketAPI.Repositories.Contracts;
using BasketAPI.Services.Contracts;

namespace BasketAPI.Services
{
    public class BasketService : IBasketService
    {       
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<BasketModel> UpdateBasketItemAsync(ItemModel item, int quantity)
        {
            BasketModel _basket = await GetBasketAsync();
            _basket.UpdateItem(item, quantity);
            await _basketRepository.UpdateBasketAsync(_basket);

            return _basket;
        }

        public async Task<BasketModel> ClearBasketAsync()
        {
            BasketModel _basket = await GetBasketAsync();
            _basket.ClearItems();
            await _basketRepository.UpdateBasketAsync(_basket);

            return _basket;
        }

        public async Task<BasketModel> GetBasketAsync() {
            BasketModel _basket = await _basketRepository.GetBasket();

            if (_basket == null) {
                _basket = await _basketRepository.CreateBasket();
            }

            return _basket;
        }
    }
}