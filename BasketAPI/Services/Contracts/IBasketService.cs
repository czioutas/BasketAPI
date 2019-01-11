using System.Threading.Tasks;
using BasketAPI.Models;

namespace BasketAPI.Services.Contracts
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasketAsync();
        Task<BasketModel> UpdateBasketItemAsync(ItemModel item, int quantity);
        Task<BasketModel> ClearBasketAsync();
    }
}