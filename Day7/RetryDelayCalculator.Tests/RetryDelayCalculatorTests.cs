
using System;
using Xunit;

public class RetryDelayCalculatorTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 4)]
    [InlineData(4, 8)]
    [InlineData(5, 8)]
    public void GetDelay_ShouldReturnExpectedDelay(
        int attempt,
        int expectedSeconds)
    {
        var result = RetryDelayCalculator.GetDelay(attempt);

        Assert.Equal(
            TimeSpan.FromSeconds(expectedSeconds),
            result
        );
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GetDelay_InvalidAttempt_ShouldThrowArgumentOutOfRangeException(
        int attempt)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => RetryDelayCalculator.GetDelay(attempt)
        );
    }
}
