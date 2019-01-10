using System;
using System.Threading.Tasks;
using BasketAPI.Data;
using BasketAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BasketAPI.Repositories.Contracts
{

    public class ItemRepository : IItemRepository
    {
        protected ApplicationDbContext _context { get; set; }

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemModel> GetItem(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}