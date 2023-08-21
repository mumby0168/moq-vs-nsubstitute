namespace OrderProcessor.Domain;

public class Order : IOrder
{
    public Guid Id { get; }
    
    public Guid CustomerId { get; }
    
    public OrderStatus Status { get; }

    public DateTime ExpectedDeliveryDate { get; }
    
    public List<OrderLine> OrderLines { get; }
    
    public record OrderLineDto(
        Guid ProductId,
        double Price);

    public Order(
        Guid id,
        Guid customerId,
        DateTime expectedDeliveryDate,
        List<OrderLine> orderLines)
    {
        Id = id;
        CustomerId = customerId;
        ExpectedDeliveryDate = expectedDeliveryDate;
        OrderLines = orderLines;
        Status = OrderStatus.Placed;
    }
}

public enum OrderStatus
{
    Placed,
    Fulfilling,
    Fulfilled,
    OutForDelivery,
    Complete
}