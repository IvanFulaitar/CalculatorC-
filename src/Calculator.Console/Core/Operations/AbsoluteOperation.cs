using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для модуля числа.
/// Назва abs використовується парсером у виразах на кшталт abs(-5).
/// </summary>
public sealed class AbsoluteOperation : UnaryOperation
{
    public AbsoluteOperation()
        : base(OperationKind.Absolute, "abs")
    {
    }

    protected override double Calculate(double value) => Math.Abs(value);
}
