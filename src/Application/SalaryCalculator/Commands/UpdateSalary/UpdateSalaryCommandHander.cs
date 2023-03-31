using Entekhab.Salary.Application.Common.Exceptions;
using Entekhab.Salary.Application.Common.Helper;
using Entekhab.Salary.Application.Common.Interfaces;
using Entekhab.Salary.Application.SalaryCalculator.Commands.DeleteSalary;
using Entekhab.Salary.Domain.Entities;
using MediatR;
using OvertimePolicies;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.UpdateSalary;

public class UpdateSalaryCommandHandler : IRequestHandler<UpdateSalaryCommand,int>
{
    private readonly IApplicationDbContext _context;

    public UpdateSalaryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
    {
        const double taxPercent = 0.2;
        Enum.TryParse(request.CalculatorType.ToString(), out OvertimeCalculatorFactory.CalculatorType cType);
        OvertimeCalculator calculator = OvertimeCalculatorFactory.CreateCalculator(cType);

        var item = _context.SalaryData.FirstOrDefault(r => r.Id == request.ItemId);
        if (item != null)
        {
            item = item.Update(
                request.SalaryData.PersonId,
                request.SalaryData.FirstName,
                request.SalaryData.LastName,
                request.SalaryData.BasicSalary,
                request.SalaryData.Allowance,
                request.SalaryData.Transportation,
                taxPercent,
                request.SalaryData.Date.ConvertPersianToGeorgian(), calculator,
                request.CalculatorType
            );
            _context.SalaryData.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item.Id;
        }
        throw new NotFoundException(nameof(SalaryData), request.ItemId);
    }
}