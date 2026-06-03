# Calculator OOP Learning Project

Це консольний калькулятор на C#/.NET 9, зроблений не тільки для обчислень, а як навчальний проєкт для вивчення ООП.

Якщо ти вчиш C# і хочеш зрозуміти `class`, `object`, `interface`, `abstract class`, `inheritance`, `polymorphism`, `encapsulation`, `enum`, `nullable`, `try/catch` і тести, цей проєкт можна читати як практичний конспект.

## Що вміє калькулятор

- Рахує базові вирази: `2 + 3`, `10 - 4`, `3 * 7`, `15 / 3`.
- Підтримує пріоритет операцій: `2 + 3 * 4`.
- Підтримує дужки: `(2 + 3) * 4`.
- Підтримує функції: `sqrt(9)`, `abs(-5)`, `pow(2, 8)`, `percent(50, 20)`.
- Зберігає історію успішних і помилкових обчислень.
- Має xUnit-тести для калькулятора, parser, engine і history.

## Як запустити

Потрібен встановлений .NET 9 SDK.

```powershell
dotnet build
dotnet test
dotnet run --project src/Calculator.Console/Calculator.Console.csproj
```

Після запуску можна вводити приклади:

```text
2 + 3 * 4
sqrt(9)
abs(-5)
pow(2, 8)
percent(50, 20)
history
history clear
exit
```

## Структура проєкту

```text
src/
  Calculator.Console/
    Program.cs
    Core/
      ICalculator.cs
      BasicCalculator.cs
      CalculatorEngine.cs
      IOperation.cs
      Operation.cs
      BinaryOperation.cs
      UnaryOperation.cs
      OperationRegistry.cs
      ExpressionParser.cs
      CalculationHistory.cs
      CalculationRecord.cs
      OperationKind.cs
      CalculationStatus.cs
      Operations/
        AddOperation.cs
        SubtractOperation.cs
        MultiplyOperation.cs
        DivideOperation.cs
        PowerOperation.cs
        SquareRootOperation.cs
        AbsoluteOperation.cs
        PercentOperation.cs

tests/
  Calculator.Tests/
    BasicCalculatorTests.cs
    CalculatorEngineTests.cs
    ExpressionParserTests.cs
    CalculationHistoryTests.cs
```

## Що тут вивчати

| Тема | Де дивитись |
| --- | --- |
| Старт програми, цикл, консоль | `Program.cs` |
| `interface` | `ICalculator.cs`, `IOperation.cs` |
| `class` і `object` | `BasicCalculator.cs`, `CalculatorEngine.cs` |
| `abstract class` | `Operation.cs` |
| Наслідування | `BinaryOperation.cs`, `UnaryOperation.cs`, `Operations/*.cs` |
| Поліморфізм | `Operation.Execute()` і `Calculate()` у конкретних операціях |
| Інкапсуляція | `CalculationHistory.cs`, `OperationRegistry.cs` |
| `enum` | `OperationKind.cs`, `CalculationStatus.cs` |
| `nullable` | `CalculationRecord.cs`, `Program.cs` |
| `try/catch` і помилки | `Program.cs`, `DivideOperation.cs`, `SquareRootOperation.cs` |
| Тести | `tests/Calculator.Tests/*.cs` |

## Рекомендований порядок читання

1. `OOP_LEARNING_MAP.md`
2. `Program.cs`
3. `ICalculator.cs`
4. `BasicCalculator.cs`
5. `CalculatorEngine.cs`
6. `OperationKind.cs`
7. `IOperation.cs`
8. `Operation.cs`
9. `BinaryOperation.cs`
10. `UnaryOperation.cs`
11. `Operations/AddOperation.cs`
12. `Operations/DivideOperation.cs`
13. Інші файли в `Operations/`
14. `OperationRegistry.cs`
15. `ExpressionParser.cs`
16. `CalculationStatus.cs`
17. `CalculationRecord.cs`
18. `CalculationHistory.cs`
19. `CalculatorEngineTests.cs`
20. `CalculationHistoryTests.cs`
21. `BasicCalculatorTests.cs`
22. `ExpressionParserTests.cs`

Детальніший план з поясненнями є в `OOP_LEARNING_MAP.md`.

## Як закріпити знання

Після читання спробуй додати нову операцію `ModuloOperation`.

План:

1. Додай `Modulo` в `OperationKind`.
2. Створи `ModuloOperation.cs` у папці `Core/Operations`.
3. Наслідуйся від `BinaryOperation`.
4. Реалізуй формулу, наприклад `left % right`.
5. Зареєструй операцію в `OperationRegistry.CreateDefault()`.
6. Додай тест у `CalculatorEngineTests`.
7. Додай підтримку `mod(10, 3)` в `ExpressionParser`.
8. Запусти `dotnet test`.

## Навіщо тут багато коментарів

Коментарі в коді спеціально навчальні. Вони пояснюють не тільки що робить рядок, а й чому використано саме такий OOP-прийом.

Цей проєкт можна читати у два проходи:

1. Перший раз - зрозуміти загальну структуру.
2. Другий раз - відкрити кожен файл і зв'язати код з термінами з `OOP_LEARNING_MAP.md`.

## Команди для перевірки

```powershell
dotnet build
dotnet test
```

Очікуваний результат: збірка без помилок і всі тести зелені.
