namespace Calculator.Console.Core;

/// <summary>
/// BasicCalculator лишається простим фасадом для старого інтерфейсу ICalculator.
/// Це дозволяє не ламати ExpressionParser і тести, але всередині вже працює повноцінна OOP-модель.
/// sealed означає, що від цього класу не планується наслідування.
/// </summary>
public sealed class BasicCalculator : ICalculator
{
    // private readonly поле сховане всередині класу.
    // readonly гарантує, що engine не буде випадково замінений після створення BasicCalculator.
    private readonly CalculatorEngine _engine;

    // Порожній constructor створює стандартний engine.
    // Він передає роботу іншому constructor через this(...).
    public BasicCalculator()
        : this(new CalculatorEngine())
    {
    }

    // Цей constructor дозволяє передати власний CalculatorEngine.
    // Такий підхід зручний для тестів і показує dependency injection без зовнішніх бібліотек.
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

    public double Percent(double value, double percent) => _engine.Calculate(OperationKind.Percent, value, percent);
}
