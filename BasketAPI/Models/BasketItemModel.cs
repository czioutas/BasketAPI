using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketAPI.Models
{
    public class BasketItemModel : BaseModel
    {
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public ItemModel Item {get; set;}
        public int PricePerUnit {get; set;} = 0;
        public int Quantity {get; set;} = 1;
    }
}