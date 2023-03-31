using Entekhab.Salary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Salary.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<SalaryData> SalaryData { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}