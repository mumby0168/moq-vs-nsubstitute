namespace OrderProcessor.Application.DTOs;

public record PlaceOrderDto(
    Guid CustomerId,
    IEnumerable<PlaceOrderDto.OrderLineDto> OrderLines)
{
    public record OrderLineDto(
        Guid ProductId,
        double Price);
}