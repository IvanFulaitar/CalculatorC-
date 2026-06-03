namespace Calculator.Console.Core;

/// <summary>
/// CalculationHistory відповідає тільки за історію.
/// Це окремий клас, щоб Program не зберігав правила додавання, очищення і ліміту записів.
/// </summary>
public sealed class CalculationHistory
{
    private readonly List<CalculationRecord> _records = [];

    public CalculationHistory(int maxSize)
    {
        if (maxSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxSize), "History size must be positive.");
        }

        MaxSize = maxSize;
    }

    public int MaxSize { get; }

    public int Count => _records.Count;

    public void AddSuccess(string expression, double result)
    {
        Add(new CalculationRecord(expression, result, errorMessage: null));
    }

    public void AddError(string expression, string errorMessage)
    {
        Add(new CalculationRecord(expression, result: null, errorMessage));
    }

    public void Clear()
    {
        _records.Clear();
    }

    public IReadOnlyList<CalculationRecord> GetAll()
    {
        return _records.ToArray();
    }

    private void Add(CalculationRecord record)
    {
        if (_records.Count == MaxSize)
        {
            _records.RemoveAt(0);
        }

        _records.Add(record);
    }
}
