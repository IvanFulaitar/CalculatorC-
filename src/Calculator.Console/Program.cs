using System.Globalization;
using Calculator.Console.Core;

// const - це незмінне значення, яке відоме ще під час компіляції.
// Такі обмеження зручно тримати зверху, щоб не шукати "магічні числа" по всій програмі.
const int MaxInputLength = 200;
const int MaxHistorySize = 10;

// Об'єкти створюються один раз і потім використовуються в циклі.
// Так Program відповідає за консоль, Parser за розбір тексту, History за історію.
ExpressionParser parser = new();
CalculationHistory history = new(MaxHistorySize);

// Обробка Ctrl+C: без цього консоль може завершитись різко, не показавши нормальне повідомлення.
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    Console.WriteLine();
    Console.WriteLine("Goodbye!");
    Environment.Exit(0);
};

Console.WriteLine("=== Calculator ===");
Console.WriteLine("Commands: history, history clear, exit");
Console.WriteLine("Examples: 2 + 3 * 4, sqrt(9), abs(-5), pow(2, 8), percent(50, 20)");
Console.WriteLine();

while (true)
{
    Console.Write("Enter expression: ");

    // string? означає nullable string: Console.ReadLine() може повернути null,
    // наприклад якщо потік вводу закрився. Тому нижче є окрема перевірка input is null.
    string? input = Console.ReadLine();

    if (input is null)
    {
        Console.WriteLine();
        Console.WriteLine("Goodbye!");
        break;
    }

    input = input.Trim();

    if (input.Length > MaxInputLength)
    {
        Console.WriteLine($"Error: Input exceeds the maximum length of {MaxInputLength} characters.");
        Console.WriteLine();
        continue;
    }

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
        input.Equals("quit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    if (input.Equals("history clear", StringComparison.OrdinalIgnoreCase))
    {
        history.Clear();
        Console.WriteLine("History cleared.");
        Console.WriteLine();
        continue;
    }

    if (input.Equals("history", StringComparison.OrdinalIgnoreCase))
    {
        if (history.Count == 0)
        {
            Console.WriteLine("History is empty.");
        }
        else
        {
            IReadOnlyList<CalculationRecord> records = history.GetAll();

            // for зручний тут, бо нам потрібен номер рядка в історії.
            for (int index = 0; index < records.Count; index++)
            {
                Console.WriteLine($"  {index + 1}. {records[index]}");
            }
        }

        Console.WriteLine();
        continue;
    }

    // try/catch дозволяє показати користувачу нормальну помилку,
    // а не завершити програму неконтрольованим exception.
    try
    {
        double result = parser.Parse(input);
        string formattedResult = result.ToString("G", CultureInfo.InvariantCulture);

        history.AddSuccess(input, result);
        Console.WriteLine($"Result: {formattedResult}");
    }
    catch (Exception exception) when (
        exception is FormatException or
        DivideByZeroException or
        ArgumentException)
    {
        // exception.Message - текст помилки. Ми зберігаємо його в історію,
        // щоб користувач бачив не тільки успішні обчислення, а й невдалі спроби.
        history.AddError(input, exception.Message);
        Console.WriteLine($"Error: {exception.Message}");
    }

    Console.WriteLine();
}
