using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для модуля числа.
/// Назва abs використовується парсером у виразах на кшталт abs(-5).
/// Це ще один приклад unary operation.
/// </summary>
public sealed class AbsoluteOperation : UnaryOperation
{
    public AbsoluteOperation()
        : base(OperationKind.Absolute, "abs")
    {
    }

    // Math.Abs повертає число без мінуса.
    protected override double Calculate(double value) => Math.Abs(value);
}
