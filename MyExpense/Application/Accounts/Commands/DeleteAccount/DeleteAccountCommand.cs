using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }

        public DeleteAccountCommand(Guid accountId)
        {
            AccountId = accountId;
        }
    }

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts.SingleOrDefaultAsync(x => x.Id == request.AccountId);
            if(entity != null)
            {
                entity.IsActive = false;
                await _context.SaveChangesAsync(cancellationToken);
            }
            return new Unit();
        }
    }
}
