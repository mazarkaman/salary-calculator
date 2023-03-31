using Microsoft.Extensions.DependencyInjection.SalaryCalculator.Models;

namespace WebUI.Controllers.Salary.Models;

public class AddSalaryRequest   
{
    public CalculatorType OverTimeCalculator { get; set; }
    public SalaryDataDto SalaryData { get; set; }
}