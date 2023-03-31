using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;
using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.UpdateSalary;

public class UpdateSalaryCommand: IRequest<int>
{
    public int ItemId { get; }
    public SalaryDataDto SalaryData { get; }
    public CalculatorType CalculatorType { get; }

    public UpdateSalaryCommand(int itemId,SalaryDataDto salaryData,CalculatorType calculatorType)
    {
        ItemId = itemId;
        SalaryData = salaryData;
        CalculatorType = calculatorType;
    }
}