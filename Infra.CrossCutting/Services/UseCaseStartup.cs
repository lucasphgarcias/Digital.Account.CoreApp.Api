using Application.UseCases.Customer.Create;
using Domain.Contracts.UseCases.Customer;
using Infra.CrossCutting;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.Services
{
    public class UseCaseStartup : IServicesStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerUseCase).Assembly));
        }
    }
} 