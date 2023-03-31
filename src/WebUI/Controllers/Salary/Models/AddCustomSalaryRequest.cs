using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;

namespace WebUI.Controllers.Salary.Models;

public class AddCustomSalaryRequest   
{
    public CalculatorType OverTimeCalculator { get; set; }
    public string SalaryData { get; set; }
}