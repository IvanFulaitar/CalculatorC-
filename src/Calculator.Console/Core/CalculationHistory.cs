namespace Calculator.Console.Core;

/// <summary>
/// CalculationHistory відповідає тільки за історію.
/// Це окремий клас, щоб Program не зберігав правила додавання, очищення і ліміту записів.
/// Це приклад single responsibility: клас має одну чітку причину для зміни.
/// </summary>
public sealed class CalculationHistory
{
    // List схований у private полі. Зовнішній код не може напряму додати або видалити записи.
    private readonly List<CalculationRecord> _records = [];

    // Constructor перевіряє правило: історія не може мати нульовий або від'ємний розмір.
    public CalculationHistory(int maxSize)
    {
        if (maxSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxSize), "History size must be positive.");
        }

        MaxSize = maxSize;
    }

    // Public property дає читати налаштування, але не дозволяє змінювати його після створення.
    public int MaxSize { get; }

    // Count - обчислювана property, яка повертає поточну кількість записів.
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
        // ToArray створює копію. Так зовнішній код не отримує доступ до справжнього _records.
        return _records.ToArray();
    }

    // Private Add містить спільну логіку ліміту історії.
    // AddSuccess і AddError використовують його, щоб не дублювати код.
    private void Add(CalculationRecord record)
    {
        if (_records.Count == MaxSize)
        {
            _records.RemoveAt(0);
        }

        _records.Add(record);
    }
}
