using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для обчислення відсотка від числа.
/// percent(50, 20) означає: знайти 20% від 50, тобто 10.
/// </summary>
public sealed class PercentOperation : BinaryOperation
{
    public PercentOperation()
        : base(OperationKind.Percent, "percent")
    {
    }

    // Формула: значення * відсоток / 100.
    protected override double Calculate(double left, double right) => left * right / 100d;
}
