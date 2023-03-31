using Entekhab.Salary.Application.Common.Helper;
using Entekhab.Salary.Application.Common.Interfaces;
using Entekhab.Salary.Domain.Entities;
using MediatR;
using OvertimePolicies;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;

public class CreateSalaryByJsonCommandHandler : IRequestHandler<CreateSalaryByJsonCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSalaryByJsonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSalaryByJsonCommand request, CancellationToken cancellationToken)
    {
        const double taxPercent = 0.2;
        Enum.TryParse(request.CalculatorType.ToString(), out OvertimeCalculatorFactory.CalculatorType cType);
        OvertimeCalculator calculator = OvertimeCalculatorFactory.CreateCalculator(cType);

        SalaryData salaryData = SalaryData.CreateNew(
            request.SalaryData.PersonId,
            request.SalaryData.FirstName,
            request.SalaryData.LastName,
            request.SalaryData.BasicSalary,
            request.SalaryData.Allowance,
            request.SalaryData.Transportation,
            taxPercent,
            request.SalaryData.Date.ConvertPersianToGeorgian(), calculator,
            request.CalculatorType);
        
        var data = _context.SalaryData.Add(salaryData);
        await _context.SaveChangesAsync(cancellationToken);
        return data.Entity.Id;
    }
}