using Application.Accounts.Commands.CreateAccount;
using Application.Accounts.Commands.DeleteAccount;
using Application.Accounts.Queries.GetAccounts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyExpenseApi.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IValidator<CreateAccountCommand> _createAccountCommandValidator;

        public AccountController(IValidator<CreateAccountCommand> createAccountCommandValidator)
        {
            _createAccountCommandValidator = createAccountCommandValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            return Ok(await Mediator.Send(new GetAccountsQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<ActionResult<Guid>> CreateAccount(CreateAccountCommand createAccountCommand)
        {
            var validationResult = await _createAccountCommandValidator.ValidateAsync(createAccountCommand);
            if (validationResult.IsValid)
                return Ok(await Mediator.Send(createAccountCommand));

            return BadRequest(validationResult.Errors);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(DeleteAccountCommand deleteAccountCommand)
        {
            return Ok(await Mediator.Send(deleteAccountCommand));
        }
    }
}