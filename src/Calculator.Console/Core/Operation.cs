namespace Calculator.Console.Core;

/// <summary>
/// Abstract class містить спільну логіку для всіх операцій.
/// Об'єкти напряму з нього не створюються, бо сама "операція" без формули нічого не рахує.
/// Це база для inheritance: AddOperation, DivideOperation та інші отримують від нього Execute.
/// </summary>
public abstract class Operation : IOperation
{
    /// <summary>
    /// Constructor одразу задає незмінні властивості операції.
    /// this використовується, щоб явно показати: ми заповнюємо властивість поточного об'єкта.
    /// </summary>
    protected Operation(OperationKind kind, string name, int argumentCount)
    {
        this.Kind = kind;
        this.Name = name;
        this.ArgumentCount = argumentCount;
    }

    // Property з get без set можна прочитати зовні, але не можна змінити після constructor.
    public OperationKind Kind { get; }

    // Name потрібен для пошуку операції за текстовою назвою, наприклад "sqrt".
    public string Name { get; }

    // ArgumentCount описує, скільки чисел очікує операція.
    public int ArgumentCount { get; }

    /// <summary>
    /// public метод доступний іншим класам, але він не знає формулу конкретної операції.
    /// Він перевіряє спільні правила, а потім через polymorphism викликає реалізацію спадкоємця.
    /// </summary>
    public double Execute(params double[] arguments)
    {
        if (arguments.Length != ArgumentCount)
        {
            throw new ArgumentException($"Operation '{Name}' expects {ArgumentCount} argument(s).");
        }

        return Calculate(arguments);
    }

    /// <summary>
    /// protected abstract означає: метод доступний тільки всередині цього класу і його спадкоємців,
    /// а кожен дочірній клас зобов'язаний написати власну формулу.
    /// </summary>
    protected abstract double Calculate(double[] arguments);
}
