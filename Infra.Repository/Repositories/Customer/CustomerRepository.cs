using Domain.Contracts.Repositories.Customer;
using Domain.Entities;

namespace Infra.Repository.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Domain.Entities.Customer> _customers = new();

        public async Task<Domain.Entities.Customer?> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));
        }

        public async Task<Domain.Entities.Customer?> GetByEmailAsync(string email)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.Email.Value == email));
        }

        public async Task<Domain.Entities.Customer?> GetByDocumentAsync(string document)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.Document.Value == document));
        }

        public async Task<IEnumerable<Domain.Entities.Customer>> GetAllAsync()
        {
            return await Task.FromResult(_customers.AsEnumerable());
        }

        public async Task<IEnumerable<Domain.Entities.Customer>> GetActiveCustomersAsync()
        {
            return await Task.FromResult(_customers.Where(c => c.IsActive).AsEnumerable());
        }

        public async Task<Domain.Entities.Customer> CreateAsync(Domain.Entities.Customer customer)
        {
            _customers.Add(customer);
            return await Task.FromResult(customer);
        }

        public async Task<Domain.Entities.Customer> UpdateAsync(Domain.Entities.Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                var index = _customers.IndexOf(existingCustomer);
                _customers[index] = customer;
            }
            return await Task.FromResult(customer);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.Deactivate();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.FromResult(_customers.Any(c => c.Id == id));
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await Task.FromResult(_customers.Any(c => c.Email.Value == email));
        }

        public async Task<bool> ExistsByDocumentAsync(string document)
        {
            return await Task.FromResult(_customers.Any(c => c.Document.Value == document));
        }
    }
} 