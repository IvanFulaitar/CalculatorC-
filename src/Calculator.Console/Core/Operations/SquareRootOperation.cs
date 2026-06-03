using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для квадратного кореня.
/// Це unary operation, бо приймає одне число.
/// </summary>
public sealed class SquareRootOperation : UnaryOperation
{
    public SquareRootOperation()
        : base(OperationKind.SquareRoot, "sqrt")
    {
    }

    protected override double Calculate(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Square root is not defined for negative numbers.");
        }

        return Math.Sqrt(value);
    }
}
