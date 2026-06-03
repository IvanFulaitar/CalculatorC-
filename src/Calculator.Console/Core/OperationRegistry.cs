using Calculator.Console.Core.Operations;

namespace Calculator.Console.Core;

/// <summary>
/// Registry зберігає всі доступні операції в одному місці.
/// Це приклад encapsulation: зовнішній код не працює напряму зі словником і не може зламати його стан.
/// Якщо потрібна операція, її треба просити через методи registry.
/// </summary>
public sealed class OperationRegistry
{
    // Dictionary швидко знаходить операцію за enum-ключем.
    private readonly Dictionary<OperationKind, IOperation> _operationsByKind = [];

    // StringComparer.OrdinalIgnoreCase дозволяє писати "sqrt", "SQRT" або "Sqrt".
    private readonly Dictionary<string, IOperation> _operationsByName = new(StringComparer.OrdinalIgnoreCase);

    // IEnumerable означає "будь-яка колекція, по якій можна пройти foreach".
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
            new AbsoluteOperation(),
            new PercentOperation()
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
        // IReadOnlyCollection не дає зовнішньому коду змінити внутрішній Dictionary.
        return _operationsByKind.Values.ToArray();
    }

    // private метод використовується тільки всередині registry.
    // Він централізує правило додавання операції у два словники.
    private void Register(IOperation operation)
    {
        _operationsByKind[operation.Kind] = operation;
        _operationsByName[operation.Name] = operation;
    }
}
