using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Expenses.Queries.GetExpenses
{
    public class GetExpensesQuery : IRequest<IEnumerable<ExpenseDto>>
    {
    }

    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExpensesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseDto>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Expenses.ProjectTo<ExpenseDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}