using Domain.Entities;
using Domain.Contracts.Repositories;
using Domain.Contracts.UseCases.AddCustomer;


namespace Application.UseCases.AddCustomer
{
    public class AddCustomerUseCase : IAddCustomerUseCase
    {
        private readonly IAddCustomerRepository _addCustomerRepository;

        public AddCustomerUseCase (IAddCustomerRepository addCustomerRepository)
        {
            _addCustomerRepository = addCustomerRepository;
        }
        public void AddCutomer(Custormer custorme)
        {
            _addCustomerRepository.AddCutomer(custorme);
        }
    }
}
