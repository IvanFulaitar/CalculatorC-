using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для ділення.
/// Тут є додаткове бізнес-правило: на нуль ділити не можна.
/// Саме тут правильно тримати це правило, бо воно стосується тільки ділення.
/// </summary>
public sealed class DivideOperation : BinaryOperation
{
    public DivideOperation()
        : base(OperationKind.Divide, "divide")
    {
    }

    protected override double Calculate(double left, double right)
    {
        if (right == 0)
        {
            // Exception повідомляє про помилковий сценарій, який Program потім обробить через catch.
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        return left / right;
    }
}
