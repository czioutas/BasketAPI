using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasketAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassLibraryDemoController : ControllerBase
    {
        // GET api/ClassLibraryDemo/AddItem
        [HttpGet]
        public async Task<ActionResult> AddItemAsync()
        {
            BasketAPILibrary.IBasketAPI a = BasketAPILibrary.Basket.BasketAPIClient();
            await a.ChangeItemAsync(1, 1);
            return Ok(1);
        }

        // GET api/ClassLibraryDemo/RemoveItem
        [HttpGet]
        public async Task<ActionResult> RemoveItem()
        {
            BasketAPILibrary.IBasketAPI a = BasketAPILibrary.Basket.BasketAPIClient();
            await a.ChangeItemAsync(1, -1);
            return Ok(1);
        }

        // GET api/ClassLibraryDemo/Clear
        [HttpGet]
        public async Task<ActionResult> Clear()
        {
            BasketAPILibrary.IBasketAPI a = BasketAPILibrary.Basket.BasketAPIClient();
            await a.ClearCartAsync();
            return Ok(1);
        }
    }
}
