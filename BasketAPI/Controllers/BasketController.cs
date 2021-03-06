using System.Threading.Tasks;
using BasketAPI.Models;
using BasketAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IItemService _itemService;

        public BasketController(IBasketService basketService, IItemService itemService)
        {
            _basketService = basketService;
            _itemService = itemService;
        }

        /// <summary>
        /// Retrieve the whole basket
        /// </summary>
        /// <returns>An array of items</returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _basketService.GetBasketAsync());
        }

        // add/remove item based on quantity
        // POST api/basket
        [HttpPost]
        public async Task<ActionResult> Post(int itemId, int quantity)
        {
            ItemModel _item = await _itemService.GetItemAsync(itemId);

            if (_item == null) {
                return BadRequest("Item not found");
            } 

            await _basketService.UpdateBasketItemAsync(_item, quantity);

            return Ok();
        }

        // clears basket
        // DELETE api/basket/
        [HttpDelete("")]
        public async Task<ActionResult> Delete()
        {
            await _basketService.ClearBasketAsync();

            return Ok();
        }
    }
}