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

## План читання файлів

Йди в такому порядку, щоб спочатку зрозуміти запуск програми, потім базові OOP-концепції, потім складніший парсер і тести.

1. `OOP_LEARNING_MAP.md` - загальна мапа: що де лежить, які терміни є, що закріплювати.
2. `src/Calculator.Console/Program.cs` - старт програми: `while`, `if`, `string?`, `try/catch`, робота з консоллю.
3. `src/Calculator.Console/Core/ICalculator.cs` - перший `interface`: які методи має калькулятор.
4. `src/Calculator.Console/Core/BasicCalculator.cs` - клас реалізує `ICalculator` і передає роботу в `CalculatorEngine`.
5. `src/Calculator.Console/Core/CalculatorEngine.cs` - центральний клас: приймає запит на обчислення і знаходить потрібну операцію.
6. `src/Calculator.Console/Core/OperationKind.cs` - `enum` зі списком доступних типів операцій.
7. `src/Calculator.Console/Core/IOperation.cs` - другий `interface`: контракт для кожної математичної операції.
8. `src/Calculator.Console/Core/Operation.cs` - головний OOP-файл: `abstract class`, `constructor`, `property`, `Execute`, `protected abstract`.
9. `src/Calculator.Console/Core/BinaryOperation.cs` - база для операцій з двома числами: `+`, `-`, `*`, `/`, `pow`.
10. `src/Calculator.Console/Core/UnaryOperation.cs` - база для операцій з одним числом: `sqrt`, `abs`.
11. `src/Calculator.Console/Core/Operations/AddOperation.cs` - найпростіша конкретна операція.
12. `src/Calculator.Console/Core/Operations/DivideOperation.cs` - операція з додатковою перевіркою і `DivideByZeroException`.
13. `src/Calculator.Console/Core/Operations/*.cs` - інші операції: `Subtract`, `Multiply`, `Power`, `SquareRoot`, `Absolute`, `Percent`.
14. `src/Calculator.Console/Core/OperationRegistry.cs` - реєстрація і пошук операцій через `Dictionary`.
15. `src/Calculator.Console/Core/ExpressionParser.cs` - складніший файл: розбирає текст `2 + sqrt(9)` у математичний результат.
16. `src/Calculator.Console/Core/CalculationStatus.cs` - маленький `enum` для статусу історії.
17. `src/Calculator.Console/Core/CalculationRecord.cs` - запис історії: `nullable`, `ToString()`, дата, статус.
18. `src/Calculator.Console/Core/CalculationHistory.cs` - інкапсуляція списку історії: `private List`, `AddSuccess`, `AddError`, `GetAll`.
19. `tests/Calculator.Tests/CalculatorEngineTests.cs` - тести центральної логіки.
20. `tests/Calculator.Tests/CalculationHistoryTests.cs` - тести історії.
21. `tests/Calculator.Tests/BasicCalculatorTests.cs` - перевірка арифметичних методів.
22. `tests/Calculator.Tests/ExpressionParserTests.cs` - найскладніші тести: парсер, пріоритет операцій, функції, помилки.

## Як тренуватися далі

1. Додай нову операцію `ModuloOperation`.
2. Додай її в `OperationKind` і `OperationRegistry.CreateDefault()`.
3. Додай метод у `ICalculator` і `BasicCalculator`, якщо хочеш старий API.
4. Додай підтримку в `ExpressionParser`, наприклад `mod(10, 3)`.
5. Напиши тести на успішний випадок і неправильну кількість аргументів.

## Розписані моменти

Цей розділ можна використовувати як шпаргалку для повторення. Спочатку прочитай термін, потім знайди його приклад у коді проєкту.

### ООП терміни

