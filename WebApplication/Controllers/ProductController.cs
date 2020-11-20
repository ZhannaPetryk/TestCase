using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Entities;
using WebApplication.Interfaces;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products")]
        public List<Product> Index()
        {
            return  _productService.GetProducts();
        }
        [HttpGet]
        [Route("product/{productId:int}")]
        public async Task<Product> GetProduct(int productId)
        {
            return await _productService.GetProduct(productId);
        }
        
        [HttpPut]
        [Route("add")]
        public async Task<Product> Add(Product product)
        {
            return await _productService.AddProduct(product);
        }
        
        [HttpPut]
        [Route("edit")]
        public async Task<Product> Edit(Product product)
        {
            return await _productService.EditProduct(product);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task Delete(Product product)
        {
            await _productService.DeleteProduct(product);
        }
    }
}