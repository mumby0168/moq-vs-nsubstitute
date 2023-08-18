using OrderProcessor.Application.Internals;
using OrderProcessor.Infrastructure;

namespace OrderProcessor.Application.Services;

public partial class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IIdGenerator _idGenerator;
    private readonly IOrderDateService _orderDateService;

    public OrderService(
        IOrderRepository orderRepository,
        IEventPublisher eventPublisher,
        IIdGenerator idGenerator,
        IOrderDateService orderDateService)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
        _idGenerator = idGenerator;
        _orderDateService = orderDateService;
    }
}