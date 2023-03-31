namespace OvertimePolicies;

public abstract class OvertimeCalculator
{
    
    /// <summary>
    /// This function calculates the overtime pay of an employee.
    /// </summary>
    /// <param name="basicSalary">The basic salary of the employee</param>
    /// <param name="allowance">the allowance of the employee</param>
    public abstract int OverTimeCalculator(int basicSalary, int allowance);
}