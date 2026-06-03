namespace Calculator.Console.Core;

/// <summary>
/// Interface описує контракт: будь-яка математична операція повинна мати назву,
/// тип, кількість аргументів і метод Execute.
/// Клас, який реалізує IOperation, зобов'язаний мати всі ці members.
/// </summary>
public interface IOperation
{
    OperationKind Kind { get; }

    string Name { get; }

    int ArgumentCount { get; }

    double Execute(params double[] arguments);
}
