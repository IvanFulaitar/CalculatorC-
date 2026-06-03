# OOP Learning Map

Цей проєкт не просто рахує вирази. Він зроблений як навчальна база для C# і ООП: кожен клас має окрему відповідальність, а важливі місця пояснені коментарями в коді.

## Що запускати

- `dotnet run --project src/Calculator.Console/Calculator.Console.csproj`
- `dotnet test`

## Що вивчати по файлах

- `src/Calculator.Console/Program.cs` - консольний цикл, `while`, `if/else`, `string?`, `try/catch`, робота з історією.
- `src/Calculator.Console/Core/ICalculator.cs` - interface як контракт для калькулятора.
- `src/Calculator.Console/Core/BasicCalculator.cs` - facade: старий простий API, який всередині використовує OOP-движок.
- `src/Calculator.Console/Core/IOperation.cs` - interface для всіх математичних операцій.
- `src/Calculator.Console/Core/Operation.cs` - abstract class, constructor, `this`, encapsulation, `protected`, спільна перевірка аргументів.
- `src/Calculator.Console/Core/BinaryOperation.cs` - inheritance для операцій з двома аргументами і overload імені `Calculate`.
- `src/Calculator.Console/Core/UnaryOperation.cs` - inheritance для операцій з одним аргументом.
- `src/Calculator.Console/Core/Operations/*.cs` - polymorphism через `override`: кожна операція має свою формулу.
- `src/Calculator.Console/Core/OperationKind.cs` - `enum` для типів операцій.
- `src/Calculator.Console/Core/CalculationStatus.cs` - `enum` для статусів історії.
- `src/Calculator.Console/Core/OperationRegistry.cs` - `Dictionary`, `IEnumerable`, `IReadOnlyCollection`, пошук операцій за назвою або enum.
- `src/Calculator.Console/Core/CalculatorEngine.cs` - композиція об'єктів: engine використовує registry, але не знає формул.
- `src/Calculator.Console/Core/CalculationRecord.cs` - nullable: `double? Result` і `string? ErrorMessage`.
- `src/Calculator.Console/Core/CalculationHistory.cs` - encapsulation списку через private `List` і public методи.
- `src/Calculator.Console/Core/ExpressionParser.cs` - рекурсивний парсер, методи, оператори, колекції, перевірки помилок.
- `tests/Calculator.Tests/*.cs` - xUnit-тести, які перевіряють нормальні та помилкові випадки.

## Як тренуватися далі

1. Додай нову операцію `PercentOperation`.
2. Додай її в `OperationKind` і `OperationRegistry.CreateDefault()`.
3. Додай метод у `ICalculator` і `BasicCalculator`, якщо хочеш старий API.
4. Додай підтримку в `ExpressionParser`, наприклад `percent(50, 20)`.
5. Напиши тести на успішний випадок і неправильну кількість аргументів.
