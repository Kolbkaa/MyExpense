using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Operations.Queries.GetOperations
{
    public class GetOperationsQuery : IRequest<IEnumerable<OperationDto>>
    {
    }

    public class GetOperationesQueryHandler : IRequestHandler<GetOperationsQuery, IEnumerable<OperationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOperationesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OperationDto>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Operations.ProjectTo<OperationDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}