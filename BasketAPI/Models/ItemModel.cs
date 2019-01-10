using System;
using System.ComponentModel.DataAnnotations;

namespace BasketAPI.Models
{
    public class ItemModel : BaseModel
    {
        public string Title {get; set;}
        public int PricePerUnit {get; set;} = 0;
    }
}