using FluentAssertions;
using NSubstitute;
using OrderProcessor.Domain;
using Xunit;

namespace OrderProcessor.NSubstituteTests.Domain;

public class OrderTests
{
    [Fact]
    public void Id_Mock_ReturnsMockedId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var sut = Substitute.For<IOrder>();
        sut.Id.Returns(id);

        // Act
        var result = sut.Id;

        // Assert
        result.Should().Be(id);
    }
}