using FluentAssertions;
using Moq;
using OrderProcessor.Domain;
using Xunit;

namespace OrderProcessor.MoqTests.Domain;

public class OrderTests
{
    [Fact]
    public void Id_Mock_ReturnsMockedId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var sut = new Mock<IOrder>();
        sut.SetupGet(o => o.Id).Returns(id);

        // Act
        var result = sut.Object.Id;

        // Assert
        result.Should().Be(id);
    }
}