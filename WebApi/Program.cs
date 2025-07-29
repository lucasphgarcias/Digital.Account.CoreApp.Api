using Infra.CrossCutting;
using System.Globalization;
using WebApi.Models.Customer;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Configure startup handler
var startupHandler = new StartupHandler();
startupHandler.ConfigureServices(builder.Services, builder.Configuration);

// Add FluentValidation
builder.Services.AddTransient<IValidator<CreateCustomerInput>, CreateCustomerInputValidator>();

var app = builder.Build();

// Configure the application
startupHandler.ConfigureApp(app);

// Configure culture
var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.Run();
