namespace Domain.Contracts.UseCases.Customer
{
    public interface IUpdateCustomerUseCase
    {
        Task<UpdateCustomerResult> ExecuteAsync(Guid id, UpdateCustomerRequest request);
    }

    public record UpdateCustomerRequest(string Name, string Email, string Document);
    
    public record UpdateCustomerResult(bool Success, Guid? CustomerId = null, List<string>? Errors = null)
    {
        public List<string> Errors { get; init; } = Errors ?? new List<string>();
    }
} 