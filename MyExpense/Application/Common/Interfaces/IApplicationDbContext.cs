using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Account> Accounts { get; }
    DbSet<Operation> Operations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}