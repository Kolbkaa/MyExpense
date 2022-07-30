using Application.Accounts.Commands.CreateAccount;
using Application.Accounts.Queries.GetAccounts;
using Microsoft.AspNetCore.Mvc;

namespace MyExpenseApi.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            return await Mediator.Send(new GetAccountsQuery());
        }

        [HttpPost]
        public async Task<Guid> CreateAccount(CreateAccountCommand createAccountCommand)
        {
            return await Mediator.Send(createAccountCommand);
        }
    }
}