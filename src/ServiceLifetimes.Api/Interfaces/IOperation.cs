namespace ServiceLifetimes.Api.Interfaces;

public interface IOperation
{
    Guid OperationId { get; }
}

public class Operation : IOperation
{
    public Guid OperationId { get; } = Guid.NewGuid();
}
