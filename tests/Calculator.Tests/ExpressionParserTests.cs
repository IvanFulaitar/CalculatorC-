using Calculator.Console.Core;

namespace Calculator.Tests;

public class ExpressionParserTests
{
    private readonly ExpressionParser _parser = new();

    [Theory]
    [InlineData("2 + 3", 5d)]
    [InlineData("10 - 4", 6d)]
    [InlineData("3 * 7", 21d)]
    [InlineData("15 / 3", 5d)]
    public void Parse_SimpleExpressions_ReturnsExpectedResult(string expression, double expected)
    {
        double result = _parser.Parse(expression);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData("sqrt(9)", 3d)]
    [InlineData("abs(-5)", 5d)]
    [InlineData("pow(2,8)", 256d)]
    [InlineData("percent(50,20)", 10d)]
    public void Parse_FunctionExpressions_ReturnsExpectedResult(string expression, double expected)
    {
        double result = _parser.Parse(expression);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData("2 + 3 * 4", 14d)]
    [InlineData("2 ^ 3 * 2", 16d)]
    public void Parse_OperatorPrecedence_ReturnsExpectedResult(string expression, double expected)
    {
        double result = _parser.Parse(expression);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData("(2 + 3) * 4", 20d)]
    [InlineData("pow(2, (1 + 2))", 8d)]
    public void Parse_Parentheses_ReturnsExpectedResult(string expression, double expected)
    {
        double result = _parser.Parse(expression);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("2 + + 3")]
    [InlineData("sqrt()")]
    [InlineData("pow(2)")]
    [InlineData("percent(50)")]
    [InlineData("(2 + 3")]
    public void Parse_InvalidExpressions_ThrowFormatException(string expression)
    {
        Assert.Throws<FormatException>(() => _parser.Parse(expression));
    }
}
