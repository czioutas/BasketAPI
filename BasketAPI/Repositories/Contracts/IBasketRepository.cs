using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BasketAPI.Models;

namespace BasketAPI.Repositories.Contracts
{
    public interface IBasketRepository
    {
        Task UpdateBasketAsync(BasketModel basket);

        Task<BasketModel> GetBasket();

        Task<BasketModel> CreateBasket();
    }
}