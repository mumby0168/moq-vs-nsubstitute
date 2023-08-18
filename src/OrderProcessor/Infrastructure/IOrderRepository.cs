using OrderProcessor.Domain;

namespace OrderProcessor.Infrastructure;

/// <summary>
/// Responsible for persisting and retrieving orders.
/// </summary>
public interface IOrderRepository
{
    Task SaveAsync(
        Order order);
}