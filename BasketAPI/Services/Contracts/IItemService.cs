using System.Collections.Generic;
using System.Threading.Tasks;
using BasketAPI.Models;

namespace BasketAPI.Services.Contracts
{
    public interface IItemService
    {
        Task<ItemModel> GetItemAsync(int id);
    }
}