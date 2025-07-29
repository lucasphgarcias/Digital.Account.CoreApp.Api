namespace Domain.Contracts.UseCases.Customer
{
    public interface ICreateCustomerUseCase
    {
        Task<CreateCustomerResult> ExecuteAsync(CreateCustomerRequest request);
    }

    public record CreateCustomerRequest(string Name, string Email, string Document);
    
    public record CreateCustomerResult(bool Success, Guid? CustomerId = null, List<string>? Errors = null)
    {
        public List<string> Errors { get; init; } = Errors ?? new List<string>();
    }
} 