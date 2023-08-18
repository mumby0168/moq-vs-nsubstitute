using Moq;
using OrderProcessor.Application.Internals;
using OrderProcessor.Application.Services;
using OrderProcessor.Infrastructure;

namespace OrderProcessor.MoqTests.Application;

public partial class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<IEventPublisher> _eventPublisher;
    private readonly Mock<IIdGenerator> _idGenerator;
    private readonly Mock<IOrderDateService> _orderDateService;

    public OrderServiceTests()
    {
        _orderRepository = new Mock<IOrderRepository>();
        _eventPublisher = new Mock<IEventPublisher>();
        _idGenerator = new Mock<IIdGenerator>();
        _orderDateService = new Mock<IOrderDateService>();
    }
    
    private IOrderService CreateSut() =>
        new OrderService(
            _orderRepository.Object,
            _eventPublisher.Object,
            _idGenerator.Object,
            _orderDateService.Object);
}