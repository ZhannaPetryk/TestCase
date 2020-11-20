using System.Threading.Tasks;
using WebApplication.Data.Entities;

namespace WebApplication.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddToCart(int customerId, int productId, int count);
        Task<Order> GetOrderById(int orderId);
        Task<Order> EditOrder(Order order);
        Task DeleteOrder(Order order);
        Task<Order> ConfirmOrder(int orderId);
        Task<Order> PaymentOrder(int orderId);
        Task<Order> FinishOrder(int orderId);
        Task<Order> CancelOrder(int orderId);
    }
}