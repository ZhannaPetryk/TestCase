using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Data.Entities;
using WebApplication.Interfaces;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        
        public List<Customer> GetCustomersByFullName(List<Customer> customers,string fullName)
        {
            if (!string.IsNullOrEmpty(fullName.Trim()))
            {
                customers=customers.Where(c => c.FullName.Contains(fullName, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            
            return customers;
        }
        
        public List<Customer> GetCustomersByCountry(List<Customer> customers, string country)
        {
            if (!string.IsNullOrEmpty(country.Trim()))
            {
               customers=customers.Where(c => c.Country.Contains(country, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return customers;
        }
        
        public async Task<Customer> GetCustomer(int customerId)
        {
            return await _context.Customers.Where(p=>p.Id==customerId).FirstOrDefaultAsync();
        }
        
        public async Task<Customer> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> EditCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}