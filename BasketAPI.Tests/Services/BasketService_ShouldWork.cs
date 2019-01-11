using Moq;
using Xunit;
using BasketAPI.Services;
using BasketAPI.Services.Contracts;
using BasketAPI.Repositories.Contracts;
using System.Threading.Tasks;
using BasketAPI.Models;

namespace BasketAPI.Tests.Services
{
    public class BasketService_ShouldWork
    {
        private readonly IBasketService _basketService;
        private readonly Mock<IBasketRepository> _basketRepository;

        public BasketService_ShouldWork()
        {
            BasketModel _moqBasket = new Mock<BasketModel>().Object;
            _basketRepository = new Mock<IBasketRepository>();
            _basketService = new BasketService(_basketRepository.Object);

            _basketRepository.Setup(m => m.GetBasket()).Returns(Task.FromResult((BasketModel)null));
            _basketRepository.Setup(m => m.CreateBasket()).Returns(Task.FromResult(new BasketModel()));

            _basketRepository.Setup(m => m.UpdateBasketAsync(It.IsAny<BasketModel>()))
                .Returns(Task.FromResult(""));
        }
        
        [Fact]
        public async Task Test_GenerateOrGetBasketAsync()
        {
            BasketModel _basket = await _basketService.GetBasketAsync();

            Assert.NotNull(_basket);
        }

        /// <summary>
        /// We add an item expecting to increase the basket size and total cost
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_AddItemToBasket()
        {           
            BasketModel _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, 1);

            Assert.Single(_basket.Items);
            Assert.Equal(400, _basket.TotalCost);
        }

        /// <summary>
        /// We add multiple same items expecting the increase in quantity
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_AddMultipleSameItemsToBasket()
        {
            BasketModel _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, 1);
            _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, 1);

            Assert.Single(_basket.Items);
            Assert.Equal(800, _basket.TotalCost);
        }

        /// <summary>
        /// We add multiple different items expecting the increase in total cost
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_AddMultipleDifferentItemsToBasket()
        {
            BasketModel _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, 1);
            _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 2, PricePerUnit = 500 }, 1);

            Assert.Equal(2, _basket.Items.Count);
            Assert.Equal(900, _basket.TotalCost);
        }

        /// <summary>
        /// We add an item and then immediately remove it expecting an empty basket
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_RemoveItemFromBasket()
        {
            BasketModel _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1 , PricePerUnit = 400 }, 1);
            _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, -1);
        
            Assert.Empty(_basket.Items);
            Assert.Equal(0, _basket.TotalCost);
        }

        /// <summary>
        /// We add a few items and then issue a clear
        /// Expecting to receive an empty Basket
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_ClearBasket()
        {
            BasketModel _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, 1);
            _basket = await _basketService.UpdateBasketItemAsync(new ItemModel { Id = 1, PricePerUnit = 400 }, 1);

            _basket = await _basketService.ClearBasketAsync();

            Assert.Null(_basket.Items);
            Assert.Equal(0, _basket.TotalCost);
        }
    }
}
