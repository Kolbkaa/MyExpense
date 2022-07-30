using Application.Mappings;
using Domain.Entities;

namespace Application.Accounts.Queries.GetAccounts;

public class AccountDto : IMapFrom<Account>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}