using System.Collections.Generic;
using System.Threading.Tasks;
using BasketAPI.Models;

namespace BasketAPI.Services.Contracts
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasketAsync();
        Task UpdateBasketItemAsync(ItemModel item, int quantity);
        Task ClearBasketAsync();
    }
}