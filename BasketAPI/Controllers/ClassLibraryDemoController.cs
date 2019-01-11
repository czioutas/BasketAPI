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
            BasketAPILibrary.IBasketAPI a = BasketAPILibrary.Basket.BasketAPIClient(o => {
                o.Url = "http://127.0.0.1:9005/api/v1/basket/";
            });

            await a.ChangeItemAsync(1, 1);
            return Ok(1);
        }        
    }
}
