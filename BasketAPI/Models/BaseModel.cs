using System;
using System.ComponentModel.DataAnnotations;

namespace BasketAPI.Models
{
    public class BaseModel
    {
        [Key]
        public int Id {get; set;}
        public DateTimeOffset CreatedAt {get; set;} = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt {get; set;} = DateTimeOffset.UtcNow;
        public DateTimeOffset DeletedAt {get; set;}
        public Boolean Deleted {get; set;} = false;

    }
}