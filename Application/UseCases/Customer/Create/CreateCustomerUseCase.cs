using Domain.Contracts.Repositories.Customer;
using Domain.Contracts.UseCases.Customer;
using Domain.Entities;
using Domain.Events;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Customer.Create
{
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;

        public CreateCustomerUseCase(ICustomerRepository customerRepository, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public async Task<CreateCustomerResult> ExecuteAsync(CreateCustomerRequest request)
        {
            try
            {
                // Validate if customer already exists
                if (await _customerRepository.ExistsByEmailAsync(request.Email))
                {
                    return new CreateCustomerResult(false, Errors: new List<string> { "Customer with this email already exists" });
                }

                if (await _customerRepository.ExistsByDocumentAsync(request.Document))
                {
                    return new CreateCustomerResult(false, Errors: new List<string> { "Customer with this document already exists" });
                }

                // Create value objects
                var name = new Name(request.Name);
                var email = new Email(request.Email);
                var document = new Document(request.Document);

                // Create customer entity
                var customer = new Domain.Entities.Customer(name, email, document);

                if (customer.HasNotifications())
                {
                    return new CreateCustomerResult(false, Errors: customer.Notifications.ToList());
                }

                // Save to repository
                var createdCustomer = await _customerRepository.CreateAsync(customer);

                // Publish domain event
                await _mediator.Publish(new CustomerCreatedDomainEvent(createdCustomer));

                return new CreateCustomerResult(true, createdCustomer.Id);
            }
            catch (Exception ex)
            {
                return new CreateCustomerResult(false, Errors: new List<string> { ex.Message });
            }
        }
    }
} 