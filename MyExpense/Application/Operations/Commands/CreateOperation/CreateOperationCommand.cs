using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Operations.Commands.CreateOperation
{
    public class CreateOperationCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountId { get; set; }
    }

    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateOperationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == request.AccountId);

            if (account == null) return Guid.Empty;

            var operation = new Operation()
            {
                Name = request.Name,
                Date = request.Date,
                Account = account,
                Value = request.Value,
            };

            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync(cancellationToken);
            return operation.Id;
        }
    }
}