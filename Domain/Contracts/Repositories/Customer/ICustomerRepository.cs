using Domain.Entities;

namespace Domain.Contracts.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task<Domain.Entities.Customer?> GetByIdAsync(Guid id);
        Task<Domain.Entities.Customer?> GetByEmailAsync(string email);
        Task<Domain.Entities.Customer?> GetByDocumentAsync(string document);
        Task<IEnumerable<Domain.Entities.Customer>> GetAllAsync();
        Task<IEnumerable<Domain.Entities.Customer>> GetActiveCustomersAsync();
        Task<Domain.Entities.Customer> CreateAsync(Domain.Entities.Customer customer);
        Task<Domain.Entities.Customer> UpdateAsync(Domain.Entities.Customer customer);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByDocumentAsync(string document);
    }
} 