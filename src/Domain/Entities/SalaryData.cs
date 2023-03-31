using OvertimePolicies;

namespace Entekhab.Salary.Domain.Entities;

public class SalaryData:BaseAuditableEntity
{
    public int PersonId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int BasicSalary { get; private set; }
    public int Allowance { get; private set; }
    public int Transportation { get; private set; }
    public int FinalSalary { get; private set; }
    public double TaxPercent { get; private set; } 
    public CalculatorType OverTimeCalculatorType { get;private  set; }
    public DateTime Date { get; private set; }
    private SalaryData()
    {
        
    }
    private SalaryData(int personId,string firstName,string lastName,int basicSalary,int allowance,int transportation,double taxPercent,DateTime date,OvertimeCalculator calculator,CalculatorType overTimeCalculatorType)
    {
        PersonId = personId;
        FirstName = firstName;
        LastName = lastName;
        BasicSalary = basicSalary;
        Allowance = allowance;
        Transportation = transportation;
        TaxPercent = taxPercent;
        Date = date;
        OverTimeCalculatorType = overTimeCalculatorType;
        FinalSalary = CalculateFinalSalary(basicSalary, allowance, transportation, taxPercent, calculator);
        Created = DateTime.Now;
    }

    /// <summary>
    /// It calculates the final salary of an employee by adding basic salary, allowance, transportation, overtime and then
    /// subtracting tax
    /// </summary>
    /// <param name="basicSalary">The basic salary of the employee</param>
    /// <param name="allowance">the allowance of the employee</param>
    /// <param name="transportation">the transportation allowance</param>
    /// <param name="taxPercent">The tax percentage that will be deducted from the salary.</param>
    /// <param name="calculator">This is the interface that we will use to inject the dependency.</param>
    /// <returns>
    /// The salary after tax.
    /// </returns>
    private int CalculateFinalSalary(int basicSalary, int allowance, int transportation, double taxPercent,
        OvertimeCalculator calculator)
    {
        var salary = basicSalary + allowance + transportation + calculator.OverTimeCalculator(basicSalary, allowance);
        salary -= (int) (salary * taxPercent);
        return salary;
    }

    /// <summary>
    /// It updates the salary data with the given parameters and returns the updated salary data
    /// </summary>
    /// <param name="personId">The id of the person</param>
    /// <param name="firstName">First name of the person</param>
    /// <param name="lastName">The last name of the person.</param>
    /// <param name="basicSalary">The basic salary of the person</param>
    /// <param name="allowance">The amount of money that the employee gets as an allowance.</param>
    /// <param name="transportation">The amount of money that the company pays for the employee's transportation.</param>
    /// <param name="taxPercent">The tax percentage that will be deducted from the salary.</param>
    /// <param name="date">The date of the salary data.</param>
    /// <param name="calculator">This is the calculator that will be used to calculate the overtime.</param>
    /// <param name="overTimeCalculatorType">This is an enum that contains the type of calculator to be used.</param>
    /// <returns>
    /// SalaryData
    /// </returns>
    public SalaryData Update(int personId,string firstName,string lastName,int basicSalary,int allowance,int transportation,double taxPercent,DateTime date,OvertimeCalculator calculator,CalculatorType overTimeCalculatorType)
    {
        PersonId = personId;
        FirstName = firstName;
        LastName = lastName;
        BasicSalary = basicSalary;
        Allowance = allowance;
        Transportation = transportation;
        TaxPercent = taxPercent;
        Date = date;
        OverTimeCalculatorType = overTimeCalculatorType;
        FinalSalary = CalculateFinalSalary(basicSalary, allowance, transportation, taxPercent, calculator);
        LastModified = DateTime.Now;
        return this;
    }


    /// <summary>
    /// It creates a new instance of the SalaryData class
    /// </summary>
    /// <param name="personId">The id of the person</param>
    /// <param name="firstName">The first name of the person</param>
    /// <param name="lastName">The last name of the person</param>
    /// <param name="basicSalary">The basic salary of the person.</param>
    /// <param name="allowance">is the amount of money that the employee gets as a bonus.</param>
    /// <param name="transportation">The transportation allowance</param>
    /// <param name="taxPercent">The tax percentage that will be applied to the salary.</param>
    /// <param name="date">The date of the salary.</param>
    /// <param name="calculator">This is the calculator that will be used to calculate the overtime.</param>
    /// <param name="overTimeCalculatorType">This is an enum that contains the type of calculator to be used.</param>
    /// <returns>
    /// A new SalaryData object is being returned.
    /// </returns>
    public static SalaryData CreateNew(int personId,string firstName,string lastName,int basicSalary,int allowance,int transportation,double taxPercent,DateTime date,OvertimeCalculator calculator,CalculatorType overTimeCalculatorType)
    {
        return new SalaryData(personId, firstName, lastName, basicSalary, allowance, transportation, taxPercent, date,
            calculator, overTimeCalculatorType);
    }
}