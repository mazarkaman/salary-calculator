using Entekhab.Salary.Application.Common.Mappings;
using Entekhab.Salary.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.SalaryCalculator.Models;

public class SalaryDataDto:IMapFrom<SalaryData>
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BasicSalary { get; set; }
    public int Allowance { get; set; }
    public int Transportation { get; set; }
    public DateTime Date { get; set; }
}

public enum CalculatorType {
    TypeA, TypeB, TypeC
}