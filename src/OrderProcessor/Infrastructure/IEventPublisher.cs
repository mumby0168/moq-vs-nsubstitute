using OrderProcessor.Domain;

namespace OrderProcessor.Infrastructure;


/// <summary>
/// Responsible for publishing & constructing events.
/// </summary>
public interface IEventPublisher
{
    Task PublishOrderPlacedEventAsync(
        Order order);
}