using System.Collections.Generic;

namespace WebApplication.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }
        
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}