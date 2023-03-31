namespace OvertimePolicies;

public class OvertimeCalculatorFactory {
    public enum CalculatorType {
        TypeA, TypeB, TypeC
    }

    /// <summary>
    /// If the type is CalculatorType.TypeA, return a new CalculatorA, if it's CalculatorType.TypeB, return a new
    /// CalculatorB, if it's CalculatorType.TypeC, return a new CalculatorC, otherwise throw an exception.
    /// </summary>
    /// <param name="type">The enum that contains the different types of calculators.</param>
    /// <returns>
    /// A new instance of the CalculatorA, CalculatorB, or CalculatorC class.
    /// </returns>
    public static OvertimeCalculator CreateCalculator(CalculatorType type)
    {
        return type switch
        {
            CalculatorType.TypeA => new CalculatorA(),
            CalculatorType.TypeB => new CalculatorB(),
            CalculatorType.TypeC => new CalculatorC(),
            _ => throw new ArgumentException("Invalid calculator type")
        };
    }
}