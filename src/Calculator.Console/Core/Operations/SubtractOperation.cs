using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для віднімання.
/// Він має тільки свою формулу, а перевірку кількості аргументів отримує від базового класу.
/// </summary>
public sealed class SubtractOperation : BinaryOperation
{
    public SubtractOperation()
        : base(OperationKind.Subtract, "subtract")
    {
    }

    protected override double Calculate(double left, double right) => left - right;
}
