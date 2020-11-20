using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Entities;
using WebApplication.Interfaces;

namespace WebApplication.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("order/{orderId:int}")]
        public async Task<Order> GetData(int orderId)
        {
            return await _orderService.GetOrderById(orderId);
        }

        [HttpPost]
        [Route("add-to-cart")]
        public async Task<Order> AddToCart(int customerId, int productId, int count)
        {
            return await _orderService.AddToCart(customerId, productId, count);
        }

        [HttpGet]
        [Route("order/{orderId:int}/confirm")]
        public async Task<Order> ConfirmOrder(int orderId)
        {
            return await _orderService.ConfirmOrder(orderId);
        }
        
        [HttpGet]
        [Route("order/{orderId:int}/pay")]
        public async Task<Order> PayOrder(int orderId)
        {
            return await _orderService.PaymentOrder(orderId);
        }

        [HttpGet]
        [Route("order/{orderId:int}/finish")]
        public async Task<Order> FinishOrder(int orderId)
        {
            return await _orderService.FinishOrder(orderId);
        }        
        
        [HttpGet]
        [Route("order/{orderId:int}/cancel")]
        public async Task<Order> CancelOrder(int orderId)
        {
            return await _orderService.CancelOrder(orderId);
        }
        
        [HttpPut]
        [Route("edit")]
        public async Task<Order> Edit(Order order)
        {
            return await _orderService.EditOrder(order);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task Delete(Order order)
        {
            await _orderService.DeleteOrder(order);
        }
    }
}