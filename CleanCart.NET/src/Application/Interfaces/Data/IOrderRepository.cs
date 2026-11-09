
using Domain.Entities;
namespace Application.Interfaces.Data;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);
    Task UpdateOrderasync(Order order);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
}
