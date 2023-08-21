namespace OrderProcessor.Domain;

public interface IOrder
{
    Guid Id { get; }
    Guid CustomerId { get; }
    OrderStatus Status { get; }
    DateTime ExpectedDeliveryDate { get; }
    List<OrderLine> OrderLines { get; }
}