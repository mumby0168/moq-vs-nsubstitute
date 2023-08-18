using OrderProcessor.Application.DTOs;

namespace OrderProcessor.Application.Services;

public interface IOrderService
{
    Task<Guid> PlaceOrderAsync(PlaceOrderDto dto);
}