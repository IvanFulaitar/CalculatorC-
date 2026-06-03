namespace Calculator.Console.Core;

/// <summary>
/// Статус показує, чим завершилась спроба обчислення.
/// Це корисніше за bool, бо з часом можна додати нові статуси без зміни сенсу старого коду.
/// Наприклад, пізніше можна додати Cancelled або Warning.
/// </summary>
public enum CalculationStatus
{
    Success,
    Error
}
