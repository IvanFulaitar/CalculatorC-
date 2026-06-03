namespace Calculator.Tests;

using Calculator.Console.Core;

public class BasicCalculatorTests
{
    private readonly BasicCalculator _calculator = new();

    [Theory]
    [InlineData(2d, 3d, 5d)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(-2d, 5d, 3d)]
    [InlineData(2.5d, 1.5d, 4d)]
    public void Add_ReturnsExpectedResult(double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10d, 4d, 6d)]
    [InlineData(0d, 5d, -5d)]
    [InlineData(-3d, -2d, -1d)]
    [InlineData(5.5d, 2.2d, 3.3d)]
    public void Subtract_ReturnsExpectedResult(double a, double b, double expected)
    {
        double result = _calculator.Subtract(a, b);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData(3d, 7d, 21d)]
    [InlineData(0d, 10d, 0d)]
    [InlineData(-4d, 2d, -8d)]
    [InlineData(2.5d, 0.4d, 1d)]
    public void Multiply_ReturnsExpectedResult(double a, double b, double expected)
    {
        double result = _calculator.Multiply(a, b);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData(15d, 3d, 5d)]
    [InlineData(0d, 5d, 0d)]
    [InlineData(-9d, 3d, -3d)]
    [InlineData(7.5d, 2.5d, 3d)]
    public void Divide_ReturnsExpectedResult(double a, double b, double expected)
    {
        double result = _calculator.Divide(a, b);

        Assert.Equal(expected, result, 10);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10d, 0d));
    }

    [Theory]
    [InlineData(9d, 3d)]
    [InlineData(0d, 0d)]
    [InlineData(2.25d, 1.5d)]
    public void SquareRoot_ReturnsExpectedResult(double value, double expected)
    {
        double result = _calculator.SquareRoot(value);

        Assert.Equal(expected, result, 10);
    }

    [Fact]
    public void SquareRoot_NegativeValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-1d));
    }

    [Theory]
    [InlineData(2d, 8d, 256d)]
    [InlineData(5d, 0d, 1d)]
    [InlineData(-2d, 3d, -8d)]
    [InlineData(9d, 0.5d, 3d)]
    public void Power_ReturnsExpectedResult(double @base, double exponent, double expected)
    {
        double result = _calculator.Power(@base, exponent);

        Assert.Equal(expected, result, 10);
    }

    [Theory]
    [InlineData(5d, 5d)]
    [InlineData(-5d, 5d)]
    [InlineData(0d, 0d)]
    [InlineData(-2.75d, 2.75d)]
    public void Abs_ReturnsExpectedResult(double value, double expected)
    {
        double result = _calculator.Abs(value);

        Assert.Equal(expected, result, 10);
    }
}
