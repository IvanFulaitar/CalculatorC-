using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для множення.
/// Це окремий об'єкт, тому його легко тестувати або замінити без зміни інших операцій.
/// Кожна операція має свою маленьку відповідальність.
/// </summary>
public sealed class MultiplyOperation : BinaryOperation
{
    public MultiplyOperation()
        : base(OperationKind.Multiply, "multiply")
    {
    }

    // Polymorphism: MultiplyOperation рахує множення, хоча engine викликає той самий Execute.
    protected override double Calculate(double left, double right) => left * right;
}
