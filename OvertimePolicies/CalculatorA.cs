namespace OvertimePolicies;

public class CalculatorA : OvertimeCalculator {
  
    /// <summary>
    /// > This function calculates the overtime pay of an employee
    /// </summary>
    /// <param name="basicSalary">The basic salary of the employee</param>
    /// <param name="allowance">The amount of money that the employee gets as an allowance.</param>
    /// <returns>
    /// The total of the basic salary and the allowance multiplied by 0.1
    /// </returns>
    public override int OverTimeCalculator(int basicSalary,int allowance)
    {
        var total = basicSalary + allowance;
        return Convert.ToInt32(total * 0.1);
    }
}