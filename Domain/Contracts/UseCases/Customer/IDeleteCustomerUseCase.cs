namespace Domain.Contracts.UseCases.Customer
{
    public interface IDeleteCustomerUseCase
    {
        Task<DeleteCustomerResult> ExecuteAsync(Guid id);
    }

    public record DeleteCustomerResult(bool Success, List<string>? Errors = null)
    {
        public List<string> Errors { get; init; } = Errors ?? new List<string>();
    }
} 