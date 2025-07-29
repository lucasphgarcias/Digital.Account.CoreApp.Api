namespace Application.UseCases.Customer.Update.DTOs
{
    public class UpdateCustomerRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
    }
} 