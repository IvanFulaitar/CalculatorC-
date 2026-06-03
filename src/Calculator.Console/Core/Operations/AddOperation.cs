using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для додавання.
/// Завдяки override він підставляє свою формулу в загальний механізм Operation.Execute.
/// public sealed class означає: клас доступний зовні, але від нього не можна наслідуватися.
/// </summary>
public sealed class AddOperation : BinaryOperation
{
    public AddOperation()
        : base(OperationKind.Add, "add")
    {
    }

    // override реалізує abstract метод з BinaryOperation.
    protected override double Calculate(double left, double right) => left + right;
}
