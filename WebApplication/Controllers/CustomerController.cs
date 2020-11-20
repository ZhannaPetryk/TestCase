using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Entities;
using WebApplication.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomerController: Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customers")]
        public List<Customer> Index(FilterModel filter)
        {
            var customers = _customerService.GetCustomers();
            if (filter.Country != null)
            {
               customers=_customerService.GetCustomersByCountry(customers, filter.Country);
            }

            if (filter.FullName != null)
            {
                customers= _customerService.GetCustomersByFullName(customers, filter.FullName);
            }

            return customers;
        }
        [HttpGet]
        [Route("customers/{customerId:int}")]
        public async Task<Customer> GetCustomer(int customerId)
        {
            return await _customerService.GetCustomer(customerId);
        }
        
        [HttpPut]
        [Route("add")]
        public async Task<Customer> Add(Customer customer)
        {
            return await _customerService.AddCustomer(customer);
        }
        
        [HttpPut]
        [Route("edit")]
        public async Task<Customer> Edit(Customer customer)
        {
            return await _customerService.EditCustomer(customer);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task Delete(Customer customer)
        {
            await _customerService.DeleteCustomer(customer);
        }
    }
}