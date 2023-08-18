using FluentAssertions;
using OrderProcessor.Application.DTOs;
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
}