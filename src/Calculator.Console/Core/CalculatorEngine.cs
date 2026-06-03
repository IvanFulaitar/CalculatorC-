namespace Calculator.Console.Core;

/// <summary>
/// CalculatorEngine координує операції.
/// Він не знає формул +, -, sqrt тощо; він лише знаходить потрібний об'єкт і викликає його.
/// </summary>
public sealed class CalculatorEngine
{
    private readonly OperationRegistry _registry;

    public CalculatorEngine()
        : this(OperationRegistry.CreateDefault())
    {
    }

    public CalculatorEngine(OperationRegistry registry)
    {
        _registry = registry ?? throw new ArgumentNullException(nameof(registry));
    }

    public double Calculate(OperationKind kind, params double[] arguments)
    {
        IOperation operation = _registry.GetRequired(kind);
        return operation.Execute(arguments);
    }

    public double Calculate(string operationName, params double[] arguments)
    {
        if (!_registry.TryGetByName(operationName, out IOperation? operation) || operation is null)
        {
            throw new ArgumentException($"Unknown operation '{operationName}'.");
        }

        return operation.Execute(arguments);
    }
}
