namespace OrderProcessor.Domain;

public record OrderLine(
    Guid Id,
    Guid ProductId,
    double Price);