using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketAPI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BasketAPI.Data.Seed
{
    public class DemoSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using (ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>())
            {
                await AddItemsAsync(context);
            }
        }

        private static async Task AddItemsAsync(ApplicationDbContext context)
        {
            List<ItemModel> _items = new List<ItemModel>();
            
            _items.Add(new ItemModel {
                Title = "CD",
                PricePerUnit = 400
            });

            _items.Add(new ItemModel {
                Title = "DVD",
                PricePerUnit = 500
            });

            _items.Add(new ItemModel {
                Title = "Keyboard",
                PricePerUnit = 3000
            });

            _items.Add(new ItemModel {
                Title = "Mouse",
                PricePerUnit = 2400
            });

            _items.Add(new ItemModel {
                Title = "Mousepad",
                PricePerUnit = 1000
            });

            _items.Add(new ItemModel {
                Title = "Speakers",
                PricePerUnit = 6000
            });

            _items.Add(new ItemModel {
                Title = "Screen",
                PricePerUnit = 24000
            });

            if (context.Items.Count() != _items.Count()) {
                await context.Items.AddRangeAsync(_items);
                await context.SaveChangesAsync();
            }
        }
    }
}