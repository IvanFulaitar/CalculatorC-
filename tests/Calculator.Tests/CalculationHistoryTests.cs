using Calculator.Console.Core;

namespace Calculator.Tests;

public class CalculationHistoryTests
{
    [Fact]
    public void AddSuccess_StoresSuccessfulRecord()
    {
        CalculationHistory history = new(maxSize: 3);

        history.AddSuccess("2 + 3", 5d);

        CalculationRecord record = Assert.Single(history.GetAll());
        Assert.Equal("2 + 3", record.Expression);
        Assert.Equal(5d, record.Result);
        Assert.Null(record.ErrorMessage);
        Assert.Equal(CalculationStatus.Success, record.Status);
    }

    [Fact]
    public void AddError_StoresErrorRecord()
    {
        CalculationHistory history = new(maxSize: 3);

        history.AddError("10 / 0", "Division by zero is not allowed.");

        CalculationRecord record = Assert.Single(history.GetAll());
        Assert.Equal("10 / 0", record.Expression);
        Assert.Null(record.Result);
        Assert.Equal("Division by zero is not allowed.", record.ErrorMessage);
        Assert.Equal(CalculationStatus.Error, record.Status);
    }

    [Fact]
    public void Add_WhenHistoryIsFull_RemovesOldestRecord()
    {
        CalculationHistory history = new(maxSize: 2);

        history.AddSuccess("1 + 1", 2d);
        history.AddSuccess("2 + 2", 4d);
        history.AddSuccess("3 + 3", 6d);

        IReadOnlyList<CalculationRecord> records = history.GetAll();

        Assert.Equal(2, records.Count);
        Assert.Equal("2 + 2", records[0].Expression);
        Assert.Equal("3 + 3", records[1].Expression);
    }

    [Fact]
    public void Constructor_InvalidMaxSize_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CalculationHistory(0));
    }
}
