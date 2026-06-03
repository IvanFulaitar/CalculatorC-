namespace Calculator.Console.Core;

/// <summary>
/// Статус показує, чим завершилась спроба обчислення.
/// Це корисніше за bool, бо з часом можна додати нові статуси без зміни сенсу старого коду.
/// </summary>
public enum CalculationStatus
{
    Success,
    Error
}
