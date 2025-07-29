using Application.UseCases.Customer.Create;
using Domain.Contracts.UseCases.Customer;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Customer;
using WebApi.Models.Error;
using FluentValidation;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICreateCustomerUseCase _createCustomerUseCase;
        private readonly IValidator<CreateCustomerInput> _createCustomerInputValidator;

        public CustomerController(
            ICreateCustomerUseCase createCustomerUseCase,
            IValidator<CreateCustomerInput> createCustomerInputValidator)
        {
            _createCustomerUseCase = createCustomerUseCase;
            _createCustomerInputValidator = createCustomerInputValidator;
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="input">Customer information</param>
        /// <returns>Created customer information</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerInput input)
        {
            var validatorResult = await _createCustomerInputValidator.ValidateAsync(input);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.ToCustomValidatorFailure());
            }

            var request = new CreateCustomerRequest(input.Name, input.Email, input.Document);

            var result = await _createCustomerUseCase.ExecuteAsync(request);

            if (!result.Success)
            {
                return BadRequest(new { errors = result.Errors });
            }

            return CreatedAtAction(nameof(GetCustomer), new { id = result.CustomerId }, new { id = result.CustomerId });
        }

        /// <summary>
        /// Gets a customer by ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Customer information</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            // TODO: Implement GetCustomerUseCase
            return Ok(new { message = "Get customer endpoint - to be implemented" });
        }
    }
} 