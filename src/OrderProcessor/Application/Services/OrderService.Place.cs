using OrderProcessor.Application.DTOs;
using OrderProcessor.Domain;

namespace OrderProcessor.Application.Services;

public partial class OrderService
{
    public async Task<Guid> PlaceOrderAsync(
        PlaceOrderDto dto)
    {
        var (customerId, orderLines) = dto;

        var orderId = _idGenerator.NewOrderId();

        var lines = orderLines.Select(
                x => new OrderLine(
                    _idGenerator.NewOrderLineId(),
                    x.ProductId,
                    x.Price))
            .ToList();
        
        var expectedDeliveryDate = _orderDateService.CalculateExpectedOrderDate(
            customerId,
            lines);

        var order = new Order(
            orderId,
            customerId,
            expectedDeliveryDate,
            lines);

        await _orderRepository.SaveAsync(order);
        await _eventPublisher.PublishOrderPlacedEventAsync(order);

        return orderId;
    }
}