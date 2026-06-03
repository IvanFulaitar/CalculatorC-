namespace Calculator.Console.Core;

/// <summary>
/// UnaryOperation є базовим класом для операцій з одним числом: sqrt, abs.
/// Так ми не дублюємо перевірку кількості аргументів у кожному класі.
/// </summary>
public abstract class UnaryOperation : Operation
{
    protected UnaryOperation(OperationKind kind, string name)
        : base(kind, name, argumentCount: 1)
    {
    }

    protected sealed override double Calculate(double[] arguments)
    {
        return Calculate(arguments[0]);
    }

    protected abstract double Calculate(double value);
}
