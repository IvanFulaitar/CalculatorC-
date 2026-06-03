namespace Calculator.Console.Core;

/// <summary>
/// CalculatorEngine координує операції.
/// Він не знає формул +, -, sqrt тощо; він лише знаходить потрібний об'єкт і викликає його.
/// Це приклад composition: engine складається з OperationRegistry і використовує його.
/// </summary>
public sealed class CalculatorEngine
{
    // Engine не зберігає всі операції сам. Він делегує це registry.
    private readonly OperationRegistry _registry;

    // Constructor без параметрів створює engine зі стандартним набором операцій.
    public CalculatorEngine()
        : this(OperationRegistry.CreateDefault())
    {
    }

    // Constructor з параметром дозволяє передати інший registry.
    // ?? throw захищає клас від null-залежності.
    public CalculatorEngine(OperationRegistry registry)
    {
        _registry = registry ?? throw new ArgumentNullException(nameof(registry));
    }

    // params дозволяє викликати метод так: Calculate(OperationKind.Add, 2, 3),
    // хоча всередині arguments буде звичайним double[].
    public double Calculate(OperationKind kind, params double[] arguments)
    {
        IOperation operation = _registry.GetRequired(kind);
        return operation.Execute(arguments);
    }

    // Це overload методу Calculate: назва та сама, але параметри інші.
    // Тут операція шукається за текстовою назвою, наприклад "sqrt".
    public double Calculate(string operationName, params double[] arguments)
    {
        if (!_registry.TryGetByName(operationName, out IOperation? operation) || operation is null)
        {
            throw new ArgumentException($"Unknown operation '{operationName}'.");
        }

        return operation.Execute(arguments);
    }
}
