using Domain.Contracts.Repositories.Customer;
using Infra.CrossCutting;
using Infra.Repository.Repositories.Customer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.Services
{
    public class RepositoryStartup : IServicesStartup, IApplicationBuilderStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public void ConfigureApp(IApplicationBuilder app)
        {
            // Repository-specific app configuration if needed
        }
    }
} 