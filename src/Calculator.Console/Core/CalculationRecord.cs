using System.Globalization;

namespace Calculator.Console.Core;

/// <summary>
/// CalculationRecord описує один запис історії.
/// Тут використані nullable-властивості: Result є null при помилці, ErrorMessage є null при успіху.
/// </summary>
public sealed class CalculationRecord
{
    public CalculationRecord(string expression, double? result, string? errorMessage)
    {
        this.Expression = string.IsNullOrWhiteSpace(expression) ? "<empty>" : expression.Trim();
        this.Result = result;
        this.ErrorMessage = string.IsNullOrWhiteSpace(errorMessage) ? null : errorMessage;
        this.CreatedAt = DateTime.Now;
        this.Status = errorMessage is null ? CalculationStatus.Success : CalculationStatus.Error;
    }

    public string Expression { get; }

    public double? Result { get; }

    public string? ErrorMessage { get; }

    public DateTime CreatedAt { get; }

    public CalculationStatus Status { get; }

    public override string ToString()
    {
        string time = CreatedAt.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

        return Status switch
        {
            CalculationStatus.Success => $"[{time}] {Expression} = {Result?.ToString("G", CultureInfo.InvariantCulture)}",
            CalculationStatus.Error => $"[{time}] {Expression} -> Error: {ErrorMessage}",
            _ => $"[{time}] {Expression}"
        };
    }
}
