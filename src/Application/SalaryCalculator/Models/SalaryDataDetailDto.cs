using Entekhab.Salary.Application.Common.Mappings;
using Entekhab.Salary.Domain.Entities;

namespace Entekhab.Salary.Application.SalaryCalculator.Models;

public class SalaryDataDetailDto:IMapFrom<SalaryData>
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BasicSalary { get; set; }
    public int Allowance { get; set; }
    public int Transportation { get; set; }
    public DateTime Date { get; set; }
    public int FinalSalary { get; set; }
    public CalculatorType OverTimeCalculatorType { get; set; }
}