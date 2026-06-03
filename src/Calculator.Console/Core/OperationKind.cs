namespace Calculator.Console.Core;

/// <summary>
/// Enum зберігає фіксований набір типів операцій.
/// Так код не залежить від "магічних рядків" на кшталт "+" або "sqrt" у всіх класах одразу.
/// </summary>
public enum OperationKind
{
    Add,
    Subtract,
    Multiply,
    Divide,
    SquareRoot,
    Power,
    Absolute
}
