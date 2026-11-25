
using System;
using Xunit;

public class PrintJobQueueTests
{
    [Fact]
    public void ProcessNext_ShouldReturnJobsInFifoOrder()
    {
        var queue = new PrintJobQueue();

        queue.AddJob("Report.pdf");
        queue.AddJob("Invoice.pdf");

        Assert.Equal("Report.pdf", queue.ProcessNext());
        Assert.Equal("Invoice.pdf", queue.ProcessNext());
        Assert.Equal(0, queue.PendingCount);
    }

    [Fact]
    public void ProcessNext_EmptyQueue_ShouldReturnNull()
    {
        var queue = new PrintJobQueue();

        var result = queue.ProcessNext();

        Assert.Null(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AddJob_InvalidJobName_ShouldThrowArgumentException(
        string? jobName)
    {
        var queue = new PrintJobQueue();

        Assert.Throws<ArgumentException>(
            () => queue.AddJob(jobName)
        );
    }

    [Fact]
    public void AddJob_ShouldTrimWhitespace()
    {
        var queue = new PrintJobQueue();

        queue.AddJob("  Report.pdf  ");

        Assert.Equal("Report.pdf", queue.ProcessNext());
    }

    [Fact]
    public void PendingCount_ShouldTrackWaitingJobs()
    {
        var queue = new PrintJobQueue();

        queue.AddJob("Report.pdf");
        queue.AddJob("Invoice.pdf");

        Assert.Equal(2, queue.PendingCount);

        queue.ProcessNext();

        Assert.Equal(1, queue.PendingCount);
    }
}
