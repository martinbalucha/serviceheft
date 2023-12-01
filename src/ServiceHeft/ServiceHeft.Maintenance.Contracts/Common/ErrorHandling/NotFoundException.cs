namespace ServiceHeft.Maintenance.Contracts.Common.ErrorHandling;

/// <summary>
/// Should be thrown when a sought entity does not exist.
/// </summary>
public sealed class NotFoundException : Exception
{
    public NotFoundException() : base() { }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
