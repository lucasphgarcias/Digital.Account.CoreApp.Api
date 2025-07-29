using Domain.Contracts.Repositories;
using Domain.Entities;

namespace Infra.Repository.Repositories.AddCustomer
{
    public class AddCustomerRepository : IAddCustomerRepository
    {
        private readonly IList<Custormer> _customs = new List<Custormer>();
        public void AddCutomer(Custormer custorme)
        {
            _customs.Add(custorme);
        }
    }
}
