using NSubstitute;
using OrderProcessor.Application.Internals;
using OrderProcessor.Application.Services;
using OrderProcessor.Infrastructure;

namespace OrderProcessor.NSubstituteTests.Application;

public partial class OrderServiceTests
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IIdGenerator _idGenerator;
    private readonly IOrderDateService _orderDateService;

    public OrderServiceTests()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _eventPublisher = Substitute.For<IEventPublisher>();
        _idGenerator = Substitute.For<IIdGenerator>();
        _orderDateService = Substitute.For<IOrderDateService>();
    }
    
    private IOrderService CreateSut() =>
        new OrderService(
            _orderRepository,
            _eventPublisher,
            _idGenerator,
            _orderDateService);
}