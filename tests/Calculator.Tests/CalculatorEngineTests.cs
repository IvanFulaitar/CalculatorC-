using Calculator.Console.Core;

namespace Calculator.Tests;

public class CalculatorEngineTests
{
    private readonly CalculatorEngine _engine = new();

    [Theory]
    [InlineData(OperationKind.Add, 2d, 3d, 5d)]
    [InlineData(OperationKind.Subtract, 10d, 4d, 6d)]
    [InlineData(OperationKind.Multiply, 3d, 7d, 21d)]
    [InlineData(OperationKind.Divide, 15d, 3d, 5d)]
    [InlineData(OperationKind.Power, 2d, 8d, 256d)]
    [InlineData(OperationKind.Percent, 50d, 20d, 10d)]
    public void Calculate_BinaryOperationKind_ReturnsExpectedResult(
        OperationKind kind,
        double left,
        double right,
        double expected)
    {
        double result = _engine.Calculate(kind, left, right);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData("sqrt", 9d, 3d)]
    [InlineData("abs", -5d, 5d)]
    public void Calculate_UnaryOperationName_ReturnsExpectedResult(string operationName, double value, double expected)
    {
        double result = _engine.Calculate(operationName, value);

        Assert.Equal(expected, result, 10);
    }

    [Fact]
    public void Calculate_UnknownOperationName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _engine.Calculate("unknown", 1d));
    }

    [Fact]
    public void Calculate_InvalidArgumentCount_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _engine.Calculate(OperationKind.Add, 1d));
    }
}
