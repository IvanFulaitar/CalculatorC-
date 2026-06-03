namespace Calculator.Console.Core;

/// <summary>
/// BinaryOperation є базовим класом для операцій з двома числами: +, -, *, /, pow.
/// Він показує inheritance: конкретні операції успадковують спільну поведінку.
/// abstract означає, що цей клас теж не створюється напряму.
/// </summary>
public abstract class BinaryOperation : Operation
{
    protected BinaryOperation(OperationKind kind, string name)
        : base(kind, name, argumentCount: 2)
    {
    }

    // sealed override означає: цей рівень вже остаточно обробляє масив аргументів,
    // а дочірні класи повинні реалізувати простіший Calculate(left, right).
    protected sealed override double Calculate(double[] arguments)
    {
        return Calculate(arguments[0], arguments[1]);
    }

    /// <summary>
    /// Перевантаження імені Calculate робить код спадкоємців читабельнішим:
    /// вони отримують два числа, а не сирий масив аргументів.
    /// </summary>
    protected abstract double Calculate(double left, double right);
}
