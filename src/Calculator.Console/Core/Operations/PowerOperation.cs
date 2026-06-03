using Calculator.Console.Core;

namespace Calculator.Console.Core.Operations;

/// <summary>
/// Конкретний клас для піднесення до степеня.
/// Він показує, що в систему можна додати нову операцію без переписування Engine.
/// </summary>
public sealed class PowerOperation : BinaryOperation
{
    public PowerOperation()
        : base(OperationKind.Power, "power")
    {
    }

    protected override double Calculate(double left, double right) => Math.Pow(left, right);
}
