namespace Calculator.Console.Core;

/// <summary>
/// UnaryOperation є базовим класом для операцій з одним числом: sqrt, abs.
/// Так ми не дублюємо перевірку кількості аргументів у кожному класі.
/// Це пара до BinaryOperation, але для одного аргументу.
/// </summary>
public abstract class UnaryOperation : Operation
{
    protected UnaryOperation(OperationKind kind, string name)
        : base(kind, name, argumentCount: 1)
    {
    }

    // Тут polymorphism переходить від загального Calculate(double[]) до конкретного Calculate(value).
    protected sealed override double Calculate(double[] arguments)
    {
        return Calculate(arguments[0]);
    }

    protected abstract double Calculate(double value);
}
