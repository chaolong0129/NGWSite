using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NGWSite.Models
{
    public class Order
    {
        public int OrderId {get;set;}
        [Required]
        public DateTime Date{get;set;}
        public ICollection<OrderItem> OrderItems{get;set;}
    }
}