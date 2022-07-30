using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQuery : IRequest<IEnumerable<AccountDto>>
    {
    }

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IEnumerable<AccountDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Accounts.ProjectTo<AccountDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}