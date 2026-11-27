
using System;
using Xunit;

public class CalendarHelperTests
{
    [Theory]
    [InlineData(1, 2025, 31)]
    [InlineData(4, 2025, 30)]
    [InlineData(2, 2025, 28)]
    [InlineData(2, 2024, 29)]
    [InlineData(2, 1900, 28)]
    [InlineData(2, 2000, 29)]
    public void GetDaysInMonth_ShouldReturnExpectedDays(
        int month,
        int year,
        int expectedDays)
    {
        var result = CalendarHelper.GetDaysInMonth(month, year);

        Assert.Equal(expectedDays, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    public void GetDaysInMonth_InvalidMonth_ShouldThrow(
        int month)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => CalendarHelper.GetDaysInMonth(month, 2025)
        );
    }

    [Fact]
    public void GetDaysInMonth_InvalidYear_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => CalendarHelper.GetDaysInMonth(2, 0)
        );
    }
}
