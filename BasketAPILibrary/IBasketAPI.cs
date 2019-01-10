using System.Threading.Tasks;

namespace BasketAPILibrary
{
    public interface IBasketAPI
    {
        /// <summary>
        /// Allows adding or removing an item from basket based on quantity
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<bool> ChangeItemAsync(int itemId, int quantity);
        Task<bool> ClearCartAsync();
    }
}
