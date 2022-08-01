using Application.Accounts.Queries.GetAccounts;
using Application.Mappings;
using Domain.Entities;

namespace Application.Operations.Queries.GetOperations
{
    public class OperationDto : IMapFrom<Operation>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public AccountDto Account { get; set; }
    }
}