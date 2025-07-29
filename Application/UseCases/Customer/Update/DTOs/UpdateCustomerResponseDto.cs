namespace Application.UseCases.Customer.Update.DTOs
{
    public class UpdateCustomerResponseDto
    {
        public bool Success { get; set; }
        public Guid? CustomerId { get; set; }
        public List<string> Errors { get; set; } = new();

        public UpdateCustomerResponseDto(Guid customerId)
        {
            Success = true;
            CustomerId = customerId;
        }

        public UpdateCustomerResponseDto(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
} 