using System;
using System.Collections.Generic;
using WebApplication.Data.Enums;

namespace WebApplication.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public DateTime Date { get; set; }
        
        public OrderStatus Status { get; set; }
        
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}