using FluentAssertions;
using Moq;
using OrderProcessor.Application.DTOs;
using OrderProcessor.Domain;
using Xunit;

namespace OrderProcessor.MoqTests.Application;

public partial class OrderServiceTests
{
    [Fact]
    public async Task PlaceOrderAsync_Order_ReturnsOrderId()
    {
        // Arrange
        var sut = CreateSut();

        var orderId = Guid.NewGuid();
        _idGenerator.Setup(x => x.NewOrderId()).Returns(orderId);

        var placeOrderDto = new PlaceOrderDto(
            Guid.NewGuid(),
            new List<PlaceOrderDto.OrderLineDto>
            {
                new(
                    Guid.NewGuid(),
                    10.0)
            });


        // Act
        var result = await sut.PlaceOrderAsync(placeOrderDto);

        // Assert
        result.Should().Be(orderId);
    }
    
    [Fact]
    public async Task PlaceOrderAsync_Order_SavesOrderWithCorrectOrderId()
    {
        // Arrange
        var sut = CreateSut();

        var orderId = Guid.NewGuid();
        _idGenerator.Setup(x => x.NewOrderId()).Returns(orderId);

        var placeOrderDto = new PlaceOrderDto(
            Guid.NewGuid(),
            new List<PlaceOrderDto.OrderLineDto>
            {
                new(
                    Guid.NewGuid(),
                    10.0)
            });


        // Act
        await sut.PlaceOrderAsync(placeOrderDto);

        // Assert
        _orderRepository.Verify(
            o => o.SaveAsync(It.Is<Order>(order => order.Id == orderId)),
            Times.Once);
    }

    [Fact]
    public async Task PlaceOrderAsync_Order_SavesOrderWithCorrectDeliveryDate()
    {
        // Arrange
        var sut = CreateSut();
        var customerId = Guid.NewGuid();

        _idGenerator.Setup(x => x.NewOrderId()).Returns(Guid.NewGuid);

        var orderDeliveryDate = DateTime.UtcNow.AddDays(1);

        _orderDateService.Setup(
                o => o.CalculateExpectedOrderDate(
                    customerId,
                    It.IsAny<IEnumerable<OrderLine>>()))
            .Returns(orderDeliveryDate);

        var placeOrderDto = new PlaceOrderDto(
            customerId,
            new List<PlaceOrderDto.OrderLineDto>
            {
                new(
                    Guid.NewGuid(),
                    10.0)
            });


        // Act
        await sut.PlaceOrderAsync(placeOrderDto);

        // Assert
        _orderRepository.Verify(
            o => o.SaveAsync(It.Is<Order>(order => order.ExpectedDeliveryDate == orderDeliveryDate)),
            Times.Once);
    }
}