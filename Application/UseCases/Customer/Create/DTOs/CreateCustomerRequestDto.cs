namespace Application.UseCases.Customer.Create.DTOs
{
    public class CreateCustomerRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
    }
} 