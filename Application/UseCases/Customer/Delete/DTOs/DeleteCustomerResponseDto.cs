namespace Application.UseCases.Customer.Delete.DTOs
{
    public class DeleteCustomerResponseDto
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new();

        public DeleteCustomerResponseDto()
        {
            Success = true;
        }

        public DeleteCustomerResponseDto(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
} 