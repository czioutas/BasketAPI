using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BasketAPI.Models;

namespace BasketAPI.Repositories.Contracts
{
    public interface IItemRepository
    {
        Task<ItemModel> GetItem(int id);
    }
}