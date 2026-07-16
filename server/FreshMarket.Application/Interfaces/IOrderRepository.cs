using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();

    Task<List<Order>> GetByUserIdAsync(Guid userId);

    Task<Order?> GetByIdAsync(Guid id);

    Task AddAsync(Order order);

    Task AddOrderItemAsync(OrderItem orderItem);

    Task AddOrderItemsAsync(IEnumerable<OrderItem> orderItems);

    void Update(Order order);

    void Delete(Order order);

    Task SaveChangesAsync();
}