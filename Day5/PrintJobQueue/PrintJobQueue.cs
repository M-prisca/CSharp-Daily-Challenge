
#nullable enable

using System;
using System.Collections.Generic;

public class PrintJobQueue
{
    private readonly Queue<string> _jobs = new();

    public void AddJob(string? jobName)
    {
        if (string.IsNullOrWhiteSpace(jobName))
        {
            throw new ArgumentException(
                "Job name cannot be null, empty, or whitespace.",
                nameof(jobName)
            );
        }

        _jobs.Enqueue(jobName.Trim());
    }

    public string? ProcessNext()
    {
        if (_jobs.Count == 0)
        {
            return null;
        }

        return _jobs.Dequeue();
    }

    public int PendingCount => _jobs.Count;
}
