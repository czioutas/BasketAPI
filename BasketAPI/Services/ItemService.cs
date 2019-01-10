using System.Collections.Generic;
using System.Threading.Tasks;
using BasketAPI.Models;
using BasketAPI.Repositories.Contracts;
using BasketAPI.Services.Contracts;

namespace BasketAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<ItemModel> GetItemAsync(int id)
        {
            return await _itemRepository.GetItem(id);
        }
    }
}