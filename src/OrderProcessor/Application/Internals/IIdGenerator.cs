namespace OrderProcessor.Application.Internals;

public interface IIdGenerator
{
    Guid NewOrderId();

    Guid NewOrderLineId();
}