using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для віднімання.
/// Він має тільки свою формулу, а перевірку кількості аргументів отримує від базового класу.
/// Це показує користь inheritance: спільна логіка не дублюється.
/// </summary>
public sealed class SubtractOperation : BinaryOperation
{
    public SubtractOperation()
        : base(OperationKind.Subtract, "subtract")
    {
    }

    // Тут формула інша, але виклик ззовні все одно йде через Execute.
    protected override double Calculate(double left, double right) => left - right;
}
