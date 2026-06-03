namespace Calculator.Console.Core;

/// <summary>
/// BasicCalculator лишається простим фасадом для старого інтерфейсу ICalculator.
/// Це дозволяє не ламати ExpressionParser і тести, але всередині вже працює повноцінна OOP-модель.
/// </summary>
public sealed class BasicCalculator : ICalculator
{
    private readonly CalculatorEngine _engine;

    public BasicCalculator()
        : this(new CalculatorEngine())
    {
    }

    public BasicCalculator(CalculatorEngine engine)
    {
        _engine = engine ?? throw new ArgumentNullException(nameof(engine));
    }

    public double Add(double a, double b) => _engine.Calculate(OperationKind.Add, a, b);

    public double Subtract(double a, double b) => _engine.Calculate(OperationKind.Subtract, a, b);

    public double Multiply(double a, double b) => _engine.Calculate(OperationKind.Multiply, a, b);

    public double Divide(double a, double b) => _engine.Calculate(OperationKind.Divide, a, b);

    public double SquareRoot(double a) => _engine.Calculate(OperationKind.SquareRoot, a);

    public double Power(double @base, double exponent) => _engine.Calculate(OperationKind.Power, @base, exponent);

    public double Abs(double a) => _engine.Calculate(OperationKind.Absolute, a);
}
