using System.Collections.Generic;

namespace WebApplication.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}