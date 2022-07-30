using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountId { get; set; }
    }

    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateExpenseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == request.AccountId);

            if(account == null) return Guid.Empty;

            var expense = new Expense()
            {
                Name = request.Name,
                Date = request.Date,
                Account = account
            };

            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync(cancellationToken);
            return expense.Id;
        }
    }
}