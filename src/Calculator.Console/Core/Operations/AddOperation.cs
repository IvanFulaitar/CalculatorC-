using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для додавання.
/// Завдяки override він підставляє свою формулу в загальний механізм Operation.Execute.
/// </summary>
public sealed class AddOperation : BinaryOperation
{
    public AddOperation()
        : base(OperationKind.Add, "add")
    {
    }

    protected override double Calculate(double left, double right) => left + right;
}
