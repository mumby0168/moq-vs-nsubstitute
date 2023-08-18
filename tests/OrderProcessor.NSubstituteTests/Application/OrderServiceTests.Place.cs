using FluentAssertions;
using NSubstitute;
using OrderProcessor.Application.DTOs;
using OrderProcessor.Domain;
using Xunit;

namespace OrderProcessor.NSubstituteTests.Application;

public partial class OrderServiceTests
{
    [Fact]
    public async Task PlaceOrderAsync_Order_ReturnsOrderId()
    {
        // Arrange
        var sut = CreateSut();

        var orderId = Guid.NewGuid();
        _idGenerator.NewOrderId().Returns(orderId);

        var placeOrderDto = new PlaceOrderDto(
            Guid.NewGuid(),
            new List<PlaceOrderDto.OrderLineDto>
            {
                new(
                    Guid.NewGuid(),
                    10.0),
                new(
                    Guid.NewGuid(),
                    20.0),
                new(
                    Guid.NewGuid(),
                    30.0)
            });


        // Act
        var result = await sut.PlaceOrderAsync(placeOrderDto);

        // Assert
        result.Should().Be(orderId);
    }

    [Fact]
    public async Task PlaceOrderAsync_Order_SavesOrderWithCorrectDeliveryDate()
    {
        // Arrange
        var sut = CreateSut();
        var customerId = Guid.NewGuid();

        _idGenerator.NewOrderId().Returns(Guid.NewGuid());

        var orderDeliveryDate = DateTime.UtcNow.AddDays(1);

        _orderDateService.CalculateExpectedOrderDate(
                customerId,
                Arg.Any<IEnumerable<OrderLine>>())
            .Returns(orderDeliveryDate);

        var placeOrderDto = new PlaceOrderDto(
            customerId,
            new List<PlaceOrderDto.OrderLineDto>
            {
                new(
                    Guid.NewGuid(),
                    10.0),
                new(
                    Guid.NewGuid(),
                    20.0),
                new(
                    Guid.NewGuid(),
                    30.0)
            });


        // Act
        await sut.PlaceOrderAsync(placeOrderDto);

        //Assert
        await _orderRepository.Received(1).SaveAsync(
            Arg.Is<Order>(o =>
                o.ExpectedDeliveryDate == orderDeliveryDate));
    }
}