using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account() { Name = request.Name };
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync(cancellationToken);

            return account.Id;
        }
    }
}