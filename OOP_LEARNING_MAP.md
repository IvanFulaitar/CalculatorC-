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

## Розписані моменти
ООП Терміни

class - шаблон для створення об’єктів. Наприклад, CalculatorEngine, CalculationHistory.
object - конкретний екземпляр класу. Наприклад, new CalculatorEngine().
interface - контракт: описує, що клас повинен мати, але не каже як саме це працює. Наприклад, IOperation, ICalculator.
abstract class - базовий клас, з якого не створюють об’єкти напряму. Наприклад, Operation.
inheritance - наслідування: один клас бере поведінку іншого. Наприклад, AddOperation : BinaryOperation.
polymorphism - поліморфізм: один виклик працює по-різному залежно від конкретного класу. Наприклад, Execute() викликає різні Calculate().
encapsulation - інкапсуляція: внутрішні дані сховані, доступ через методи. Наприклад, _records у CalculationHistory.
constructor - спеціальний метод, який викликається при створенні об’єкта. Наприклад, CalculationHistory(int maxSize).
property - властивість класу для читання/запису даних. Наприклад, Name, Kind, Count.
field - внутрішня змінна класу. Наприклад, _engine, _registry, _records.
method - дія, яку вміє виконувати клас. Наприклад, Calculate(), AddSuccess().
override - перевизначення методу з базового класу.
sealed - забороняє наслідування від класу або подальше перевизначення методу.
public - доступно з інших класів.
private - доступно тільки всередині цього класу.
protected - доступно в цьому класі і його дочірніх класах.
readonly - поле можна присвоїти тільки в constructor або при оголошенні.
static - належить класу, а не конкретному об’єкту. Наприклад, OperationRegistry.CreateDefault().
enum - набір фіксованих значень. Наприклад, OperationKind, CalculationStatus.
nullable - тип, який може бути null. Наприклад, string?, double?.
exception - помилка, яку можна кинути або обробити. Наприклад, ArgumentException.
try/catch - конструкція для обробки помилок.
params - дозволяє передавати змінну кількість аргументів у метод.
Ключові Методи

Calculate(OperationKind kind, params double[] arguments) - рахує операцію за enum-типом.
Calculate(string operationName, params double[] arguments) - рахує операцію за назвою, наприклад "sqrt".
Execute(params double[] arguments) - загальний метод операції: перевіряє кількість аргументів і запускає формулу.
Calculate(double[] arguments) - abstract/protected метод у базовому класі, який реалізують дочірні класи.
Calculate(double left, double right) - метод для операцій з двома числами.
Calculate(double value) - метод для операцій з одним числом.
GetRequired(OperationKind kind) - дістає операцію з реєстру або кидає помилку.
TryGetByName(string? name, out IOperation? operation) - пробує знайти операцію за назвою.
CreateDefault() - створює стандартний набір операцій.
GetAll() - повертає всі записи або всі операції.
AddSuccess(string expression, double result) - додає успішний запис в історію.
AddError(string expression, string errorMessage) - додає помилковий запис в історію.
Clear() - очищає історію.
ToString() - перетворює об’єкт у текст.
Parse(string expression) - розбирає текстовий математичний вираз.
Add(double a, double b) - додавання.
Subtract(double a, double b) - віднімання.
Multiply(double a, double b) - множення.
Divide(double a, double b) - ділення.
SquareRoot(double a) - квадратний корінь.
Power(double base, double exponent) - піднесення до степеня.
Abs(double a) - модуль числа.
Що Закріпити Першим

class, object, constructor
public, private, protected
interface
abstract class
inheritance
override
polymorphism
encapsulation
enum
nullable і try/catch
