using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using BasketAPI.Services;
using BasketAPI.Services.Contracts;
using BasketAPI.Repositories;
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
            _basketRepository = new Mock<IBasketRepository>();
            _basketService = new BasketService(_basketRepository.Object);

            _basketRepository.Setup(m => m.GetBasket()).Returns(Task.FromResult((BasketModel)null));
            _basketRepository.Setup(m => m.CreateBasket()).Returns(Task.FromResult(new BasketModel()));
        }


        [Fact]
        public async Task Test_GenerateOrGetBasketAsync()
        {
            BasketModel _basket = await _basketService.GetBasketAsync();

            Assert.NotNull(_basket);
        }
    }
}
