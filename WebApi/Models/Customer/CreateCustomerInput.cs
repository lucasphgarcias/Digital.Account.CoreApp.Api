namespace WebApi.Models.Customer
{
    public class CreateCustomerInput
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
    }
} 