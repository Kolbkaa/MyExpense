
using Application.Expenses.Commands.CreateExpense;
using Application.Expenses.Queries.GetExpenses;
using Microsoft.AspNetCore.Mvc;

namespace MyExpenseApi.Controllers
{
    public class ExpenseController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ExpenseDto>> GetExpenses()
        {
            return await Mediator.Send(new GetExpensesQuery());
        }

        [HttpPost]
        public async Task<Guid> CreateExpense(CreateExpenseCommand createExpenseCommand)
        {
            return await Mediator.Send(createExpenseCommand);
        }
    }
}