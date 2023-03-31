using Entekhab.Salary.Application.Common.Helper;
using Entekhab.Salary.Application.Common.Interfaces;
using Entekhab.Salary.Domain.Entities;
using MediatR;
using OvertimePolicies;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByCustom;

public class CreateSalaryByCustomCommandHandler: IRequestHandler<CreateSalaryByCustomCommand,List<int>>
{
    private readonly IApplicationDbContext _context;

    public CreateSalaryByCustomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<int>> Handle(CreateSalaryByCustomCommand request, CancellationToken cancellationToken)
    {
        const double taxPercent = 0.2;
        List<int> ret = new();
        string[] lines = request.SalaryData.Split('\n');
        string[] headers = lines[0].Split('/');
        int personIdIndex = Array.IndexOf(headers, "PersonId");
        int firstNameIndex = Array.IndexOf(headers, "FirstName");
        int lastNameIndex = Array.IndexOf(headers, "LastName");
        int basicSalaryIndex = Array.IndexOf(headers, "BasicSalary");
        int allowanceIndex = Array.IndexOf(headers, "Allowance");
        int transportationIndex = Array.IndexOf(headers, "Transportation");
        int dateIndex = Array.IndexOf(headers, "Date");
        Enum.TryParse(request.OverTimeCalculator.ToString(), out OvertimeCalculatorFactory.CalculatorType cType);
        OvertimeCalculator calculator = OvertimeCalculatorFactory.CreateCalculator(cType);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split('/');
            int personId = int.Parse(fields[personIdIndex]);
            string firstName = fields[firstNameIndex];
            string lastName = fields[lastNameIndex];
            int basicSalary = int.Parse(fields[basicSalaryIndex]);
            int allowance = int.Parse(fields[allowanceIndex]);
            int transportation = int.Parse(fields[transportationIndex]);
            DateTime date = fields[dateIndex].ConvertPersianToGeorgian();
            SalaryData salaryData = SalaryData.CreateNew(personId, firstName, lastName, basicSalary, allowance, transportation, taxPercent, date, calculator, request.OverTimeCalculator);
            var data = _context.SalaryData.Add(salaryData);
            ret.Add(data.Entity.Id);
        }
        await _context.SaveChangesAsync(cancellationToken);
        return ret;
    }
}