using Ordering.Domain.Entities;

namespace Ordering.Application.Constracts.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}

