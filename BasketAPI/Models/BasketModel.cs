using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BasketAPI.Data;
using BasketAPI.Models;

namespace BasketAPI.Models
{
    public class BasketModel : BaseModel
    {
        public List<BasketItemModel> Items {get; set;} = new List<BasketItemModel>();
        public int TotalCost { get; set; } = 0;

        public void UpdateItem(ItemModel item, int quantity)
        {
            BasketItemModel _basketItem = this.Items.Where(bi => bi.ItemId == item.Id).FirstOrDefault();

            if (_basketItem == null) {
                _basketItem = new BasketItemModel {
                    ItemId = item.Id,
                    Item = item,
                    PricePerUnit = item.PricePerUnit,
                    Quantity = quantity
                };
                Items.Add(_basketItem);
            } else {
                _basketItem.Quantity += quantity;
            }

            TotalCost += _basketItem.PricePerUnit * quantity;
            if (TotalCost < 0) { TotalCost = 0; }

            if (_basketItem.Quantity < 1) {              
                Items.Remove(_basketItem);
            }
        }

        public void ClearItems()
        {
            this.Items = null;
            this.TotalCost = 0;
        }

        public void CalculateTotalCost()
        {
            this.TotalCost = this.Items.Sum(i => i.PricePerUnit * i.Quantity);
        }
    }
}