using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Data.Entities;
using WebApplication.Data.Enums;
using WebApplication.Interfaces;

namespace WebApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders.Include(o => o.OrderItems).ThenInclude(i => i.Product)
                .FirstAsync(o => o.Id == orderId);
        }

        public async Task<Order> AddOrder(Order order)
        {
            order.Status = OrderStatus.Cart;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> ConfirmOrder(int orderId)
        {
            var confirmedOrder = await GetOrderById(orderId);
            confirmedOrder.Status = OrderStatus.Confirmed;
            _context.Orders.Update(confirmedOrder);
            return confirmedOrder;
        }

        public async Task<Order> PaymentOrder(int orderId)
        {
            var paymentOrder = await GetOrderById(orderId);
            paymentOrder.Status = OrderStatus.Payment;
            _context.Orders.Update(paymentOrder);
            return paymentOrder;
        }

        public async Task<Order> FinishOrder(int orderId)
        {
            var finishedOrder = await GetOrderById(orderId);
            finishedOrder.Status = OrderStatus.Done;
            _context.Orders.Update(finishedOrder);
            return finishedOrder;
        }

        public async Task<Order> CancelOrder(int orderId)
        {
            var cancelledOrder = await GetOrderById(orderId);
            cancelledOrder.Status = OrderStatus.Cancelled;
            _context.Orders.Update(cancelledOrder);
            return cancelledOrder;
        }

        public async Task<Order> EditOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> EditOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task DeleteOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> AddToCart(int customerId, int productId, int count)
        {
            OrderItem orderItem = new OrderItem
            {
                ProductId = productId,
                ProductCount = count,
                OrderId = FindOrderCartByCustomerId(customerId)?.Id ??
                          AddOrder(new Order {CustomerId = customerId}).Id
            };
            await _context.SaveChangesAsync();
            return await GetOrderById(orderItem.OrderId);
        }

        private Order? FindOrderCartByCustomerId(int customerId)
        {
            return _context.Orders.FirstOrDefault(o => o.CustomerId == customerId && o.Status == OrderStatus.Cart);
        }
    }
}