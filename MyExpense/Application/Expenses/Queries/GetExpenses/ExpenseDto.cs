using Application.Accounts.Queries.GetAccounts;
using Application.Mappings;
using Domain.Entities;

namespace Application.Expenses.Queries.GetExpenses
{
    public class ExpenseDto : IMapFrom<Expense>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public AccountDto Account { get; set; }
    }
}