| Термін | Що означає | Приклад у проєкті |
| --- | --- | --- |
| `class` | Шаблон для створення об'єктів. | `CalculatorEngine`, `CalculationHistory` |
| `object` | Конкретний екземпляр класу, створений через `new`. | `new CalculatorEngine()` |
| `interface` | Контракт: описує, що клас повинен мати, але не описує реалізацію. | `IOperation`, `ICalculator` |
| `abstract class` | Базовий клас, з якого не створюють об'єкти напряму. | `Operation` |
| `inheritance` | Наслідування: один клас бере спільну поведінку іншого. | `AddOperation : BinaryOperation` |
| `polymorphism` | Один виклик працює по-різному залежно від конкретного класу. | `Execute()` викликає різні `Calculate()` |
| `encapsulation` | Внутрішні дані сховані, доступ іде через методи або властивості. | `_records` у `CalculationHistory` |
| `constructor` | Метод, який викликається при створенні об'єкта. | `CalculationHistory(int maxSize)` |
| `property` | Властивість класу для читання або запису даних. | `Name`, `Kind`, `Count` |
| `field` | Внутрішня змінна класу, яка зберігає стан. | `_engine`, `_registry`, `_records` |
| `method` | Дія, яку вміє виконувати клас. | `Calculate()`, `AddSuccess()` |
| `override` | Перевизначення методу з базового класу. | `protected override double Calculate(...)` |
| `sealed` | Забороняє наслідування від класу або подальше перевизначення методу. | `public sealed class CalculatorEngine` |
| `public` | Доступно з інших класів і проєктів, які бачать цей код. | `public sealed class BasicCalculator` |
| `private` | Доступно тільки всередині цього класу. | `private readonly List<CalculationRecord> _records` |
| `protected` | Доступно в цьому класі і його дочірніх класах. | `protected abstract double Calculate(...)` |
| `readonly` | Поле можна присвоїти тільки при оголошенні або в конструкторі. | `private readonly OperationRegistry _registry` |
| `static` | Належить класу, а не конкретному об'єкту. | `OperationRegistry.CreateDefault()` |
| `enum` | Набір фіксованих іменованих значень. | `OperationKind`, `CalculationStatus` |
| `nullable` | Тип, який може мати значення `null`. | `string?`, `double?` |
| `exception` | Помилка, яку можна кинути або обробити. | `ArgumentException`, `DivideByZeroException` |
| `try/catch` | Конструкція для контрольованої обробки помилок. | Обробка помилок у `Program.cs` |
| `params` | Дозволяє передавати змінну кількість аргументів у метод. | `Execute(params double[] arguments)` |

### Ключові методи

| Метод | Де знаходиться | Для чого потрібен |
| --- | --- | --- |
| `Calculate(OperationKind kind, params double[] arguments)` | `CalculatorEngine` | Рахує операцію за enum-типом. |
| `Calculate(string operationName, params double[] arguments)` | `CalculatorEngine` | Рахує операцію за назвою, наприклад `sqrt`. |
| `Execute(params double[] arguments)` | `Operation` | Перевіряє кількість аргументів і запускає конкретну формулу. |
| `Calculate(double[] arguments)` | `Operation` | Базовий abstract/protected метод, який мають реалізувати дочірні класи. |
| `Calculate(double left, double right)` | `BinaryOperation` | Метод для операцій з двома числами. |
| `Calculate(double value)` | `UnaryOperation` | Метод для операцій з одним числом. |
| `GetRequired(OperationKind kind)` | `OperationRegistry` | Дістає операцію з реєстру або кидає помилку. |
| `TryGetByName(string? name, out IOperation? operation)` | `OperationRegistry` | Пробує знайти операцію за назвою. |
| `CreateDefault()` | `OperationRegistry` | Створює стандартний набір операцій. |
| `GetAll()` | `OperationRegistry`, `CalculationHistory` | Повертає всі операції або всі записи історії. |
| `AddSuccess(string expression, double result)` | `CalculationHistory` | Додає успішний запис в історію. |
| `AddError(string expression, string errorMessage)` | `CalculationHistory` | Додає помилковий запис в історію. |
| `Clear()` | `CalculationHistory` | Очищає історію. |
| `ToString()` | `CalculationRecord` | Перетворює запис історії у текст для виводу. |
| `Parse(string expression)` | `ExpressionParser` | Розбирає текстовий математичний вираз. |
| `Add(double a, double b)` | `BasicCalculator` | Додавання. |
| `Subtract(double a, double b)` | `BasicCalculator` | Віднімання. |
| `Multiply(double a, double b)` | `BasicCalculator` | Множення. |
| `Divide(double a, double b)` | `BasicCalculator` | Ділення. |
| `SquareRoot(double a)` | `BasicCalculator` | Квадратний корінь. |
| `Power(double base, double exponent)` | `BasicCalculator` | Піднесення до степеня. |
| `Abs(double a)` | `BasicCalculator` | Модуль числа. |

### Що закріпити першим

1. `class`, `object`, `constructor`
2. `public`, `private`, `protected`
3. `interface`
4. `abstract class`
5. `inheritance`
6. `override`
7. `polymorphism`
8. `encapsulation`
9. `enum`
10. `nullable` і `try/catch`

### Міні-практика

- Знайди в коді всі класи з `sealed` і поясни, чому від них не треба наслідуватися.
- Відкрий `Operation.cs` і поясни, чому він `abstract`.
- Відкрий `AddOperation.cs` і `DivideOperation.cs` та порівняй їхні `Calculate`.
- Додай нову операцію `PercentOperation` і підключи її в `OperationRegistry`.
- Напиши тест на нову операцію в `CalculatorEngineTests`.
