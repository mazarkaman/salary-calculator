namespace OvertimePolicies;
using System;

public class CalculatorC : OvertimeCalculator {
    
    /// <summary>
    /// This function calculates the overtime pay for a given basic salary and allowance.
    /// </summary>
    /// <param name="basicSalary">The basic salary of the employee</param>
    /// <param name="allowance">The allowance of the employee</param>
    /// <returns>
    /// The total of the basic salary and the allowance multiplied by 0.2
    /// </returns>
    public override int OverTimeCalculator(int basicSalary,int allowance) {
        var total = basicSalary + allowance;
        return Convert.ToInt32(total * 0.2);
    }
}
