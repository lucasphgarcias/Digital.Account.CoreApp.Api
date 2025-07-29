namespace Application.UseCases.Customer.Create.DTOs
{
    public class CreateCustomerResponseDto
    {
        public bool Success { get; set; }
        public Guid? CustomerId { get; set; }
        public List<string> Errors { get; set; } = new();

        public CreateCustomerResponseDto(Guid customerId)
        {
            Success = true;
            CustomerId = customerId;
        }

        public CreateCustomerResponseDto(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
} 