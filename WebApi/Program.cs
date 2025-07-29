using Application.UseCases.AddCustomer;
using Domain.Contracts.Repositories;
using Domain.Contracts.UseCases.AddCustomer;
using FluentValidation;
using Infra.CrossCutting;
using Infra.Repository.Repositories.AddCustomer;
using System.Globalization;
using WebApi.Models.Customer;
using WebApi.Models.AddCustomer;

// Register the use case implementation

var builder = WebApplication.CreateBuilder(args);

// Configure startup handler
var startupHandler = new StartupHandler();
startupHandler.ConfigureServices(builder.Services, builder.Configuration);

// Add FluentValidation
builder.Services.AddTransient<IValidator<CreateCustomerInput>, CreateCustomerInputValidator>();
builder.Services.AddTransient<IValidator<AddCustomerInput>, AddCustomerInputValidator>();
// REGISTRO DA INTERFACE

// Register the repository implementation
builder.Services.AddScoped<IAddCustomerRepository, AddCustomerRepository>();
builder.Services.AddScoped<IAddCustomerUseCase, AddCustomerUseCase>();
var app = builder.Build();

// Configure the application
startupHandler.ConfigureApp(app);

// Configure culture
var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.Run();
