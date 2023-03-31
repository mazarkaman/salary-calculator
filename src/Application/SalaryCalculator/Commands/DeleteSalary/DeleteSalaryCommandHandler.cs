using Entekhab.Salary.Application.Common.Interfaces;
using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.DeleteSalary;

public class DeleteSalaryCommandHandler : IRequestHandler<DeleteSalaryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSalaryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
    {
        var item = _context.SalaryData.FirstOrDefault(r => r.Id == request.ItemId);
        if (item != null)
        {
            _context.SalaryData.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}