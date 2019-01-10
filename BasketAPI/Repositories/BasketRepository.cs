using System;
using System.Threading.Tasks;
using BasketAPI.Data;
using BasketAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BasketAPI.Repositories.Contracts
{

    public class BasketRepository : IBasketRepository
    {
        protected ApplicationDbContext _context { get; set; }

        public BasketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpdateBasketAsync(BasketModel basket)
        {
            _context.Basket.Update(basket);
            await _context.SaveChangesAsync();
        }

        public Task<BasketModel> GetBasket() => _context.Basket.Include(b => b.Items).FirstOrDefaultAsync();

        public async Task<BasketModel> CreateBasket()
        {
            BasketModel _basket = new BasketModel();
            await _context.AddAsync(_basket);
            await _context.SaveChangesAsync();

            return _basket;
        }
    }
}