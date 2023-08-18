using OrderProcessor.Domain;

namespace OrderProcessor.Application.Internals;

public interface IOrderDateService
{
    DateTime CalculateExpectedOrderDate(
        Guid customerId,
        IEnumerable<OrderLine> lines);
}