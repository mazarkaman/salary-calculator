namespace Entekhab.Salary.Domain.Entities;

public class SalaryData
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BasicSalary { get; set; }
    public int Allowance { get; set; }
    public int Transportation { get; set; }
    public DateTime Date { get; set; }
}