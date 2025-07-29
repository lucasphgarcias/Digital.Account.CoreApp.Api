using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;
using Domain.Contracts.UseCases.AddCustomer;
using FluentValidation;
using WebApi.Models.Error;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCase;
        private readonly IValidator<AddCustomerInput> _addCustomerInputValidator;

        public AddCustomerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> addCustomerInputValidator) 
        {
            _addCustomerUseCase = addCustomerUseCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }


        /// <summary>
        /// Chama use case para adicionar o customer
        /// </summary>
        /// <param name="input">Name, Email e Document</param>
        /// <returns>Cadastrar o Customer</returns>
        /// 
        [HttpPost]

        public IActionResult AddCustomer(AddCustomerInput input)
        {
            var validatorResult = _addCustomerInputValidator.Validate(input);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.ToCustomValidatorFailure());
                
            }

            var customer = new Custormer(input.Name, input.Email, input.Document);
            _addCustomerUseCase.AddCutomer(customer);
            return Created("", customer);

            
        }

    }
}
