using Calculator.Console.Core.Operations;

namespace Calculator.Console.Core;

/// <summary>
/// Registry зберігає всі доступні операції в одному місці.
/// Це приклад encapsulation: зовнішній код не працює напряму зі словником і не може зламати його стан.
/// </summary>
public sealed class OperationRegistry
{
    private readonly Dictionary<OperationKind, IOperation> _operationsByKind = [];
    private readonly Dictionary<string, IOperation> _operationsByName = new(StringComparer.OrdinalIgnoreCase);

    public OperationRegistry(IEnumerable<IOperation> operations)
    {
        foreach (IOperation operation in operations)
        {
            Register(operation);
        }
    }

    /// <summary>
    /// Static factory method створює стандартний набір операцій без дублювання цього списку в Program.
    /// </summary>
    public static OperationRegistry CreateDefault()
    {
        IOperation[] operations =
        [
            new AddOperation(),
            new SubtractOperation(),
            new MultiplyOperation(),
            new DivideOperation(),
            new SquareRootOperation(),
            new PowerOperation(),
            new AbsoluteOperation()
        ];

        return new OperationRegistry(operations);
    }

    public IOperation GetRequired(OperationKind kind)
    {
        if (!_operationsByKind.TryGetValue(kind, out IOperation? operation))
        {
            throw new InvalidOperationException($"Operation '{kind}' is not registered.");
        }

        return operation;
    }

    public bool TryGetByName(string? name, out IOperation? operation)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            operation = null;
            return false;
        }

        return _operationsByName.TryGetValue(name, out operation);
    }

    public IReadOnlyCollection<IOperation> GetAll()
    {
        return _operationsByKind.Values.ToArray();
    }

    private void Register(IOperation operation)
    {
        _operationsByKind[operation.Kind] = operation;
        _operationsByName[operation.Name] = operation;
    }
}
