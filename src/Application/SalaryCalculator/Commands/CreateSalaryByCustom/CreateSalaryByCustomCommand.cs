using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;
using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByCustom;

public class CreateSalaryByCustomCommand: IRequest<List<int>>
{
    public string SalaryData { get; }
    public CalculatorType OverTimeCalculator { get; }

    public CreateSalaryByCustomCommand(string salaryData, CalculatorType overTimeCalculator)
    {
        SalaryData = salaryData;
        OverTimeCalculator = overTimeCalculator;
    }
}