namespace Calculator.Console.Core;

/// <summary>
/// Interface - це контракт для калькулятора.
/// Він каже, які методи мають бути, але не вирішує, як саме вони рахують.
/// </summary>
public interface ICalculator
{
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="a">The first addend.</param>
    /// <param name="b">The second addend.</param>
    /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
    double Add(double a, double b);

    /// <summary>
    /// Subtracts the second number from the first number.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>The difference between <paramref name="a"/> and <paramref name="b"/>.</returns>
    double Subtract(double a, double b);

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="a">The first factor.</param>
    /// <param name="b">The second factor.</param>
    /// <returns>The product of <paramref name="a"/> and <paramref name="b"/>.</returns>
    double Multiply(double a, double b);

    /// <summary>
    /// Divides the first number by the second number.
    /// </summary>
    /// <param name="a">The dividend.</param>
    /// <param name="b">The divisor.</param>
    /// <returns>The quotient of <paramref name="a"/> divided by <paramref name="b"/>.</returns>
    /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
    double Divide(double a, double b);

    /// <summary>
    /// Calculates the square root of a number.
    /// </summary>
    /// <param name="a">The value whose square root should be calculated.</param>
    /// <returns>The square root of <paramref name="a"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="a"/> is negative.</exception>
    double SquareRoot(double a);

    /// <summary>
    /// Raises a number to the specified exponent.
    /// </summary>
    /// <param name="base">The base value.</param>
    /// <param name="exponent">The exponent value.</param>
    /// <returns>The result of raising <paramref name="base"/> to <paramref name="exponent"/>.</returns>
    double Power(double @base, double exponent);

    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    /// <param name="a">The input value.</param>
    /// <returns>The absolute value of <paramref name="a"/>.</returns>
    double Abs(double a);
}
