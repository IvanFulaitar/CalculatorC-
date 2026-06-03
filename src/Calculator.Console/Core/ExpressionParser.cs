using System.Globalization;

namespace Calculator.Console.Core;

public sealed class ExpressionParser
{
    // Parser залежить не від BasicCalculator напряму, а від ICalculator.
    // Це дозволяє підставити іншу реалізацію калькулятора, якщо буде потрібно.
    private readonly ICalculator _calculator;

    // Ці поля зберігають стан поточного розбору виразу.
    private string _expression = string.Empty;
    private int _position;

    public ExpressionParser()
        : this(new BasicCalculator())
    {
    }

    // Constructor з ICalculator показує роботу з interface як із залежністю.
    public ExpressionParser(ICalculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    // Parse - головний public метод парсера.
    // Він приймає текст, розбирає його і повертає готовий результат.
    public double Parse(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            throw new FormatException("Expression cannot be empty.");
        }

        _expression = expression;
        _position = 0;

        double result = ParseAdditive();
        SkipWhitespace();

        if (!IsAtEnd)
        {
            throw new FormatException($"Unexpected token at position {_position + 1}.");
        }

        return result;
    }

    private double ParseAdditive()
    {
        double value = ParseMultiplicative();

        // while використовується, бо кількість + і - у виразі наперед невідома.
        while (true)
        {
            SkipWhitespace();

            if (Match('+'))
            {
                value = _calculator.Add(value, ParseMultiplicative());
                continue;
            }

            if (Match('-'))
            {
                value = _calculator.Subtract(value, ParseMultiplicative());
                continue;
            }

            return value;
        }
    }

    private double ParseMultiplicative()
    {
        double value = ParseUnary();

        while (true)
        {
            SkipWhitespace();

            if (Match('*'))
            {
                value = _calculator.Multiply(value, ParseUnary());
                continue;
            }

            if (Match('/'))
            {
                value = _calculator.Divide(value, ParseUnary());
                continue;
            }

            return value;
        }
    }

    private double ParseUnary()
    {
        SkipWhitespace();

        if (Match('-'))
        {
            return _calculator.Subtract(0d, ParseUnary());
        }

        return ParsePower();
    }

    private double ParsePower()
    {
        double value = ParseAtom();

        SkipWhitespace();
        if (Match('^'))
        {
            double exponent = ParseUnary();
            return _calculator.Power(value, exponent);
        }

        return value;
    }

    private double ParseAtom()
    {
        SkipWhitespace();

        if (Match('('))
        {
            double value = ParseAdditive();
            Expect(')');
            return value;
        }

        if (char.IsLetter(Current))
        {
            return ParseFunctionCall();
        }

        return ParseNumber();
    }

    private double ParseFunctionCall()
    {
        string identifier = ParseIdentifier();
        SkipWhitespace();

        if (!Match('('))
        {
            throw new FormatException($"Unknown identifier '{identifier}'.");
        }

        List<double> arguments = [];
        SkipWhitespace();

        if (!Match(')'))
        {
            while (true)
            {
                arguments.Add(ParseAdditive());
                SkipWhitespace();

                if (Match(')'))
                {
                    break;
                }

                Expect(',');
            }
        }

        return identifier.ToLowerInvariant() switch
        {
            "sqrt" when arguments.Count == 1 => _calculator.SquareRoot(arguments[0]),
            "abs" when arguments.Count == 1 => _calculator.Abs(arguments[0]),
            "pow" when arguments.Count == 2 => _calculator.Power(arguments[0], arguments[1]),
            "sqrt" or "abs" or "pow" => throw new FormatException($"Invalid argument count for function '{identifier}'."),
            _ => throw new FormatException($"Unknown function '{identifier}'.")
        };
    }

    private string ParseIdentifier()
    {
        int start = _position;

        // Identifier - це назва функції, наприклад sqrt, abs або pow.
        while (!IsAtEnd && char.IsLetter(Current))
        {
            _position++;
        }

        return _expression[start.._position];
    }

    private double ParseNumber()
    {
        SkipWhitespace();
        int start = _position;
        bool hasDecimalPoint = false;

        while (!IsAtEnd)
        {
            if (char.IsDigit(Current))
            {
                _position++;
                continue;
            }

            if (Current == '.' && !hasDecimalPoint)
            {
                hasDecimalPoint = true;
                _position++;
                continue;
            }

            break;
        }

        if (start == _position)
        {
            throw new FormatException($"Expected number at position {_position + 1}.");
        }

        string token = _expression[start.._position];
        if (!double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new FormatException($"Invalid number '{token}'.");
        }

        return value;
    }

    private void Expect(char expected)
    {
        SkipWhitespace();

        if (!Match(expected))
        {
            throw new FormatException($"Expected '{expected}' at position {_position + 1}.");
        }
    }

    private bool Match(char expected)
    {
        if (Current != expected)
        {
            return false;
        }

        _position++;
        return true;
    }

    private void SkipWhitespace()
    {
        while (!IsAtEnd && char.IsWhiteSpace(Current))
        {
            _position++;
        }
    }

    private bool IsAtEnd => _position >= _expression.Length;

    // Current - property, яка безпечно повертає поточний символ або '\0' в кінці рядка.
    private char Current => IsAtEnd ? '\0' : _expression[_position];
}
