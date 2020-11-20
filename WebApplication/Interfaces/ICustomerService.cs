using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Data.Entities;

namespace WebApplication.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        List<Customer> GetCustomersByFullName(List<Customer> customers, string fullName);
        List<Customer> GetCustomersByCountry(List<Customer> customers, string country);
        Task<Customer> GetCustomer(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> EditCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
    }
}